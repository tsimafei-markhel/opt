using System;

// TODO: Think over the interface...

namespace opt.DataModel.New
{
    /// <summary>
    /// Represents a parameter
    /// </summary>
    [Serializable]
    public abstract class Parameter : ModelEntity
    {
        /// <summary>
        /// Initializes new instance of <see cref="Parameter"/>
        /// </summary>
        /// <param name="id">Parameter identifier</param>
        /// <param name="properties">Parameter properties collection</param>
        protected Parameter(TId id, PropertyDictionary properties)
            : base(id, properties)
        {
        }

        /// <summary>
        /// Initializes new instance of <see cref="Parameter"/>
        /// </summary>
        /// <param name="id">Parameter identifier</param>
        protected Parameter(TId id)
            : this(id, new PropertyDictionary())
        {
        }

        /// <summary>
        /// Checks if a <paramref name="valueToCheck"/> is valid parameter value
        /// </summary>
        /// <param name="valueToCheck">Value to be checked</param>
        /// <returns>True if <paramref name="valueToCheck"/> can be used as a value
        /// of this parameter; otherwise false</returns>
        public abstract Boolean IsValidValue(Real valueToCheck);

        /// <summary>
        /// Gets <see cref="Range"/> instance identifying minimal and maximal possible
        /// values for this parameter
        /// </summary>
        public abstract Range Range { get; }
    }
}