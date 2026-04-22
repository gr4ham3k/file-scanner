using FileScannerApp.Models;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace FileScannerApp
{
    public partial class OrganizeForm : Form
    {
        public string SelectedFolder { get; private set; }
        public string SelectedDestination { get; private set; }
        public string Radio { get; private set; }
        public OrganizeOptions Options { get; private set; }


        public List<string> FileTypes { get; private set; } = new List<string>();
        public OrganizeForm(string folder)
        {
            InitializeComponent();
            this.SelectedFolder = folder;
            this.Options = new OrganizeOptions();
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

                    try
                    {
                        FileScannerService.Scan(SelectedFolder);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
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

            if (radioMove.Checked)
            {
                this.Radio = "move";
            }
            else if (radioCopy.Checked)
            {
                this.Radio = "copy";
            }
            else
            {
                this.Radio = "move";
            }

            this.Options = new OrganizeOptions();

            foreach (var item in checkedListBox1.CheckedItems)
            {
                string group = item.ToString();

                switch (group)
                {
                    case "Create subfolders by type":
                        Options.CreateSubfolders = true;
                        break;

                    case "Overwrite existing files":
                        Options.OverwriteExisting = true;
                        break;
                }
            }


        }

        private void changeDestinationBtn_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog dialog = new FolderBrowserDialog())
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    textBox1.Text = dialog.SelectedPath;
                    this.SelectedDestination = dialog.SelectedPath;
                }
            }
        }



        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e) { 

            if (string.IsNullOrEmpty(textBoxFolder.Text) || string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("No folder selected!");
                return;
            }

            setSettings();

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    
    }
}
