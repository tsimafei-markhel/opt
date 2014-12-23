using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace opt.DataModel.New
{
    /// <summary>
    /// A collection of <see cref="CustomProperty"/> or derived type instances
    /// </summary>
    [Serializable]
    public sealed class PropertyDictionary : Dictionary<String, CustomProperty>, ICloneable
    {
        /// <summary>
        /// Initializes new instance of <see cref="PropertyDictionary"/>
        /// </summary>
        public PropertyDictionary() : base() { }

        /// <summary>
        /// Initializes new instance of <see cref="PropertyDictionary"/> with predefined capacity
        /// </summary>
        /// <param name="capacity">Desired capacity of a new <see cref="PropertyDictionary"/></param>
        public PropertyDictionary(Int32 capacity) : base(capacity) { }

        /// <summary>
        /// Initializes new instance of <see cref="PropertyDictionary"/> - for binary serialization
        /// </summary>
        /// <param name="info">A <see cref="SerializationInfo"/> object containing the information required 
        /// to serialize the <see cref="PropertyDictionary"/></param>
        /// <param name="context">A <see cref="StreamingContext"/> structure containing the
        /// source and destination of the serialized stream associated with the <see cref="PropertyDictionary"/></param>
        private PropertyDictionary(SerializationInfo info, StreamingContext context) : base(info, context) { }

        /// <summary>
        /// Creates a deep copy of <see cref="PropertyDictionary"/> instance
        /// </summary>
        /// <returns>Deep copy of self</returns>
        public object Clone()
        {
            PropertyDictionary copy = new PropertyDictionary(Count);
            foreach (KeyValuePair<string, CustomProperty> property in this)
            {
                copy.Add(property.Key, (CustomProperty)property.Value.Clone());
            }

            return copy;
        }
    }
}