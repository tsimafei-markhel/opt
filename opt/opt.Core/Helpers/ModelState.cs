using System;
using System.Collections.Generic;
using System.Linq;
using opt.DataModel;

namespace opt.Helpers
{
    /// <summary>
    /// Describes <see cref="Model"/> state snapshot
    /// </summary>
    public sealed class ModelState
    {
        /// <summary>
        /// Gets whether parameters were defined in the <see cref="Model"/>
        /// </summary>
        public bool HasParameters { get; private set; }

        /// <summary>
        /// Gets whether criteria were defined in the <see cref="Model"/>
        /// </summary>
        public bool HasCriteria { get; private set; }

        /// <summary>
        /// Gets whether functional constraints were defined in the <see cref="Model"/>
        /// </summary>
        public bool HasFunctionalConstraints { get; private set; }

        /// <summary>
        /// Gets whether experiments were defined in the <see cref="Model"/>
        /// </summary>
        public bool HasExperiments { get; private set; }

        /// <summary>
        /// Gets whether each experiment in the <see cref="Model"/> has values for all parameters
        /// </summary>
        public bool HasParameterValues { get; private set; }

        /// <summary>
        /// Gets whether each experiment in the <see cref="Model"/> has values for all criteria
        /// </summary>
        public bool HasCriterionValues { get; private set; }

        /// <summary>
        /// Gets whether each experiment in the <see cref="Model"/> has values for all functional constraints
        /// </summary>
        public bool HasFunctionalConstraintValues { get; private set; }

        /// <summary>
        /// Gets whether <see cref="Model"/> has experiments in Pareto front
        /// </summary>
        public bool HasParetoFront { get; private set; }

        /// <summary>
        /// Creates a snapshot of <paramref name="model"/> state
        /// </summary>
        /// <param name="model"><see cref="Model"/> to get state of</param>
        /// <returns><see cref="ModelState"/> of a <paramref name="model"/></returns>
        /// <exception cref="ArgumentNullException">If <paramref name="model"/> is null</exception>
        public static ModelState GetModelState(Model model)
        {
            if (model == null)
            {
                throw new ArgumentNullException("model");
            }

            ModelState state = new ModelState()
            {
                HasParameters = CheckParametersExistence(model),
                HasCriteria = CheckCriteriaExistence(model),
                HasFunctionalConstraints = CheckFunctionalConstraintsExistence(model),
                HasExperiments = CheckExperimentsExistence(model),
                HasParameterValues = CheckParameterValuesExistence(model),
                HasCriterionValues = CheckCriterionValuesExistence(model),
                HasFunctionalConstraintValues = CheckFunctionalConstraintValuesExistence(model),
                HasParetoFront = CheckParetoFrontExistence(model)
            };

            return state;
        }

        /// <summary>
        /// Checks whether parameters were added to <paramref name="model"/>
        /// </summary>
        /// <param name="model"><see cref="Model"/> instance to be checked</param>
        /// <returns>True if <paramref name="model"/> contains one or more parameters</returns>
        private static bool CheckParametersExistence(Model model)
        {
            return CheckCollectionExistence<Parameter>(model.Parameters);
        }

        /// <summary>
        /// Checks whether criteria were added to <paramref name="model"/>
        /// </summary>
        /// <param name="model"><see cref="Model"/> instance to be checked</param>
        /// <returns>True if <paramref name="model"/> contains one or more criteria</returns>
        private static bool CheckCriteriaExistence(Model model)
        {
            return CheckCollectionExistence<Criterion>(model.Criteria);
        }

        /// <summary>
        /// Checks whether functional constraints were added to <paramref name="model"/>
        /// </summary>
        /// <param name="model"><see cref="Model"/> instance to be checked</param>
        /// <returns>True if <paramref name="model"/> contains one or more functional constraints</returns>
        private static bool CheckFunctionalConstraintsExistence(Model model)
        {
            return CheckCollectionExistence<Constraint>(model.FunctionalConstraints);
        }

        /// <summary>
        /// Checks whether experiments were added to <paramref name="model"/>
        /// </summary>
        /// <param name="model"><see cref="Model"/> instance to be checked</param>
        /// <returns>True if <paramref name="model"/> contains one or more experiments</returns>
        private static bool CheckExperimentsExistence(Model model)
        {
            return CheckCollectionExistence<Experiment>(model.Experiments);
        }

