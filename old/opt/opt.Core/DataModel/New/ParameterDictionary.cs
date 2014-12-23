using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace opt.DataModel.New
{
    /// <summary>
    /// A collection of <see cref="Parameter"/> or derived type instances. Just a
    /// typed wrapper over <see cref="ModelEntityDictionary"/>
    /// </summary>
    [Serializable]
    public class ParameterDictionary : ModelEntityDictionary<Parameter>
    {
        /// <summary>
        /// Initializes new instance of <see cref="ParameterDictionary"/>
        /// </summary>
        public ParameterDictionary() : base() { }

        /// <summary>
        /// Initializes new instance of <see cref="ParameterDictionary"/> with predefined capacity
        /// </summary>
        /// <param name="capacity">Desired capacity of a new <see cref="ParameterDictionary"/></param>
        public ParameterDictionary(Int32 capacity) : base(capacity) { }

        /// <summary>
        /// Initializes new instance of <see cref="ParameterDictionary"/> - for binary serialization
        /// </summary>
        /// <param name="info">A <see cref="SerializationInfo"/> object containing the information required 
        /// to serialize the <see cref="ParameterDictionary"/></param>
        /// <param name="context">A <see cref="StreamingContext"/> structure containing the
        /// source and destination of the serialized stream associated with the <see cref="ParameterDictionary"/></param>
        protected ParameterDictionary(SerializationInfo info, StreamingContext context) : base(info, context) { }

        /// <summary>
        /// Creates a deep copy of <see cref="ParameterDictionary"/> instance
        /// </summary>
        /// <returns>Deep copy of self</returns>
        public override Object Clone()
        {
            ParameterDictionary result = new ParameterDictionary(Count);
            foreach (KeyValuePair<TId, Parameter> parameter in this)
            {
                result.Add(parameter.Key, (Parameter)parameter.Value.Clone());
            }

            return result;
        }
    }
}