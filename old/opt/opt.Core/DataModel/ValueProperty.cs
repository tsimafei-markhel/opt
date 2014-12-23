using System;

namespace opt.DataModel
{
    /// <summary>
    /// Base class for simple value-typed properties
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [Serializable]
    public abstract class ValueProperty<T> : CustomProperty
    {
        /// <summary>
        /// Gets or sets value of the property
        /// </summary>
        public T Value { get; set; }

        /// <summary>
        /// Initializes new instance of <see cref="ValueProperty"/> with specified value
        /// </summary>
        /// <param name="value">Value of a new property</param>
        protected ValueProperty(T value)
        {
            Value = value;
        }
    }
}