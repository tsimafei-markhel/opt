using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using opt.DataModel;
using opt.Solvers.Genetics;
using opt.Solvers.Genetics.Additive;

namespace opt.UI.Forms
{
    public partial class AdditiveProcessForm : Form
    {
        private Form _prevForm;
        private Form _nextForm;

        private Model _model;
        public Model OptModel
        {
            get { return this._model; }
            set { this._model = value; }
        }

        private AdditiveParams _gaParams;
        private AdditiveMethodResult _result;

        public AdditiveProcessForm()
        {
            InitializeComponent();
        }

        public AdditiveProcessForm(
            Form prevForm,
            Model model,
            AdditiveParams gaParams)
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
            this._gaParams = gaParams;

            // Поищем решение
            this._result = AdditiveSolver.FindDecision(this._model, this._gaParams, this.dgvData);

            // Запустим сборщик мусора, чтобы убить
            // предыдущие ветки
            System.GC.Collect();
        }

        private void AdditiveGAProcessForm_FormClosing(object sender, FormClosingEventArgs e)
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
            this._nextForm = new AdditiveResultsForm(this._prevForm, this._model, this._result);
            
            this._nextForm.Show();
            this.Hide();
        }
    }
}
