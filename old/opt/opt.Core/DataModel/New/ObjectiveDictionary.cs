using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace opt.DataModel.New
{
    /// <summary>
    /// A collection of <see cref="Objective"/> or derived type instances. Just a
    /// typed wrapper over <see cref="ModelEntityDictionary"/>
    /// </summary>
    [Serializable]
    public class ObjectiveDictionary : ModelEntityDictionary<Objective>
    {
        /// <summary>
        /// Initializes new instance of <see cref="ObjectiveDictionary"/>
        /// </summary>
        public ObjectiveDictionary() : base() { }

        /// <summary>
        /// Initializes new instance of <see cref="ObjectiveDictionary"/> with predefined capacity
        /// </summary>
        /// <param name="capacity">Desired capacity of a new <see cref="ObjectiveDictionary"/></param>
        public ObjectiveDictionary(Int32 capacity) : base(capacity) { }

        /// <summary>
        /// Initializes new instance of <see cref="ObjectiveDictionary"/> - for binary serialization
        /// </summary>
        /// <param name="info">A <see cref="SerializationInfo"/> object containing the information required 
        /// to serialize the <see cref="ObjectiveDictionary"/></param>
        /// <param name="context">A <see cref="StreamingContext"/> structure containing the
        /// source and destination of the serialized stream associated with the <see cref="ObjectiveDictionary"/></param>
        protected ObjectiveDictionary(SerializationInfo info, StreamingContext context) : base(info, context) { }

        /// <summary>
        /// Creates a deep copy of <see cref="ObjectiveDictionary"/> instance
        /// </summary>
        /// <returns>Deep copy of self</returns>
        public override Object Clone()
        {
            ObjectiveDictionary result = new ObjectiveDictionary(Count);
            foreach (KeyValuePair<TId, Objective> objective in this)
            {
                result.Add(objective.Key, (Objective)objective.Value.Clone());
            }

            return result;
        }
    }
}