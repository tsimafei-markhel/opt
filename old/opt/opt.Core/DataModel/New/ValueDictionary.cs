using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace opt.DataModel.New
{
    [Serializable]
    public abstract class ValueDictionary<TValue> : Dictionary<TId, TValue>
    {
        /// <summary>
        /// Initializes new instance of <see cref="ValueDictionary"/>
        /// </summary>
        protected ValueDictionary() : base() { }

        /// <summary>
        /// Initializes new instance of <see cref="ValueDictionary"/> with predefined capacity
        /// </summary>
        /// <param name="capacity">Desired capacity of a new <see cref="ValueDictionary"/></param>
        protected ValueDictionary(Int32 capacity) : base(capacity) { }

        /// <summary>
        /// Initializes new instance of <see cref="ValueDictionary"/> - for binary serialization
        /// </summary>
        /// <param name="info">A <see cref="SerializationInfo"/> object containing the information required 
        /// to serialize the <see cref="ValueDictionary"/></param>
        /// <param name="context">A <see cref="StreamingContext"/> structure containing the
        /// source and destination of the serialized stream associated with the <see cref="ValueDictionary"/></param>
        protected ValueDictionary(SerializationInfo info, StreamingContext context) : base(info, context) { }

        /// <summary>
        /// Creates a deep copy of <see cref="ValueDictionary"/> instance
        /// </summary>
        /// <returns>Deep copy of self</returns>
        public abstract Object Clone();
    }
}