using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace opt.DataModel
{
    /// <summary>
    /// A collection of <see cref="CustomProperty"/> or derived type instances
    /// </summary>
    [SuppressMessage("Microsoft.Naming", "CA1710:IdentifiersShouldHaveCorrectSuffix",
        Justification = "Fixed in opt.DataModel.New.PropertyDictionary class")]
    [SuppressMessage("Microsoft.Naming", "CA1711:IdentifiersShouldNotHaveIncorrectSuffix",
        Justification = "Fixed in opt.DataModel.New.PropertyDictionary class")]
    [Serializable]
    public sealed class PropertyCollection : Dictionary<string, CustomProperty>, ICloneable
    {
        /// <summary>
        /// Initializes new instance of <see cref="PropertyCollection"/>
        /// </summary>
        public PropertyCollection() : base() { }

        /// <summary>
        /// Initializes new instance of <see cref="PropertyCollection"/> with predefined capacity
        /// </summary>
        /// <param name="capacity">Desired capacity of a new <see cref="PropertyCollection"/></param>
        public PropertyCollection(int capacity) : base(capacity) { }

        /// <summary>
        /// Initializes new instance of <see cref="PropertyCollection"/> - for binary serialization
        /// </summary>
        /// <param name="info">A <see cref="SerializationInfo"/> object containing the information required 
        /// to serialize the <see cref="PropertyCollection"/></param>
        /// <param name="context">A <see cref="StreamingContext"/> structure containing the
        /// source and destination of the serialized stream associated with the <see cref="PropertyCollection"/></param>
        private PropertyCollection(SerializationInfo info, StreamingContext context) : base(info, context) { }

        /// <summary>
        /// Finds property of a desired type by its name
        /// </summary>
        /// <typeparam name="T">Type of the property to search for. 
        /// Must be <see cref="CustomProperty"/> or derived</typeparam>
        /// <param name="propertyName">Name of the property to search for</param>
        /// <returns>Property with specified <paramref name="propertyName"/> or null if 
        /// property with such name was not found or it cannot be casted to desired type</returns>
        public T GetProperty<T>(string propertyName) where T : CustomProperty
        {
            if (string.IsNullOrEmpty(propertyName))
            {
                throw new ArgumentNullException("propertyName");
            }

            CustomProperty property = null;
            if (TryGetValue(propertyName, out property))
            {
                return property as T;
            }

            return null;
        }

        /// <summary>
        /// Creates a deep copy of <see cref="PropertyCollection"/> instance
        /// </summary>
        /// <returns>Deep copy of self</returns>
        public object Clone()
        {
            PropertyCollection copy = new PropertyCollection(Count);
            foreach (KeyValuePair<string, CustomProperty> property in this)
            {
                copy.Add(property.Key, property.Value.Clone());
            }

            return copy;
        }
    }
}