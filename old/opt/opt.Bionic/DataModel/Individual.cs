using System;
using System.Collections.Generic;
using opt.DataModel;

namespace opt.Bionic.DataModel
{
    [Serializable]
    public sealed class Individual : ModelEntity, ICloneable
    {
        public uint GenerationNumber { get; private set; }
        public double FitnessValue { get; set; }
        public Dictionary<TId, double> AttributeValues { get; private set; }
        public Dictionary<TId, double> ConstraintValues { get; private set; }
        public bool IsActive { get; set; }

        public Individual(
            TId id,
            uint generationNumber,
            IDictionary<TId, double> attributeValues)
            : base(id)
        {
            GenerationNumber = generationNumber;
            FitnessValue = double.NaN;
            if (attributeValues != null)
            {
                AttributeValues = new Dictionary<TId, double>(attributeValues);
            }
            else
            {
                AttributeValues = new Dictionary<TId, double>();
            }

            ConstraintValues = new Dictionary<TId, double>();
            IsActive = true;
        }

        public Individual(
            TId id,
            uint generationNumber)
            : this(id, generationNumber, null)
        {
        }

        public object Clone()
        {
            return new Individual(Id, GenerationNumber, AttributeValues)
                {
                    FitnessValue = FitnessValue,
                    ConstraintValues = new Dictionary<TId, double>(ConstraintValues)
                };
            // Skip Properties copying for now
        }
    }
}