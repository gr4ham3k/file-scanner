using FileScannerApp.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileScannerApp
{
    public partial class ScanOptionsForm : Form
    {
        public string SelectedFolder { get; private set; }
        public ScanOptionsForm(string selectedFolder)
        {
            InitializeComponent();

            this.SelectedFolder = selectedFolder;
            
        }

        private void ScanOptionsForm_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(SelectedFolder))
            {
                textBoxFolder.Text = SelectedFolder;
            }
        }


        private void changeFolderBtn_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog dialog = new FolderBrowserDialog())
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    textBoxFolder.Text = dialog.SelectedPath;
                    SelectedFolder = dialog.SelectedPath;
                }
            }
        }

        private void startScanBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxFolder.Text))
            {
                MessageBox.Show("Nie wybrano folderu!");
                return;
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
