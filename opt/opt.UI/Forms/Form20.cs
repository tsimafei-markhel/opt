using System;
using System.Collections.Generic;
using System.Windows.Forms;
using opt.DataModel;
using opt.UI.Helpers;
using opt.UI.Helpers.DataModel;

namespace opt.UI.Forms
{
    internal partial class Form20 : Form
    {
        private Form _prevForm;
        private Form _nextForm;

        private Model _model;
        public Model OptModel
        {
            get { return this._model; }
            set { this._model = value; }
        }

        public Form20()
        {
            InitializeComponent();
        }

        public Form20(
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
            // Спрячем колонку "Выражение" от дурачков
            this.dgvConstraints.Columns[5].Visible = false;
#endif

            this._prevForm = prevForm;
            this._model = model;

            this.UpdateConstraintsDataGrid();

            // Запустим сборщик мусора, чтобы убить
            // предыдущие ветки
            System.GC.Collect();
        }

        /// <summary>
        /// Метод для заполнения таблицы данными об ограничениях
        /// </summary>
        private void UpdateConstraintsDataGrid()
        {
            this.dgvConstraints.SuspendLayout();

            this.dgvConstraints.Rows.Clear();
            foreach (KeyValuePair<TId, Constraint> constraint in this._model.FunctionalConstraints)
            {
                int ind = this.dgvConstraints.Rows.Add();
                this.dgvConstraints[0, ind].Value = constraint.Value.Id;
                this.dgvConstraints[1, ind].Value = constraint.Value.Name;
                this.dgvConstraints[2, ind].Value = constraint.Value.VariableIdentifier;
                this.dgvConstraints[3, ind].Value = RelationManager.GetRelationName(constraint.Value.ConstraintRelation);
                this.dgvConstraints[4, ind].Value = constraint.Value.Value.ToString(SettingsManager.Instance.DoubleStringFormat);
#if !DUMMY
                // НЕ РАБОТАЕТ В РЕЖИМЕ ДЛЯ ДУРАЧКОВ
                this.dgvConstraints[5, ind].Value = constraint.Value.Expression;
#endif
            }

            this.dgvConstraints.ResumeLayout();
        }

        /// <summary>
        /// Метод для выделения определенной строки в таблице
        /// </summary>
        /// <param name="rowIndex">Индекс строки, которую нужно выделить</param>
        private void SelectDataGridRow(int rowIndex)
        {
            foreach (DataGridViewRow row in this.dgvConstraints.Rows)
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

        private void Form20_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnAddConstraint_Click(object sender, EventArgs e)
        {
            ConstraintForm addForm = new ConstraintForm(this._model);
            if (addForm.ShowDialog() == DialogResult.OK)
            {
                this.UpdateConstraintsDataGrid();
            }

            addForm.Dispose();
        }

        private void btnEditCriteriaConstraint_Click(object sender, EventArgs e)
        {
            if (this.dgvConstraints.SelectedRows.Count == 0 ||
                this.dgvConstraints.SelectedRows.Count > 1)
            {
                MessageBoxHelper.ShowExclamation("Выберите в списке только одно функциональное ограничение для редактирования");
                return;
            }

            TId index = (TId)this.dgvConstraints.SelectedRows[0].Cells[0].Value;
            ConstraintForm editForm = new ConstraintForm(this._model, index);
            if (editForm.ShowDialog() == DialogResult.OK)
            {
                this.UpdateConstraintsDataGrid();
                SelectDataGridRow((index));
            }
            editForm.Dispose();
        }

        private void btnDeleteConstraint_Click(object sender, EventArgs e)
        {
            if (this.dgvConstraints.SelectedRows.Count == 0)
            {
                MessageBoxHelper.ShowExclamation("Выберите в списке хотя бы одно функциональное ограничение для удаления");
                return;
            }

            DialogResult result = MessageBox.Show("Удалить выбранные функциональные ограничения?", Program.ApplicationSettings.ApplicationName, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                foreach (DataGridViewRow selRow in this.dgvConstraints.SelectedRows)
                {
                    TId constrId = (TId)selRow.Cells[0].Value;
                    this._model.FunctionalConstraints.Remove(constrId);
                }

                this.UpdateConstraintsDataGrid();
            }
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
            this._nextForm = new Form25(this, this._model);
            this._nextForm.Show();
            this.Hide();
        }
    }
}