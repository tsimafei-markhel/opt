using System;
using System.Collections.Generic;
using System.Windows.Forms;
using opt.DataModel;
using opt.Helpers;

namespace opt.UI
{
    public partial class AdequacyCriterionForm : ModelDefinitionForm
    {
        public AdequacyCriterionForm()
        {
            throw new InvalidOperationException("Parameterless constructor called");
        }

        public AdequacyCriterionForm(OptIdFormBase previous)
            : base(previous)
        {
            InitializeComponent();
            AdjustFormParameters(previous);
            AddAdditionColumnsToDataGrid();
            UpdateParametersDataGrid(ModelStorage.Instance.Model.Criteria);
        }

        protected override void btnNext_Click(object sender, EventArgs e)
        {
            if (nextForm == null)
            {
                nextForm = new ConstraintForm(this);
            }

            base.btnNext_Click(sender, e);
        }

        protected override void buttonAdd_Click(object sender, EventArgs e)
        {
            EditAdequacyCriterionForm addForm = new EditAdequacyCriterionForm();
            AddEntity(addForm, ModelStorage.Instance.Model.Criteria);
        }

        protected override void buttonEdit_Click(object sender, EventArgs e)
        {
            TId criterionId = GetSelectedEntityId();
            if (criterionId != -1)
            {
                EditAdequacyCriterionForm editForm = new EditAdequacyCriterionForm(ModelStorage.Instance.Model.Criteria[criterionId]);
                EditEntity(editForm, ModelStorage.Instance.Model.Criteria, criterionId);
            }
        }

        protected override void buttonDelete_Click(object sender, EventArgs e)
        {
            DeleteEntities(ModelStorage.Instance.Model.Criteria);
        }

        protected override void UpdateParametersDataGrid<T>(NamedModelEntityCollection<T> entities)
        {
            base.UpdateParametersDataGrid<T>(entities);

            this.dgvModelEntities.SuspendLayout();
            int ind = 0;
            foreach (KeyValuePair<TId, AdequacyCriterion> criterion in ModelStorage.Instance.Model.Criteria)
            {
                this.dgvModelEntities[3, ind].Value = AdequacyCriterionTypeManager.GetFriendlyName(criterion.Value.AdequacyType);
                ind++;
            }

            this.dgvModelEntities.ResumeLayout();
        }

        private void AddAdditionColumnsToDataGrid()
        {
            DataGridViewTextBoxColumn colCriterionFunction = new DataGridViewTextBoxColumn();

            colParameterName.HeaderText = "Название критерия";
            colParameterIdentifier.HeaderText = "Идентификатор переменной критерия";
            // 
            // colCriterionFunction
            // 
            colCriterionFunction.HeaderText = "Функция критерия адекватности";
            colCriterionFunction.MinimumWidth = 100;
            colCriterionFunction.Name = "colCriterionFunction";
            colCriterionFunction.ReadOnly = true;
            colCriterionFunction.Width = 250;

            dgvModelEntities.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            colCriterionFunction});
        }
    }
}