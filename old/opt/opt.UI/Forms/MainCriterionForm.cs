using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using opt.DataModel;
using opt.Solvers.MainCriterion;
using opt.UI.Helpers;
using opt.UI.Helpers.DataModel;

namespace opt.UI.Forms
{
    public partial class MainCriterionForm : Form
    {
        private Form _prevForm;
        private Form _nextForm;

        private Model _model;
        public Model OptModel
        {
            get { return this._model; }
            set { this._model = value; }
        }

        private CriterialConstraints _criterialConstraints;
        private TId _mainCriterionId;

        public MainCriterionForm()
        {
            InitializeComponent();
        }

        public MainCriterionForm(
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
            this._criterialConstraints = new CriterialConstraints();

            // Удалим неактивные на данный момент 
            // эксперименты (чтоб не мешались потом)
            this._model.Experiments.RemoveInactiveExperiments();
            // Заполним выпадающий список критериями оптимальности
            this.FillCriteriaComboBox();
            // Обновим таблицу с ограничениями
            this.FillConstraintsDataGrid();

            // Запустим сборщик мусора, чтобы убить
            // предыдущие ветки
            System.GC.Collect();
        }

        private void FillConstraintsDataGrid()
        {
            this.dgvData.SuspendLayout();

            this.dgvData.Rows.Clear();
            foreach (CriterialConstraint constraint in this._criterialConstraints)
            {
                int ind = this.dgvData.Rows.Add();
                this.dgvData[0, ind].Value = constraint.Id;
                this.dgvData[1, ind].Value = this._model.Criteria[constraint.CriterionId].Name;
                this.dgvData[2, ind].Value = 
                    this._model.Criteria[constraint.CriterionId].VariableIdentifier;
                this.dgvData[3, ind].Value = RelationManager.GetRelationName(constraint.Relation);
                this.dgvData[4, ind].Value = constraint.Value.ToString(SettingsManager.Instance.DoubleStringFormat);
            }

            this.dgvData.ResumeLayout();
        }

        private void FillCriteriaComboBox()
        {
            this.cmbMainCriterion.Items.Clear();

            foreach (Criterion crit in this._model.Criteria.Values)
            {
                CriterionComboBoxItem item = 
                    new CriterionComboBoxItem(crit.Id, crit.Name);
                this.cmbMainCriterion.Items.Add(item);
            }

            this.cmbMainCriterion.SelectedIndex = 0;
            this._mainCriterionId = 
                ((CriterionComboBoxItem)this.cmbMainCriterion.SelectedItem).criterionId;
        }

        private void MainCriterionForm_FormClosing(object sender, FormClosingEventArgs e)
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
            this._nextForm = new MainCriterionResultsForm(
                this, 
                this._model, 
                this._criterialConstraints, 
                this._mainCriterionId);
            this._nextForm.Show();
            this.Hide();
        }

        private void cmbMainCriterion_SelectedIndexChanged(object sender, EventArgs e)
        {
            TId newSelectionId = 
                ((CriterionComboBoxItem)this.cmbMainCriterion.SelectedItem).criterionId;
            
            // Посмотрим, если ли в списке ограничения на выбранный критерий
            bool constraintsExist = false;
            foreach(CriterialConstraint constr in this._criterialConstraints)
            {
                if (constr.CriterionId == newSelectionId)
                {
                    constraintsExist = true;
                    break;
                }
            }

            // Если в списке есть ограничения на выбранный критерий, 
            // скажем пользователю, что они будут удалены и хочет ли 
            // он сменить главный критерий
            if (constraintsExist)
            {
                string message = "В списке ограничений имеются ограничения на только что " + 
                    "выбранный в выпадающем списке критерий\n" + 
                    "В случае выбора данного критерия в качестве главного эти ограничения " +
                    "будут удалены\n" +
                    "Установить выбранный критерий в качестве главного?";
                DialogResult result = MessageBox.Show(
                    message, 
                    Program.ApplicationSettings.ApplicationName,
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    this._mainCriterionId = newSelectionId;
                    this.UpdateCriterialConstraints();
                }
                else
                {
                    foreach (object item in this.cmbMainCriterion.Items)
                    {
                        TId itemCritId = ((CriterionComboBoxItem)item).criterionId;
                        if (itemCritId == this._mainCriterionId)
                        {
                            this.cmbMainCriterion.SelectedItem = item;
                            break;
                        }
                    }
                }
            }
            else
            {
                // Если нет, то просто сменим критерий
                this._mainCriterionId = newSelectionId;
            }
        }

        /// <summary>
        /// Метод для удаления из списка критериальных ограничений 
        /// ограничений, относящихся к выбранному в качестве главного 
        /// критерию
        /// </summary>
        private void UpdateCriterialConstraints()
        {
            // Обнаружим, какие именно ограничения следует удалить
            // (те, у которых CriterionId совпадает с ID текущего 
            // главного критерия)
            List<TId> constraintsToRemove = new List<TId>();
            foreach (CriterialConstraint constr in this._criterialConstraints)
            {
                if (constr.CriterionId == this._mainCriterionId)
                {
                    constraintsToRemove.Add(constr.Id);
                }
            }

            // Удалим ограничения согласно списку
            foreach (TId constrId in constraintsToRemove)
            {
                if (this._criterialConstraints.ContainsConstraint(constrId))
                {
                    this._criterialConstraints.Remove(constrId);
                }
            }

            // Обновим таблицу
            this.FillConstraintsDataGrid();
        }

        private void btnAddCriterialConstraint_Click(object sender, EventArgs e)
        {
            CriterialConstraintForm addForm = new CriterialConstraintForm(
                this._model.Criteria, this._mainCriterionId);
            if (addForm.ShowDialog() == DialogResult.OK)
            {
                this._criterialConstraints.Add(
                    (CriterialConstraint)addForm.Constraint.Clone());
                this.FillConstraintsDataGrid();
            }
            addForm.Dispose();
        }

        private void btnEditCriterialConstraint_Click(object sender, EventArgs e)
        {
            if (this.dgvData.SelectedRows.Count == 0 ||
                this.dgvData.SelectedRows.Count > 1)
            {
                MessageBoxHelper.ShowExclamation("Выберите в списке только одно ограничение для редактирования");
                return;
            }

            TId index = (TId)this.dgvData.SelectedRows[0].Cells[0].Value;
            CriterialConstraintForm editForm = new CriterialConstraintForm(
                this._model.Criteria, this._mainCriterionId, this._criterialConstraints[index]);
            if (editForm.ShowDialog() == DialogResult.OK)
            {
                this.FillConstraintsDataGrid();
            }
            editForm.Dispose();
        }

        private void btnDeleteCriterialConstraint_Click(object sender, EventArgs e)
        {
            if (this.dgvData.SelectedRows.Count == 0)
            {
                MessageBoxHelper.ShowExclamation("Выберите в списке хотя бы одно ограничение для удаления");
                return;
            }

            DialogResult result = MessageBox.Show("Удалить выбранные ограничения?", Program.ApplicationSettings.ApplicationName, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                foreach (DataGridViewRow selRow in this.dgvData.SelectedRows)
                {
                    TId constrId = (TId)selRow.Cells[0].Value;
                    this._criterialConstraints.Remove(constrId);
                }

                this.FillConstraintsDataGrid();
            }
        }

    }

    internal class CriterionComboBoxItem
    {
        public TId criterionId;
        public string criterionName;

        public CriterionComboBoxItem(
            TId critId,
            string critName)
        {
            this.criterionId = critId;
            this.criterionName = critName;
        }

        public override string ToString()
        {
            return this.criterionName;
        }
    }
}