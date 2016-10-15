using System;
using System.Collections.Generic;
using opt.DataModel;

// TODO: Implement ConvertToIdentification() method

namespace opt.Helpers
{
    /// <summary>
    /// Helper class, contains routines for conversion between <see cref="Model"/> and <see cref="IdentificationModel"/>
    /// </summary>
    public static class ModelsConverter
    {
        /// <summary>
        /// Creates new instance of <see cref="IdentificationModel"/> and fills it with data taken from
        /// <paramref name="optimizationModel"/>
        /// </summary>
        /// <param name="optimizationModel"><see cref="Model"/> instance to be converted</param>
        /// <returns>New instance of <see cref="IdentificationModel"/> based on <paramref name="optimizationModel"/></returns>
        public static IdentificationModel ConvertToIdentification(Model optimizationModel)
        {
            // Low priority
            throw new NotImplementedException();
        }

        /// <summary>
        /// Creates new instance of <see cref="Model"/> and fills it with data taken from
        /// <paramref name="identificationModel"/>
        /// </summary>
        /// <param name="identificationModel"><see cref="IdentificationModel"/> instance to be converted</param>
        /// <returns>New instance of <see cref="Model"/> based on <paramref name="identificationModel"/></returns>
        public static Model ConvertToOptimization(IdentificationModel identificationModel)
        {
            Model optimizationModel = new Model();

            // 1. Copy the optimization parameters (X)
            CopyParameters(identificationModel.OptimizationParameters, optimizationModel.Parameters);

            // 2. Copy the identification parameters (α)
            Dictionary<TId, TId> parameterIds = CopyParameters(identificationModel.IdentificationParameters, optimizationModel.Parameters, true);

            // 3. Copy adequacy criteria (Φ). No conversion is needed
            CopyModelEntites<AdequacyCriterion, Criterion>(identificationModel.Criteria, optimizationModel.Criteria);

            // 4. Copy functional constraints (f)
            CopyModelEntites<Constraint, Constraint>(identificationModel.FunctionalConstraints, optimizationModel.FunctionalConstraints);

            // 5. Copy experiments
            CreateExperiments(identificationModel, optimizationModel.Experiments, parameterIds);
            CopyOptimizationParametersValues(identificationModel, optimizationModel.Experiments);

            return optimizationModel;
        }

        /// <summary>
        /// Copies references to <see cref="Parameter"/> instances from <paramref name="source"/> collection to the
        /// <paramref name="destination"/> collection, optionally - with IDs shift
        /// </summary>
        /// <param name="source">Source collection (copy from)</param>
        /// <param name="destination">Destination collection (copy to)</param>
        /// <param name="shiftIds">If True, method will create a deep copy of each <see cref="Parameter"/> instance
        /// and assign it new free ID from <paramref name="destination"/> collection</param>
        /// <returns>If <paramref name="shiftIds"/> is True, method will return a map of IDs: key is an ID of 
        /// <see cref="Parameter"/> instance in <paramref name="source"/> and value is this instance's ID in the
        /// <paramref name="destination"/></returns>
        private static Dictionary<TId, TId> CopyParameters(NamedModelEntityCollection<Parameter> source, 
            NamedModelEntityCollection<Parameter> destination, bool shiftIds = false)
        {
            Dictionary<TId, TId> idMap = new Dictionary<TId, TId>(source.Count);

            foreach (Parameter parameter in source.Values)
            {
                Parameter toAdd = parameter;
                if (shiftIds)
                {
                    TId newId = destination.GetFreeConsequentId();
                    // Here we are leaving Custom Properties behind, but that should be fine for now
                    toAdd = new Parameter(newId, parameter.Name, parameter.VariableIdentifier, parameter.MinValue, parameter.MaxValue);
                    idMap.Add(parameter.Id, newId);
                }

                destination.Add(toAdd);
            }

            return idMap;
        }

