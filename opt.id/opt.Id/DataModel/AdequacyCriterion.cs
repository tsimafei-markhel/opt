using System;

namespace opt.DataModel
{
    /// <summary>
    /// Represents an adequacy criterion (residual between real criterion values and ones obtained from the model)
    /// </summary>
    [Serializable]
    public class AdequacyCriterion : Criterion, ICloneable
    {
        /// <summary>
        /// Gets or sets adequacy criterion type (defines how a residual is calculated)
        /// </summary>
        public AdequacyCriterionType AdequacyType { get; set; }

        /// <summary>
        /// Initializes new instance of <see cref="AdequacyCriterion"/>
        /// </summary>
        /// <param name="id">Adequacy criterion identifier</param>
        /// <param name="name">Adequacy criterion name</param>
        /// <param name="variableIdentifier">Adequacy criterion variable identifier</param>
        /// <param name="adequacyType">Adequacy criterion type</param>
        public AdequacyCriterion(
            TId id,
            string name,
            string variableIdentifier,
            AdequacyCriterionType adequacyType) : base(id, name, variableIdentifier, CriterionType.Minimizing, string.Empty)
        {
            AdequacyType = adequacyType;
        }

        /// <summary>
        /// Creates a deep copy of <see cref="AdequacyCriterion"/> instance
        /// </summary>
        /// <returns>Deep copy of self</returns>
        public override object Clone()
        {
            return new AdequacyCriterion(Id, Name, VariableIdentifier, AdequacyType)
                {
                    Weight = Weight,
                    Expression = Expression
                };
        }
    }
}