using FileScannerApp.Models;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace FileScannerApp
{

    public partial class RenameForm : Form
    {
        public string SelectedFolder { get; private set; }

        public RenameForm(string folder)
        {
            InitializeComponent();
            
            this.SelectedFolder = folder;
            textBoxFolder.Text = SelectedFolder;

            if (SelectedFolder != null)
            {
                dataGridView1.Visible = true;
                LoadFiles();
            }
            else
            {
                dataGridView1.Visible = false;
            }

            textBoxPattern.TextChanged += (s, e) => UpdatePreview();

            radioCopy.CheckedChanged += (s, e) => UpdatePreview();
            radioMove.CheckedChanged += (s, e) => UpdatePreview();
            radioButton1.CheckedChanged += (s, e) => UpdatePreview();
        }


        private void changeFolderBtn_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog dialog = new FolderBrowserDialog())
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    textBoxFolder.Text = dialog.SelectedPath;
                    SelectedFolder = dialog.SelectedPath;

                    FileScannerService.Scan(SelectedFolder);
                    dataGridView1.Visible = true;
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

        private void textBoxPattern_TextChanged(object sender, EventArgs e)
        {
            UpdatePreview();
        }

        private void LoadFiles()
        {


            dataGridView1.DataSource = RenameService.LoadPreview(SelectedFolder);

            dataGridView1.Columns["NameBefore"].HeaderText = "Current";
            dataGridView1.Columns["NameAfter"].HeaderText = "After";

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            UpdatePreview();
        }

        private void UpdatePreview()
        {
            if (dataGridView1.DataSource == null)
                return;

            var list = dataGridView1.DataSource as List<RenamePreview>;
            dataGridView1.Columns["FullPath"].Visible = false;
            if (list == null)
                return;

            int counter = 1;

            foreach (var item in list)
            {
                item.NameAfter = RenameService.GenerateNewName(
                    textBoxPattern.Text,
                    item.NameBefore,
                    counter,
                    GetSelectedOption()
                );

                counter++;
            }

            dataGridView1.Refresh();
        }

        private string GetSelectedOption()
        {
            if (radioCopy.Checked) return "upper";
            if (radioMove.Checked) return "lower";
            if (radioButton1.Checked) return "capitalize";

            return "none";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(SelectedFolder == null)
            {
                MessageBox.Show("No folder selected!");
                return;
            }

            var list = dataGridView1.DataSource as List<RenamePreview>;

            try
            {
                RenameService.RenameFiles(list);
                MessageBox.Show("Done!");

                this.DialogResult = DialogResult.OK;

                this.Close();

                LoadFiles();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
