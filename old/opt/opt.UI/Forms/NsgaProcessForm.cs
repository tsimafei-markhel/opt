using System;
using System.Windows.Forms;
using opt.DataModel;
using opt.Solvers.Genetics.Additive;
using opt.Solvers.Genetics.Nsga;

namespace opt.UI.Forms
{
    public partial class NsgaProcessForm : Form
    {
        private Form _prevForm;
        private Form _nextForm;

        private Model _model;
        public Model OptModel
        {
            get { return this._model; }
            set { this._model = value; }
        }

        private NsgaParams _gaParams;
        private NsgaMethodResult _result;

        public NsgaProcessForm()
        {
            InitializeComponent();
        }

        public NsgaProcessForm(
            Form prevForm,
            Model model,
            NsgaParams gaParams)
        {
            InitializeComponent();

            // Подстройка интерфейса
            Left = prevForm.Left;
            Top = prevForm.Top;
            if (FormBorderStyle != FormBorderStyle.FixedSingle)
            {
                WindowState = prevForm.WindowState;
            }
            if (WindowState == FormWindowState.Normal)
            {
                Width = prevForm.Width;
                Height = prevForm.Height;
            }

            _prevForm = prevForm;
            _model = model;
            _gaParams = gaParams;

            // Поищем решение
            _result = NsgaSolver.FindDecision(ref _model, _gaParams, dgvData);

            // Запустим сборщик мусора, чтобы убить
            // предыдущие ветки
            GC.Collect();
        }

        private void NsgaProcessForm_FormClosing(object sender, FormClosingEventArgs e)
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
            this._nextForm = new NsgaResultsForm(_prevForm, _model, _result);
            
            this._nextForm.Show();
            this.Hide();
        }
    }
}