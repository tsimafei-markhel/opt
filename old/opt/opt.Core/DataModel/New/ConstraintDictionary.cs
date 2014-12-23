using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace opt.DataModel.New
{
    /// <summary>
    /// A collection of <see cref="Constraint"/> or derived type instances. Just a
    /// typed wrapper over <see cref="ModelEntityDictionary"/>
    /// </summary>
    [Serializable]
    public class ConstraintDictionary : ModelEntityDictionary<Constraint>
    {
        /// <summary>
        /// Initializes new instance of <see cref="ConstraintDictionary"/>
        /// </summary>
        public ConstraintDictionary() : base() { }

        /// <summary>
        /// Initializes new instance of <see cref="ConstraintDictionary"/> with predefined capacity
        /// </summary>
        /// <param name="capacity">Desired capacity of a new <see cref="ConstraintDictionary"/></param>
        public ConstraintDictionary(Int32 capacity) : base(capacity) { }

        /// <summary>
        /// Initializes new instance of <see cref="ConstraintDictionary"/> - for binary serialization
        /// </summary>
        /// <param name="info">A <see cref="SerializationInfo"/> object containing the information required 
        /// to serialize the <see cref="ConstraintDictionary"/></param>
        /// <param name="context">A <see cref="StreamingContext"/> structure containing the
        /// source and destination of the serialized stream associated with the <see cref="ConstraintDictionary"/></param>
        protected ConstraintDictionary(SerializationInfo info, StreamingContext context) : base(info, context) { }

        /// <summary>
        /// Creates a deep copy of <see cref="ConstraintDictionary"/> instance
        /// </summary>
        /// <returns>Deep copy of self</returns>
        public override Object Clone()
        {
            ConstraintDictionary result = new ConstraintDictionary(Count);
            foreach (KeyValuePair<TId, Constraint> constraint in this)
            {
                result.Add(constraint.Key, (Constraint)constraint.Value.Clone());
            }

            return result;
        }
    }
}