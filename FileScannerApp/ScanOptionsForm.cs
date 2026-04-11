using FileScannerApp.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileScannerApp
{
    public partial class ScanOptionsForm : Form
    {
        public string SelectedFolder { get; private set; }
        public List<string> FileTypes { get; private set; } = new List<string>();
        public ScanOptionsForm(string selectedFolder)
        {
            InitializeComponent();

            this.SelectedFolder = selectedFolder;
            textBoxFolder.Text = SelectedFolder;

        }


        private void changeFolderBtn_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog dialog = new FolderBrowserDialog())
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    this.SelectedFolder = dialog.SelectedPath;
                    textBoxFolder.Text = SelectedFolder;

                    var db = new Database();
                    var files = FileScannerService.Scan(SelectedFolder);
                    db.SaveFiles(files);

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

            setSettings();

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void setSettings()
        {

            this.FileTypes.Clear();

            foreach (var item in checkBoxes.CheckedItems)
            {
                string group = item.ToString();

                switch (group)
                {
                    case "Executables":
                        FileTypes.AddRange(new[] { ".exe", ".msi", ".bat" });
                        break;

                    case "Documents":
                        FileTypes.AddRange(new[] { ".pdf", ".docx", ".txt" });
                        break;

                    case "Images":
                        FileTypes.AddRange(new[] { ".jpg", ".png", ".bmp", ".gif" });
                        break;

                    case "Videos":
                        FileTypes.AddRange(new[] { ".mp4", ".avi", ".mkv" });
                        break;
                }
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
