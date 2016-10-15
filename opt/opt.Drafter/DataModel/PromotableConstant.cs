using System;
using opt.DataModel;

namespace opt.Drafter.DataModel
{
    /// <summary>
    /// Represents a promotable constant - entity, that can represent constant value (in non-promoted state) 
    /// or an optimization parameter (in promoted state)
    /// </summary>
    public sealed class PromotableConstant : Parameter, ICloneable
    {
        // Not making this [Serializable] for now as we probably won't need it

        /// <summary>
        /// Gets or sets constant value
        /// </summary>
        public double Value { get; set; }

        /// <summary>
        /// Gets or sets <see cref="PromotableConstant"/> state - whether it is promoted to 
        /// <see cref="Parameter"/> (True) or not (False)
        /// </summary>
        public bool IsPromoted { get; set; }

        /// <summary>
        /// Initializes new instance of <see cref="PromotableConstant"/>
        /// </summary>
        /// <param name="id">Promotable constant identifier</param>
        /// <param name="name">Promotable constant name</param>
        /// <param name="variableIdentifier">Promotable constant variable identifier</param>
        /// <param name="value">Promotable constant value</param>
        /// <remarks>New instance is in non-promoted state; MinValue is -1.0, MaxValue is 1.0</remarks>
        public PromotableConstant(
            TId id,
            string name,
            string variableIdentifier,
            double value)
            : base(id, name, variableIdentifier, -1.0, 1.0)
        {
            Value = value;
            IsPromoted = false;
        }

        /// <summary>
        /// Creates new <see cref="Parameter"/> instance based on the current state of 
        /// the promoted <see cref="PromotableConstant"/> instance
        /// </summary>
        /// <returns>New <see cref="Parameter"/> instance</returns>
        /// <exception cref="InvalidOperationException">If an attempt to get <see cref="Parameter"/> 
        /// instance from the non-promoted state was made</exception>
        public Parameter GetParameter()
        {
            if (!IsPromoted)
            {
                throw new InvalidOperationException("Cannot get Parameter from the non-promoted Promotable constant");
            }

            return (Parameter)((Parameter)this).Clone();
        }

        /// <summary>
        /// Creates a deep copy of <see cref="PromotableConstant"/> instance
        /// </summary>
        /// <returns>Deep copy of self</returns>
        public new object Clone()
        {
            return new PromotableConstant(Id, Name, VariableIdentifier, Value)
            {
                MinValue = MinValue,
                MaxValue = MaxValue,
                IsPromoted = IsPromoted,
                Properties = (PropertyCollection)Properties.Clone()
            };
        }
    }
}