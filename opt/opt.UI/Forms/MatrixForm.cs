using System;
using System.Windows.Forms;
using opt.DataModel;
using opt.Provider;
using opt.Provider.Xml;
using opt.UI.Exporters;
using opt.UI.Helpers;

namespace opt.UI.Forms
{
    internal partial class MatrixForm : Form
    {
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

        public MatrixForm()
        {
            InitializeComponent();
        }

        public MatrixForm(
            Model model)
        {
            InitializeComponent();

            this._model = model;

            this._enableSorting = true;
            this._repeatParams = true;
            this._hideInactiveExperiments = false;

            // Заполним табличку
            MatrixDataGridFiller.FillMatrixDataGrid(this._model,
                this.dgvData, this._enableSorting, this._repeatParams, this._hideInactiveExperiments);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void mnuEnableSorting_Click(object sender, EventArgs e)
        {
            this._enableSorting = this.mnuEnableSorting.Checked;
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
    }
}