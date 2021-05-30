using PlotManager.ConsoleAppManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PlotManager
{
    public class Plotter
    {
        static string chiaPath;
        public static void ConfigureChiaPath(string Path)
        {
            chiaPath = Path;
        }

        ConsoleApp runningPlot;

        public Guid PlotterId { get; private set; } = Guid.NewGuid();
        public string Log { get; private set; } = "";
        public int KSize { get; private set; }
        public int BufferSize { get; private set; }
        public int ThreadCount { get; private set; }
        public string TempFolder { get; private set; }
        public string OutputFolder { get; private set; }
        public int CurrentPhase { get; private set; } = 1;
        public bool Finished { get; private set; }
        public string LastLogEntry { get; private set; } = "";

        public ConsoleApp RunningPlot { get { return runningPlot; } }

        Regex regPhase = new Regex("^Starting phase ([0-9])/4");

        public event EventHandler PhaseUpdated;
        public event EventHandler LogUpdated;
        public event EventHandler PlotFinished;

        public Plotter(int KSize, int BufferSize, int ThreadCount, string TempFolder, string OutputFolder)
        {
            this.KSize = KSize;
            this.BufferSize = BufferSize;
            this.ThreadCount = ThreadCount;
            this.TempFolder = TempFolder;
            this.OutputFolder = OutputFolder;
        }

        public void StartPlotter()
        {
            if (runningPlot == null)
            {
                runningPlot = new ConsoleApp(chiaPath, $"plots create -k {KSize} -b {BufferSize} -u 128 -r {ThreadCount} -t {TempFolder} -d {OutputFolder} -n 1 --override-k");
                runningPlot.ConsoleOutput += RunningPlot_ConsoleOutput;
                runningPlot.Exited += RunningPlot_Exited;
                runningPlot.Run();
            }
        }

        private void RunningPlot_Exited(object sender, EventArgs e)
        {
            Finished = true;

            if (PlotFinished != null)
                PlotFinished(this, EventArgs.Empty);
        }

        private void RunningPlot_ConsoleOutput(object sender, ConsoleOutputEventArgs e)
        {
            LastLogEntry = e.Line;

            Log += "\r\n" + e.Line;

            var match = regPhase.Match(e.Line);

            if (match != null && match.Success)
            {
                CurrentPhase = int.Parse(match.Groups[1].Value);
                if (PhaseUpdated != null)
                    PhaseUpdated(this, EventArgs.Empty);
            }

            if (LogUpdated != null)
                LogUpdated(this, EventArgs.Empty);
        }

        public void PausePlotter()
        {
            if(runningPlot != null)
                runningPlot.Pause();
        }

        public void ResumePlotter()
        {
            if (runningPlot != null)
                runningPlot.Resume();
        }
    }
}
