using System;
using System.Windows.Forms;
using opt.DataModel;
using opt.Solvers.MainCriterion;
using opt.UI.Exporters;
using opt.UI.Helpers;

namespace opt.UI.Forms
{
    public partial class MainCriterionResultsForm : Form
    {
        private Form _prevForm;

        private Model _model;
        public Model OptModel
        {
            get { return this._model; }
            set { this._model = value; }
        }

        private MainCriterionMethodResult _result;
        private CriterialConstraints _criterialConstraints;
        private bool _showInactiveExperiments;

        public MainCriterionResultsForm()
        {
            InitializeComponent();
        }

        public MainCriterionResultsForm(
            Form prevForm,
            Model model,
            CriterialConstraints criterialConstraints,
            TId mainCriterionId)
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
            this._criterialConstraints = criterialConstraints;

            this._showInactiveExperiments = false;

            // Найдем решение
            this._criterialConstraints.ApplyCriterialConstraints(ref this._model);
            MainCriterionSolver solver = new MainCriterionSolver();
            this._result = solver.FindDecision(this._model, mainCriterionId);

            // Заполним таблицу результатами
            MainCriterionDataGridFiller.FillDataGrid(
                this._model,
                this._result,
                this.dgvData,
                this._showInactiveExperiments);

            // Запустим сборщик мусора, чтобы убить
            // предыдущие ветки
            System.GC.Collect();
        }

        private void btnOptions_Click(object sender, EventArgs e)
        {
            int xPos = this.Location.X + ((Button)sender).Location.X;
            int yPos = this.Location.Y + ((Button)sender).Location.Y +
                2 * ((Button)sender).Size.Height;
            this.optionsMenu.Show(xPos, yPos);
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

        private void btnFinish_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void mnuShowInactiveExperiments_Click(object sender, EventArgs e)
        {
            this._showInactiveExperiments = this.mnuShowInactiveExperiments.Checked;
            // Заполним таблицу результатами
            MainCriterionDataGridFiller.FillDataGrid(
                this._model,
                this._result,
                this.dgvData,
                this._showInactiveExperiments);
        }

        private void MainCriterionResultsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}