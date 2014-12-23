using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

// TODO: Add validation

namespace opt.DataModel
{
    /// <summary>
    /// A collection of named model entities or derived type instances
    /// </summary>
    [Serializable]
    public class NamedModelEntityCollection<T> : ModelEntityCollection<T>, ICloneable where T: NamedModelEntity, ICloneable
    {
        /// <summary>
        /// Initializes new instance of <see cref="NamedModelEntityCollection"/>
        /// </summary>
        public NamedModelEntityCollection() : base() { }

        /// <summary>
        /// Initializes new instance of <see cref="NamedModelEntityCollection"/> with predefined capacity
        /// </summary>
        /// <param name="capacity">Desired capacity of a new <see cref="NamedModelEntityCollection"/></param>
        public NamedModelEntityCollection(int capacity) : base(capacity) { }

        /// <summary>
        /// Initializes new instance of <see cref="NamedModelEntityCollection"/> - for binary serialization
        /// </summary>
        /// <param name="info">A <see cref="SerializationInfo"/> object containing the information required 
        /// to serialize the <see cref="NamedModelEntityCollection"/></param>
        /// <param name="context">A <see cref="StreamingContext"/> structure containing the
        /// source and destination of the serialized stream associated with the <see cref="NamedModelEntityCollection"/></param>
        protected NamedModelEntityCollection(SerializationInfo info, StreamingContext context) : base(info, context) { }

        /// <summary>
        /// Finds ID of a named entity with specified name
        /// </summary>
        /// <param name="name">Name of the element to search for</param>
        /// <returns>ID of a named model entity with specified <paramref name="name"/></returns>
        /// <exception cref="InvalidOperationException">If a named model entity with 
        /// <paramref name="name"/> was not found</exception>
        public virtual TId FindIdByName(string name)
        {
            return Values.Where(e => e.Name.Equals(name, StringComparison.Ordinal)).Select(e => e.Id).First();
        }

        /// <summary>
        /// Finds a named entity with specified name
        /// </summary>
        /// <param name="name">Name of the element to search for</param>
        /// <returns>An element with specified <paramref name="name"/> or null
        /// if such element was not found</returns>
        public virtual T FindByName(string name)
        {
            return Values.Where(e => e.Name.Equals(name, StringComparison.Ordinal)).FirstOrDefault();
        }

        /// <summary>
        /// Finds ID of a named entity with specified variable identifier
        /// </summary>
        /// <param name="variableIdentifier">Variable identifier of the element to search for</param>
        /// <returns>ID of a named model entity with specified <paramref name="variableIdentifier"/></returns>
        /// <exception cref="InvalidOperationException">If a named model entity with 
        /// <paramref name="variableIdentifier"/> was not found</exception>
        public virtual TId FindIdByVariableIdentifier(string variableIdentifier)
        {
            return Values.Where(e => e.VariableIdentifier.Equals(variableIdentifier, StringComparison.Ordinal)).Select(e => e.Id).First();
        }

        /// <summary>
        /// Finds a named entity with specified variable identifier
        /// </summary>
        /// <param name="variableIdentifier">Variable identifier of the element to search for</param>
        /// <returns>An element with specified <paramref name="variableIdentifier"/> or null
        /// if such element was not found</returns>
        public virtual T FindByVariableIdentifier(string variableIdentifier)
        {
            return Values.Where(e => e.VariableIdentifier.Equals(variableIdentifier, StringComparison.Ordinal)).FirstOrDefault();
        }

        /// <summary>
        /// Creates a deep copy of <see cref="NamedModelEntityCollection{T}"/> instance
        /// </summary>
        /// <returns>Deep copy of self</returns>
        public virtual object Clone()
        {
            NamedModelEntityCollection<T> copy = new NamedModelEntityCollection<T>(Count);
            foreach (KeyValuePair<TId, T> item in this)
            {
                copy.Add(item.Key, (T)item.Value.Clone());
            }

            return copy;
        }
    }
}