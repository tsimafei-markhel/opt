using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace opt.DataModel
{
    /// <summary>
    /// A collection of <see cref="Experiment"/> or derived type instances
    /// </summary>
    [Serializable]
    public sealed class ExperimentCollection : ModelEntityCollection<Experiment>, ICloneable
    {
        /// <summary>
        /// Initializes new instance of <see cref="ExperimentCollection"/>
        /// </summary>
        public ExperimentCollection() : base() { }

        /// <summary>
        /// Initializes new instance of <see cref="ExperimentCollection"/> with predefined capacity
        /// </summary>
        /// <param name="capacity">Desired capacity of a new <see cref="ExperimentCollection"/></param>
        public ExperimentCollection(int capacity) : base(capacity) { }

        /// <summary>
        /// Initializes new instance of <see cref="ExperimentCollection"/> - for binary serialization
        /// </summary>
        /// <param name="info">A <see cref="SerializationInfo"/> object containing the information required 
        /// to serialize the <see cref="ExperimentCollection"/></param>
        /// <param name="context">A <see cref="StreamingContext"/> structure containing the
        /// source and destination of the serialized stream associated with the <see cref="ExperimentCollection"/></param>
        private ExperimentCollection(SerializationInfo info, StreamingContext context) : base(info, context) { }

        /// <summary>
        /// Finds ID of an <see cref="Experiment"/> with <paramref name="experimentNumber"/> number
        /// </summary>
        /// <param name="experimentNumber">Number of the <see cref="Experiment"/> to search for</param>
        /// <returns>ID of an <see cref="Experiment"/> with <paramref name="experimentNumber"/> number</returns>
        /// <exception cref="InvalidOperationException">If <see cref="Experiment"/> with 
        /// <paramref name="experimentNumber"/> was not found</exception>
        public TId FindIdByNumber(int experimentNumber)
        {
            return Values.Where(e => e.Number == experimentNumber).Select(e => e.Id).First();
        }

        /// <summary>
        /// Finds <see cref="Experiment"/> with <paramref name="experimentNumber"/> number
        /// </summary>
        /// <param name="experimentNumber">Number of the <see cref="Experiment"/> to search for</param>
        /// <returns><see cref="Experiment"/> with <paramref name="experimentNumber"/> number or null
        /// if such element was not found</returns>
        public Experiment FindByNumber(int experimentNumber)
        {
            return Values.Where(e => e.Number == experimentNumber).FirstOrDefault();
        }

        /// <summary>
        /// Counts active experiments (those satisfying various constraints)
        /// </summary>
        /// <returns>Number of active experiments</returns>
        public int CountActiveExperiments()
        {
            return Values.Count(e => e.IsActive);
        }

        /// <summary>
        /// Removes all inactive experiments from the collection
        /// </summary>
        public void RemoveInactiveExperiments()
        {
            List<TId> inactiveExperimentIds = Values.Where(e => !e.IsActive).Select(e => e.Id).ToList();
            foreach (TId inactiveId in inactiveExperimentIds)
            {
                Remove(inactiveId);
            }
        }

        /// <summary>
        /// Creates a deep copy of <see cref="ExperimentCollection"/> instance
        /// </summary>
        /// <returns>Deep copy of self</returns>
        public object Clone()
        {
            ExperimentCollection clone = new ExperimentCollection(Count);
            foreach (KeyValuePair<TId, Experiment> experiment in this)
            {
                clone.Add(experiment.Key, (Experiment)experiment.Value.Clone());
            }

            return clone;
        }
    }
}