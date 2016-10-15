using System.Collections.Generic;
using System.Linq;
using opt.DataModel;
using opt.Helpers;

namespace opt.Solvers.IntegralCriterion
{
    public class AdditiveCriterionSolver : IIntegralCriterionMethodSolver
    {
        #region IIntegralCriterionMethodSolver Members

        public IntegralCriterionMethodResult FindDecision(Model model)
        {
            var result =
                new IntegralCriterionMethodResult("Аддитивный критерий", "Значение аддитивного критерия");

            // Нормализуем критерии
            foreach (Criterion crit in model.Criteria.Values)
            {
                Dictionary<TId, double> normalizedCrit = NormalizationHelper.NormalizeCriterionValues(model.Experiments, crit);
                    //Normalization.NormalizeCriterion(model.Experiments, crit);
                result.AddNormalizedCriterion(normalizedCrit, crit.Id);
            }

            // Вычислим значения аддитивного критерия для каждого из
            // экспериментов
            var additiveCriterion = new Dictionary<TId, double>();
            foreach (Experiment exp in model.Experiments.Values)
            {
                if (exp.IsActive)
                {
                    double additiveCriterionValue = 0;
                    foreach (Criterion crit in model.Criteria.Values)
                    {
                        double normalizedCriterionValue =
                            result.GetNormalizedCriterion(crit.Id)[exp.Id];
                        normalizedCriterionValue *= crit.Weight;
                        //switch (crit.Type)
                        //{
                        //    case CriterionType.Maximizing:
                        //        additiveCriterionValue -= normalizedCriterionValue;
                        //        break;
                        //    case CriterionType.Minimizing:
                                additiveCriterionValue += normalizedCriterionValue;
                        //        break;
                        //}
                    }

                    additiveCriterion.Add(exp.Id, additiveCriterionValue);
                }
            }

            // Отсортируем результаты по возрастанию по значению
            // аддитивного критерия (меньше - лучше)
            List<SortableDouble> sortedAdditiveCriterionValues = additiveCriterion.Select<KeyValuePair<TId, double>, SortableDouble>(
                    kvp => new SortableDouble() { Direction = SortDirection.Ascending, Id = kvp.Key, Value = kvp.Value }
                ).ToList();
            sortedAdditiveCriterionValues.Sort();

            // Заполним результаты
            foreach (SortableDouble sortedAdditiveCriterionValue in sortedAdditiveCriterionValues)
            {
                result.SortedPoints.Add(sortedAdditiveCriterionValue.Id);
                result.AdditionalData.Add(sortedAdditiveCriterionValue.Id, sortedAdditiveCriterionValue.Value);
            }

            return result;
        }

        public IntegralCriterionMethodResult FindDecisionWithUtilityFunction(
            Model model,
            Dictionary<TId, UtilityFunction> uFunctions)
        {
            var result = new IntegralCriterionMethodResult("Аддитивный критерий с учетом функции полезности", "Значение аддитивного критерия с учетом функции полезности");

            // Найдем значения функций полезности для каждого эксперимента 
            // по каждому из критериев
            foreach (Criterion crit in model.Criteria.Values)
            {
                var utilityFunctionValues = new Dictionary<TId, double>();
                foreach (Experiment exp in model.Experiments.Values)
                {
                    UtilityFunction utFunc = uFunctions[crit.Id];
                    double criterionValue = exp.CriterionValues[crit.Id];
                    double utilityFunctionValue = utFunc.GetUtilityFunctionValue(criterionValue);
                    utilityFunctionValues.Add(exp.Id, utilityFunctionValue);
                }

                result.AddUtilityFunction(utilityFunctionValues, crit.Id);
            }

            // Вычислим значения аддитивного критерия для каждого из
            // экспериментов
            var additiveCriterion = new Dictionary<TId, double>();
            foreach (Experiment exp in model.Experiments.Values)
            {
                if (exp.IsActive)
                {
                    double additiveCriterionValue = 0;
                    foreach (Criterion crit in model.Criteria.Values)
                    {
                        double utilityFunctionValue =
                            result.GetUtilityFunction(crit.Id)[exp.Id];
                        utilityFunctionValue *= crit.Weight;
                        
                        additiveCriterionValue += utilityFunctionValue;
                    }

                    additiveCriterion.Add(exp.Id, additiveCriterionValue);
                }
            }

            // Отсортируем результаты по убыванию по значению
            // аддитивного критерия (больше - лучше)
            List<SortableDouble> sortedAdditiveCriterionValues = additiveCriterion.Select<KeyValuePair<TId, double>, SortableDouble>(
                    kvp => new SortableDouble() { Direction = SortDirection.Descending, Id = kvp.Key, Value = kvp.Value }
                ).ToList();
            sortedAdditiveCriterionValues.Sort();

            // Заполним результаты
            foreach (SortableDouble sortedAdditiveCriterionValue in sortedAdditiveCriterionValues)
            {
                result.SortedPoints.Add(sortedAdditiveCriterionValue.Id);
                result.AdditionalData.Add(sortedAdditiveCriterionValue.Id, sortedAdditiveCriterionValue.Value);
            }

            return result;
        }

        #endregion
    }
}