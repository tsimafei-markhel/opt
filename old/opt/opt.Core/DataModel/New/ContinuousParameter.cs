using System;

namespace opt.DataModel.New
{
    /// <summary>
    /// Represents a continuous parameter that can take any <see cref="Real"/> value
    /// within specified <see cref="Range"/>
    /// </summary>
    /// <remarks>Immutable</remarks>
    [Serializable]
    public class ContinuousParameter : Parameter
    {
        /// <summary>
        /// Stores parameter range
        /// </summary>
        private Range range;

        /// <summary>
        /// Gets <see cref="Range"/> instance identifying minimal and maximal possible
        /// values for this parameter. Range ends are always closed
        /// </summary>
        public override Range Range
        {
            get { return range; }
        }

        /// <summary>
        /// Initializes new instance of <see cref="ContinuousParameter"/>
        /// </summary>
        /// <param name="id">Parameter identifier</param>
        /// <param name="properties">A collection of entity properties</param>
        /// <param name="variationRange"><see cref="Range"/> instance that determines minimal and
        /// maximal possible values for this parameter. Note: resulting <see cref="ContinuousParameter"/>
        /// instance will have closed ends despite what is specified in this parameter</param>
        protected ContinuousParameter(
            TId id,
            PropertyDictionary properties,
            Range variationRange)
            : base(id, properties)
        {
            if (variationRange.IsMaximumOpen || variationRange.IsMinimumOpen)
            {
                range = new Range(variationRange.Minimum, variationRange.Maximum);
            }
            else
            {
                range = variationRange;
            }
        }

        /// <summary>
        /// Initializes new instance of <see cref="ContinuousParameter"/>
        /// </summary>
        /// <param name="id">Parameter identifier</param>
        /// <param name="variationRange"><see cref="Range"/> instance that determines minimal and
        /// maximal possible values for this parameter. Note: resulting <see cref="ContinuousParameter"/>
        /// instance will have closed ends despite what is specified in this parameter</param>
        public ContinuousParameter(
            TId id,
            Range variationRange)
            : this(id, new PropertyDictionary(), variationRange)
        {
        }

        /// <summary>
        /// Checks if a <paramref name="valueToCheck"/> is valid parameter value
        /// </summary>
        /// <param name="valueToCheck">Value to be checked</param>
        /// <returns>True if <paramref name="valueToCheck"/> can be used as a value
        /// of this parameter; otherwise false</returns>
        public override Boolean IsValidValue(Real valueToCheck)
        {
            return Range.IsInRange(valueToCheck);
        }

        /// <summary>
        /// Creates a deep copy of <see cref="ContinuousParameter"/> instance
        /// </summary>
        /// <returns>Deep copy of self</returns>
        public override Object Clone()
        {
            return new ContinuousParameter(Id, (PropertyDictionary)Properties.Clone(), Range);
        }
    }
}