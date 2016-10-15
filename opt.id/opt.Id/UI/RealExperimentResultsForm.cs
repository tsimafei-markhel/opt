using System;
using System.Collections.Generic;
using System.Windows.Forms;
using opt.DataModel;
using opt.Helpers;
using opt.Xml;
using OfficeOpenXml;
using System.IO;

namespace opt.UI
{
    public partial class RealExperimentResultsForm : OptIdFormBase
    {
        public RealExperimentResultsForm()
        {
            throw new InvalidOperationException("Parameterless constructor called");
        }

        public RealExperimentResultsForm(OptIdFormBase previous)
            : base(previous)
        {
            InitializeComponent();
            AdjustFormParameters(previous);
        }

        private void InitDataGrid()
        {
            InsertParamterColumns();
            InsertCriterionColumns();
            InsertConstraintColumns();

            InsetValues();
        }

        protected override void btnNext_Click(object sender, EventArgs e)
        {
            UpdateModelFromDataGrid();
            if (nextForm == null)
            {
                nextForm = new GenerateExperimentsForm(this);
            }

            base.btnNext_Click(sender, e);
        }

        protected override void btnPrevious_Click(object sender, EventArgs e)
        {
            UpdateModelFromDataGrid();
            base.btnPrevious_Click(sender, e);
        }

        // TODO: Update header after model change
        private void InsertParamterColumns()
        {
            foreach (KeyValuePair<TId, Parameter> parameter in ModelStorage.Instance.Model.OptimizationParameters)
            {
                InsetColumn("colParam" + parameter.Value.Id, parameter.Value.Name);
            }
        }

        private void InsertCriterionColumns()
        {
            foreach (KeyValuePair<TId, AdequacyCriterion> criterion in ModelStorage.Instance.Model.Criteria)
            {
                InsetColumn("colCriterion" + criterion.Value.Id, criterion.Value.Name);
            }
        }

        private void InsertConstraintColumns()
        {
            foreach (KeyValuePair<TId, opt.DataModel.Constraint> constraint in ModelStorage.Instance.Model.FunctionalConstraints)
            {
                InsetColumn("colConstraint" + constraint.Value.Id, constraint.Value.Name);
            }
        }

        private void InsetColumn(string colName, string variableIdentifier)
        {
            DataGridViewTextBoxColumn column = new DataGridViewTextBoxColumn();

            column.Name = colName;
            column.HeaderText = variableIdentifier;
            column.ReadOnly = false;

            dgvExperimentsResults.Columns.Add(column);
        }

        private void InsetValues()
        {
            dgvExperimentsResults.Rows.Clear();
            foreach(Experiment experiment in ModelStorage.Instance.Model.RealExperiments.Values)
            {
                dgvExperimentsResults.Rows.Add();
                for (int j = 0; j < dgvExperimentsResults.ColumnCount; j++)
                {
                    if (j < ModelStorage.Instance.Model.OptimizationParameters.Count)
                    {
                        dgvExperimentsResults[j, experiment.Id].Value = experiment.ParameterValues[j].ToString();
                    }
                    else if (j < ModelStorage.Instance.Model.OptimizationParameters.Count + ModelStorage.Instance.Model.Criteria.Count)
                    {
                        dgvExperimentsResults[j, experiment.Id].Value = experiment.CriterionValues[j - ModelStorage.Instance.Model.OptimizationParameters.Count].ToString();
                    }
                    else
                    {
                        dgvExperimentsResults[j, experiment.Id].Value = experiment.ConstraintValues[j - ModelStorage.Instance.Model.OptimizationParameters.Count - ModelStorage.Instance.Model.Criteria.Count].ToString();
                    }
                }
            }
        }

        // TODO: Move Excel parsing to a separate class

        // TODO: think about validation
        private void UpdateModelFromDataGrid()
        {
            ModelStorage.Instance.Model.RealExperiments.Clear();
            try
            {
                for (int i = 0; i < dgvExperimentsResults.RowCount - 1; i++) //ignore last row, because it's always empty
                {
                    Experiment experiment = new Experiment(ModelStorage.Instance.Model.RealExperiments.GetFreeConsequentId(), i + 1);
                    for (int j = 0; j < dgvExperimentsResults.ColumnCount; j++)
                    {
                        string valueStr = (string)dgvExperimentsResults[j, i].Value;
                        double value = ParseValue(valueStr);
                        SetValueToExperiment(experiment, value, j);
                    }

                    ModelStorage.Instance.Model.RealExperiments.Add(experiment);
                }
            }
            catch (ArgumentException ag)
            {
                ModelStorage.Instance.Model.RealExperiments.Clear();
                MessageBoxHelper.ShowExclamation("Ошибка при чтении. " + ag.Message);
            }
        }

