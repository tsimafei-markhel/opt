using opt.DataModel;
using opt.Helpers;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace opt.Bionic.DataModel
{
    [Serializable]
    public sealed class BionicModel : ICloneable
    {
        public NamedModelEntityCollection<Parameter> Attributes { get; private set; }
        public Criterion FitnessCriterion { get; set; }
        public NamedModelEntityCollection<Constraint> FunctionalConstraints { get; private set; }
        public Population CurrentPopulation { get; private set; }
        public uint CurrentGeneration { get; set; }

        public BionicModel()
        {
            Attributes = new NamedModelEntityCollection<Parameter>();
            FitnessCriterion = null;
            FunctionalConstraints = new NamedModelEntityCollection<Constraint>();
            CurrentPopulation = new Population();
            CurrentGeneration = 0;
        }

        /// <summary>
        /// Marks experiments that do not match functional constraints as inactive;
        /// marks all matching experiments as active
        /// </summary>
        public void ApplyFunctionalConstraints()
        {
            Parallel.ForEach<Individual>(CurrentPopulation.Values, individual => ApplyFunctionalConstraints(individual));
        }

        private void ApplyFunctionalConstraints(Individual individual)
        {
            individual.IsActive = true;
            foreach (KeyValuePair<TId, double> constraint in individual.ConstraintValues)
            {
                if (FunctionalConstraints.ContainsKey(constraint.Key))
                {
                    if (!Comparer.CompareValuesWithSign(
                            constraint.Value,
                            FunctionalConstraints[constraint.Key].Value,
                            FunctionalConstraints[constraint.Key].ConstraintRelation)
                        )
                    {
                        individual.IsActive = false;
                        // It is enough to fail only one f. c.
                        break;
                    }
                }
            }
        }

        public object Clone()
        {
            return new BionicModel()
                {
                    Attributes = (NamedModelEntityCollection<Parameter>)Attributes.Clone(),
                    FitnessCriterion = (Criterion)FitnessCriterion.Clone(),
                    FunctionalConstraints = (NamedModelEntityCollection<Constraint>)FunctionalConstraints.Clone(),
                    CurrentPopulation = (Population)CurrentPopulation.Clone(),
                    CurrentGeneration = CurrentGeneration
                };
        }
    }
}