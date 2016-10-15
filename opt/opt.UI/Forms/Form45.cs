using System;
using System.Windows.Forms;
using opt.DataModel;
using opt.Provider;
using opt.Provider.Xml;
using opt.UI.Exporters;
using opt.UI.Helpers;

namespace opt.UI.Forms
{
    internal partial class Form45 : Form
    {
        private Form _prevForm;
        private Form _nextForm;

        private Model _model;
        public Model OptModel
        {
            get { return this._model; }
            set { this._model = value; }
        }

        // TODO: Dependency injection.
        private readonly IModelProvider modelProvider = new XmlModelProvider();

        private bool _repeatParams;
        private bool _enableSorting;
        private bool _hideInactiveExperiments;

        public Form45()
        {
            InitializeComponent();
        }

        public Form45(
            Form prevForm,
            Model model)
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

            this._enableSorting = true;
            this._repeatParams = true;
            this._hideInactiveExperiments = false;

            // Применим ограничения
            this._model.ApplyFunctionalConstraints();
            // Заполним табличку
            MatrixDataGridFiller.FillMatrixDataGrid(this._model,
                this.dgvData, this._enableSorting, this._repeatParams, this._hideInactiveExperiments);

            // Запустим сборщик мусора, чтобы убить
            // предыдущие ветки
            System.GC.Collect();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
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

        private void btnNext_Click(object sender, EventArgs e)
        {
            this._nextForm = new Form50(this, this._model);
            this._nextForm.Show();
            this.Hide();
        }

        private void Form45_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void btnOptions_Click(object sender, EventArgs e)
        {
            int xPos = this.Location.X + ((Button)sender).Location.X;
            int yPos = this.Location.Y + ((Button)sender).Location.Y + 
                2 * ((Button)sender).Size.Height;
            this.optionsMenu.Show(xPos, yPos);
        }

        private void mnuRepeatParams_Click(object sender, EventArgs e)
        {
            this._repeatParams = this.mnuRepeatParams.Checked;
            // Заполним табличку
            MatrixDataGridFiller.FillMatrixDataGrid(this._model,
                this.dgvData, this._enableSorting, this._repeatParams, this._hideInactiveExperiments);
        }

        private void mnuHideInactiveExperiments_Click(object sender, EventArgs e)
        {
            this._hideInactiveExperiments = this.mnuHideInactiveExperiments.Checked;
            // Заполним табличку
            MatrixDataGridFiller.FillMatrixDataGrid(this._model,
                this.dgvData, this._enableSorting, this._repeatParams, this._hideInactiveExperiments);
        }

        private void mnuEnableSorting_Click(object sender, EventArgs e)
        {
            this._enableSorting = this.mnuEnableSorting.Checked;
            // Заполним табличку
            MatrixDataGridFiller.FillMatrixDataGrid(this._model,
                this.dgvData, this._enableSorting, this._repeatParams, this._hideInactiveExperiments);
        }

        private void mnuApplyConstraints_Click(object sender, EventArgs e)
        {
            if (this.mnuApplyConstraints.Checked)
            {
                this._model.ApplyFunctionalConstraints();
            }
            else
            {
                foreach (Experiment exp in this._model.Experiments.Values)
                {
                    exp.IsActive = true;
                }
            }
            // Заполним табличку
            MatrixDataGridFiller.FillMatrixDataGrid(this._model,
                this.dgvData, this._enableSorting, this._repeatParams, this._hideInactiveExperiments);
        }

        private void mnuChangeConstraints_Click(object sender, EventArgs e)
        {
            ChangeConstraintsForm ccf = new ChangeConstraintsForm(this._model);
            if (ccf.ShowDialog() == DialogResult.OK)
            {
                if (this.mnuApplyConstraints.Checked)
                {
                    // Заполним табличку
                    MatrixDataGridFiller.FillMatrixDataGrid(this._model,
                        this.dgvData, this._enableSorting, this._repeatParams, this._hideInactiveExperiments);
                }
            }
            ccf.Dispose();
        }

        private void btnSaveMatrix_Click(object sender, EventArgs e)
        {
            if (this.dlgSaveModel.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string filePath = dlgSaveModel.FileName;
                    if (filePath.EndsWith(ExcelExporter.ExcelFileExtension, StringComparison.InvariantCultureIgnoreCase))
                    {
                        ExcelExporter excelExporter = new ExcelExporter(new ExcelExporterSettings() { ExportWhat = ExportableData.Experiments | ExportableData.ValidExperiments, FilePath = filePath });
                        excelExporter.Export(this._model);
                    }
                    else
                    {
                        modelProvider.Save(this._model, filePath);
                    }
                }
                catch (Exception ex)
                {
                    MessageBoxHelper.ShowError("Невозможно выполнить сохранение по указанному пути\nОригинальное сообщение: " + ex.Message);
                    return;
                }
                this.dlgSaveModel.FileName = string.Empty;
            }
        }

        private void btnCorrelations_Click(object sender, EventArgs e)
        {
            CriterionCorrelationsForm correlationsForm = new CriterionCorrelationsForm(this._model);
            correlationsForm.Show();
        }
    }
}