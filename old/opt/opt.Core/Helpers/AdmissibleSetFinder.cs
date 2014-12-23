using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using opt.DataModel;

// TODO: Make comments in English
// TODO: Make class non-static, init with Model, save sorted lists to speed up

namespace opt.Helpers
{
    /// <summary>
    /// Helper class, contains methods for admissible set finding
    /// </summary>
    public static class AdmissibleSetFinder
    {
        /// <summary>
        /// Метод для выделения начального состояния модели, до 
        /// построения допустимого множества
        /// </summary>
        /// <param name="model">Оптимизационная модель</param>
        /// <returns>Список активных экспериментов ДО построения
        /// допустимого множества</returns>
        public static ReadOnlyCollection<TId> GetInitialSet(Model model)
        {
            if (model == null)
            {
                throw new ArgumentNullException("model");
            }

            if (model.Experiments == null)
            {
                throw new InvalidOperationException();
            }

            return model.Experiments.Values.Where(e => e.IsActive).Select(e => e.Id).ToList().AsReadOnly();
        }

        /// <summary>
        /// Метод для переноса допустимого множества на модель: 
        /// эксперименты, входящие в допустимое множество, делаются 
        /// активными, а не входящие - неактивными
        /// </summary>
        /// <param name="admissibleSet">Список ID экспериментов, входящих в 
        /// допустимое множество</param>
        /// <param name="model">Оптимизационная модель</param>
        public static void ApplyAdmissibleSet(ReadOnlyCollection<TId> admissibleSet, Model model)
        {
            if (admissibleSet == null)
            {
                throw new ArgumentNullException("admissibleSet");
            }

            if (model == null)
            {
                throw new ArgumentNullException("model");
            }

            if (model.Experiments == null)
            {
                throw new InvalidOperationException();
            }

            foreach (Experiment experiment in model.Experiments.Values)
            {
                experiment.IsActive = admissibleSet.Contains(experiment.Id);
            }
        }

        /// <summary>
        /// Метод для построения допустимого множества по набору 
        /// граничных точек
        /// </summary>
        /// <param name="boundaryPoints">Набор граничных точек (по точке для каждого 
        /// из критериев)</param>
        /// <param name="model">Оптимизационная модель</param>
        /// <returns>Список ID экспериментов, входящих в допустимое множество</returns>
        public static ReadOnlyCollection<TId> GetAdmissibleSet(IDictionary<TId, int> boundaryPoints, Model model)
        {
            if (boundaryPoints == null)
            {
                throw new ArgumentNullException("boundaryPoints");
            }

            if (model == null)
            {
                throw new ArgumentNullException("boundaryPoints");
            }

            if (model.Criteria == null ||
                model.Experiments == null)
            {
                throw new InvalidOperationException();
            }

            ReadOnlyCollection<TId> result = GetInitialSet(model);

            foreach (Criterion criterion in model.Criteria.Values)
            {
                // TODO: Use Id instead of Number in the below
                List<SortableDouble> sortedExperiments = model.Experiments.Values.Where(e => e.IsActive).Select<Experiment, SortableDouble>(
                        e => new SortableDouble() { Direction = model.Criteria[criterion.Id].SortDirection, Id = e.Number, Value = e.CriterionValues[criterion.Id] }
                    ).ToList();
                sortedExperiments.Sort();

                List<TId> criterionAdmissibleSet = new List<TId>();
                foreach (SortableDouble sortedExperiment in sortedExperiments)
                {
                    int experimentNumber = sortedExperiment.Id; // Sorted experiment ID here actually stores number (see above)
                    TId experimentId = model.Experiments.FindIdByNumber(experimentNumber);
                    criterionAdmissibleSet.Add(experimentId);

                    // Если номер только что скопированного эксперимента
                    // равен номеру граничной точки для данного критерия,
                    // то выйдем из цикла - дальше копировать не надо
                    if (experimentNumber == boundaryPoints[criterion.Id])
                    {
                        break;
                    }
                }

                // Выберем пересечение того множества, что у нас уже есть, 
                // и того, которое только что сформировали
                List<TId> temp = new List<TId>();
                foreach (Experiment experiment in model.Experiments.Values)
                {
                    if (experiment.IsActive &&
                        result.Contains(experiment.Id) &&
                        criterionAdmissibleSet.Contains(experiment.Id))
                    {
                        temp.Add(experiment.Id);
                    }
                }

                result = temp.AsReadOnly();
            }

            return result;
        }
    }
}