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

    public partial class RenameForm : Form
    {
        public string SelectedFolder { get; private set; }
        public RenameForm(string folder)
        {
            InitializeComponent();
            LoadFiles();
            this.SelectedFolder = folder;
            textBoxFolder.Text = SelectedFolder;
        }


        private void changeFolderBtn_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog dialog = new FolderBrowserDialog())
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    textBoxFolder.Text = dialog.SelectedPath;
                    SelectedFolder = dialog.SelectedPath;

                    var db = new Database();
                    var files = FileScannerService.Scan(SelectedFolder);
                    db.SaveFiles(files);
                    LoadFiles();

                }
            }
        }

        private void listBoxTokens_DoubleClick(object sender, EventArgs e)
        {
            if (listBoxTokens.SelectedItem == null) return;

            string token = listBoxTokens.SelectedItem.ToString();

            textBoxPattern.Text += token;
            textBoxPattern.SelectionStart = textBoxPattern.Text.Length;
        }

        private void LoadFiles()
        {
            var db = new Database();

            dataGridView1.DataSource = db.GetFiles();

       
        }

    }
}
