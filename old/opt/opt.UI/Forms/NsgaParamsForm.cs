using System;
using System.Windows.Forms;
using opt.DataModel;
using opt.Solvers.Genetics.Nsga;
using opt.UI.Helpers;

namespace opt.UI.Forms
{
    public partial class NsgaParamsForm : Form
    {
        private Form _prevForm;
        private Form _nextForm;

        private Model _model;
        public Model OptModel
        {
            get { return this._model; }
            set { this._model = value; }
        }

        public NsgaParamsForm()
        {
            InitializeComponent();
        }

        public NsgaParamsForm(
            Form prevForm,
            Model model)
        {
            InitializeComponent();

            SetCalcAppFromCommandLine();

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

            // Заполним некоторые данные
            int activeExperimentsCount = this._model.Experiments.CountActiveExperiments();
            this.txtInitialGenerationCount.Text = activeExperimentsCount.ToString();
            this.nudSelectionLimit.Minimum = 2;
            this.nudSelectionLimit.Maximum = activeExperimentsCount;
            this.txtDescendantsCount.Text = "2";

            // Запустим сборщик мусора, чтобы убить
            // предыдущие ветки
            GC.Collect();
        }

        private void SetCalcAppFromCommandLine()
        {
            string calcAppFilePath = Program.ApplicationSettings.CalcAppFilePath;
            if (!string.IsNullOrEmpty(calcAppFilePath))
            {
                txtExternalAppPath.Text = calcAppFilePath;
            }
        }

        private void AdditiveGAParamsForm_FormClosing(object sender, FormClosingEventArgs e)
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

        private void btnNext_Click(object sender, EventArgs e)
        {
            string externalAppPath = this.txtExternalAppPath.Text.Trim();
            if (string.IsNullOrEmpty(externalAppPath))
            {
                MessageBoxHelper.ShowExclamation("Необходимо выбрать внешнюю расчетную программу, которая будет осуществлять расчет значений критериев");
                return;
            }

            NsgaParams geneticAlgorithmParams =
                new NsgaParams(this._model.Experiments.CountActiveExperiments(),
                               (int)this.nudSelectionLimit.Value,
                               (int)this.nudMaxGenerationsNumber.Value,
                               externalAppPath);

            if (this.chbShowProcess.Checked)
            {
                this._nextForm = new NsgaProcessForm(this, this._model, geneticAlgorithmParams);
            }
            else
            {
                this._nextForm = new NsgaResultsForm(this, this._model, geneticAlgorithmParams);
            }

            this._nextForm.Show();
            this.Hide();
        }

        private void btnChooseFile_Click(object sender, EventArgs e)
        {
            if (this.dlgExternalApp.ShowDialog() == DialogResult.OK)
            {
                this.txtExternalAppPath.Text = this.dlgExternalApp.FileName;
                this.dlgExternalApp.FileName = string.Empty;
            }
        }
    }
}