        /// <summary>
        /// Copies <see cref="NamedModelEntity"/> instances or instances of the derived classes from 
        /// <paramref name="source"/> collection to the <paramref name="destination"/> collection
        /// </summary>
        /// <typeparam name="TSource">Type of the source items</typeparam>
        /// <typeparam name="TDestination">Type of the destination items</typeparam>
        /// <param name="source">Source collection (copy from)</param>
        /// <param name="destination">Destination collection (copy to)</param>
        private static void CopyModelEntites<TSource, TDestination>(NamedModelEntityCollection<TSource> source, NamedModelEntityCollection<TDestination> destination)
            where TSource : TDestination
            where TDestination : NamedModelEntity, ICloneable
        {
            foreach (TSource item in source.Values)
            {
                destination.Add((TDestination)item.Clone());
            }
        }

        /// <summary>
        /// Creates <see cref="Model"/>'s experiments (<see cref="Experiment"/>) based on the <see cref="IdentificationExperiment"/>
        /// stored in the <paramref name="identificationModel"/> and puts them to the <paramref name="destination"/> collection
        /// </summary>
        /// <param name="identificationModel"><see cref="IdentificationModel"/> instance to take experiments from</param>
        /// <param name="destination">Destination collection (save experiments to)</param>
        /// <param name="identificationParameterIdMap">IDs map for parameters (<see cref="ModelsConverter.CopyParameters"/></param>
        private static void CreateExperiments(IdentificationModel identificationModel, ExperimentCollection destination, IDictionary<TId, TId> identificationParameterIdMap)
        {
            destination.Clear();
            foreach (IdentificationExperiment experiment in identificationModel.IdentificationExperiments.Values)
            {
                // Here we are leaving Custom Properties behind, but that should be fine for now
                Experiment toAdd = new Experiment(experiment.Id, experiment.Number);

                foreach (Parameter identificationParameter in identificationModel.IdentificationParameters.Values)
                {
                    TId parameterId = identificationParameterIdMap[identificationParameter.Id];
                    if (experiment.IdentificationParameterValues.ContainsKey(identificationParameter.Id))
                    {
                        toAdd.ParameterValues.Add(parameterId, experiment.IdentificationParameterValues[identificationParameter.Id]);
                    }
                }

                foreach (AdequacyCriterion criterion in identificationModel.Criteria.Values)
                {
                    if (experiment.AdequacyCriterionValues.ContainsKey(criterion.Id))
                    {
                        toAdd.CriterionValues.Add(criterion.Id, experiment.AdequacyCriterionValues[criterion.Id]);
                    }
                }

                foreach (Constraint constraint in identificationModel.FunctionalConstraints.Values)
                {
                    if (experiment.ConstraintValues.ContainsKey(constraint.Id))
                    {
                        toAdd.ConstraintValues.Add(constraint.Id, experiment.ConstraintValues[constraint.Id]);
                    }
                }

                destination.Add(toAdd);
            }
        }

        /// <summary>
        /// Copies values of optimization <see cref="Parameter"/>s from <paramref name="identificationModel"/>
        /// to the <see cref="Experiment"/> instances in <paramref name="destination"/> collection
        /// </summary>
        /// <param name="identificationModel"><see cref="IdentificationModel"/> instance to take values from</param>
        /// <param name="destination">Destination collection (set values to)</param>
        private static void CopyOptimizationParametersValues(IdentificationModel identificationModel, ExperimentCollection destination)
        {
            foreach (IdentificationExperiment experiment in identificationModel.IdentificationExperiments.Values)
            {
                Experiment toModify = destination[experiment.Id];
                Experiment realExperiment = identificationModel.RealExperiments[experiment.RealExperimentId];

                foreach (KeyValuePair<TId, double> optimizationParameter in realExperiment.ParameterValues)
                {
                    toModify.ParameterValues.Add(optimizationParameter.Key, optimizationParameter.Value);
                }
            }
        }
    }
}