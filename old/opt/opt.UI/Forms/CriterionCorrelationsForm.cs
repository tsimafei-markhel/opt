using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using opt.Helpers;
using opt.DataModel;

namespace opt.UI.Forms
{
    public partial class CriterionCorrelationsForm : Form
    {
        public CriterionCorrelationsForm()
        {
            InitializeComponent();
        }

        public CriterionCorrelationsForm(Model model)
        {
            InitializeComponent();

            Dictionary<TId, List<double>> correlationCoefficients = LinearCorrelationHelper.FindCorrelationCoefficients(model);
            Dictionary<TId, List<CorrelationType>> correlationSignificances = LinearCorrelationHelper.DetermineCorrelationSignificances(model, correlationCoefficients);

            FillCorrelationTable(model, correlationCoefficients, correlationSignificances);
        }

        private void FillCorrelationTable(Model model, Dictionary<TId, List<double>> correlationCoefficients, Dictionary<TId, List<CorrelationType>> correlationSignificances)
        {
            dgvCorrelations.SuspendLayout();
            dgvCorrelations.Columns.Clear();
            dgvCorrelations.Rows.Clear();

            // Add columns
            foreach (Criterion crit in model.Criteria.Values)
            {
                int colIndex = dgvCorrelations.Columns.Add(crit.Id.ToString(), crit.Name);
                dgvCorrelations.Columns[colIndex].SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            // Fill the table
            foreach (Criterion crit in model.Criteria.Values)
            {
                DataGridViewRow critRow = new DataGridViewRow();
                critRow.HeaderCell.Value = crit.Name;
                int rowIndex = dgvCorrelations.Rows.Add(critRow);

                for (int i = 0; i < model.Criteria.Values.Count; i++)
                {
                    dgvCorrelations[i, rowIndex].Value = correlationCoefficients[crit.Id][i];

                    switch (correlationSignificances[crit.Id][i])
                    {
                        case CorrelationType.SignificantlyRelated:
                            if (!(crit.Id == i && correlationCoefficients[crit.Id][i] == 1.0))
                            {
                                dgvCorrelations[i, rowIndex].Style.BackColor = Color.PaleGreen;
                            }
                            break;
                        case CorrelationType.ResultsNotSignificant:
                            dgvCorrelations[i, rowIndex].Style.ForeColor = Color.LightGray;
                            break;
                    }
                }
            }

            dgvCorrelations.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            dgvCorrelations.ResumeLayout();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}