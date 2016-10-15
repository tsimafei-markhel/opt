using System;
using System.Collections.Generic;
using System.Windows.Forms;
using opt.DataModel;
using opt.Solvers.IntegralCriterion;
using opt.UI.Exporters;
using opt.UI.Helpers;

namespace opt.UI.Forms
{
    public partial class IntegralResultsForm : Form
    {
        private Form _prevForm;

        private Model _model;
        public Model OptModel
        {
            get { return this._model; }
            set { this._model = value; }
        }

        private IntegralCriterionMethodResult _result;
        private Dictionary<TId, UtilityFunction> _utilityFunctions;
        private bool _showNormalizedCriterionValues;
        private bool _showUtilityFunctionValues;

        public IntegralResultsForm()
        {
            InitializeComponent();
        }

        public IntegralResultsForm(
            Form prevForm,
            Model model,
            Dictionary<TId, UtilityFunction> utilityFunctions,
            IntegralCriterionMethods method)
        {
            InitializeComponent();

            // Подстройка интерфейса
            this.Left = prevForm.Left;
            this.Top = prevForm.Top;
            if (this.FormBorderStyle != FormBorderStyle.FixedSingle)
            {
                this.WindowState = prevForm.WindowState;
            }
            if (this.WindowState == FormWindowState.Normal)
            {
                this.Width = prevForm.Width;
                this.Height = prevForm.Height;
            }

            this._prevForm = prevForm;
            this._model = model;
            this._utilityFunctions = utilityFunctions;

            this._showNormalizedCriterionValues = false;
            this._showUtilityFunctionValues = false;

            IIntegralCriterionMethodSolver solver = new AdditiveCriterionSolver();
            switch (method)
            {
                case IntegralCriterionMethods.AdditiveCriterion:
                case IntegralCriterionMethods.AdditiveCriterionWithUtilityFunction:
                    solver = new AdditiveCriterionSolver();
                    break;
                case IntegralCriterionMethods.MultiplicativeCriterion:
                case IntegralCriterionMethods.MultiplicativeCriterionWithUtilityFunction:
                    solver = new MultiplicativeCriterionSolver();
                    break;
                case IntegralCriterionMethods.MinimaxMethod:
                    solver = new MinimaxSolver();
                    // Уберем возможность показывать значения функции полезности
                    this.mnuShowUtilityFunctionValues.Enabled = false;
                    break;
            }

            switch (method)
            {
                case IntegralCriterionMethods.AdditiveCriterion:
                case IntegralCriterionMethods.MultiplicativeCriterion:
                case IntegralCriterionMethods.MinimaxMethod:
                    this.mnuShowUtilityFunctionValues.Enabled = false;
                    this.mnuShowNormalizedCriterionValues.Enabled = true;
                    this._result = solver.FindDecision(this._model);
                    IntegralCriterionResultDataGridFiller.FillDataGrid(
                        this._model,
                        this._result,
                        this.dgvData,
                        this._showNormalizedCriterionValues);
                    break;
                case IntegralCriterionMethods.AdditiveCriterionWithUtilityFunction:
                case IntegralCriterionMethods.MultiplicativeCriterionWithUtilityFunction:
                    this.mnuShowUtilityFunctionValues.Enabled = true;
                    this.mnuShowNormalizedCriterionValues.Enabled = false;
                    this._result = 
                        solver.FindDecisionWithUtilityFunction(this._model, this._utilityFunctions);
                    IntegralCriterionResultDataGridFiller.FillDataGridWithUtilityFunction(
                        this._model,
                        this._utilityFunctions,
                        this._result,
                        this.dgvData,
                        this._showUtilityFunctionValues);
                    break;
            }

            // Запустим сборщик мусора, чтобы убить
            // предыдущие ветки
            System.GC.Collect();
        }

        private void btnFinish_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void IntegralResultsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void btnSaveMatrix_Click(object sender, EventArgs e)
        {
            if (this.dlgSaveResults.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    OptModel.Properties[_result.Name] = _result;
                    string filePath = dlgSaveResults.FileName;
                    IDataExporter exporter = null;
                    if (filePath.EndsWith(ExcelExporter.ExcelFileExtension, StringComparison.InvariantCultureIgnoreCase))
                    {
                        exporter = new ExcelExporter(new ExcelExporterSettings() { ExportWhat = ExportableData.Results, FilePath = filePath });
                    }
                    else
                    {
                        exporter = new TextResultExporter(new TextResultExporterSettings() { ExportWhat = ExportableData.Results, FilePath = filePath });
                    }

                    exporter.Export(OptModel);
                }
                catch (Exception ex)
                {
                    MessageBoxHelper.ShowError("Невозможно выполнить сохранение по указанному пути\nОригинальное сообщение: " + ex.Message);
                    return;
                }
                this.dlgSaveResults.FileName = string.Empty;
            }
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            // Подстройка интерфейса
            this._prevForm.Left = this.Left;
            this._prevForm.Top = this.Top;
            if (this._prevForm.FormBorderStyle != FormBorderStyle.FixedSingle)
            {
                this._prevForm.WindowState = this.WindowState;
            }
            if (this._prevForm.WindowState == FormWindowState.Normal)
            {
                this._prevForm.Width = this.Width;
                this._prevForm.Height = this.Height;
            }

            this._prevForm.Show();
            this.Hide();
        }

        private void btnOptions_Click(object sender, EventArgs e)
        {
            int xPos = this.Location.X + ((Button)sender).Location.X;
            int yPos = this.Location.Y + ((Button)sender).Location.Y +
                2 * ((Button)sender).Size.Height;
            this.optionsMenu.Show(xPos, yPos);
        }

        private void mnuShowNormalizedCriterionValues_Click(object sender, EventArgs e)
        {
            this._showNormalizedCriterionValues = this.mnuShowNormalizedCriterionValues.Checked;
            IntegralCriterionResultDataGridFiller.FillDataGrid(
                this._model,
                this._result,
                this.dgvData,
                this._showNormalizedCriterionValues);
        }

        private void mnuShowUtilityFunctionValues_Click(object sender, EventArgs e)
        {
            this._showUtilityFunctionValues = this.mnuShowUtilityFunctionValues.Checked;
            IntegralCriterionResultDataGridFiller.FillDataGridWithUtilityFunction(
                this._model,
                this._utilityFunctions,
                this._result,
                this.dgvData,
                this._showUtilityFunctionValues);
        }
    }
}