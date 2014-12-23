using System.Collections.Generic;
using System.Linq;
using opt.Helpers;
using opt.DataModel;

namespace opt.Solvers.MainCriterion
{
    public class MainCriterionSolver
    {
        public MainCriterionMethodResult FindDecision(Model model, TId mainCriterionId)
        {
            // Сюда приходит модель с уже отсеянными по 
            // критериальным ограничениям экспериментами
            // Остается только отсортировать их по 
            // главному критерию

            var result = new MainCriterionMethodResult("Метод главного критерия", mainCriterionId);

            List<SortableDouble> sortedExperiments = model.Experiments.Values.Select<Experiment, SortableDouble>(
                     e => new SortableDouble() { Direction = model.Criteria[mainCriterionId].SortDirection, Id = e.Id, Value = e.CriterionValues[mainCriterionId] }
                ).ToList();
            sortedExperiments.Sort();

            foreach (SortableDouble sortedExperiment in sortedExperiments)
            {
                result.SortedPoints.Add(sortedExperiment.Id);
            }

            return result;
        }
    }
}