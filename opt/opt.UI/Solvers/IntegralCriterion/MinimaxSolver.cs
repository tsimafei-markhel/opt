using System;
using System.Collections.Generic;
using System.Linq;
using opt.Helpers;
using opt.DataModel;

namespace opt.Solvers.IntegralCriterion
{
    public class MinimaxSolver : IIntegralCriterionMethodSolver
    {
        #region IIntegralCriterionMethodSolver Members

        public IntegralCriterionMethodResult FindDecision(Model model)
        {
            IntegralCriterionMethodResult result = new IntegralCriterionMethodResult("Метод минимакса", "Максимальное из значений локальных критериев");

            // Нормализуем критерии
            foreach (Criterion criterion in model.Criteria.Values)
            {
                Dictionary<TId, double> normalizedCrit = NormalizationHelper.NormalizeCriterionValues(model.Experiments, criterion);
                result.AddNormalizedCriterion(normalizedCrit, criterion.Id);
            }

            // Обнаружим максимальные значения
            List<SortableDouble> sortedMaxLocalCriterionValues = new List<SortableDouble>(model.Experiments.CountActiveExperiments());
            foreach (Experiment experiment in model.Experiments.Values)
            {
                if (experiment.IsActive)
                {
                    var normalizedCriteriaForExp = new List<double>();
                    foreach (Criterion crit in model.Criteria.Values)
                    {
                        double normalizedCriterionValue = result.GetNormalizedCriterion(crit.Id)[experiment.Id];
                        normalizedCriterionValue *= crit.Weight;
                        normalizedCriteriaForExp.Add(normalizedCriterionValue);
                    }

                    double maxLocalCriterion = normalizedCriteriaForExp.Max();
                    sortedMaxLocalCriterionValues.Add(new SortableDouble() { Direction = SortDirection.Ascending, Id = experiment.Id, Value = maxLocalCriterion });
                }
            }

            sortedMaxLocalCriterionValues.Sort();

            // Заполним результаты
            foreach (SortableDouble sortedMaxLocalCriterionValue in sortedMaxLocalCriterionValues)
            {
                result.SortedPoints.Add(sortedMaxLocalCriterionValue.Id);
                result.AdditionalData.Add(sortedMaxLocalCriterionValue.Id, sortedMaxLocalCriterionValue.Value);
            }

            return result;
        }

        public IntegralCriterionMethodResult FindDecisionWithUtilityFunction(
            Model model,
            Dictionary<TId, UtilityFunction> uFunctions)
        {
            throw new NotSupportedException("Метод минимакса не поддерживает использование функции полезности");
        }

        #endregion
    }
}