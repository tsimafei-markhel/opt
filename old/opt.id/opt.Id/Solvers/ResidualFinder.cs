using System;
using opt.DataModel;

namespace opt.Solvers
{
    /// <summary>
    /// Contains methods for finding adequacy criteria values
    /// </summary>
    public static class ResidualFinder
    {
        /// <summary>
        /// Calculates adequacy criteria values for all identification experiments in the given <paramref name="model"/>
        /// </summary>
        /// <param name="model">Instance of <see cref="IdentificationModel"/> to take data from and
        /// put calculation results to</param>
        /// <remarks>Utilizes <see cref="ResidualFunctionRegistry"/>. Overwrites existing adequacy criteria values</remarks>
        public static void CalculateAdequacyCriteriaValues(IdentificationModel model)
        {
            if (model == null)
            {
                throw new ArgumentNullException("model");
            }

            foreach (IdentificationExperiment identificationExperiment in model.IdentificationExperiments.Values)
            {
                identificationExperiment.AdequacyCriterionValues.Clear();
                foreach (AdequacyCriterion criterion in model.Criteria.Values)
                {
                    double mathCriterionValue = identificationExperiment.MathematicalCriterionValues[criterion.Id];
                    double realCriterionValue = model.RealExperiments[identificationExperiment.RealExperimentId].CriterionValues[criterion.Id];
                    identificationExperiment.AdequacyCriterionValues.Add(criterion.Id, GetResidual(criterion.AdequacyType, mathCriterionValue, realCriterionValue));
                }
            }
        }

        /// <summary>
        /// Gets adequacy criterion value (residual) by its type
        /// </summary>
        /// <param name="criterionType">Type of the adequacy criterion - defines residual function 
        /// to use to calculate adequacy criterion value</param>
        /// <param name="mathCriterionValue">Value of the criterion calculated by mathematical model (Φc)</param>
        /// <param name="realCriterionValue">Value of the criterion observed during the real experiment (Φexp)</param>
        /// <returns>adequacy criterion value</returns>
        /// <remarks>Utilizes <see cref="ResidualFunctionRegistry"/></remarks>
        /// <exception cref="NotSupportedException">If there is no residual function for <paramref name="criterionType"/></exception>
        private static double GetResidual(AdequacyCriterionType criterionType, double mathCriterionValue, double realCriterionValue)
        {
            Func<double, double, double> residualFunction = ResidualFunctionRegistry.Instance[criterionType];
            if (residualFunction == null)
            {
                throw new NotSupportedException("Adequacy criterion type " + criterionType.ToString() + " is not currently supported");
            }

            return residualFunction(mathCriterionValue, realCriterionValue);
        }
    }
}