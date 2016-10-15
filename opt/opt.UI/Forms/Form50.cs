using System;
using System.Windows.Forms;
using opt.DataModel;
using opt.Helpers;
using opt.Solvers.Formal;

namespace opt.UI.Forms
{
    internal partial class Form50 : Form
    {
        private Form _prevForm;
        private Form _nextForm;

        private Model _model;
        public Model OptModel
        {
            get { return this._model; }
            set { this._model = value; }
        }

        public Form50()
        {
            InitializeComponent();
        }

        public Form50(
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

            // Запустим сборщик мусора, чтобы убить
            // предыдущие ветки
            System.GC.Collect();
        }

        private void Form50_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
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

        private void btnShowMatrixForm_Click(object sender, EventArgs e)
        {
            MatrixForm matrix = new MatrixForm(this._model);
            matrix.ShowDialog();
            matrix.Dispose();
        }

        private void rbnFormalMethods_CheckedChanged(object sender, EventArgs e)
        {
            this.grpFormalMethods.Enabled = this.rbnFormalMethods.Checked;
        }

        private void rbnCriteriaConvolution_CheckedChanged(object sender, EventArgs e)
        {
            this.grpCriteriaConvolution.Enabled = this.rbnCriteriaConvolution.Checked;
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (this.rbnFormalMethods.Checked)
            {
                // Скопируем объект модели, чтобы там
                // ничего не покорявилось в процессе
                byte[] modelCopyBytes = Model.Serialize(this._model);
                Model modelCopy = Model.Deserialize(modelCopyBytes);
                // Применим формальный метод
                // А какой - узнаем:
                if (this.rbnIdealPoint.Checked)
                {
                    this._nextForm = 
                        new AdmissibleSetForm(this, modelCopy, FormalMethods.IdealPoint);
                }
                if (this.rbnMaximalPower.Checked)
                {
                    this._nextForm =
                        new AdmissibleSetForm(this, modelCopy, FormalMethods.MaximalPower);
                }
                if (this.rbnBinaryRelations.Checked)
                {
                    this._nextForm =
                        new AdmissibleSetForm(this, modelCopy, FormalMethods.BinaryRelations);
                }
            }
            else if (this.rbnCriteriaConvolution.Checked)
            {
                // Ести информация о важности критериев
                // Узнаем, как пользователь может ее предоставить
                if (this.rbnFlexiblePriority.Checked)
                {
                    // Хочет задать весовые коэффициенты
                    this._nextForm =
                        new WeightsForm(this, this._model);
                }
                if (this.rbnMainCriterionMethod.Checked)
                {
                    // Скопируем объект модели, чтобы там
                    // ничего не покорявилось в процессе
                    byte[] modelCopyBytes = Model.Serialize(this._model);
                    Model modelCopy = Model.Deserialize(modelCopyBytes);
                    // Метод главного критерия
                    this._nextForm =
                        new MainCriterionForm(this, modelCopy);
                }
                if (this.rbnSuccessiveConcessionsMethod.Checked)
                {
                    // Скопируем объект модели, чтобы там
                    // ничего не покорявилось в процессе
                    byte[] modelCopyBytes = Model.Serialize(this._model);
                    Model modelCopy = Model.Deserialize(modelCopyBytes);
                    // Метод главного критерия
                    this._nextForm =
                        new CriteriaPriorityForm(this, modelCopy);
                }
            }
            else if (this.rbnNsga2.Checked)
            {
                // Это идет генетический алгоритм
                this._nextForm = new NsgaParamsForm(this, this._model);
            }
            
            // Покажем следующую форму, а какую именно - 
            // мы уже определили выше
            this._nextForm.Show();
            this.Hide();
        }
    }
}
