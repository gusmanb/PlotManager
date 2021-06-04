using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlotManager
{ 
    public class PlotterConfig
    {
        public int KSize { get; set; }
        public int Buffer { get; set; }
        public int Threads { get; set; }
        public TemporalFolder[] TempFolders { get; set; }
        public string[] OutputFolders { get; set; }
        public int Interval { get; set; }
        public int PlotsInPhaseOne { get; set; }
    }
}