        private void UpdateModelFromXls(string filePath)
        {
            // File validation
            FileInfo file = null;
            try 
            {
                file = new FileInfo(filePath);
            }
            catch (Exception e)
            {
                throw new ArgumentException("Cannot open file.", e);
            }

            ExcelPackage ep = new ExcelPackage(file);
            if (ep.Workbook == null && !(ep.Workbook.Worksheets.Count > 0))
            {
                throw new ArgumentException("File format error.");
            }

            ExcelWorksheet sheet = ep.Workbook.Worksheets[1];
            int columnsNeed = ModelStorage.Instance.Model.OptimizationParameters.Count +
                              ModelStorage.Instance.Model.Criteria.Count +
                              ModelStorage.Instance.Model.FunctionalConstraints.Count;
            if (sheet.Dimension.End.Column != columnsNeed)
            {
                throw new ArgumentException("Excel file and user model have different columns count.");
            }

            // Reading file
            ModelStorage.Instance.Model.RealExperiments.Clear();
            try
            {
                for (int i = 2; i < sheet.Dimension.End.Row + 1; i++)
                {
                    Experiment experiment = new Experiment(ModelStorage.Instance.Model.RealExperiments.GetFreeConsequentId(), i + 1);
                    for (int j = 1; j < sheet.Dimension.End.Column + 1; j++)
                    {
                        string valueStr = sheet.Cells[i, j].Value.ToString();
                        double value = ParseValue(valueStr);
                        SetValueToExperiment(experiment, value, j - 1);
                    }

                    ModelStorage.Instance.Model.RealExperiments.Add(experiment);
                }
            }
            catch (ArgumentException ag)
            {
                ModelStorage.Instance.Model.RealExperiments.Clear();
                MessageBoxHelper.ShowExclamation("Ошибка при чтении. " + ag.Message);
            }
        }

        // TODO: add model validation
        private double ParseValue(string valueStr)
        {
            // What is the purpose of this method? Is it to reduce number of exception types?
            // Or it is a placeholder for future validation?
            // BTW, what about double.TryParse()?

            try
            {
                return double.Parse(valueStr);
            }
            catch (FormatException fe)
            {
                throw new ArgumentException("Cannot parse value " + valueStr, fe);
            }
            catch (ArgumentException ag)
            {
                throw new ArgumentException("Cannot parse value " + valueStr, ag);
            }
        }

        private void SetValueToExperiment(Experiment experiment, double value, int columnNumber)
        {
            // TODO: Mapping column number to entity ID is risky: what if ID changes from int to, for example, string?
            if (columnNumber < ModelStorage.Instance.Model.OptimizationParameters.Count)
            {
                experiment.ParameterValues.Add(columnNumber, value);
            }
            else if (columnNumber < ModelStorage.Instance.Model.OptimizationParameters.Count + 
                         ModelStorage.Instance.Model.Criteria.Count)
            {
                experiment.CriterionValues.Add(columnNumber - 
                    ModelStorage.Instance.Model.OptimizationParameters.Count, value);
            }
            else
            {
                experiment.ConstraintValues.Add(columnNumber - 
                    ModelStorage.Instance.Model.OptimizationParameters.Count - 
                    ModelStorage.Instance.Model.Criteria.Count, value);
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (dialogSaveModel.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    XmlIdentificationModelProvider.Save(ModelStorage.Instance.Model, dialogSaveModel.FileName);
                }
                catch (Exception ex)
                {
                    MessageBoxHelper.ShowError(ex.Message);
                }

                dialogSaveModel.FileName = string.Empty;
            }
        }

        private void buttonReadXls_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Multiselect = false;
            ofd.Filter = "Excel Files (.xls, .xlsx)|*.xls;*.xlsx|All Files (*.*)|*.*";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string xlsFilePath = ofd.FileName;
                try
                {
                    UpdateModelFromXls(xlsFilePath);
                    InsetValues();
                }
                catch (ArgumentException ag)
                {
                    MessageBoxHelper.ShowExclamation("Ошибка." + ag.Message);
                }
            }
        }

        private void RealExperimentResultsForm_VisibleChanged(object sender, EventArgs e)
        {
            dgvExperimentsResults.Columns.Clear();
            InitDataGrid();
        }
    }
}