using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using opt.DataModel;
using opt.UI.Helpers;
using opt.UI.Helpers.DataModel;

namespace opt.UI.Forms
{
    internal partial class Form40 : Form
    {
        private Form _prevForm;
        private Form _nextForm;

        private Model _model;
        public Model OptModel
        {
            get { return this._model; }
            set { this._model = value; }
        }

        public Form40()
        {
            InitializeComponent();
        }

        public Form40(
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

            this.FillDataGrid();

            // Запустим сборщик мусора, чтобы убить
            // предыдущие ветки
            System.GC.Collect();
        }

        /// <summary>
        /// Метод для заполнения таблицы данных
        /// полями для ввода значений критериев и
        /// функциональных ограничений
        /// </summary>
        private void FillDataGrid()
        {
            this.dgvData.SuspendLayout();

            // Очистка
            this.dgvData.Columns.Clear();
            this.dgvData.Rows.Clear();

            // Создадим колонки
            DataGridViewColumn indexCol = new DataGridViewColumn();
            indexCol.CellTemplate = new DataGridViewTextBoxCell();
            indexCol.SortMode = DataGridViewColumnSortMode.NotSortable;
            indexCol.Visible = false;
            this.dgvData.Columns.Add(indexCol);
            // Колонки для параметров
            foreach (KeyValuePair<TId, Parameter> kvp in this._model.Parameters)
            {
                DataGridViewColumn paramCol = new DataGridViewColumn();
                paramCol.CellTemplate = new DataGridViewTextBoxCell();
                paramCol.CellTemplate.ValueType = typeof(double);
                //paramCol.CellTemplate.ReadOnly = true;
                paramCol.SortMode = DataGridViewColumnSortMode.NotSortable;
                paramCol.HeaderText = kvp.Value.Name;
                paramCol.Name = kvp.Key.ToString();
                paramCol.Tag = "parameter";
                paramCol.HeaderCell.ToolTipText = kvp.Value.GetDescription();
                this.dgvData.Columns.Add(paramCol);
            }
            // Колонки для критериев
            foreach (KeyValuePair<TId, Criterion> kvp in this._model.Criteria)
            {
                DataGridViewColumn critCol = new DataGridViewColumn();
                critCol.CellTemplate = new DataGridViewTextBoxCell();
                critCol.CellTemplate.ValueType = typeof(double);
                critCol.SortMode = DataGridViewColumnSortMode.NotSortable;
                critCol.HeaderText = kvp.Value.Name;
                critCol.Name = kvp.Key.ToString();
                critCol.Tag = "criterion";
                critCol.HeaderCell.ToolTipText = kvp.Value.GetDescription();
                this.dgvData.Columns.Add(critCol);
            }
            // Колонки для функциональных ограничения
            foreach (KeyValuePair<TId, Constraint> kvp in this._model.FunctionalConstraints)
            {
                DataGridViewColumn constrCol = new DataGridViewColumn();
                constrCol.CellTemplate = new DataGridViewTextBoxCell();
                constrCol.CellTemplate.ValueType = typeof(double);
                constrCol.SortMode = DataGridViewColumnSortMode.NotSortable;
                constrCol.HeaderText = kvp.Value.Name;
                constrCol.Name = kvp.Key.ToString();
                constrCol.Tag = "constraint";
                constrCol.HeaderCell.ToolTipText = kvp.Value.GetDescription();
                this.dgvData.Columns.Add(constrCol);
            }

            // Создадим рядки и заполним их инфой
            foreach (KeyValuePair<TId, Experiment> kvp in this._model.Experiments)
            {
                // Добавим рядок
                int rowInd = this.dgvData.Rows.Add();
                // Запишем в невидимую колонку индекс эксперимента
                this.dgvData[0, rowInd].Value = kvp.Key;
                // Запишем в хедер рядка номер эксперимента
                this.dgvData.Rows[rowInd].HeaderCell.Value =
                        kvp.Value.Number.ToString();
                // Запишем в ячейки значения оптимизируемых параметров
                foreach (KeyValuePair<TId, double> pvs in kvp.Value.ParameterValues)
                {
                    int colInd = 0;
                    try
                    {
                        colInd = this.dgvData.Columns[pvs.Key.ToString()].Index;
                    }
                    catch (Exception ex)
                    {
                        MessageBoxHelper.ShowError(ex.Message);
                        return;
                    }
                    this.dgvData[colInd, rowInd].Value =
                        pvs.Value.ToString(SettingsManager.Instance.DoubleStringFormat);
                    this.dgvData[colInd, rowInd].ReadOnly = true;
                }
                // Записывать в ячейки значения критериев оптимальности и 
                // функциональных ограничений смысла нет - эта форма не
                // используется для просмотра, а нужна только для ввода
                // этих самых значений критериев и ограничений
            }

            this.dgvData.ResumeLayout();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form40_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Все введенные значения будут утеряны!\nВы действительно хотите вернуться назад?",
                Program.ApplicationSettings.ApplicationName,
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
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
        }

