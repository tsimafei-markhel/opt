using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using opt.DataModel;
using opt.Helpers;

// TODO: Normalization???
// TODO: Reuse DistanceHelper here

namespace opt.Solvers.Formal
{
    public class IdealPointSolver : IFormalMethodSolver
    {
        #region IFormalMethodSolver Members

        public FormalMethodResult FindDecision(Model model)
        {
            FormalMethodResult result = new FormalMethodResult("Метод поиска точки с минимальным удалением от идеальной", "Расстояние до идеальной точки");

            // Search among active pareto-optimal experiments only
            IEnumerable<Experiment> targetPoints = model.Experiments.Values.Where(e => e.IsActive && e.IsParetoOptimal);

            // Координаты идеальной точки
            Dictionary<TId, double> idealPoint = new Dictionary<TId, double>(model.Criteria.Count);
            // В качестве дефолтных возьмем лучшие из тех,
            // что есть
            foreach (Criterion criterion in model.Criteria.Values)
            {
                IEnumerable<double> criterionValues = targetPoints.Select<Experiment, double>(e => e.CriterionValues[criterion.Id]);

                double bestCriterionValue = double.NaN;
                switch (criterion.Type)
                {
                    case CriterionType.Minimizing:
                        bestCriterionValue = criterionValues.Min();
                        break;

                    case CriterionType.Maximizing:
                        bestCriterionValue = criterionValues.Max();
                        break;
                }

                idealPoint.Add(criterion.Id, bestCriterionValue);
            }

            // Спросим у юзера, может он хочет их поменять
            idealPoint = GetUserIdealPoint(model.Criteria, idealPoint);

            // Теперь координаты идеальной точки есть.
            // Можем найти расстояния от нее до каждой из
            // паретовских точек
            Dictionary<TId, double> distances = new Dictionary<TId, double>(targetPoints.Count());
            foreach (Experiment experiment in targetPoints)
            {
                double distance = 0;
                foreach (Criterion criterion in model.Criteria.Values)
                {
                    double pointCoordinate = experiment.CriterionValues[criterion.Id];
                    double idealPointCoordinate = idealPoint[criterion.Id];

                    distance += Math.Pow(idealPointCoordinate - pointCoordinate, 2);
                }

                distance = Math.Sqrt(distance);
                distances.Add(experiment.Id, distance);
            }

            // Отсортируем результаты по возрастанию по расстоянию
            // до идеальной точки (ближайшая - лучшая)
            List<SortableDouble> sortedDistances = distances.Select<KeyValuePair<TId, double>, SortableDouble>(
                    kvp => new SortableDouble() { Direction = SortDirection.Ascending, Id = kvp.Key, Value = kvp.Value }
                ).ToList();
            sortedDistances.Sort();

            foreach (SortableDouble distance in sortedDistances)
            {
                result.SortedPoints.Add(distance.Id);
                result.AdditionalData.Add(distance.Id, distance.Value);
            }

            return result;
        }

        #endregion

        private static Dictionary<TId, double> GetUserIdealPoint(Dictionary<TId, Criterion> criteria, Dictionary<TId, double> idealPointCoordinates)
        {
            Dictionary<TId, double> result = new Dictionary<TId, double>();

            IdealPointForm idealPointForm = new IdealPointForm(criteria, idealPointCoordinates);
            if (idealPointForm.ShowDialog() == DialogResult.OK)
            {
                result = idealPointForm.IdealPoint;
            }

            idealPointForm.Dispose();

            return result;
        }

    }
}