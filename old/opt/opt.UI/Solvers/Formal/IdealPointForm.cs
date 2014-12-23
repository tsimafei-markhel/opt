using System;
using System.Collections.Generic;
using System.Windows.Forms;
using opt.DataModel;
using opt.UI.Helpers;
using opt.UI.Helpers.DataModel;

namespace opt.Solvers.Formal
{
    public partial class IdealPointForm : Form
    {
        private Dictionary<TId, Criterion> _criteria;

        private Dictionary<TId, double> _idealPt;

        public IdealPointForm()
        {
            InitializeComponent();
        }

        public IdealPointForm(
            Dictionary<TId, Criterion> criteria,
            Dictionary<TId, double> idealPt)
        {
            InitializeComponent();

            _criteria = criteria;
            _idealPt = idealPt;

            FillDataGrid();
        }

        public Dictionary<TId, double> IdealPoint { get { return _idealPt; } }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (ParseUserValues())
            {
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void FillDataGrid()
        {
            dgvData.SuspendLayout();

            dgvData.Rows.Clear();

            foreach (Criterion crit in _criteria.Values)
            {
                int rowId = dgvData.Rows.Add();
                
                dgvData[0, rowId].Value = crit.Id;

                dgvData[1, rowId].ReadOnly = true;
                dgvData[1, rowId].Value = crit.Name;
                dgvData[1, rowId].ToolTipText = crit.GetDescription();

                dgvData[2, rowId].Value = _idealPt[crit.Id].ToString(SettingsManager.Instance.DoubleStringFormat);
            }

            dgvData.ResumeLayout();
        }

        private bool ParseUserValues()
        {
            foreach (DataGridViewRow row in dgvData.Rows)
            {
                TId critId = (TId)row.Cells[0].Value;
                double critValue = double.NaN;
                var critInput = (string)row.Cells[2].Value;

                if (string.IsNullOrEmpty(critInput))
                {
                    MessageBoxHelper.ShowExclamation("Для критерия '" + _criteria[critId].Name + "' не введено значение!");
                    return false;
                }

                try
                {
                    critValue = Convert.ToDouble(critInput);
                }
                catch (Exception ex)
                {
                    MessageBoxHelper.ShowExclamation(
                        "Не удалось преобразовать введенное для критерия '" +
                        _criteria[critId].Name + "' значение в число!" +
                        "\nОригинальное сообщение: " + ex.Message);
                    return false;
                }

                _idealPt[critId] = critValue;
            }

            return true;
        }

    }
}