        /// <summary>
        /// Checks whether <paramref name="collection"/> is not null and not empty
        /// </summary>
        /// <typeparam name="T">Type of the objects in the dictionary</typeparam>
        /// <param name="collection"><see cref="IDictionary"/> to be checked</param>
        /// <returns>True if <paramref name="collection"/> is not null and not empty</returns>
        private static bool CheckCollectionExistence<T>(IDictionary<TId, T> collection)
        {
            if (collection == null || collection.Count <= 0)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Checks whether all experiments in <paramref name="model"/> contain values for all parameters
        /// </summary>
        /// <param name="model"><see cref="Model"/> instance to be checked</param>
        /// <returns>True if all experiments in <paramref name="model"/> contain values for all parameters</returns>
        private static bool CheckParameterValuesExistence(Model model)
        {
            return CheckEntityValuesExistence<Parameter>(model.Experiments, model.Parameters);
        }

        /// <summary>
        /// Checks whether all experiments in <paramref name="model"/> contain values for all criteria
        /// </summary>
        /// <param name="model"><see cref="Model"/> instance to be checked</param>
        /// <returns>True if all experiments in <paramref name="model"/> contain values for all criteria</returns>
        private static bool CheckCriterionValuesExistence(Model model)
        {
            return CheckEntityValuesExistence<Criterion>(model.Experiments, model.Criteria);
        }

        /// <summary>
        /// Checks whether all experiments in <paramref name="model"/> contain values for all functional constraints
        /// </summary>
        /// <param name="model"><see cref="Model"/> instance to be checked</param>
        /// <returns>True if all experiments in <paramref name="model"/> contain values for all functional constraints</returns>
        private static bool CheckFunctionalConstraintValuesExistence(Model model)
        {
            return CheckEntityValuesExistence<Constraint>(model.Experiments, model.FunctionalConstraints);
        }

        /// <summary>
        /// Checks whether all <paramref name="experiments"/> contain values for all <paramref name="entities"/>
        /// </summary>
        /// <typeparam name="T">Type of the entity. Currently only <see cref="Parameter"/>, <see cref="Criterion"/> and
        /// <see cref="Constraint"/> are supported</typeparam>
        /// <param name="experiments">Collection of the experiments</param>
        /// <param name="entities">Collection of the entities, presence of values for which should be checked</param>
        /// <exception cref="ArgumentException">If <typeparamref name="T"/> is not <see cref="Parameter"/>, <see cref="Criterion"/> or
        /// <see cref="Constraint"/></exception>
        /// <returns>True if all <paramref name="experiments"/> contain values for all <paramref name="entities"/></returns>
        private static bool CheckEntityValuesExistence<T>(IDictionary<TId, Experiment> experiments, IDictionary<TId, T> entities)
        {
            if (!CheckCollectionExistence<T>(entities))
            {
                return false;
            }

            if (!CheckCollectionExistence<Experiment>(experiments))
            {
                return false;
            }

            Type entityType = typeof(T);
            foreach (TId entityId in entities.Keys)
            {
                Func<Experiment, bool> entityExistenceFunc = null;
                if (entityType == typeof(Parameter))
                {
                    entityExistenceFunc = e => CheckEntityValueExistence(e.ParameterValues, entityId);
                }
                else if (entityType == typeof(Criterion))
                {
                    entityExistenceFunc = e => CheckEntityValueExistence(e.CriterionValues, entityId);
                }
                else if (entityType == typeof(Constraint))
                {
                    entityExistenceFunc = e => CheckEntityValueExistence(e.ConstraintValues, entityId);
                }
                else
                {
                    throw new InvalidOperationException();
                }

                int experimentWithEntityValueCount = experiments.Values.Where(entityExistenceFunc).ToList().Count;
                if (experimentWithEntityValueCount < experiments.Count)
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Checks whether <paramref name="collection"/> contains element with <paramref name="entityId"/> key
        /// </summary>
        /// <param name="collection"><see cref="IDictionary"/> to be checked</param>
        /// <param name="entityId">Key to search for in <paramref name="collection"/></param>
        /// <returns>True if <paramref name="collection"/> is not null and contains element with <paramref name="entityId"/> key</returns>
        private static bool CheckEntityValueExistence(IDictionary<TId, double> collection, TId entityId)
        {
            return collection != null && collection.Keys.Contains(entityId);
        }

        /// <summary>
        /// Checks whether <paramref name="model"/> has experiments in Pareto front
        /// </summary>
        /// <param name="model"><see cref="Model"/> instance to be checked</param>
        /// <returns>True if <paramref name="model"/> has at least one experiment in Pareto front</returns>
        private static bool CheckParetoFrontExistence(Model model)
        {
            if (!CheckExperimentsExistence(model))
            {
                return false;
            }

            return model.Experiments.Values.Where(e => e.IsParetoOptimal).ToList().Count > 0;
        }
    }
}