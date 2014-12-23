using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using opt.DataModel;
using opt.Helpers;
using opt.Xml;

namespace opt.UI
{
    public partial class ViewCalculatedResults : OptIdFormBase
    {
        public ViewCalculatedResults()
        {
            InitializeComponent();
        }
        public ViewCalculatedResults(OptIdFormBase previous) 
            : base(previous)
        {
            InitializeComponent();
            AdjustFormParameters(previous);
            btnNext.Enabled = false;

            InsertOptimizationParameterColumns();
            InsertIndentificationParameterColumns();
            InsertRealExperimentCriterionColumns();
            InsertMathematicalCriterionColumns();
            InsertAdequacyCriterionColumns();

            FillDataGrid();
        }

        private void InsertOptimizationParameterColumns()
        {
            foreach (KeyValuePair<TId, Parameter> parameter in ModelStorage.Instance.Model.OptimizationParameters)
            {
                InsetColumn("colParam" + parameter.Value.Id, parameter.Value.Name);
            }
        }

        private void InsertIndentificationParameterColumns()
        {
            foreach (KeyValuePair<TId, Parameter> parameter in ModelStorage.Instance.Model.IdentificationParameters)
            {
                // TODO: Column names will conflict with Optimization Parameters!
                InsetColumn("colParam" + parameter.Value.Id, parameter.Value.Name);
            }
        }

        private void InsertRealExperimentCriterionColumns()
        {
            foreach (KeyValuePair<TId, AdequacyCriterion> criterion in ModelStorage.Instance.Model.Criteria)
            {
                InsetColumn("colCriterion" + criterion.Value.Id, criterion.Value.Name + " - Эксперимент");
            }
        }

        private void InsertMathematicalCriterionColumns()
        {
            foreach (KeyValuePair<TId, AdequacyCriterion> criterion in ModelStorage.Instance.Model.Criteria)
            {
                InsetColumn("colMathematicalCriterion" + criterion.Value.Id, criterion.Value.Name + " - Мат. модель");
            }
        }

        private void InsertAdequacyCriterionColumns()
        {
            foreach (KeyValuePair<TId, AdequacyCriterion> criterion in ModelStorage.Instance.Model.Criteria)
            {
                InsetColumn("colAdequacyCriterion" + criterion.Value.Id, "Невязка по " + criterion.Value.Name);
            }
        }

        private void InsetColumn(string colName, string variableIdentifier)
        {
            DataGridViewTextBoxColumn column = new DataGridViewTextBoxColumn();

            column.Name = colName;
            column.HeaderText = variableIdentifier;
            column.ReadOnly = false;

            dgvResults.Columns.Add(column);
        }

        private void FillDataGrid()
        {
            foreach (IdentificationExperiment experiment in ModelStorage.Instance.Model.IdentificationExperiments.Values)
            {
                int ind = this.dgvResults.Rows.Add();
                TId idRealExp = experiment.RealExperimentId;
                if (idRealExp % 2 != 0)
                {
                    // TODO: Number will be better than ID...
                    this.dgvResults.Rows[ind].DefaultCellStyle.BackColor = Color.LightGray;
                }

                this.dgvResults[2, ind].Value = ModelStorage.Instance.Model.RealExperiments[idRealExp].Number;
                this.dgvResults[3, ind].Value = ModelStorage.Instance.Model.IdentificationExperiments[experiment.Id].Number;

                int offset = 4;
                int parameterNumber = 0;
                foreach (double paramValue in ModelStorage.Instance.Model.RealExperiments[idRealExp].ParameterValues.Values)
                {
                    this.dgvResults[offset + parameterNumber, ind].Value = paramValue.ToString(SettingsManager.Instance.DoubleStringFormat);
                    parameterNumber++;
                }

                offset += ModelStorage.Instance.Model.OptimizationParameters.Count;
                parameterNumber = 0;
                foreach (double paramValue in experiment.IdentificationParameterValues.Values)
                {
                    this.dgvResults[offset + parameterNumber, ind].Value = paramValue.ToString(SettingsManager.Instance.DoubleStringFormat);
                    parameterNumber++;
                }

                offset += ModelStorage.Instance.Model.IdentificationParameters.Count;
                parameterNumber = 0;
                foreach (double critValue in ModelStorage.Instance.Model.RealExperiments[idRealExp].CriterionValues.Values)
                {
                    this.dgvResults[offset + parameterNumber, ind].Value = critValue.ToString(SettingsManager.Instance.DoubleStringFormat);
                    parameterNumber++;
                }

                offset += ModelStorage.Instance.Model.Criteria.Count;
                parameterNumber = 0;
                foreach (double critValue in experiment.MathematicalCriterionValues.Values)
                {
                    this.dgvResults[offset + parameterNumber, ind].Value = critValue.ToString(SettingsManager.Instance.DoubleStringFormat);
                    parameterNumber++;
                }

                offset += ModelStorage.Instance.Model.Criteria.Count;
                parameterNumber = 0;
                foreach (double critValue in experiment.AdequacyCriterionValues.Values)
                {
                    this.dgvResults[offset + parameterNumber, ind].Value = critValue.ToString(SettingsManager.Instance.DoubleStringFormat);
                    parameterNumber++;
                }
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (dialogSaveModel.ShowDialog() == DialogResult.OK)
            {
                int filterIndex = dialogSaveModel.FilterIndex;
                try
                {
                    switch (filterIndex)
                    {
                        // OPT model
                        case 2:
                            Model optModel = ModelsConverter.ConvertToOptimization(ModelStorage.Instance.Model);
                            XmlModelProvider.Save(optModel, dialogSaveModel.FileName);
                            break;

                        // OPT.ID model
                        case 1:
                        default:
                            XmlIdentificationModelProvider.Save(ModelStorage.Instance.Model, dialogSaveModel.FileName);
                            break;
                    }
                }
                catch (Exception ex)
                {
                    MessageBoxHelper.ShowError(ex.Message);
                }

                dialogSaveModel.FileName = string.Empty;
            }
        }

    }
}