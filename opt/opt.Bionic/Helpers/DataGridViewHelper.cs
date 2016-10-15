using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace opt.Bionic.Helpers
{
    public static class DataGridViewHelper
    {
        public static DataGridViewColumn CreateColumn(
            string name,
            string headerText,
            DataGridViewCell cellTemplate = null,
            string toolTipText = "")
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("name");
            }

            DataGridViewCell columnCellTemplate = cellTemplate;
            if (columnCellTemplate == null)
            {
                columnCellTemplate = new DataGridViewTextBoxCell();
            }

            DataGridViewColumn column = new DataGridViewColumn();
            column.Name = name;
            column.HeaderText = headerText;
            column.CellTemplate = columnCellTemplate;
            column.ToolTipText = toolTipText;

            return column;
        }

        public static void CopyColumn(DataGridViewColumn toCopy, DataGridView destination)
        {
            if (toCopy == null)
            {
                throw new ArgumentNullException("toCopy");
            }

            if (destination == null)
            {
                throw new ArgumentNullException("destination");
            }

            // TODO: Replace 'null' below with real cell template
            DataGridViewColumn columnCopy = CreateColumn(toCopy.Name, toCopy.HeaderText, null, toCopy.ToolTipText);
            destination.Columns.Add(columnCopy);
        }
    }
}