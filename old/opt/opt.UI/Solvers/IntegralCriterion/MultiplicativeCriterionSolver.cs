using System;
using System.Collections.Generic;
using System.Linq;
using opt.DataModel;
using opt.Helpers;

namespace opt.Solvers.IntegralCriterion
{
    public class MultiplicativeCriterionSolver : IIntegralCriterionMethodSolver
    {
        #region IIntegralCriterionMethodSolver Members

        public IntegralCriterionMethodResult FindDecision(Model model)
        {
            var result = new IntegralCriterionMethodResult("Мультипликативный критерий", "Значение мультипликативного критерия");

            // Нормализуем критерии и определим их тип
            foreach (Criterion crit in model.Criteria.Values)
            {
                Dictionary<TId, double> normalizedCrit = NormalizationHelper.NormalizeCriterionValues(model.Experiments, crit);
                result.AddNormalizedCriterion(normalizedCrit, crit.Id);
            }

            // Вычислим значения мультипликативного критерия для каждого из
            // экспериментов
            var multiplicativeCriterion = new Dictionary<TId, double>();
            foreach (Experiment exp in model.Experiments.Values)
            {
                if (exp.IsActive)
                {
                    double multiplicativeCriterionValue = 1;
                    foreach (Criterion crit in model.Criteria.Values)
                    {
                        double normalizedCriterionValue =
                            result.GetNormalizedCriterion(crit.Id)[exp.Id];
                        normalizedCriterionValue = Math.Pow(normalizedCriterionValue, crit.Weight);
                        // Вычислим
                        multiplicativeCriterionValue *= normalizedCriterionValue;
                    }

                    multiplicativeCriterion.Add(exp.Id, multiplicativeCriterionValue);
                }
            }

            // Отсортируем результаты по возрастанию
            List<SortableDouble> sortedValues = multiplicativeCriterion.Select<KeyValuePair<TId, double>, SortableDouble>(
                    kvp => new SortableDouble() { Direction = SortDirection.Ascending, Id = kvp.Key, Value = kvp.Value }
                ).ToList();
            sortedValues.Sort();

            // Заполним результаты
            foreach (SortableDouble sortedValue in sortedValues)
            {
                result.SortedPoints.Add(sortedValue.Id);
                result.AdditionalData.Add(sortedValue.Id, sortedValue.Value);
            }

            return result;
        }

        public IntegralCriterionMethodResult FindDecisionWithUtilityFunction(
            Model model,
            Dictionary<TId, UtilityFunction> uFunctions)
        {
            throw new NotImplementedException();
        }

        #endregion

        public static bool CriteriaHaveSimilarType(Model model)
        {
            // Проверим, все ли критерии одного типа
            int maximizing = 0;
            int minimizing = 0;
            int total = model.Criteria.Count;
            foreach (Criterion crit in model.Criteria.Values)
            {
                if (crit.Type == CriterionType.Maximizing)
                {
                    maximizing++;
                }
                else
                {
                    minimizing++;
                }
            }

            if ((minimizing > 0 && minimizing < total) ||
                (maximizing > 0 && maximizing < total))
            {
                // Критерии имеют разный тип, применять этот метод 
                // до выяснения некоторых обстоятельств НЕЛЬЗЯ
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}