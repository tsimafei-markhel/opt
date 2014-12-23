using System;
using opt.DataModel.New;

namespace opt.ConstraintValidation
{
    class ModelValidator
    {
        public ValueDictionaryValidator Validator { get; set; }

        private void ValidateExperimentFunctionalConstraints(Experiment experiment, ConstraintDictionary constraints)
        {
            foreach (Constraint constraint in constraints.Values)
            {
                bool validationResult = Validator.ValidateConstraint(experiment.FunctionalConstraintValues, constraint);
                // TODO: Create marker and add to the experiment - or modify existing one
            }
        }

        private void ValidateExperimentObjectiveConstraints(Experiment experiment, ConstraintDictionary constraints)
        {
            foreach (Constraint constraint in constraints.Values)
            {
                bool validationResult = Validator.ValidateConstraint(experiment.ObjectiveConstraintValues, constraint);
                // TODO: Create marker and add to the experiment - or modify existing one
            }
        }

        // TODO: Change this interface once Model is ready
        public void ValidateModel(ExperimentDictionary experiments, ConstraintDictionary functionalConstraints, ConstraintDictionary objectiveConstraints)
        {
            foreach (Experiment experiment in experiments.Values)
            {
                ValidateExperimentFunctionalConstraints(experiment, functionalConstraints);
                ValidateExperimentObjectiveConstraints(experiment, objectiveConstraints);
            }
        }

        public static void ClearValidationResults(ExperimentDictionary experiments)
        {
            throw new NotImplementedException();
            // TODO: Remove all markers
        }
    }
}