using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PlotManager
{
    public static class PlotProgrammer
    {
        static readonly Dictionary<int, long> plotSizes = new Dictionary<int, long> {
            { 25, 600 * 1024 * 1024 },
            { 32, 102L * 1024L * 1024L * 1024L  },
            { 33, 209L * 1024L * 1024L * 1024L  },
            { 34, 430L * 1024L * 1024L * 1024L  },
            { 35, 885L * 1024L * 1024L * 1024L  }
        };
        static ConcurrentDictionary<Guid, Plotter> runningPlots = new ConcurrentDictionary<Guid, Plotter>();
        static CancellationTokenSource cancelSrc;

        public static string Log { get; private set; } = "";
        public static event EventHandler LogUpdated;
        public static event EventHandler NewPlot;
        static int _KSize;
        static int _BufferSize;
        static int _ThreadCount;
        static string[] _TempFolders;
        static string[] _OutputFolders;
        static int _MinInterval;
        static int _MaxPhaseOne;
        static int _MaxPerTemp;

        public static bool Running { get; set; }

        public static bool Start(int KSize, int BufferSize, int ThreadCount, string[] TempFolders, string[] OutputFolders, int MinInterval, int MaxPhaseOne, int MaxPerTemp)
        {
            if (cancelSrc != null)
            {
                AppendLog("Programmer already running");
                return false;
            }

            _KSize = KSize;
            _BufferSize = BufferSize;
            _ThreadCount = ThreadCount;
            _TempFolders = TempFolders;
            _OutputFolders = OutputFolders;
            _MinInterval = MinInterval;
            _MaxPhaseOne = MaxPhaseOne;
            _MaxPerTemp = MaxPerTemp;

            cancelSrc = new CancellationTokenSource();
            ExecuteProgrammer();
            AppendLog("Programmer has started");

            Running = true;

            return true;
        }

        public static bool Stop()
        {
            if (cancelSrc != null)
            {
                cancelSrc.Cancel();
                return true;
            }

            return false;
        }

        public static bool PausePlotter(Guid id)
        {
            runningPlots.TryGetValue(id, out Plotter plot);

            if (plot == null)
                return false;

            AppendLog("Pausing plot...");
            plot.PausePlotter();

            return true;
        }

        public static bool ResumePlotter(Guid id)
        {
            runningPlots.TryGetValue(id, out Plotter plot);

            if (plot == null)
                return false;

            AppendLog("Resuming plot...");
            plot.ResumePlotter();

            return true;
        }

        public static void KillAllPlots()
        {
            AppendLog("Killing plots...");

            foreach (var item in runningPlots.Values)
                item.RunningPlot.Kill();

            AppendLog("All plots are dead...");
        }

        static void ExecuteProgrammer()
        {
            Task.Run(async () => 
            {
                try
                {
                    while (!cancelSrc.IsCancellationRequested)
                    {
                        if (_MinInterval != 0)
                        {
                            var latest = runningPlots.Values.OrderByDescending(p => p.RunningPlot.StartTime.Value).FirstOrDefault();

                            if (latest != null)
                            {
                                while ((DateTime.Now - latest.RunningPlot.StartTime.Value).TotalMinutes < _MinInterval)
                                {
                                    AppendLog("Delaying plot start...");
                                    await Task.Delay(5000, cancelSrc.Token);
                                    cancelSrc.Token.ThrowIfCancellationRequested();
                                }
                            }
                        }

                        cancelSrc.Token.ThrowIfCancellationRequested();

                        int onPhase1 = 0;

                        do
                        {
                            onPhase1 = runningPlots.Values.Where(p => p.CurrentPhase == 1).Count();

                            if (onPhase1 >= _MaxPhaseOne)
                            {
                                AppendLog("Phase1 plot exceeded, delaying plot start...");
                                await Task.Delay(5000, cancelSrc.Token);
                            }
                            cancelSrc.Token.ThrowIfCancellationRequested();

                        } while (onPhase1 >= _MaxPhaseOne);

                        cancelSrc.Token.ThrowIfCancellationRequested();

                        string selectedTemp = null;

                        while (selectedTemp == null)
                        {
                            var grp = _TempFolders
                            .Select(f => new { Folder = f, Running = runningPlots.Count(rp => rp.Value.TempFolder == f) })
                            .OrderBy(g => g.Running).FirstOrDefault();

                            if (grp == null || grp.Running >= _MaxPerTemp)
                            {
                                AppendLog("Max files per temp exceeded, delaying plot start...");
                                await Task.Delay(5000, cancelSrc.Token);
                            }
                            else
                                selectedTemp = grp.Folder;

                            cancelSrc.Token.ThrowIfCancellationRequested();
                        }

                        var selectedOutput = _OutputFolders
                            .Where(f => GetFreeDisc(f) >= plotSizes[_KSize])
                            .Select(f => new 
                            { 
                                Folder = f, 
                                Running = runningPlots.Count(rp => rp.Value.OutputFolder == f), 
                                RunningPhaseOne = runningPlots.Count(rp => rp.Value.OutputFolder == f && rp.Value.CurrentPhase == 1) 
                            })
                            .OrderBy(g => g.Running)
                            .ThenBy(g => g.RunningPhaseOne)
                            .FirstOrDefault();

                        if (selectedOutput == null)
                        {
                            AppendLog("Output destinations are full, stopping programmer...");
                            cancelSrc.Cancel();
                        }

                        cancelSrc.Token.ThrowIfCancellationRequested();

                        AppendLog($"Starting plot in '{selectedTemp}' to '{selectedOutput.Folder}'...");

                        Plotter pt = new Plotter(_KSize, _BufferSize, _ThreadCount, selectedTemp, selectedOutput.Folder);
                        pt.PlotFinished += Pt_PlotFinished;

                        if (NewPlot != null)
                            NewPlot(pt, EventArgs.Empty);

                        runningPlots[pt.PlotterId] = pt;

                        pt.StartPlotter();
                    }
                }
                catch { }

                Running = false;

                AppendLog("Programmer is stopped.");

                try 
                {
                    var cancel = cancelSrc;
                    cancelSrc = null;
                    cancel.Dispose();
                }
                catch { }

            });
        }

        private static long GetFreeDisc(string Path)
        {
            var runningIn = runningPlots.Where(p => p.Value.OutputFolder == Path).Count();

            long toRemove = runningIn * plotSizes[_KSize];

            var info = new DriveInfo(Path.Substring(0, 1));
            return Math.Max(0, info.AvailableFreeSpace - toRemove);
        }

        private static void Pt_PlotFinished(object sender, EventArgs e)
        {
            Plotter pt = sender as Plotter;
            runningPlots.TryRemove(pt.PlotterId, out _);
        }

        private static void AppendLog(string newLog)
        {
            string[] lines = Log.Split("\r\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

            List<string> finalLines = new List<string>();

            int skip = Math.Max(0, lines.Length - 99);

            finalLines.AddRange(lines.Skip(skip));
            finalLines.Add(newLog);

            Log = string.Join("\r\n", finalLines);

            if (LogUpdated != null)
                LogUpdated(null, EventArgs.Empty);
        }

        public static void KillPlots(Guid id)
        {

            runningPlots.TryGetValue(id, out Plotter plot);

            if (plot == null)
            {
                AppendLog("Cannot find plot...");
                return;
            }

            AppendLog("Killing plot...");

            plot.RunningPlot.Kill();

            AppendLog("Plot is dead...");
        }
    }
}
