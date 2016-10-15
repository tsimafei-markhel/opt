using System;
using System.Collections.Generic;
using System.Windows.Forms;
using opt.DataModel;
using opt.Helpers;
using opt.Id;

namespace opt.UI
{
    public partial class ConstraintForm : ModelDefinitionForm
    {
        public ConstraintForm()
        {
            throw new InvalidOperationException("Parameterless constructor called");
        }

        public ConstraintForm(OptIdFormBase previous)
            : base(previous)
        {
            InitializeComponent();
            AdjustFormParameters(previous);
            AddAdditionColumnsToDataGrid();
            UpdateParametersDataGrid(ModelStorage.Instance.Model.FunctionalConstraints);
        }

        protected override void btnNext_Click(object sender, EventArgs e)
        {
            if (nextForm == null)
            {
                nextForm = new RealExperimentResultsForm(this);
            }

            base.btnNext_Click(sender, e);
        }

        protected override void buttonAdd_Click(object sender, EventArgs e)
        {
            EditConstraintForm addForm = new EditConstraintForm();
            AddEntity(addForm, ModelStorage.Instance.Model.FunctionalConstraints);
        }

        protected override void buttonEdit_Click(object sender, EventArgs e)
        {
            TId index = GetSelectedEntityId();
            if (index != -1)
            {
                EditConstraintForm editForm = new EditConstraintForm(ModelStorage.Instance.Model.FunctionalConstraints[index]);
                EditEntity(editForm, ModelStorage.Instance.Model.FunctionalConstraints, index);
            }
        }

        protected override void buttonDelete_Click(object sender, EventArgs e)
        {
            DeleteEntities(ModelStorage.Instance.Model.FunctionalConstraints);
        }

        protected override void UpdateParametersDataGrid<T>(NamedModelEntityCollection<T> entities)
        {
            base.UpdateParametersDataGrid<T>(entities);

            this.dgvModelEntities.SuspendLayout();
            int ind = 0;
            foreach (KeyValuePair<TId, opt.DataModel.Constraint> constraint in 
                ModelStorage.Instance.Model.FunctionalConstraints)
            {
                this.dgvModelEntities[3, ind].Value = RelationManager.
                    GetRelationName(constraint.Value.ConstraintRelation);
                this.dgvModelEntities[4, ind].Value = constraint.Value.Value;
                ind++;
            }

            this.dgvModelEntities.ResumeLayout();
        }

        private void AddAdditionColumnsToDataGrid()
        {
            DataGridViewTextBoxColumn colSing = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn colValue = new DataGridViewTextBoxColumn();

            colParameterName.HeaderText = "Название ограничения";
            colParameterIdentifier.HeaderText = "Идентификатор переменной ограничения";
            // 
            // colSing
            // 
            colSing.HeaderText = "Знак";
            colSing.MinimumWidth = 40;
            colSing.Name = "colSing";
            colSing.ReadOnly = true;
            colSing.Width = 40;
            // 
            // colValue
            // 
            colValue.HeaderText = "Значение";
            colValue.MinimumWidth = 60;
            colValue.Name = "colValue";
            colValue.ReadOnly = true;
            colValue.Width = 60;

            dgvModelEntities.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            colSing, colValue});
        }
    }
}