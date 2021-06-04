using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PlotManager
{
    public partial class TempSelector : Form
    {
        public string Folder { get; set; }
        public int MaxConcurrency { get; set; }
        public TempSelector()
        {
            InitializeComponent();
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFolder.Text))
            {
                MessageBox.Show("Select temporary folder.");
                return;
            }

            Folder = txtFolder.Text;
            MaxConcurrency = (int)nudConcurrency.Value;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog fb = new FolderBrowserDialog())
            {
                if (fb.ShowDialog() != DialogResult.OK)
                    return;

                txtFolder.Text = fb.SelectedPath;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
