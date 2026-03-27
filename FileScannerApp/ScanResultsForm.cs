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
    public partial class ScanResultsForm : Form
    {
        private int scanId;
        private Database db = new Database();
        public ScanResultsForm(int scanId)
        {
            InitializeComponent();
            this.scanId = scanId;
        }

        private void ScanResultsForm_Load(object sender, EventArgs e)
        {
            var results = db.GetScanResults(scanId);

            dataGridView1.DataSource = results;

            StyleGrid();
        }

        private void StyleGrid()
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells["Malicious"].Value.ToString().Contains("Yes"))
                {
                    row.DefaultCellStyle.BackColor = Color.LightCoral;
                }
                else
                {
                    row.DefaultCellStyle.BackColor = Color.LightGreen;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
