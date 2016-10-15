using System;
using System.Collections.Generic;
using System.Linq;
using opt.Bionic.DataModel;
using opt.DataModel;
using opt.Helpers;

namespace opt.Bionic.Helpers
{
    public sealed class ModelsConverterSettings
    {
        public bool UseRecordPoint { get; set; }
        public uint NeighborhoodSizePercent { get; set; }
        public TId FitnessCriterionId { get; set; }

        public ModelsConverterSettings()
        {
            UseRecordPoint = false;
            NeighborhoodSizePercent = 5;
            FitnessCriterionId = -1;
        }
    }

    public static class ModelsConverter
    {
        public static BionicModel ModelToBionicModel(Model source, ModelsConverterSettings settings)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }

            if (settings == null)
            {
                throw new ArgumentNullException("settings");
            }

            BionicModel result = new BionicModel();

            ConvertAttributes(source, settings, result);
            CopyFitnessCriterion(source, settings, result);
            CopyFunctionalConstraints(source, result);

            return result;
        }

        private static void CopyFunctionalConstraints(Model source, BionicModel destination)
        {
            foreach (Constraint constraint in source.FunctionalConstraints.Values)
            {
                destination.FunctionalConstraints.Add((Constraint)constraint.Clone());
            }
        }

        private static void CopyFitnessCriterion(Model source, ModelsConverterSettings settings, BionicModel destination)
        {
            destination.FitnessCriterion = (Criterion)source.Criteria[settings.FitnessCriterionId].Clone();
        }

        private static void ConvertAttributes(Model source, ModelsConverterSettings settings, BionicModel destination)
        {
            if (settings.UseRecordPoint)
            {
                Experiment recordPoint = GetRecordPoint(source, settings.FitnessCriterionId);
                foreach (Parameter parameter in source.Parameters.Values)
                {
                    Range attributeRange = RangeFactory.CreateRangeWithRestriction(recordPoint.ParameterValues[parameter.Id], settings.NeighborhoodSizePercent, parameter.MinValue, parameter.MaxValue);
                    Parameter attribute = (Parameter)parameter.Clone();
                    attribute.MinValue = attributeRange.MinValue;
                    attribute.MaxValue = attributeRange.MaxValue;
                    destination.Attributes.Add(attribute);
                }
            }
            else
            {
                foreach (Parameter parameter in source.Parameters.Values)
                {
                    destination.Attributes.Add((Parameter)parameter.Clone());
                }
            }
        }

        private static Experiment GetRecordPoint(Model source, TId criterionId)
        {
            source.ApplyFunctionalConstraints();
            List<Experiment> activeExperiments = source.Experiments.Where(exp => exp.Value.IsActive).Select(exp => exp.Value).ToList();
            List<SortableDouble> sortedExperiments = activeExperiments.Select<Experiment, SortableDouble>(
                    e => new SortableDouble() { Direction = source.Criteria[criterionId].SortDirection, Id = e.Id, Value = e.CriterionValues[criterionId] }
                ).ToList();
            sortedExperiments.Sort();

            return source.Experiments[sortedExperiments.First().Id];
        }

        public static Model BionicModelToModel(BionicModel source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }

            Model result = new Model();

            CopyParameters(source, result);
            CopyCriterion(source, result);
            CopyFunctionalConstraints(source, result);
            ConvertExperiments(source, result);

            return result;
        }

        private static void ConvertExperiments(BionicModel source, Model destination)
        {
            foreach (Individual individual in source.CurrentPopulation.Values)
            {
                if (double.IsNaN(individual.FitnessValue))
                {
                    Experiment experiment = new Experiment(individual.Id, individual.Id);
                    foreach (Parameter attribute in source.Attributes.Values)
                    {
                        experiment.ParameterValues.Add(attribute.Id, individual.AttributeValues[attribute.Id]);
                    }

                    destination.Experiments.Add(experiment);
                }
            }
        }

        private static void CopyFunctionalConstraints(BionicModel source, Model destination)
        {
            foreach (Constraint constraint in source.FunctionalConstraints.Values)
            {
                destination.FunctionalConstraints.Add((Constraint)constraint.Clone());
            }
        }

        private static void CopyCriterion(BionicModel source, Model destination)
        {
            destination.Criteria.Add((Criterion)source.FitnessCriterion.Clone());
        }

        private static void CopyParameters(BionicModel source, Model destination)
        {
            foreach (Parameter attribute in source.Attributes.Values)
            {
                destination.Parameters.Add((Parameter)attribute.Clone());
            }
        }
    }
}