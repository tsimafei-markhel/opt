using System;
using System.Collections.Generic;
using System.Windows.Forms;
using opt.DataModel;
using opt.UI.Helpers;
using opt.UI.Helpers.DataModel;

namespace opt.UI.Forms
{
    internal partial class Form30 : Form
    {
        private Form _prevForm;
        private Form _nextForm;

        private Model _model;
        public Model OptModel
        {
            get { return this._model; }
            set { this._model = value; }
        }

        public Form30()
        {
            InitializeComponent();
        }

        public Form30(
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
        /// значениями оптимизируемых параметров
        /// </summary>
        private void FillDataGrid()
        {
            this.dgvParameterValues.SuspendLayout();

            // Очистка
            this.dgvParameterValues.Columns.Clear();
            this.dgvParameterValues.Rows.Clear();

            // Создадим колонки
            DataGridViewColumn indexCol = new DataGridViewColumn();
            indexCol.CellTemplate = new DataGridViewTextBoxCell();
            indexCol.SortMode = DataGridViewColumnSortMode.NotSortable;
            indexCol.Visible = false;
            this.dgvParameterValues.Columns.Add(indexCol);
            foreach (KeyValuePair<TId, Parameter> kvp in this._model.Parameters)
            {
                DataGridViewColumn paramCol = new DataGridViewColumn();
                paramCol.CellTemplate = new DataGridViewTextBoxCell();
                paramCol.CellTemplate.ValueType = typeof(double);
                paramCol.SortMode = DataGridViewColumnSortMode.NotSortable;
                paramCol.HeaderText = kvp.Value.Name;
                paramCol.Name = kvp.Key.ToString();
                paramCol.HeaderCell.ToolTipText = kvp.Value.GetDescription();
                this.dgvParameterValues.Columns.Add(paramCol);
            }

            // Создадим рядки и заполним их инфой
            foreach (KeyValuePair<TId, Experiment> kvp in this._model.Experiments)
            {
                // Добавим рядок
                int rowInd = this.dgvParameterValues.Rows.Add();
                // Запишем в невидимую колонку индекс эксперимента
                this.dgvParameterValues[0, rowInd].Value = kvp.Key;
                // Запишем в хедер рядка номер эксперимента
                this.dgvParameterValues.Rows[rowInd].HeaderCell.Value =
                        kvp.Value.Number.ToString();
                // Запишем в ячейки значения оптимизируемых параметров
                foreach (KeyValuePair<TId, double> pvs in kvp.Value.ParameterValues)
                {
                    int colInd = 0;
                    try
                    {
                        colInd = this.dgvParameterValues.Columns[pvs.Key.ToString()].Index;
                    }
                    catch (Exception ex)
                    {
                        MessageBoxHelper.ShowError(ex.Message);
                        return;
                    }
                    this.dgvParameterValues[colInd, rowInd].Value =
                        pvs.Value.ToString(SettingsManager.Instance.DoubleStringFormat);
                }
            }

            this.dgvParameterValues.ResumeLayout();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form30_FormClosing(object sender, FormClosingEventArgs e)
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

        private void dgvParameterValues_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            TId expIndex = (TId)this.dgvParameterValues[0, e.RowIndex].Value;
            TId parIndex = TId.Parse(this.dgvParameterValues.Columns[e.ColumnIndex].Name);

            // Проверим на пустую строку
            if (string.IsNullOrEmpty(e.FormattedValue.ToString()))
            {
                MessageBoxHelper.ShowExclamation(
                    "Значение параметра '" + this._model.Parameters[parIndex].Name +
                    "' для эксперимента №" + this._model.Experiments[expIndex].Number.ToString() +
                    " должно быть задано");
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
                MessageBoxHelper.ShowError(
                    "Невозможно преобразовать введенное для эксперимента №" +
                    this._model.Experiments[expIndex].Number.ToString() +
                    " значение параметра '" + this._model.Parameters[parIndex].Name +
                    "' в число");
                e.Cancel = true;
                return;
            }

            // Это число и все ок?
            if (newValue != Double.NaN)
            {
                // Вписывается ли оно в допустимый диапазон
                if (newValue > this._model.Parameters[parIndex].MaxValue ||
                    newValue < this._model.Parameters[parIndex].MinValue)
                {
                    MessageBoxHelper.ShowError(
                        "Введенное для эксперимента №" +
                        this._model.Experiments[expIndex].Number.ToString() +
                        " значение параметра '" + this._model.Parameters[parIndex].Name +
                        "' выходит за границы допустимого диапазона\n" +
                        "Минимально возможное значение параметра '" +
                        this._model.Parameters[parIndex].Name +
                        "': " + this._model.Parameters[parIndex].MinValue.ToString(SettingsManager.Instance.DoubleStringFormat) +
                        "\nМаксимально возможное значение параметра '" +
                        this._model.Parameters[parIndex].Name +
                        "': " + this._model.Parameters[parIndex].MaxValue.ToString(SettingsManager.Instance.DoubleStringFormat));
                    e.Cancel = true;
                    return;
                }

                // Наконец-то сохраним введенное значение!
                if (this._model.Experiments[expIndex].ParameterValues.ContainsKey(parIndex))
                {
                    this._model.Experiments[expIndex].ParameterValues[parIndex] = newValue;
                }
                else
                {
                    this._model.Experiments[expIndex].ParameterValues.Add(
                        parIndex,
                        newValue);
                }
            }
        }

        private bool CheckParameters()
        {
            foreach (KeyValuePair<TId, Parameter> param in this._model.Parameters)
            {
                foreach (KeyValuePair<TId, Experiment> exp in this._model.Experiments)
                {
                    // Если в одном из экспериментов не задано значение данного параметра
                    if (!exp.Value.ParameterValues.ContainsKey(param.Key))
                    {
                        // Тест провален
                        MessageBoxHelper.ShowError(
                            "Для эксперимента №" + exp.Value.Number.ToString() +
                            " не задано значение параметра '" + param.Value.Name + 
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
            bool valuesOk = this.CheckParameters();

            if (valuesOk)
            {
                this._nextForm = new Form35(this, this._model);
                this._nextForm.Show();
                this.Hide();
            }
        }

    }
}