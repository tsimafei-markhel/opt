using System;
using opt.DataModel;
using opt.Helpers;

namespace opt.UI
{
    public partial class GenerateExperimentsForm : OptIdFormBase
    {
        public GenerateExperimentsForm()
        {
            InitializeComponent();
        }

        public GenerateExperimentsForm(OptIdFormBase previous)
            : base(previous)
        {
            InitializeComponent();
            AdjustFormParameters(previous);
        }

        protected override void btnNext_Click(object sender, EventArgs e)
        {
            CreateExperimentStubs();

            // Choose next form and do the job
            if (radioAutomatic.Checked)
            {
                GenerateParameterValues();
                nextForm = new ViewGeneratedExperimentsForm(this);
            }
            else if (radioManual.Checked)
            {
                // TODO
                return;
            }

            // Now call base implementation - it is responsible for forms rotation
            base.btnNext_Click(sender, e);
        }

        private void GenerateParameterValues()
        {
            int parameterNumber = 1;
            foreach (Parameter identificationParameter in ModelStorage.Instance.Model.IdentificationParameters.Values)
            {
                double parameterRange = identificationParameter.MaxValue - identificationParameter.MinValue;
                int experimentNumber = 1;
                foreach (IdentificationExperiment experiment in ModelStorage.Instance.Model.IdentificationExperiments.Values)
                {
                    double parameterValue = LpTauGenerator.GetParameterValue(experimentNumber,
                        parameterNumber) * parameterRange + identificationParameter.MinValue;
                    ModelStorage.Instance.Model.IdentificationExperiments[experiment.Id].
                        IdentificationParameterValues.Add(identificationParameter.Id, parameterValue);

                    experimentNumber++;
                }

                parameterNumber++;
            }
        }

        private void CreateExperimentStubs()
        {
            ModelStorage.Instance.Model.IdentificationExperiments.Clear();

            int experimentCount = Convert.ToInt32(numericNumberOfExperiments.Value);
            int experimentNumberOffset = 0;
            foreach (Experiment realExperiment in ModelStorage.Instance.Model.RealExperiments.Values)
            {
                for (int i = 0; i < experimentCount; i++)
                {
                    IdentificationExperiment newExperiment = new IdentificationExperiment(
                        ModelStorage.Instance.Model.IdentificationExperiments.GetFreeConsequentId(),
                        experimentNumberOffset + i + 1, realExperiment.Id);
                    ModelStorage.Instance.Model.IdentificationExperiments.Add(newExperiment);
                }

                experimentNumberOffset += experimentCount;
            }
        }
    }
}