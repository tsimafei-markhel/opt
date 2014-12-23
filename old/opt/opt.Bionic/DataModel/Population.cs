using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using opt.DataModel;

namespace opt.Bionic.DataModel
{
    /// <summary>
    /// A collection of <see cref="Individual"/>s that represent a population
    /// </summary>
    [Serializable]
    public sealed class Population : ModelEntityCollection<Individual>, ICloneable
    {
        /// <summary>
        /// Initializes new instance of <see cref="Population"/>
        /// </summary>
        public Population() : base() { }

        /// <summary>
        /// Initializes new instance of <see cref="Population"/> with predefined capacity
        /// </summary>
        /// <param name="capacity">Desired capacity of a new <see cref="Population"/></param>
        public Population(int capacity) : base(capacity) { }

        /// <summary>
        /// Initializes new instance of <see cref="Population"/> - for binary serialization
        /// </summary>
        /// <param name="info">A <see cref="SerializationInfo"/> object containing the information required 
        /// to serialize the <see cref="Population"/></param>
        /// <param name="context">A <see cref="StreamingContext"/> structure containing the
        /// source and destination of the serialized stream associated with the <see cref="Population"/></param>
        private Population(SerializationInfo info, StreamingContext context) : base(info, context) { }

        /// <summary>
        /// Creates a deep copy of <see cref="Population"/> instance
        /// </summary>
        /// <returns>Deep copy of self</returns>
        public object Clone()
        {
            Population clone = new Population(Count);
            foreach (KeyValuePair<TId, Individual> individual in this)
            {
                clone.Add(individual.Key, (Individual)individual.Value.Clone());
            }

            return clone;
        }
    }
}