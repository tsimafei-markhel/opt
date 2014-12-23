using System;
using System.Collections;
using System.Windows.Forms;
using opt.Bionic.Helpers;

namespace opt.Bionic.UI
{
    public partial class Tray : Form
    {
        public Tray()
        {
            InitializeComponent();
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            ClearTableRows();
        }

        public void ClearTableRows()
        {
            tableResults.Rows.Clear();
        }

        public void ClearTable()
        {
            ClearTableRows();
            tableResults.Columns.Clear();
        }

        public void AddColumn(DataGridViewColumn column)
        {
            if (column != null)
            {
                DataGridViewHelper.CopyColumn(column, tableResults);
            }
        }

        public void AddRow(DataGridViewRow row)
        {
            if (row != null)
            {
                int targetRowId = tableResults.Rows.Add();
                DataGridViewRow targetRow = tableResults.Rows[targetRowId];

                targetRow.DefaultCellStyle.ForeColor = row.DefaultCellStyle.ForeColor;
                foreach (DataGridViewCell cell in row.Cells)
                {
                    string cellValue = cell.Value.ToString();
                    targetRow.Cells[cell.ColumnIndex].Value = cellValue;
                }
            }
        }

        public void AddRows(IEnumerable rows)
        {
            if (rows != null)
            {
                foreach (DataGridViewRow row in rows)
                {
                    AddRow(row);
                }
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {

        }
    }
}