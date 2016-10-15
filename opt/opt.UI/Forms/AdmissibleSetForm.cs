using System;
using System.Collections.Generic;
using System.Windows.Forms;
using opt.Helpers;
using opt.DataModel;
using opt.Solvers.Formal;
using opt.UI.Helpers;
using System.Collections.ObjectModel;

namespace opt.UI.Forms
{
    public partial class AdmissibleSetForm : Form
    {
        private Form _prevForm;
        private Form _nextForm;

        private Model _model;
        public Model OptModel
        {
            get { return this._model; }
            set { this._model = value; }
        }

        private FormalMethods _method;
        private ReadOnlyCollection<TId> _initialState;

        private bool _showConstraints;
        private bool _repeatParams;

        public AdmissibleSetForm()
        {
            InitializeComponent();
        }

        public AdmissibleSetForm(
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
            this._showConstraints = false;
            this._repeatParams = false;

            this.lblSelectedMethod.Text = string.Empty;

            // Получим начальное состояние, чтобы можно было 
            // начинать сначала
            this._initialState = AdmissibleSetFinder.GetInitialSet(this._model);

            // Заполним таблицу граничных точек
            this.FillBoundaryPointsGrid();

            // Заполним матрицу решений
            MatrixDataGridFiller.FillAdmissibleSetDataGrid(
                this._model,
                this.dgvData,
                this._showConstraints,
                this._repeatParams);

            // Запустим сборщик мусора, чтобы убить
            // предыдущие ветки
            System.GC.Collect();
        }

        public AdmissibleSetForm(
            Form prevForm,
            Model model,
            FormalMethods method) : this(prevForm, model)
        {
            this._method = method;
            this.lblSelectedMethod.Text = "Выбранный метод поиска окончательного решения:\n" +
                FormalMethodsManager.GetFormalMethodName(method);
        }

        private void AdmissibleSetForm_FormClosing(object sender, FormClosingEventArgs e)
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
            switch (this._method)
            {
                case FormalMethods.BinaryRelations:
                case FormalMethods.IdealPoint:
                    this._nextForm = new ParetoPointsForm(this, this._model, this._method);
                    break;
                case FormalMethods.MaximalPower:
                    this._nextForm = new FormalResultsForm(this, this._model, this._method);
                    break;
            }
            this._nextForm.Show();
            this.Hide();
        }

        private void btnRefreshAdmissibleSet_Click(object sender, EventArgs e)
        {
            // Получим граничные точки, которые ввел пользователь
            Dictionary<TId, int> boundaryPoints = new Dictionary<TId, int>();
            bool gotAllPoints = true;
            foreach (DataGridViewRow row in this.dgvBoundaryPoints.Rows)
            {
                TId critId = (TId)row.Cells[0].Value;
                int boundaryPt = 0;
                
                try
                {
                    string value = (string)row.Cells[2].FormattedValue;
                    if (string.IsNullOrEmpty(value))
                    {
                        value = "0";
                    }
                    boundaryPt = Convert.ToInt32(value);
                }
                catch (Exception ex)
                {
                    string message = "Не могу преобразовать введенное для критерия '" +
                        this._model.Criteria[critId].Name +
                        "' значение номера граничного эксперимента в целое число" +
                        "\nОригинальное сообщение: " + ex.Message;
                    MessageBoxHelper.ShowError(message);
                    gotAllPoints = false;
                    return;
                }

                if (boundaryPt >= 0)
                {
                    boundaryPoints.Add(critId, boundaryPt);
                }
            }

            // Если все точки собраны без ошибок
            if (gotAllPoints)
            {
                // Сформируем допустимое множество
                ReadOnlyCollection<TId> admissibleSet = AdmissibleSetFinder.GetAdmissibleSet(boundaryPoints, this._model);
                // Применим его
                AdmissibleSetFinder.ApplyAdmissibleSet(admissibleSet, this._model);
                // Покажем его
                MatrixDataGridFiller.FillAdmissibleSetDataGrid(this._model, this.dgvData, this._showConstraints, this._repeatParams);
            }
        }

        private void btnResetAdmissibleSet_Click(object sender, EventArgs e)
        {
            AdmissibleSetFinder.ApplyAdmissibleSet(this._initialState, this._model);
            this.FillBoundaryPointsGrid();
            MatrixDataGridFiller.FillAdmissibleSetDataGrid(this._model, this.dgvData, this._showConstraints, this._repeatParams);
        }

        private void FillBoundaryPointsGrid()
        {
            this.dgvBoundaryPoints.SuspendLayout();

            this.dgvBoundaryPoints.Rows.Clear();

            foreach (Criterion crit in this._model.Criteria.Values)
            {
                int rowId = this.dgvBoundaryPoints.Rows.Add();

                this.dgvBoundaryPoints.Rows[rowId].Cells[0].Value = crit.Id;
                this.dgvBoundaryPoints.Rows[rowId].Cells[1].Value = crit.Name;
                this.dgvBoundaryPoints.Rows[rowId].Cells[2].Value = string.Empty;
            }

            this.dgvBoundaryPoints.ResumeLayout();
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
            MatrixDataGridFiller.FillAdmissibleSetDataGrid(this._model, this.dgvData,
                this._showConstraints, this._repeatParams);
        }

        private void mnuShowConstraints_Click(object sender, EventArgs e)
        {
            this._showConstraints = this.mnuShowConstraints.Checked;
            MatrixDataGridFiller.FillAdmissibleSetDataGrid(this._model, this.dgvData,
                this._showConstraints, this._repeatParams);
        }
    }
}