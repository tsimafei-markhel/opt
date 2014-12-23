using System;

// TODO: Add validation

namespace opt.DataModel
{
    /// <summary>
    /// Represents a parameter
    /// </summary>
    [Serializable]
    public class Parameter : NamedModelEntity, ICloneable
    {
        /// <summary>
        /// Gets or sets minimal possible value of the parameter
        /// </summary>
        public double MinValue { get; set; }

        /// <summary>
        /// Gets or sets maximal possible value of the parameter
        /// </summary>
        public double MaxValue { get; set; }

        /// <summary>
        /// Initializes new instance of <see cref="Parameter"/>
        /// </summary>
        /// <param name="id">Parameter identifier</param>
        /// <param name="name">Parameter name</param>
        /// <param name="variableIdentifier">Parameter variable identifier</param>
        /// <param name="minValue">Minimal possible value of the parameter</param>
        /// <param name="maxValue">Maximal possible value of the parameter</param>
        public Parameter(
            TId id,
            string name,
            string variableIdentifier,
            double minValue,
            double maxValue) : base(id, name, variableIdentifier)
        {
            MinValue = minValue;
            MaxValue = maxValue;
        }

        /// <summary>
        /// Creates a deep copy of <see cref="Parameter"/> instance
        /// </summary>
        /// <returns>Deep copy of self</returns>
        public override object Clone()
        {
            return new Parameter(Id, Name, VariableIdentifier, MinValue, MaxValue)
                {
                    Properties = (PropertyCollection)Properties.Clone()
                };
        }
    }
}