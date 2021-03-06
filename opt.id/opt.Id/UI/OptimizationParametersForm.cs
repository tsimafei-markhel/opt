﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;
using opt.DataModel;
using opt.Helpers;

namespace opt.UI
{
    public partial class OptimizationParametersForm : ModelDefinitionForm
    {
        public OptimizationParametersForm()
        {
            throw new InvalidOperationException("Parameterless constructor called");
        }

        public OptimizationParametersForm(OptIdFormBase previous) : base(previous)
        {
            InitializeComponent();
            AdjustFormParameters(previous);
            AddAdditionColumnsToDataGrid();
            UpdateParametersDataGrid(ModelStorage.Instance.Model.OptimizationParameters);
        }

        protected override void btnNext_Click(object sender, EventArgs e)
        {
            if (nextForm == null)
            {
                nextForm = new IdentificationParametersForm(this);
            }

            base.btnNext_Click(sender, e);
        }

        protected override void buttonAdd_Click(object sender, EventArgs e)
        {
            EditParameterForm addForm = new EditParameterForm(EditParameterForm.ParameterType.Optimization);
            AddEntity(addForm, ModelStorage.Instance.Model.OptimizationParameters);
        }

        protected override void buttonEdit_Click(object sender, EventArgs e)
        {
            TId index = GetSelectedEntityId();
            if (index != -1)
            {
                EditParameterForm editForm = new EditParameterForm(EditParameterForm.ParameterType.Optimization, ModelStorage.Instance.Model.OptimizationParameters[index]);
                EditEntity(editForm, ModelStorage.Instance.Model.OptimizationParameters, index);
            }
        }

        protected override void buttonDelete_Click(object sender, EventArgs e)
        {
            DeleteEntities(ModelStorage.Instance.Model.OptimizationParameters);
        }

        protected override void UpdateParametersDataGrid<T>(NamedModelEntityCollection<T> entities)
        {
            base.UpdateParametersDataGrid<T>(entities);

            this.dgvModelEntities.SuspendLayout();
            int ind = 0;
            foreach (KeyValuePair<TId, Parameter> parameter in ModelStorage.Instance.Model.OptimizationParameters)
            {
                this.dgvModelEntities[3, ind].Value = parameter.Value.MinValue.ToString(SettingsManager.Instance.DoubleStringFormat);
                this.dgvModelEntities[4, ind].Value = parameter.Value.MaxValue.ToString(SettingsManager.Instance.DoubleStringFormat);
                ind++;
            }

            this.dgvModelEntities.ResumeLayout();
        }

        private void AddAdditionColumnsToDataGrid()
        {
            DataGridViewTextBoxColumn colMinValue = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn colMaxValue = new DataGridViewTextBoxColumn();

            colParameterName.HeaderText = "Название параметра";
            colParameterIdentifier.HeaderText = "Идентификатор переменной параметра";
            // 
            // colMinValue
            // 
            colMinValue.HeaderText = "Минимальное значение";
            colMinValue.MinimumWidth = 100;
            colMinValue.Name = "colMinValue";
            colMinValue.ReadOnly = true;
            colMinValue.Width = 150;
            // 
            // colMaxValue
            // 
            colMaxValue.HeaderText = "Максимальное значение";
            colMaxValue.MinimumWidth = 100;
            colMaxValue.Name = "colMaxValue";
            colMaxValue.ReadOnly = true;
            colMaxValue.Width = 150;

            dgvModelEntities.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            colMinValue,
            colMaxValue});
        }
    }
}