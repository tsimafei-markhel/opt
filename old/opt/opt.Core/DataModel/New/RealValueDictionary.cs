using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using opt.Units;

namespace opt.DataModel.New
{
    /// <summary>
    /// A collection of <see cref="Real"/> values
    /// </summary>
    [Serializable]
    public class RealValueDictionary : ValueDictionary<RealValue>
    {
        /// <summary>
        /// Initializes new instance of <see cref="RealValueDictionary"/>
        /// </summary>
        public RealValueDictionary() : base() { }

        /// <summary>
        /// Initializes new instance of <see cref="RealValueDictionary"/> with predefined capacity
        /// </summary>
        /// <param name="capacity">Desired capacity of a new <see cref="RealValueDictionary"/></param>
        public RealValueDictionary(Int32 capacity) : base(capacity) { }

        /// <summary>
        /// Initializes new instance of <see cref="RealValueDictionary"/> - for binary serialization
        /// </summary>
        /// <param name="info">A <see cref="SerializationInfo"/> object containing the information required 
        /// to serialize the <see cref="RealValueDictionary"/></param>
        /// <param name="context">A <see cref="StreamingContext"/> structure containing the
        /// source and destination of the serialized stream associated with the <see cref="RealValueDictionary"/></param>
        protected RealValueDictionary(SerializationInfo info, StreamingContext context) : base(info, context) { }

        /// <summary>
        /// Creates a deep copy of <see cref="RealValueDictionary"/> instance
        /// </summary>
        /// <returns>Deep copy of self</returns>
        public override Object Clone()
        {
            RealValueDictionary result = new RealValueDictionary(Count);
            foreach (KeyValuePair<TId, RealValue> value in this)
            {
                result.Add(value.Key, (RealValue)value.Value.MemberwiseClone());
            }

            return result;
        }
    }
}