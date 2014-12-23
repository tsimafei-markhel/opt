using System;
using System.Collections.Generic;
using System.Linq;

namespace opt.DataModel.New
{
    /// <summary>
    /// Represents a set parameter that can take any <see cref="Real"/> value
    /// within specified set
    /// </summary>
    /// <remarks>Immutable</remarks>
    [Serializable]
    public class SetParameter : Parameter
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
        /// Gets a set of possible parameter values
        /// </summary>
        public ISet<Real> Set { get; private set; }

        /// <summary>
        /// Initializes new instance of <see cref="ContinuousParameter"/>
        /// </summary>
        /// <param name="id">Parameter identifier</param>
        /// <param name="properties">A collection of entity properties</param>
        /// <param name="set">A set of possible parameter values</param>
        /// <exception cref="ArgumentNullException">If <paramref name="set"/>
        /// is null</exception>
        /// <exception cref="ArgumentException">If <paramref name="set"/> is
        /// empty</exception>
        protected SetParameter(
            TId id,
            PropertyDictionary properties,
            ISet<Real> set)
            : base(id, properties)
        {
            if (set == null)
            {
                throw new ArgumentNullException("set");
            }

            if (set.Count == 0)
            {
                // The below error message has to stay
                throw new ArgumentException("Set cannot be empty", "set");
            }

            Set = set;
            ComputeRange();
        }

        /// <summary>
        /// Initializes new instance of <see cref="ContinuousParameter"/>
        /// </summary>
        /// <param name="id">Parameter identifier</param>
        /// <param name="set">A set of possible parameter values</param>
        /// <exception cref="ArgumentNullException">If <paramref name="set"/>
        /// is null</exception>
        /// <exception cref="ArgumentException">If <paramref name="set"/> is
        /// empty</exception>
        public SetParameter(
            TId id,
            ISet<Real> set)
            : this(id, new PropertyDictionary(), set)
        {
        }

        /// <summary>
        /// Initializes <see cref="SetParameter.range"/> based on a <see cref="SetParameter.Set"/>
        /// </summary>
        private void ComputeRange()
        {
            if (Set != null && Set.Count > 0)
            {
                range = new Range(Set.Min(), Set.Max());
            }
        }

        /// <summary>
        /// Checks if a <paramref name="valueToCheck"/> is valid parameter value
        /// </summary>
        /// <param name="valueToCheck">Value to be checked</param>
        /// <returns>True if <paramref name="valueToCheck"/> can be used as a value
        /// of this parameter; otherwise false</returns>
        public override Boolean IsValidValue(Real valueToCheck)
        {
            return Set.Contains(valueToCheck);
        }

        /// <summary>
        /// Creates a deep copy of <see cref="SetParameter"/> instance
        /// </summary>
        /// <returns>Deep copy of self</returns>
        public override Object Clone()
        {
            return new SetParameter(Id, (PropertyDictionary)Properties.Clone(), Set);
        }
    }
}