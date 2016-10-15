using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using opt.DataModel;
using opt.UI.Helpers;
using opt.UI.Helpers.DataModel;

namespace opt.UI.Forms
{
    internal partial class ChangeConstraintsForm : Form
    {
        private Model _model;
        public Model OptModel
        {
            get { return this._model; }
            set { this._model = value; }
        }

        public ChangeConstraintsForm()
        {
            InitializeComponent();
        }

        public ChangeConstraintsForm(
            Model model)
        {
            InitializeComponent();

#if DUMMY
            // Спрячем колонку "Выражение" от дурачков
            this.dgvConstraints.Columns[5].Visible = false;
#endif

            this._model = model;

            this.FillSignsCombo();
            this.UpdateConstraintsDataGrid();
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
                this.dgvConstraints[0, ind].ReadOnly = true;

                this.dgvConstraints[1, ind].Value = constraint.Value.Name;
                this.dgvConstraints[1, ind].ReadOnly = true;
                this.dgvConstraints[1, ind].Style.BackColor = Color.LightGray;

                this.dgvConstraints[2, ind].Value = constraint.Value.VariableIdentifier;
                this.dgvConstraints[2, ind].ReadOnly = true;
                this.dgvConstraints[2, ind].Style.BackColor = Color.LightGray;

                this.dgvConstraints[3, ind].Value = RelationManager.GetRelationName(constraint.Value.ConstraintRelation);

                this.dgvConstraints[4, ind].Value = constraint.Value.Value.ToString(SettingsManager.Instance.DoubleStringFormat);

#if !DUMMY
                // Связываемся с колонкой "Выражение" только в том случае, если
                // это режим не для дурачков
                this.dgvConstraints[5, ind].Value = constraint.Value.Expression;
                this.dgvConstraints[5, ind].ReadOnly = true;
                this.dgvConstraints[5, ind].Style.BackColor = Color.LightGray;
#endif
            }

            this.dgvConstraints.ResumeLayout();
        }

        private void FillSignsCombo()
        {
            DataGridViewComboBoxCell combo =
                (DataGridViewComboBoxCell)this.dgvConstraints.Columns[3].CellTemplate;
            combo.Items.AddRange(RelationManager.GetRelationNames().ToArray());
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnDeleteConstraint_Click(object sender, EventArgs e)
        {
            if (this.dgvConstraints.SelectedRows.Count == 0)
            {
                MessageBoxHelper.ShowError("Выберите в списке хотя бы одно функциональное ограничение для удаления");
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

        private void btnOK_Click(object sender, EventArgs e)
        {
            bool updateOk = true;
            // По очереди считаем все ячейки, которые доступны для редактирования
            foreach (DataGridViewRow row in this.dgvConstraints.Rows)
            {
                TId constrId = (TId)row.Cells[0].Value;
                Relation constrSign = RelationManager.ParseName((string)row.Cells[3].Value);
                double constrValue = double.NaN;
                try
                {
                    constrValue = Convert.ToDouble(row.Cells[4].Value);
                }
                catch (Exception ex)
                {
                    string message = "Невозможно преобразовать введенное для ограничения '" +
                        this._model.FunctionalConstraints[constrId].Name + 
                        "' значение в число\nОригинальное сообщение: " + ex.Message;
                    MessageBoxHelper.ShowExclamation(message);
                    updateOk = false;
                    return;
                }

                // Все данные в порядке, можно обновить
                this._model.FunctionalConstraints[constrId].ConstraintRelation = constrSign;
                this._model.FunctionalConstraints[constrId].Value = constrValue;
            }

            if (updateOk)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                this.UpdateConstraintsDataGrid();
            }
        }
    }
}