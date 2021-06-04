using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PlotManager
{
    public partial class MainPlotter : Form
    {
        public MainPlotter()
        {
            InitializeComponent();
            DoubleBuffered(lstRunningPlots, true);

            PlotProgrammer.LogUpdated += PlotProgrammer_LogUpdated;
            PlotProgrammer.NewPlot += PlotProgrammer_NewPlot;
        }

        private void PlotProgrammer_NewPlot(object sender, EventArgs e)
        {
            if (this.InvokeRequired)
                this.BeginInvoke((MethodInvoker)(() => AddPlotter(sender as Plotter)));
            else
                AddPlotter(sender as Plotter);
        }
        void AddPlotter(Plotter plot)
        {

            plot.LogUpdated += Plot_LogUpdated;
            plot.PhaseUpdated += Plot_PhaseUpdated;
            plot.PlotFinished += Plot_PlotFinished;

            ListViewItem lvi = new ListViewItem(new string[] { 
                DateTime.Now.ToString(), 
                plot.CurrentPhase.ToString(),
                "", 
                plot.TempFolder, 
                plot.OutputFolder,
                "Running"});

            lvi.Tag = plot.PlotterId;

            lstRunningPlots.BeginUpdate();
            lstRunningPlots.Items.Add(lvi);
            lstRunningPlots.EndUpdate();
        }

        private void Plot_PlotFinished(object sender, EventArgs e)
        {
            var plot = sender as Plotter;
            plot.LogUpdated -= Plot_LogUpdated;
            plot.PhaseUpdated -= Plot_PhaseUpdated;
            plot.PlotFinished -= Plot_PlotFinished;

            if (this.InvokeRequired)
                this.BeginInvoke((MethodInvoker)(() => FinishPlot(sender as Plotter)));
            else
                FinishPlot(sender as Plotter);
        }

        void FinishPlot(Plotter plot)
        {
            lstRunningPlots.BeginUpdate();
            var item = lstRunningPlots.Items.Cast<ListViewItem>().Where(lvi => lvi.Tag.ToString() == plot.PlotterId.ToString()).FirstOrDefault();
            if (item != null)
                item.SubItems[5].Text = "Finished";
            lstRunningPlots.EndUpdate();
        }

        private void Plot_PhaseUpdated(object sender, EventArgs e)
        {
            if (this.InvokeRequired)
                this.BeginInvoke((MethodInvoker)(() => UpdatePlotPhase(sender as Plotter)));
            else
                UpdatePlotPhase(sender as Plotter);
        }

        void UpdatePlotPhase(Plotter plot)
        {
            lstRunningPlots.BeginUpdate();
            var item = lstRunningPlots.Items.Cast<ListViewItem>().Where(lvi => lvi.Tag.ToString() == plot.PlotterId.ToString()).FirstOrDefault();
            if (item != null)
                item.SubItems[1].Text = plot.CurrentPhase.ToString();
            lstRunningPlots.EndUpdate();
        }

        private void Plot_LogUpdated(object sender, EventArgs e)
        {
            if (this.InvokeRequired)
                this.BeginInvoke((MethodInvoker)(() => UpdatePlotLog(sender as Plotter)));
            else
                UpdatePlotLog(sender as Plotter);
        }

        void UpdatePlotLog(Plotter plot)
        {
            lstRunningPlots.BeginUpdate();
            var item = lstRunningPlots.Items.Cast<ListViewItem>().Where(lvi => lvi.Tag.ToString() == plot.PlotterId.ToString()).FirstOrDefault();
            if (item != null)
                item.SubItems[2].Text = plot.LastLogEntry.ToString();
            lstRunningPlots.EndUpdate();
        }

        private void PlotProgrammer_LogUpdated(object sender, EventArgs e)
        {
            if (this.InvokeRequired)
                this.BeginInvoke((MethodInvoker)(() => UpdatePlotManagerLog()));
            else
                UpdatePlotManagerLog();
        }

        void UpdatePlotManagerLog()
        {
            txtLogProg.Text = PlotProgrammer.Log;
            txtLogProg.SelectionStart = txtLogProg.Text.Length;
            txtLogProg.SelectionLength = 0;
            txtLogProg.ScrollToCaret();

            if (!PlotProgrammer.Running)
            {
                button1.Enabled = true;
                button2.Enabled = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (lstTempFolders.Items.Count == 0 || lstOuts.Items.Count == 0)
            {
                MessageBox.Show("You must at least specify one temp folder and one output folder");
                return;
            }

            if (!PlotProgrammer.Start((int)nudKSize.Value,
                (int)nudBuffer.Value,
                (int)nudThreads.Value,
                lstTempFolders.Items.Cast<ListViewItem>().Select(lv => new TemporalFolder { Folder = lv.Text, MaxConcurrency = int.Parse(lv.SubItems[1].Text) }).ToArray(),
                lstOuts.Items.Cast<string>().ToArray(),
                (int)nudInterval.Value,
                (int)nudPlotsPhase1.Value))
            {
                MessageBox.Show("Error starting plotter programmer!");
            }
            else
            {
                var fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "plotter.cfg");
                File.WriteAllText(fileName, JsonConvert.SerializeObject(new PlotterConfig
                {
                    KSize = (int)nudKSize.Value,
                    Buffer = (int)nudBuffer.Value,
                    Threads = (int)nudThreads.Value,
                    TempFolders = lstTempFolders.Items.Cast<ListViewItem>().Select(lv => new TemporalFolder { Folder = lv.Text, MaxConcurrency = int.Parse(lv.SubItems[1].Text) }).ToArray(),
                    OutputFolders = lstOuts.Items.Cast<string>().ToArray(),
                    Interval = (int)nudInterval.Value,
                    PlotsInPhaseOne = (int)nudPlotsPhase1.Value
                }));

                button1.Enabled = false;
                button2.Enabled = true;
            }
        }

        private void btnAddTemp_Click(object sender, EventArgs e)
        {
            using (TempSelector fb = new TempSelector())
            {
                if (fb.ShowDialog() != DialogResult.OK)
                    return;

                lstTempFolders.Items.Add(new ListViewItem(new string[] { fb.Folder, fb.MaxConcurrency.ToString() }));
            }
        }

        private void btnAddOutput_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog fb = new FolderBrowserDialog())
            {
                if (fb.ShowDialog() != DialogResult.OK)
                    return;

                lstOuts.Items.Add(fb.SelectedPath);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!PlotProgrammer.Stop())
                MessageBox.Show("Error stopping the programmer!");
            else
            {
                button1.Enabled = true;
                button2.Enabled = false;
            }
        }

        void DoubleBuffered(Control control, bool enable)
        {
            var doubleBufferPropertyInfo = control.GetType().GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic);
            doubleBufferPropertyInfo.SetValue(control, enable, null);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            lstRunningPlots.BeginUpdate();
            var items = lstRunningPlots.Items.Cast<ListViewItem>().Where(lvi => lvi.SubItems[5].Text == "Finished").ToArray();
            
            if (items != null)
            {
                foreach (var item in items)
                    lstRunningPlots.Items.Remove(item);
            }

            lstRunningPlots.EndUpdate();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (lstRunningPlots.SelectedItems.Count < 1)
            {
                MessageBox.Show("Select a plot to pause/resume");
                return;
            }

            var item = lstRunningPlots.SelectedItems[0];

            if (item.SubItems[5].Text == "Finished")
            {
                MessageBox.Show("Selected plot already finished");
                return;
            }

            var id = (Guid)item.Tag;

            if (item.SubItems[5].Text == "Paused")
            {
                if (PlotProgrammer.ResumePlotter(id))
                    item.SubItems[5].Text = "Running";
            }
            else
            {
                if (PlotProgrammer.PausePlotter(id))
                    item.SubItems[5].Text = "Paused";
            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Warning!! This will kill all running plots leaving all the temp files in place, are you sure?", "Kill Plots", MessageBoxButtons.OKCancel) != DialogResult.OK)
                return;

            PlotProgrammer.KillAllPlots();
        }

        private void MainPlotter_FormClosing(object sender, FormClosingEventArgs e)
        {
            bool running = lstRunningPlots.Items.Cast<ListViewItem>().Where(lvi => lvi.SubItems[5].Text != "Finished").Any();

            if (running)
            {
                e.Cancel = true;
                MessageBox.Show("There are running plots, cancell all before closing PlotManager");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (lstRunningPlots.SelectedItems.Count < 1)
            {
                MessageBox.Show("Select a plot to kill");
                return;
            }

            var item = lstRunningPlots.SelectedItems[0];

            if (item.SubItems[5].Text == "Finished")
            {
                MessageBox.Show("Selected plot already finished");
                return;
            }

            if (MessageBox.Show("Warning!! This will kill the selected plot leaving all the temp files in place, are you sure?", "Kill Plot", MessageBoxButtons.OKCancel) != DialogResult.OK)
                return;

            var id = (Guid)item.Tag;

            PlotProgrammer.KillPlots(id);
        }

        private void MainPlotter_Load(object sender, EventArgs e)
        {
            string configFile = Path.Combine(Application.StartupPath, "ChiaPath.txt");

            if (!File.Exists(configFile))
            {
                MessageBox.Show("Cannot find chia path config file. Create a file in the application folder named \"ChiaPath.txt\" and place the full path to the chia executable.");
                Task.Run(async () => 
                {
                    await Task.Delay(1000);
                    Close();

                });
                return;
            }

            string path = File.ReadAllLines(configFile).FirstOrDefault();

            if (string.IsNullOrWhiteSpace(path))
            {
                MessageBox.Show("Broken chia path config file. Create a file in the application folder named \"ChiaPath.txt\" and place the full path to the chia executable in its first line.");
                Task.Run(async () =>
                {
                    await Task.Delay(1000);
                    Close();

                });
                return;
            }

            if (!File.Exists(path))
            {
                MessageBox.Show($"Cannot find chia executable in \"{path}\"");
                Task.Run(async () =>
                {
                    await Task.Delay(1000);
                    Close();

                });
                return;
            }

            Plotter.ConfigureChiaPath(path);
        }

        private void bttnRemoveTemp_Click(object sender, EventArgs e)
        {
            if (lstTempFolders.SelectedItems != null && lstTempFolders.SelectedItems.Count > 0)
                lstTempFolders.Items.Remove(lstTempFolders.SelectedItems[0]);
        }

        private void btnRemoveOutput_Click(object sender, EventArgs e)
        {
            if (lstOuts.SelectedIndex > -1)
                lstOuts.Items.Remove(lstOuts.SelectedItem);
        }
    }
}
