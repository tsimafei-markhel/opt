using System;
using System.Windows.Forms;
using opt.DataModel;
using opt.Helpers;
using opt.UI.Helpers;
using opt.Xml;

// TODO: Rewrite SelectNextForm() - update model contents based on its state (e.g. if there is no criteria, we should clear critera values for all experiments),
//       check other cases, not only ParameterValuesExist & CriterionValuesExist

namespace opt.UI.Forms
{
    internal partial class Form5 : Form
    {
        private Form _nextForm;

        private Model _model;
        public Model OptModel
        {
            get { return this._model; }
            set { this._model = value; }
        }

        public Form5()
        {
            InitializeComponent();
            this._model = new Model();

            SetModelFromCommandLine();
        }

        private void SetModelFromCommandLine()
        {
            string modelFilePath = Program.ApplicationSettings.ModelFilePath;
            if (!string.IsNullOrEmpty(modelFilePath))
            {
                txtFileName.Text = modelFilePath;
                rbnLoadSavedModel.Checked = true;
            }
        }

        private void btnChooseFile_Click(object sender, EventArgs e)
        {
            if (this.dlgOpenModelFile.ShowDialog() == DialogResult.OK)
            {
                this.txtFileName.Text = this.dlgOpenModelFile.FileName;
                this.dlgOpenModelFile.FileName = string.Empty;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form5_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void rbnLoadSavedModel_CheckedChanged(object sender, EventArgs e)
        {
            this.label1.Enabled = this.rbnLoadSavedModel.Checked;
            this.btnChooseFile.Enabled = this.rbnLoadSavedModel.Checked;
            this.txtFileName.Enabled = this.rbnLoadSavedModel.Checked;
            this.chbRedefineModel.Enabled = this.rbnLoadSavedModel.Checked;
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (this.rbnCreateNewModel.Checked)
            {
                // Создадим новую модель
                this._nextForm = new Form10(this, this._model);
            }
            else
            {
                // Откроем модель из файла
                string fileName = this.txtFileName.Text.Trim();

                if (string.IsNullOrEmpty(fileName))
                {
                    MessageBoxHelper.ShowExclamation("Пожалуйста выберите файл с матрицей решений");
                    return;
                }
                else
                {
                    if (!System.IO.File.Exists(fileName))
                    {
                        MessageBoxHelper.ShowError("Выбранного файла с матрицей решений не существует!");
                        return;
                    }
                    else
                    {
                        try
                        {
                            this._model = XmlModelProvider.Open(fileName);
                        }
                        catch (Exception ex)
                        {
                            MessageBoxHelper.ShowError("Не удалось загрузить матрицу из выбранного файла\nОригинальное сообщение: " + ex.Message);
                            return;
                        }

                        // Если пользователь хочет изменить модель, то
                        // сразу покажем ему форму с параметрами
                        if (this.chbRedefineModel.Checked)
                        {
                            // Очистим матрицу решений (если есть что очищать)
                            if (this._model != null)
                            {
                                this._model.Experiments.Clear();
                            }
                            // Назначим следующую форму
                            this._nextForm = new Form10(this, this._model);
                        }
                        else
                        {
                            this._nextForm = this.SelectNextForm();
                        }
                    }
                }
            }

            this._nextForm.Show();
            this.Hide();
        }

        private Form SelectNextForm()
        {
            ModelState modelState = ModelState.GetModelState(this._model);

            // Проверим, что именно было в файле,
            // и на основании этого примем решение,
            // какое окно показывать следующим
            if (modelState.HasParameterValues)
            {
                // Значения параметров уже есть
                if (modelState.HasCriterionValues)
                {
                    // Есть и значения критериев,
                    // полная матрица решений в наличии.
                    // Покажем окно с матрицей решений
                    return new Form45(this, this._model);
                }
                else
                {
                    // Нет значений критериев оптимальности.
                    // Покажем окно выбора способа ввода
                    // значений критериев оптимальности
                    return new Form35(this, this._model);
                }
            }
            else
            {
                // Нет значений оптимизируемых параметров.
                // Покажем окно выбора способа ввода
                // значений оптимизируемых параметров
                return new Form25(this, this._model);
            }
        }
    }
}