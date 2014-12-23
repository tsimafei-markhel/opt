using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace opt.DataModel.New
{
    /// <summary>
    /// A collection of <see cref="Experiment"/> or derived type instances. Just a
    /// typed wrapper over <see cref="ModelEntityDictionary"/>
    /// </summary>
    [Serializable]
    public class ExperimentDictionary : ModelEntityDictionary<Experiment>
    {
        /// <summary>
        /// Initializes new instance of <see cref="ExperimentDictionary"/>
        /// </summary>
        public ExperimentDictionary() : base() { }

        /// <summary>
        /// Initializes new instance of <see cref="ExperimentDictionary"/> with predefined capacity
        /// </summary>
        /// <param name="capacity">Desired capacity of a new <see cref="ExperimentDictionary"/></param>
        public ExperimentDictionary(Int32 capacity) : base(capacity) { }

        /// <summary>
        /// Initializes new instance of <see cref="ExperimentDictionary"/> - for binary serialization
        /// </summary>
        /// <param name="info">A <see cref="SerializationInfo"/> object containing the information required 
        /// to serialize the <see cref="ExperimentDictionary"/></param>
        /// <param name="context">A <see cref="StreamingContext"/> structure containing the
        /// source and destination of the serialized stream associated with the <see cref="ExperimentDictionary"/></param>
        protected ExperimentDictionary(SerializationInfo info, StreamingContext context) : base(info, context) { }

        /// <summary>
        /// Creates a deep copy of <see cref="ExperimentDictionary"/> instance
        /// </summary>
        /// <returns>Deep copy of self</returns>
        public override Object Clone()
        {
            ExperimentDictionary result = new ExperimentDictionary(Count);
            foreach (KeyValuePair<TId, Experiment> experiment in this)
            {
                result.Add(experiment.Key, (Experiment)experiment.Value.Clone());
            }

            return result;
        }
    }
}