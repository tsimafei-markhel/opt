using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace opt.DataModel
{
    /// <summary>
    /// A collection of <see cref="IdentificationExperiment"/> or derived type instances
    /// </summary>
    [Serializable]
    public class IdentificationExperimentCollection : ModelEntityCollection<IdentificationExperiment>, ICloneable
    {
        /// <summary>
        /// Initializes new instance of <see cref="IdentificationExperimentCollection"/>
        /// </summary>
        public IdentificationExperimentCollection() : base() { }

        /// <summary>
        /// Initializes new instance of <see cref="IdentificationExperimentCollection"/> with predefined capacity
        /// </summary>
        /// <param name="capacity">Desired capacity of a new <see cref="IdentificationExperimentCollection"/></param>
        public IdentificationExperimentCollection(int capacity) : base(capacity) { }

        /// <summary>
        /// Initializes new instance of <see cref="IdentificationExperimentCollection"/> - for binary serialization
        /// </summary>
        /// <param name="info">A <see cref="SerializationInfo"/> object containing the information required 
        /// to serialize the <see cref="IdentificationExperimentCollection"/></param>
        /// <param name="context">A <see cref="StreamingContext"/> structure containing the
        /// source and destination of the serialized stream associated with the <see cref="IdentificationExperimentCollection"/></param>
        private IdentificationExperimentCollection(SerializationInfo info, StreamingContext context) : base(info, context) { }

        /// <summary>
        /// Finds ID of an <see cref="IdentificationExperiment"/> with <paramref name="experimentNumber"/> number
        /// </summary>
        /// <param name="experimentNumber">Number of the <see cref="IdentificationExperiment"/> to search for</param>
        /// <returns>ID of an <see cref="IdentificationExperiment"/> with <paramref name="experimentNumber"/> number</returns>
        /// <exception cref="InvalidOperationException">If <see cref="IdentificationExperiment"/> with 
        /// <paramref name="experimentNumber"/> was not found</exception>
        public TId FindIdByNumber(int experimentNumber)
        {
            return Values.Where(e => e.Number == experimentNumber).Select(e => e.Id).First();
        }

        /// <summary>
        /// Finds <see cref="IdentificationExperiment"/> with <paramref name="experimentNumber"/> number
        /// </summary>
        /// <param name="experimentNumber">Number of the <see cref="IdentificationExperiment"/> to search for</param>
        /// <returns><see cref="IdentificationExperiment"/> with <paramref name="experimentNumber"/> number
        /// or null if such element was not found</returns>
        public IdentificationExperiment FindByNumber(int experimentNumber)
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
        /// Creates a deep copy of <see cref="IdentificationExperimentCollection"/> instance
        /// </summary>
        /// <returns>Deep copy of self</returns>
        public virtual object Clone()
        {
            IdentificationExperimentCollection clone = new IdentificationExperimentCollection(Count);
            foreach (KeyValuePair<TId, IdentificationExperiment> experiment in this)
            {
                clone.Add(experiment.Key, (IdentificationExperiment)experiment.Value.Clone());
            }

            return clone;
        }
    }
}