using System;
using opt.DataModel;
using opt.Xml;

namespace TestModel
{
    internal sealed class ModelCalculator
    {
        private readonly IdentificationModel model;
        private readonly string modelFile;

        public ModelCalculator(string modelFilePath)
        {
            if (string.IsNullOrEmpty(modelFilePath))
            {
                throw new ArgumentNullException("modelFilePath");
            }

            model = XmlIdentificationModelProvider.Open(modelFilePath);
            modelFile = modelFilePath;
        }

        public void CalculateModel()
        {
            if (model == null)
            {
                throw new InvalidOperationException("Model is null");
            }

            foreach (IdentificationExperiment experiment in model.IdentificationExperiments.Values)
            {
                CalculateExperiment(experiment);
            }
        }

        private void CalculateExperiment(IdentificationExperiment experiment)
        {
            // Read parameters
            double alpha1 = experiment.IdentificationParameterValues[0];
            double alpha2 = experiment.IdentificationParameterValues[1];
            double alpha3 = experiment.IdentificationParameterValues[2];

            double x1 = model.RealExperiments[experiment.RealExperimentId].ParameterValues[0];
            double x2 = model.RealExperiments[experiment.RealExperimentId].ParameterValues[1];
            double x3 = model.RealExperiments[experiment.RealExperimentId].ParameterValues[2];

            // Calculate criteria
            double c1 = alpha1 + alpha3 - (x1 * x2);
            double c2 = alpha2 + x3 / (alpha1 + x2);
            double c3 = alpha1 - x1 * (x2 / alpha3);

            experiment.MathematicalCriterionValues[0] = c1;
            experiment.MathematicalCriterionValues[1] = c2;
            experiment.MathematicalCriterionValues[2] = c3;

            // Calculate functional constraints
            double fc1 = alpha1 + x2 / (alpha3 + x1);
            double fc2 = alpha2 + alpha1 - (x2 * x3);
            double fc3 = alpha2 - x2 * (x3 / alpha1);

            experiment.ConstraintValues[0] = fc1;
            experiment.ConstraintValues[1] = fc2;
            experiment.ConstraintValues[2] = fc3;
        }

        public void Save()
        {
            if (model == null)
            {
                throw new InvalidOperationException("Model is null");
            }

            XmlIdentificationModelProvider.Save(model, modelFile);
        }
    }
}