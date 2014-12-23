using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace opt.DataModel.New
{
    /// <summary>
    /// A collection of model entities or derived type instances
    /// </summary>
    [Serializable]
    public abstract class ModelEntityDictionary<T> : Dictionary<TId, T> where T : ModelEntity
    {
        /// <summary>
        /// Initializes new instance of <see cref="ModelEntityDictionary"/>
        /// </summary>
        protected ModelEntityDictionary() : base() { }

        /// <summary>
        /// Initializes new instance of <see cref="ModelEntityDictionary"/> with predefined capacity
        /// </summary>
        /// <param name="capacity">Desired capacity of a new <see cref="ModelEntityDictionary"/></param>
        protected ModelEntityDictionary(Int32 capacity) : base(capacity) { }

        /// <summary>
        /// Initializes new instance of <see cref="ModelEntityDictionary"/> - for binary serialization
        /// </summary>
        /// <param name="info">A <see cref="SerializationInfo"/> object containing the information required 
        /// to serialize the <see cref="ModelEntityDictionary"/></param>
        /// <param name="context">A <see cref="StreamingContext"/> structure containing the
        /// source and destination of the serialized stream associated with the <see cref="ModelEntityDictionary"/></param>
        protected ModelEntityDictionary(SerializationInfo info, StreamingContext context) : base(info, context) { }

        /// <summary>
        /// Adds new item into collection, uses <see cref="T.Id"/> as key
        /// </summary>
        /// <param name="item">Item to be added into collection</param>
        /// <remarks>Does not copy the <paramref name="item"/></remarks>
        public virtual void Add(T item)
        {
            Add(item.Id, item);
        }

        /// <summary>
        /// Creates a deep copy of <see cref="ModelEntityDictionary"/> instance
        /// </summary>
        /// <returns>Deep copy of self</returns>
        public abstract Object Clone();
    }
}