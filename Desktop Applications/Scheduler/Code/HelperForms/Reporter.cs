using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Scheduler_PeterWilliams
{
    public partial class Reporter : Form
    {
        public Reporter(string repName, List<DataController> data, string[] colHeaders)
        {
            InitializeComponent();

            repLab.Text = repName;

            dgv.ColumnCount = colHeaders.Length;
            for (int i = 0; i < colHeaders.Length; i++)
            {
                dgv.Columns[i].HeaderText = colHeaders[i];
            }

            int counter = 0;

            foreach(DataController dc in data)
            {
                dgv.Rows.Add(dc.rowData);
                dgv.Rows[counter].HeaderCell.Value = dc.rowHeader;
                counter++;
            }
        }

        public Reporter(string repName, DataTable dt)
        {
            InitializeComponent();

            repLab.Text = repName;

            dgv.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgv.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            dgv.RowHeadersVisible = false;
            dgv.DataSource = dt;
        }
    }
}
