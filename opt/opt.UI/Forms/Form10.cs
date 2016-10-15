using System;
using System.Collections.Generic;
using System.Windows.Forms;
using opt.DataModel;
using opt.UI.Helpers;

namespace opt.UI.Forms
{
    internal partial class Form10 : Form
    {
        private Form _prevForm;
        private Form _nextForm;

        private Model _model;
        public Model OptModel
        {
            get { return this._model; }
            set { this._model = value; }
        }

        public Form10()
        {
            InitializeComponent();
        }

        public Form10(
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

            this.UpdateParametersDataGrid();

            // Запустим сборщик мусора, чтобы убить
            // предыдущие ветки
            System.GC.Collect();
        }

        private void Form10_FormClosing(object sender, FormClosingEventArgs e)
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

        /// <summary>
        /// Метод для заполнения таблицы данными о параметрах
        /// </summary>
        private void UpdateParametersDataGrid()
        {
            this.dgvParameters.SuspendLayout();

            this.dgvParameters.Rows.Clear();
            foreach (KeyValuePair<TId, Parameter> parameter in this._model.Parameters)
            {
                int ind = this.dgvParameters.Rows.Add();

                this.dgvParameters[0, ind].Value = parameter.Value.Id;
                this.dgvParameters[1, ind].Value = parameter.Value.Name;
                this.dgvParameters[2, ind].Value = parameter.Value.VariableIdentifier;
                this.dgvParameters[3, ind].Value = parameter.Value.MinValue.ToString(SettingsManager.Instance.DoubleStringFormat);
                this.dgvParameters[4, ind].Value = parameter.Value.MaxValue.ToString(SettingsManager.Instance.DoubleStringFormat);
            }

            this.dgvParameters.ResumeLayout();
        }

        /// <summary>
        /// Метод для выделения определенной строки в таблице
        /// </summary>
        /// <param name="rowIndex">Индекс строки, которую нужно выделить</param>
        private void SelectDataGridRow(int rowIndex)
        {
            foreach (DataGridViewRow row in this.dgvParameters.Rows)
            {
                if (row.Index == rowIndex)
                {
                    row.Selected = true;
                }
                else
                {
                    row.Selected = false;
                }
            }
        }

        private void btnDeleteParameter_Click(object sender, EventArgs e)
        {
            if (this.dgvParameters.SelectedRows.Count == 0)
            {
                MessageBoxHelper.ShowExclamation("Выберите в списке хотя бы один оптимизируемый параметр для удаления");
                return;
            }

            DialogResult result = MessageBox.Show("Удалить выбранные оптимизируемые параметры?", Program.ApplicationSettings.ApplicationName, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                foreach (DataGridViewRow selRow in this.dgvParameters.SelectedRows)
                {
                    TId paramId = (TId)selRow.Cells[0].Value;
                    this._model.Parameters.Remove(paramId);
                }

                this.UpdateParametersDataGrid();
            }
        }

        private void btnAddParameter_Click(object sender, EventArgs e)
        {
            ParameterForm addForm = new ParameterForm(this._model);
            if (addForm.ShowDialog() == DialogResult.OK)
            {
                this.UpdateParametersDataGrid();
            }
            addForm.Dispose();
        }

        private void btnEditParameter_Click(object sender, EventArgs e)
        {
            if (this.dgvParameters.SelectedRows.Count == 0 ||
                this.dgvParameters.SelectedRows.Count > 1)
            {
                MessageBoxHelper.ShowExclamation("Выберите в списке только один оптимизируемый параметр для редактирования");
                return;
            }

            TId index = (TId)this.dgvParameters.SelectedRows[0].Cells[0].Value;
            ParameterForm editForm = new ParameterForm(this._model, index);
            if (editForm.ShowDialog() == DialogResult.OK)
            {
                this.UpdateParametersDataGrid();
                SelectDataGridRow((index));
            }
            editForm.Dispose();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (this._model.Parameters.Count < 1)
            {
                MessageBoxHelper.ShowExclamation("Задайте хотя бы один оптимизируемый параметр");
                return;
            }

            this._nextForm = new Form15(this, this._model);
            this._nextForm.Show();
            this.Hide();
        }
    }
}