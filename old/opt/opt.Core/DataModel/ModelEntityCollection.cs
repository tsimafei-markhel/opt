using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace opt.DataModel
{
    /// <summary>
    /// A collection of model entities or derived type instances
    /// </summary>
    [Serializable]
    public abstract class ModelEntityCollection<T> : Dictionary<TId, T> where T : ModelEntity
    {
        /// <summary>
        /// Initializes new instance of <see cref="ModelEntityCollection"/>
        /// </summary>
        protected ModelEntityCollection() : base() { }

        /// <summary>
        /// Initializes new instance of <see cref="ModelEntityCollection"/> with predefined capacity
        /// </summary>
        /// <param name="capacity">Desired capacity of a new <see cref="ModelEntityCollection"/></param>
        protected ModelEntityCollection(int capacity) : base(capacity) { }

        /// <summary>
        /// Initializes new instance of <see cref="ModelEntityCollection"/> - for binary serialization
        /// </summary>
        /// <param name="info">A <see cref="SerializationInfo"/> object containing the information required 
        /// to serialize the <see cref="ModelEntityCollection"/></param>
        /// <param name="context">A <see cref="StreamingContext"/> structure containing the
        /// source and destination of the serialized stream associated with the <see cref="ModelEntityCollection"/></param>
        protected ModelEntityCollection(SerializationInfo info, StreamingContext context) : base(info, context) { }

        /// <summary>
        /// Provides next free ID for an entity to be added to this collection
        /// </summary>
        /// <returns>Next free ID for an entity to be added to this collection</returns>
        /// <exception cref="InvalidOperationException">Thrown if key with <see cref="int.MaxValue"/> exists in the collection</exception>
        public virtual TId GetFreeConsequentId()
        {
            if (Count == 0)
            {
                return 0;
            }

            int keysMax = Keys.Max();
            if (keysMax == int.MaxValue)
            {
                throw new InvalidOperationException("Maximum ID reached");
            }

            return keysMax + 1;
        }

        /// <summary>
        /// Adds new item into collection, uses <see cref="T.Id"/> as key
        /// </summary>
        /// <param name="item">Item to be added into collection</param>
        /// <remarks>Does not copy the <paramref name="item"/></remarks>
        public virtual void Add(T item)
        {
            Add(item.Id, item);
        }
    }
}