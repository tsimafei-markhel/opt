using System.Collections.Generic;
using System.Linq;
using opt.DataModel;
using opt.Helpers;

namespace opt.Solvers.Formal
{
    public class BinaryRelationsSolver : IFormalMethodSolver
    {
        public FormalMethodResult FindDecision(Model model)
        {
            FormalMethodResult result = new FormalMethodResult("Метод бинарных отношений", "Количество \"побед\" точки");
            IEnumerable<Experiment> paretoExperiments = model.Experiments.Values.Where(e => e.IsParetoOptimal);

            // Словарь для хранения количества побед каждой точки
            // Ключ - индекс точки, Значение - количество ее побед
            Dictionary<TId, int> wins = new Dictionary<TId, int>(paretoExperiments.Count());
            foreach (Experiment experiment in paretoExperiments)
            {
                wins.Add(experiment.Id, 0);
            }

            List<TId> seenPoints = new List<TId>(paretoExperiments.Count());
            foreach (Experiment currentExperiment in paretoExperiments)
            {
                foreach (Experiment experiment in paretoExperiments)
                {
                    if (experiment.Id != currentExperiment.Id &&
                        !seenPoints.Contains(experiment.Id))
                    {
                        foreach (Criterion criterion in model.Criteria.Values)
                        {
                            double currExpCritValue = currentExperiment.CriterionValues[criterion.Id];
                            double expCritValue = experiment.CriterionValues[criterion.Id];

                            if (Comparer.IsFirstValueBetter(currExpCritValue, expCritValue, criterion.Type))
                            {
                                wins[currentExperiment.Id]++;
                            }
                            else
                            {
                                wins[experiment.Id]++;
                            }
                        }
                    }
                }

                seenPoints.Add(currentExperiment.Id);
            }

            // Отсортируем результаты по убыванию по количеству
            // побед (больше - лучше)
            List<SortableDouble> sortedWins = wins.Select<KeyValuePair<TId, int>, SortableDouble>(
                    kvp => new SortableDouble() { Direction = SortDirection.Descending, Id = kvp.Key, Value = (double)kvp.Value }
                ).ToList();
            sortedWins.Sort();

            // Сформируем результат
            foreach (SortableDouble win in sortedWins)
            {
                result.SortedPoints.Add(win.Id);
                result.AdditionalData.Add(win.Id, win.Value);
            }

            return result;
        }
    }
}