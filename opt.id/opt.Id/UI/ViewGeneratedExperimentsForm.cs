using System;
using System.Windows.Forms;
using opt.DataModel;
using opt.Helpers;
using opt.Xml;

namespace opt.UI
{
    //TODO: editing ability
    //TODO: save
    public partial class ViewGeneratedExperimentsForm : OptIdFormBase
    {
        public ViewGeneratedExperimentsForm()
        {
            InitializeComponent();
        }
        public ViewGeneratedExperimentsForm(OptIdFormBase previous)
            : base(previous)
        {
            InitializeComponent();
            AdjustFormParameters(previous);
            //inserting columns from model
            InsertIndentificationParamterColumns();
            //inserting values
            FillDataGrid();
        }

        protected override void btnNext_Click(object sender, EventArgs e)
        {
            if (nextForm == null)
            {
                nextForm = new RunCalculationForm(this);
            }

            base.btnNext_Click(sender, e);
        }

        protected override void btnPrevious_Click(object sender, EventArgs e)
        {
            //TODO:delete generated values
            base.btnPrevious_Click(sender, e);
        }

        private void InsertIndentificationParamterColumns()
        {
            foreach (Parameter param in ModelStorage.Instance.Model.IdentificationParameters.Values)
            {
                DataGridViewTextBoxColumn column = new DataGridViewTextBoxColumn();

                column.Name = "colIdentificationParam" + param.Id;
                column.HeaderText = param.Name;
                column.ReadOnly = true;

                dgvGeneratedExp.Columns.Add(column);
            }
        }

        private void FillDataGrid()
        {
            foreach (IdentificationExperiment experiment in ModelStorage.Instance.Model.IdentificationExperiments.Values)
            {
                int ind = this.dgvGeneratedExp.Rows.Add();
                TId idRealExp = experiment.RealExperimentId;
                this.dgvGeneratedExp[2, ind].Value = ModelStorage.Instance.Model.RealExperiments[idRealExp].Number;
                this.dgvGeneratedExp[3, ind].Value = ModelStorage.Instance.Model.IdentificationExperiments[experiment.Id].Number;

                int parameterNumber = 0;
                foreach (double paramValue in experiment.IdentificationParameterValues.Values)
                {
                    this.dgvGeneratedExp[4 + parameterNumber, ind].Value = paramValue.ToString(SettingsManager.Instance.DoubleStringFormat);
                    parameterNumber++;
                }
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (dialogSaveModel.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    XmlIdentificationModelProvider.Save(ModelStorage.Instance.Model, dialogSaveModel.FileName);
                }
                catch (Exception ex)
                {
                    MessageBoxHelper.ShowError(ex.Message);
                }

                dialogSaveModel.FileName = string.Empty;
            }
        }
    }
}