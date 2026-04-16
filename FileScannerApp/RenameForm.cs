using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FileScannerApp.Models;

namespace FileScannerApp
{

    public partial class RenameForm : Form
    {
        public string SelectedFolder { get; private set; }

        public RenameForm(string folder)
        {
            InitializeComponent();

            if (folder != null)
            {
                LoadFiles();
            }
            
            this.SelectedFolder = folder;
            textBoxFolder.Text = SelectedFolder;

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

        private void textBoxPattern_TextChanged(object sender, EventArgs e)
        {
            UpdatePreview();
        }

        private void LoadFiles()
        {
            var db = new Database();
            var files = db.GetFiles();

            var previewList = files.Select(f => new RenamePreview
            {
                NameBefore = f.Path,
                NameAfter = ""
            }).ToList();

            dataGridView1.DataSource = previewList;

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
        private void StyleGrid()
        {
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 245, 245);
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.FromArgb(0, 120, 215);
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.White;
            dataGridView1.BackgroundColor = Color.White;

            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(30, 30, 30);
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);

            dataGridView1.DefaultCellStyle.Font = new Font("Segoe UI", 9);
            dataGridView1.RowTemplate.Height = 28;

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;


        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