        private bool CheckCritVals()
        {
            foreach (KeyValuePair<TId, Criterion> crit in this._model.Criteria)
            {
                foreach (KeyValuePair<TId, Experiment> exp in this._model.Experiments)
                {
                    // Если в одном из экспериментов не задано значение данного критерия
                    if (!exp.Value.CriterionValues.ContainsKey(crit.Key))
                    {
                        // Тест провален
                        MessageBoxHelper.ShowError(
                            "Для эксперимента №" + exp.Value.Number.ToString() +
                            " не задано значение критерия '" + crit.Value.Name +
                            "'");
                        return false;
                    }
                }
            }

            return true;
        }

        private bool CheckConstrVals()
        {
            foreach (KeyValuePair<TId, Constraint> constr in this._model.FunctionalConstraints)
            {
                foreach (KeyValuePair<TId, Experiment> exp in this._model.Experiments)
                {
                    // Если в одном из экспериментов не задано значение данного 
                    // функционального ограничения
                    if (!exp.Value.ConstraintValues.ContainsKey(constr.Key))
                    {
                        // Тест провален
                        MessageBoxHelper.ShowError(
                            "Для эксперимента №" + exp.Value.Number.ToString() +
                            " не задано значение функционального ограничения '" + constr.Value.Name +
                            "'");
                        return false;
                    }
                }
            }

            return true;
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            // Финальная проверка
            bool valuesOk = this.CheckCritVals() && this.CheckConstrVals();

            if (valuesOk)
            {
                this._nextForm = new Form45(this, this._model);
                this._nextForm.Show();
                this.Hide();
            }
        }

        private void dgvData_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            TId expIndex = (TId)this.dgvData[0, e.RowIndex].Value;
            TId colIndex = TId.Parse(this.dgvData.Columns[e.ColumnIndex].Name);
            string colType = this.dgvData.Columns[e.ColumnIndex].Tag.ToString();

            // Проверим на пустую строку
            if (string.IsNullOrEmpty(e.FormattedValue.ToString()))
            {
                string message = string.Empty;
                switch (colType)
                {
                    case "parameter":
                        message = "Ошибка: на этом этапе нельзя редактировать значения оптимизируемых параметров";
                        break;
                    case "criterion":
                        message = "Значение критерия '" + this._model.Criteria[colIndex].Name +
                            "' для эксперимента №" + 
                            this._model.Experiments[expIndex].Number.ToString() +
                            " должно быть задано";
                        break;
                    case "constraint":
                        message = "Значение функционального ограничения '" + 
                            this._model.FunctionalConstraints[colIndex].Name +
                            "' для эксперимента №" + 
                            this._model.Experiments[expIndex].Number.ToString() +
                            " должно быть задано";
                        break;
                }

                MessageBoxHelper.ShowExclamation(message);
                e.Cancel = true;
                return;
            }

            // Проверим, число ли это и можно ли его преобразовать в double
            double newValue = Double.NaN;
            try
            {
                newValue = Convert.ToDouble(e.FormattedValue);
            }
            catch (Exception)
            {
                string message = string.Empty;
                switch (colType)
                {
                    case "parameter":
                        message = "Ошибка: на этом этапе нельзя редактировать значения оптимизируемых параметров";
                        break;
                    case "criterion":
                        message = "Невозможно преобразовать введенное для эксперимента №" +
                            this._model.Experiments[expIndex].Number.ToString() +
                            " значение критерия '" + this._model.Criteria[colIndex].Name +
                            "' в число";
                        break;
                    case "constraint":
                        message = "Невозможно преобразовать введенное для эксперимента №" +
                            this._model.Experiments[expIndex].Number.ToString() +
                            " значение функционального ограничения '" + 
                            this._model.FunctionalConstraints[colIndex].Name +
                            "' в число";
                        break;
                }

                MessageBoxHelper.ShowError(message);
                e.Cancel = true;
                return;
            }

            // Это число и все ок?
            if (newValue != Double.NaN)
            {
                // Проверять, вписывается ли введенное значение в допустимый диапазон
                // для оптимизируемого параметра, не будем, потому что на этом этапе
                // нельзя изменять значения оптимизируемых параметров

                // Наконец-то сохраним введенное значение!
                switch (colType)
                {
                    case "criterion":
                        if (this._model.Experiments[expIndex].CriterionValues.ContainsKey(colIndex))
                        {
                            this._model.Experiments[expIndex].CriterionValues[colIndex] = newValue;
                        }
                        else
                        {
                            this._model.Experiments[expIndex].CriterionValues.Add(
                                colIndex,
                                newValue);
                        }
                        break;
                    case "constraint":
                        if (this._model.Experiments[expIndex].ConstraintValues.ContainsKey(colIndex))
                        {
                            this._model.Experiments[expIndex].ConstraintValues[colIndex] = newValue;
                        }
                        else
                        {
                            this._model.Experiments[expIndex].ConstraintValues.Add(
                                colIndex,
                                newValue);
                        }
                        break;

                }
            }
        }
    }
}