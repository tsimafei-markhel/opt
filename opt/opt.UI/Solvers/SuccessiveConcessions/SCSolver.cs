using System.Collections.Generic;
using System.Linq;
using opt.DataModel;
using opt.Helpers;

namespace opt.Solvers.SuccessiveConcessions
{
    public static class ScSolver
    {
        /// <summary>
        /// Применяет наложенные уступки
        /// </summary>
        /// <param name="model">Исходная модель</param>
        /// <param name="concessions">Уступки</param>
        /// <param name="sortingCritId">Критерий, по которому должна производиться сортировка</param>
        /// <returns>Результат поиска решения</returns>
        public static ScMethodResult ApplyConcessions(
            ref Model model,
            CriterialConcessions concessions,
            TId sortingCritId)
        {
            var result = new ScMethodResult("Метод последовательных уступок");

            // Если уступки вообще еще не заданы, то нужно вывести только 
            // эксперимент, лучший по самому важному критерию
            if (concessions.IsFirstElementIndex(sortingCritId))
            {
                TId bestExperimentId = FindBestValueId(model.Experiments, model.Criteria[sortingCritId]);
                foreach (Experiment exp in model.Experiments.Values)
                {
                    if (exp.Id != bestExperimentId)
                    {
                        exp.IsActive = false;
                    }
                }
                result.SortedPoints.Add(bestExperimentId);
                return result;
            }
            
            // Иначе же будем последовательно применять уступки, отсеивая 
            // не проходящие по ним эксперименты
            foreach(CriterialConcession concession in concessions)
            {
                if (concession.IsUsable)
                {
                    // Рассчитаем интервал
                    concession.BestValue =
                        FindBestValue(model.Experiments, model.Criteria[concession.CriterionId]);
                    concession.CalcWorstValue();
                    // Для каждого активного эксперимента проверим:
                    // если он вписывается в интервал, то оставляем активным, 
                    // а если нет, то делаем неактивным
                    foreach (Experiment exp in model.Experiments.Values)
                    {
                        if (exp.IsActive)
                        {
                            double expValue = exp.CriterionValues[concession.CriterionId];
                            exp.IsActive = concession.IsValueFittingInterval(expValue);
                        }
                    }
                }
            }

            // Посчитаем все активные эксперименты
            if (model.Experiments.CountActiveExperiments() > 0)
            {
                SortDirection sortDirection =  model.Criteria[sortingCritId].SortDirection;
                List<SortableDouble> sortedExperiments = model.Experiments.Values.Where(e => e.IsActive).Select<Experiment, SortableDouble>(
                        e => new SortableDouble() { Direction = sortDirection, Id = e.Id, Value = e.CriterionValues[sortingCritId] }
                    ).ToList();
                sortedExperiments.Sort();

                foreach (SortableDouble sortedExperiment in sortedExperiments)
                {
                    result.SortedPoints.Add(sortedExperiment.Id);
                }
            }

            return result;
        }

        /// <summary>
        /// Метод, возвращающий Id критерия, по которому нужно произвести сортировку 
        /// экспериментов
        /// </summary>
        /// <param name="concessions">Коллекция уступок по критериям</param>
        /// <returns>Id критерия, по которому нужно отсортировать эксперименты</returns>
        public static TId FindSortingCriterionId(CriterialConcessions concessions)
        {
            TId result = -1;

            // НЕ ЗАБЫТЬ: Если последняя уступка (last usable criterion)
            // задана для критерия N, то сортировка происходит по критерию 
            // N + 1

            foreach (CriterialConcession concession in concessions)
            {
                // Если все критерии not usable, то возвращается 
                // индекс первого критерия, что и требуется.
                // Если критерий N usable, a (N + 1) - not usable, 
                // то возвращается индекс (N + 1)-го критерия
                result = concession.CriterionId;
                if (!concession.IsUsable)
                {
                    break;
                }
            }

            return result;
        }

        /// <summary>
        /// Метод, обнаруживающий лучшее среди всех экспериментов значение по заданному критерию
        /// </summary>
        /// <param name="experiments">Коллекция экспериментов</param>
        /// <param name="crit">Критерий, по которому нужно обнаружить лучшее значение</param>
        /// <returns>Лучшее значение по заданному критерию среди всех экспериментов</returns>
        private static double FindBestValue(Dictionary<TId, Experiment> experiments, Criterion crit)
        {
            var bestValue = double.NaN;

            switch (crit.Type)
            {
                case CriterionType.Minimizing:
                    bestValue = double.MaxValue;
                    break;
                case CriterionType.Maximizing:
                    bestValue = double.MinValue;
                    break;
            }

            foreach (Experiment exp in experiments.Values)
            {
                if (exp.IsActive)
                {
                    switch (crit.Type)
                    {
                        case CriterionType.Minimizing:
                            if (exp.CriterionValues[crit.Id] < bestValue)
                            {
                                bestValue = exp.CriterionValues[crit.Id];
                            }
                            break;
                        case CriterionType.Maximizing:
                            if (exp.CriterionValues[crit.Id] > bestValue)
                            {
                                bestValue = exp.CriterionValues[crit.Id];
                            }
                            break;
                    }
                }
            }

            return bestValue;
        }

        /// <summary>
        /// Метод, обнаруживающий Id лучшего среди всех эксперимента по заданному критерию
        /// </summary>
        /// <param name="experiments">Коллекция экспериментов</param>
        /// <param name="crit">Критерий, по которому нужно обнаружить лучшее значение</param>
        /// <returns>Id лучшего по значению заданного критерия эксперимента</returns>
        private static TId FindBestValueId(Dictionary<TId, Experiment> experiments, Criterion crit)
        {
            double bestValue = double.NaN;
            TId bestId = -1;

            switch (crit.Type)
            {
                case CriterionType.Minimizing:
                    bestValue = double.MaxValue;
                    break;
                case CriterionType.Maximizing:
                    bestValue = double.MinValue;
                    break;
            }

            foreach (Experiment exp in experiments.Values)
            {
                if (exp.IsActive)
                {
                    switch (crit.Type)
                    {
                        case CriterionType.Minimizing:
                            if (exp.CriterionValues[crit.Id] < bestValue)
                            {
                                bestValue = exp.CriterionValues[crit.Id];
                                bestId = exp.Id;
                            }
                            break;
                        case CriterionType.Maximizing:
                            if (exp.CriterionValues[crit.Id] > bestValue)
                            {
                                bestValue = exp.CriterionValues[crit.Id];
                                bestId = exp.Id;
                            }
                            break;
                    }
                }
            }

            return bestId;
        }
    }
}