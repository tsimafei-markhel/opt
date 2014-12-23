using System;
using System.Collections.Generic;
using System.Windows.Forms;
using opt.DataModel;
using opt.UI.Helpers;
using opt.UI.Helpers.DataModel;

namespace opt.UI.Forms
{
    internal partial class Form15 : Form
    {
        private Form _prevForm;
        private Form _nextForm;

        private Model _model;
        public Model OptModel
        {
            get { return this._model; }
            set { this._model = value; }
        }

        public Form15()
        {
            InitializeComponent();
        }

        public Form15(
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

#if DUMMY
            // Уберем колонку "Выражение" подальше от дурачков
            this.dgvCriteria.Columns[4].Visible = false;
#endif

            this._prevForm = prevForm;
            this._model = model;

            this.UpdateCriteriaDataGrid();

            // Запустим сборщик мусора, чтобы убить
            // предыдущие ветки
            System.GC.Collect();
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

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form15_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// Метод для заполнения таблицы данными о критериях
        /// </summary>
        private void UpdateCriteriaDataGrid()
        {
            this.dgvCriteria.SuspendLayout();

            this.dgvCriteria.Rows.Clear();
            foreach (KeyValuePair<TId, Criterion> criterion in this._model.Criteria)
            {
                int ind = this.dgvCriteria.Rows.Add();
                this.dgvCriteria[0, ind].Value = criterion.Value.Id;
                this.dgvCriteria[1, ind].Value = criterion.Value.Name;
                this.dgvCriteria[2, ind].Value = criterion.Value.VariableIdentifier;
                this.dgvCriteria[3, ind].Value = CriterionTypeManager.GetCriterionTypeName(criterion.Value.Type);
#if !DUMMY
                // НЕ РАБОТАЕТ В РЕЖИМЕ ДЛЯ ДУРАЧКОВ
                this.dgvCriteria[4, ind].Value = criterion.Value.Expression;
#endif
            }

            this.dgvCriteria.ResumeLayout();
        }

        /// <summary>
        /// Метод для выделения определенной строки в таблице
        /// </summary>
        /// <param name="rowIndex">Индекс строки, которую нужно выделить</param>
        private void SelectDataGridRow(int rowIndex)
        {
            foreach (DataGridViewRow row in this.dgvCriteria.Rows)
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

        private void btnAddCriteria_Click(object sender, EventArgs e)
        {
            CriterionForm addForm = new CriterionForm(this._model);
            if (addForm.ShowDialog() == DialogResult.OK)
            {
                this.UpdateCriteriaDataGrid();
            }
            addForm.Dispose();
        }

        private void btnEditCriteria_Click(object sender, EventArgs e)
        {
            if (this.dgvCriteria.SelectedRows.Count == 0 ||
                this.dgvCriteria.SelectedRows.Count > 1)
            {
                MessageBoxHelper.ShowExclamation("Выберите в списке только один критерий оптимальности для редактирования");
                return;
            }

            TId index = (TId)this.dgvCriteria.SelectedRows[0].Cells[0].Value;
            CriterionForm editForm = new CriterionForm(this._model, index);
            if (editForm.ShowDialog() == DialogResult.OK)
            {
                this.UpdateCriteriaDataGrid();
                SelectDataGridRow((index));
            }
            editForm.Dispose();
        }

        private void btnDeleteCriteria_Click(object sender, EventArgs e)
        {
            if (this.dgvCriteria.SelectedRows.Count == 0)
            {
                MessageBoxHelper.ShowExclamation("Выберите в списке хотя бы один критерий оптимальности для удаления");
                return;
            }

            DialogResult result = MessageBox.Show("Удалить выбранные критерии оптимальности?", Program.ApplicationSettings.ApplicationName, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                foreach (DataGridViewRow selRow in this.dgvCriteria.SelectedRows)
                {
                    TId critId = (TId)selRow.Cells[0].Value;
                    this._model.Criteria.Remove(critId);
                }

                this.UpdateCriteriaDataGrid();
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (this._model.Criteria.Count < 1)
            {
                MessageBoxHelper.ShowExclamation("Задайте хотя бы один критерий оптимальности");
                return;
            }

            this._nextForm = new Form20(this, this._model);
            this._nextForm.Show();
            this.Hide();
        }
    }
}