using System;
using System.Diagnostics.CodeAnalysis;

// TODO: Move expression to custom properties
// TODO: Move weight to custom properties
// TODO: Add validation

namespace opt.DataModel
{
    /// <summary>
    /// Represents a criterion (objective)
    /// </summary>
    [Serializable]
    public class Criterion : NamedModelEntity, ICloneable
    {
        /// <summary>
        /// Gets or sets criterion type
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1721:PropertyNamesShouldNotMatchGetMethods",
            Justification = "Fixed in opt.DataModel.New.Objective class")]
        public CriterionType Type { get; set; }

        /// <summary>
        /// Gets or sets criterion weight
        /// </summary>
        public int Weight { get; set; }

        /// <summary>
        /// Gets or sets mathematical expression that can be used to calculate criterion value
        /// </summary>
        public string Expression { get; set; }

        /// <summary>
        /// Gets sort direction for the values of this criterion
        /// </summary>
        [SuppressMessage("Microsoft.Design", "CA1065:DoNotRaiseExceptionsInUnexpectedLocations", 
            Justification = "Fixed in opt.DataModel.New.Objective class")]
        public SortDirection SortDirection
        {
            get
            {
                switch (Type)
                {
                    case CriterionType.Minimizing:
                        return SortDirection.Ascending;

                    case CriterionType.Maximizing:
                        return SortDirection.Descending;

                    default:
                        throw new ArgumentException("Unknown criterion type.");
                }
            }
        }

        /// <summary>
        /// Initializes new instance of <see cref="Criterion"/>
        /// </summary>
        /// <param name="id">Criterion identifier</param>
        /// <param name="name">Criterion name</param>
        /// <param name="variableIdentifier">Criterion variable identifier</param>
        /// <param name="type">Criterion type</param>
        /// <param name="expression">Mathematical expression that can be used to calculate criterion value</param>
        [SuppressMessage("Microsoft.Design", "CA1026:DefaultParametersShouldNotBeUsed",
            Justification = "Fixed in opt.DataModel.New.Objective class")]
        public Criterion(
            TId id,
            string name,
            string variableIdentifier,
            CriterionType type,
            string expression = "") : base (id, name, variableIdentifier)
        {
            Type = type;
            Weight = 1;
            Expression = expression;
        }

        /// <summary>
        /// Creates a deep copy of <see cref="Criterion"/> instance
        /// </summary>
        /// <returns>Deep copy of self</returns>
        public override object Clone()
        {
            return new Criterion(Id, Name, VariableIdentifier, Type, Expression)
                {
                    Weight = Weight,
                    Properties = (PropertyCollection)Properties.Clone()
                };
        }
    }
}