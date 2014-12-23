using System.Collections.Generic;
using opt.DataModel;

// TODO: Fix comments
// TODO: Refactoring

namespace opt.Helpers
{
    public static class ParetoFinder
    {
        public static void FindParetoPoints(Model model)
        {
            // Проверим все АКТИВНЫЕ точки
            foreach (Experiment currentExperiment in model.Experiments.Values)
            {
                // Сбросим результаты предыдущего поиска, если таковые имеются
                currentExperiment.IsParetoOptimal = currentExperiment.IsActive;

                if (currentExperiment.IsActive)
                {
                    // Поищем среди всех остальных АКТИВНЫХ точек такие, которые 
                    // доминируют над данной точкой
                    foreach (Experiment experiment in model.Experiments.Values)
                    {
                        // Чтоб не сравнивать точку с самой собой
                        if (experiment.Id != currentExperiment.Id && experiment.IsActive)
                        {
                            if (CheckStrictDomination(model.Criteria.Values, experiment, currentExperiment))
                            {
                                // Если нашли точку (experiment), которая доминирует над данной
                                // (currentExperiment), то значит данная точка не может быть паретовской,
                                // искать дальше не имеет смысла
                                currentExperiment.IsParetoOptimal = false;
                                break;
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Метод для проверки строгого доминирования первой точки
        /// над второй
        /// </summary>
        /// <param name="criteria">Список критериев оптимальности</param>
        /// <param name="firstPoint">Первая точка</param>
        /// <param name="secondPoint">Вторая точка</param>
        /// <returns>True, если <paramref name="firstPoint"/> строго доминирует над 
        /// <paramref name="secondPoint"/>, иначе false</returns>
        private static bool CheckStrictDomination(IEnumerable<Criterion> criteria, Experiment firstPoint, Experiment secondPoint)
        {
            // По каждому критерию - надо проверить все
            foreach (Criterion criterion in criteria)
            {
                // Для удобства скопируем значения
                double firstPointValue = firstPoint.CriterionValues[criterion.Id];
                double secondPointValue = secondPoint.CriterionValues[criterion.Id];

                // Если при переходе от первой точки ко второй
                // мы смогли улучшить хоть один критерий, то первая
                // точка НЕ ДОМИНИРУЕТ над второй
                switch (criterion.Type)
                {
                    case CriterionType.Minimizing:
                        if (firstPointValue > secondPointValue)
                        {
                            return false;
                        }

                        break;

                    case CriterionType.Maximizing:
                        if (firstPointValue < secondPointValue)
                        {
                            return false;
                        }

                        break;
                }
            }

            // Если при переходе от первой точки ко второй
            // мы не улучшили ни одного критерия, то первая
            // точка ДОМИНИРУЕТ над второй
            return true;
        }
    }
}