using System;
using System.Windows.Forms;
using opt.DataModel;
using opt.Solvers.SuccessiveConcessions;
using opt.UI.Exporters;
using opt.UI.Helpers;

namespace opt.UI.Forms
{
    public partial class SuccessiveConcessionsResultsForm : Form
    {
        private Form _prevForm;

        private Model _model;
        public Model OptModel
        {
            get { return this._model; }
            set { this._model = value; }
        }

        private ScMethodResult _result;

        public SuccessiveConcessionsResultsForm()
        {
            InitializeComponent();
        }

        public SuccessiveConcessionsResultsForm(
            Form prevForm,
            Model model,
            ScMethodResult result)
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
            this._result = result;

            // Заполним таблицу результатами
            ScDataGridFiller.FillDataGrid(
                this._model,
                this._result,
                this.dgvData);

            // Запустим сборщик мусора, чтобы убить
            // предыдущие ветки
            System.GC.Collect();
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

        private void SuccessiveConcessionsResultsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}