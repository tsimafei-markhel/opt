using System.Collections.Generic;
using System.Linq;
using opt.DataModel;
using opt.Helpers;

namespace opt.Solvers.Formal
{
    public class MaximalPowerSolver : IFormalMethodSolver
    {
        public FormalMethodResult FindDecision(Model model)
        {
            FormalMethodResult result = new FormalMethodResult("Метод поиска точки с максимальной мощностью", "Мощность точки");

            // Search among active experiments only
            IEnumerable<Experiment> activeExperiments = model.Experiments.Values.Where(e => e.IsActive);

            // Словарь для хранения мощности каждой точки
            // Ключ - индекс точки, Значение - ее мощность
            Dictionary<TId, int> powers = new Dictionary<TId, int>(activeExperiments.Count());

            foreach (Experiment currentExperiment in activeExperiments)
            {
                powers.Add(currentExperiment.Id, 0);
                foreach (Experiment experiment in activeExperiments)
                {
                    if (experiment.Id == currentExperiment.Id)
                    {
                        continue;
                    }

                    // Подсчитаем, по скольки критериям точка currExp
                    // оказалась лучше, чем exp
                    int currExpWins = 0;
                    foreach (Criterion criterion in model.Criteria.Values)
                    {
                        double currExpCritValue = currentExperiment.CriterionValues[criterion.Id];
                        double expCritValue = experiment.CriterionValues[criterion.Id];

                        if (Comparer.IsFirstValueBetter(
                                currExpCritValue,
                                expCritValue,
                                criterion.Type))
                        {
                            currExpWins++;
                        }
                    }

                    // Если currExp оказалась лучше по всем критериям, 
                    // то запишем ей +1 к мощности
                    if (currExpWins == model.Criteria.Count)
                    {
                        powers[currentExperiment.Id]++;
                    }
                }
            }

            // Отсортируем результаты по убыванию по мощности
            // (больше - лучше)
            List<SortableDouble> sortedPowers = powers.Select<KeyValuePair<TId, int>, SortableDouble>(
                    kvp => new SortableDouble() { Direction = SortDirection.Descending, Id = kvp.Key, Value = (double)kvp.Value }
                ).ToList();
            sortedPowers.Sort();

            // Сформируем результат
            foreach (SortableDouble power in sortedPowers)
            {
                result.SortedPoints.Add(power.Id);
                result.AdditionalData.Add(power.Id, power.Value);
            }

            return result;
        }
    }
}