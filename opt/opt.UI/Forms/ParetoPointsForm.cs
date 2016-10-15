using System;
using System.Collections.Generic;
using System.Windows.Forms;
using opt.Helpers;
using opt.DataModel;
using opt.Solvers.Formal;
using opt.UI.Helpers.DataModel;
using opt.UI.Helpers;

namespace opt.UI.Forms
{
    internal partial class ParetoPointsForm : Form
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

        public ParetoPointsForm(
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

            this.lblSelectedMethod.Text = string.Empty;

            // Обнаружим паретовские точки
            ParetoFinder.FindParetoPoints(this._model);

            this.FillDataGrid();

            // Запустим сборщик мусора, чтобы убить
            // предыдущие ветки
            System.GC.Collect();
        }

        public ParetoPointsForm(
            Form prevForm,
            Model model,
            FormalMethods method) : this(prevForm, model)
        {
            this._method = method;
            this.lblSelectedMethod.Text = "Выбранный метод поиска окончательного решения:\n" +
                FormalMethodsManager.GetFormalMethodName(method);
        }

        public ParetoPointsForm()
        {
            InitializeComponent();
        }

        private void ParetoPointsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnShowMatrixForm_Click(object sender, EventArgs e)
        {
            MatrixForm matrix = new MatrixForm(this._model);
            matrix.ShowDialog();
            matrix.Dispose();
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
            if (!string.IsNullOrEmpty(this.lblSelectedMethod.Text))
            {
                this._nextForm = new FormalResultsForm(this, this._model, this._method);
                this._nextForm.Show();
                this.Hide();
            }
        }

        /// <summary>
        /// Метод для заполнения таблицы данных
        /// данными - паретовскими точками
        /// </summary>
        private void FillDataGrid()
        {
            this.dgvData.SuspendLayout();

            // Очистка
            this.dgvData.Columns.Clear();
            this.dgvData.Rows.Clear();

            // Создадим колонки
            // Колонки для параметров
            foreach (KeyValuePair<TId, Parameter> kvp in this._model.Parameters)
            {
                DataGridViewColumn paramCol = new DataGridViewColumn();
                paramCol.CellTemplate = new DataGridViewTextBoxCell();
                paramCol.SortMode = DataGridViewColumnSortMode.NotSortable;
                paramCol.HeaderText = kvp.Value.Name;
                paramCol.Name = "param_" + kvp.Key.ToString();
                paramCol.HeaderCell.ToolTipText = kvp.Value.GetDescription();
                this.dgvData.Columns.Add(paramCol);
            }
            // Колонки для критериев
            foreach (KeyValuePair<TId, Criterion> kvp in this._model.Criteria)
            {
                DataGridViewColumn critCol = new DataGridViewColumn();
                critCol.CellTemplate = new DataGridViewTextBoxCell();
                critCol.SortMode = DataGridViewColumnSortMode.NotSortable;
                critCol.HeaderText = kvp.Value.Name;
                critCol.Name = "crit_" + kvp.Key.ToString();
                critCol.HeaderCell.ToolTipText = kvp.Value.GetDescription();
                this.dgvData.Columns.Add(critCol);
            }
            // Колонки для функциональных ограничения
            foreach (KeyValuePair<TId, Constraint> kvp in this._model.FunctionalConstraints)
            {
                DataGridViewColumn constrCol = new DataGridViewColumn();
                constrCol.CellTemplate = new DataGridViewTextBoxCell();
                constrCol.SortMode = DataGridViewColumnSortMode.NotSortable;
                constrCol.HeaderText = kvp.Value.Name + " (" + kvp.Value.VariableIdentifier + ")";
                constrCol.Name = "constr_" + kvp.Key.ToString();
                constrCol.HeaderCell.ToolTipText = kvp.Value.GetDescription();
                this.dgvData.Columns.Add(constrCol);
            }





            // Создадим рядки и заполним их инфой
            foreach (KeyValuePair<TId, Experiment> kvp in this._model.Experiments)
            {
                // Выводим только если точка паретовская
                if (kvp.Value.IsParetoOptimal)
                {
                    // Добавим рядок
                    int rowInd = this.dgvData.Rows.Add();
                    // Запишем в хедер рядка номер эксперимента
                    this.dgvData.Rows[rowInd].HeaderCell.Value = kvp.Value.Number.ToString();
                    // Запишем в ячейки значения оптимизируемых параметров
                    foreach (KeyValuePair<TId, double> pvs in kvp.Value.ParameterValues)
                    {
                        int colInd = 0;
                        try
                        {
                            colInd = this.dgvData.Columns["param_" + pvs.Key.ToString()].Index;
                        }
                        catch (Exception ex)
                        {
                            MessageBoxHelper.ShowError(ex.Message);
                            return;
                        }
                        this.dgvData[colInd, rowInd].Value =
                            pvs.Value.ToString(SettingsManager.Instance.DoubleStringFormat);
                    }
                    // Запишем в ячейки значения критериев оптимальности
                    foreach (KeyValuePair<TId, double> pvs in kvp.Value.CriterionValues)
                    {
                        int colInd = 0;
                        try
                        {
                            colInd = this.dgvData.Columns["crit_" + pvs.Key.ToString()].Index;
                        }
                        catch (Exception ex)
                        {
                            MessageBoxHelper.ShowError(ex.Message);
                            return;
                        }
                        this.dgvData[colInd, rowInd].Value =
                            pvs.Value.ToString(SettingsManager.Instance.DoubleStringFormat);
                    }
                    // Запишем в ячейки значения ФО
                    foreach (KeyValuePair<TId, double> pvs in kvp.Value.ConstraintValues)
                    {
                        int colInd = 0;
                        if (this.dgvData.Columns["constr_" + pvs.Key.ToString()] != null)
                        {
                            colInd = this.dgvData.Columns["constr_" + pvs.Key.ToString()].Index;
                            this.dgvData[colInd, rowInd].Value =
                                pvs.Value.ToString(SettingsManager.Instance.DoubleStringFormat);
                        }
                    }
                }
            }

            this.dgvData.ResumeLayout();
            // Конец метода
        }
    }
}