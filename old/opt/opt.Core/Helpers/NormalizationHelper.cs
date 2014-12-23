using System;
using System.Collections.Generic;
using System.Linq;
using opt.DataModel;

// TODO: Normalization should not replace ingredient!..

// TODO: Add validation
// TODO: Add normalization that does not replace ingredient?
// TODO: Add normalization to ideal point method

namespace opt.Helpers
{
    /// <summary>
    /// Helper class, contains methods for value normalization
    /// </summary>
    public static class NormalizationHelper
    {
        /// <summary>
        /// Normalizes criterion values of active experiments AND performs ingredient replacement (maximizing criterion will become minimizing,
        /// minimizing criterion will stay minimizing)
        /// </summary>
        /// <param name="experiments">Collection of experiments to be processed</param>
        /// <param name="criterion">Criterion to normalize values of</param>
        /// <returns>Collection of normalized values (key - experiment ID, value - normalized 
        /// <paramref name="criterion"/> value)</returns>
        public static Dictionary<TId, double> NormalizeCriterionValues(Dictionary<TId, Experiment> experiments, Criterion criterion)
        {
            IEnumerable<Experiment> activeExperiments = experiments.Where(e => e.Value.IsActive).Select(e => e.Value);
            IEnumerable<double> criterionValues = activeExperiments.Select(e => e.CriterionValues[criterion.Id]);

            double maxCriterionValue = criterionValues.Max();
            double minCriterionValue = criterionValues.Min();
            // Do some caching: pre-calc everything that does not depend on experiment
            double criterionValuesVariationRange = maxCriterionValue - minCriterionValue;
            double bestCriterionValue = double.NaN;
            Func<double, double, double, double> normalizeCriterionValue = null;
            switch(criterion.Type)
            {
                case CriterionType.Maximizing:
                    normalizeCriterionValue = NormalizeMaximizingCriterionValue;
                    bestCriterionValue = maxCriterionValue;
                    break;

                case CriterionType.Minimizing:
                    normalizeCriterionValue = NormalizeMinimizingCriterionValue;
                    bestCriterionValue = minCriterionValue;
                    break;
            }

            // Perform actual normalization
            Dictionary<TId, double> normalizedCriterionValues = new Dictionary<TId, double>(activeExperiments.Count());
            foreach (Experiment experiment in activeExperiments)
            {
                normalizedCriterionValues.Add(experiment.Id, normalizeCriterionValue(experiment.CriterionValues[criterion.Id], bestCriterionValue, criterionValuesVariationRange));
            }

            return normalizedCriterionValues;
        }

        /// <summary>
        /// Normalizes local minimizing objective value
        /// </summary>
        /// <param name="valueToNormalize">Objective value to be normalized</param>
        /// <param name="minCriterionValue">Minimal value of this objective</param>
        /// <param name="criterionValuesVariationRange">Difference between maximal and minimal values of the objective</param>
        /// <returns>Normalized objective value</returns>
        private static double NormalizeMinimizingCriterionValue(double valueToNormalize, double minCriterionValue, double criterionValuesVariationRange)
        {
            return (valueToNormalize - minCriterionValue) / criterionValuesVariationRange;
        }

        /// <summary>
        /// Normalizes local maximizing objective value
        /// </summary>
        /// <param name="valueToNormalize">Objective value to be normalized</param>
        /// <param name="maxCriterionValue">Maximal value of this objective</param>
        /// <param name="criterionValuesVariationRange">Difference between maximal and minimal values of the objective</param>
        /// <returns>Normalized objective value</returns>
        private static double NormalizeMaximizingCriterionValue(double valueToNormalize, double maxCriterionValue, double criterionValuesVariationRange)
        {
            return (maxCriterionValue - valueToNormalize) / criterionValuesVariationRange;
        }
    }
}