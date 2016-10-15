using System;

// TODO: Move expression to custom properties
// TODO: Add validation

namespace opt.DataModel
{
    /// <summary>
    /// Represents a constraint (e.g. functional)
    /// </summary>
    [Serializable]
    public class Constraint : NamedModelEntity, ICloneable
    {
        /// <summary>
        /// Gets or sets constraint relation - how a constraint relates to the limiting value
        /// </summary>
        public Relation ConstraintRelation { get; set; }

        /// <summary>
        /// Gets or sets constraint limiting value
        /// </summary>
        public double Value { get; set; }

        /// <summary>
        /// Gets or sets mathematical expression that can be used to calculate constraint value
        /// </summary>
        public string Expression { get; set; }

        /// <summary>
        /// Initializes new instance of <see cref="Constraint"/>
        /// </summary>
        /// <param name="id">Constraint identifier</param>
        /// <param name="name">Constraint name</param>
        /// <param name="variableIdentifier">Constraint variable identifier</param>
        /// <param name="constraintRelation">Constraint relation</param>
        /// <param name="value">Constraint limitation value</param>
        /// <param name="expression">Mathematical expression that can be used to calculate constraint value</param>
        public Constraint(
            TId id,
            string name,
            string variableIdentifier,
            Relation constraintRelation,
            double value,
            string expression = "") : base(id, name, variableIdentifier)
        {
            ConstraintRelation = constraintRelation;
            Value = value;
            Expression = expression;
        }

        /// <summary>
        /// Creates a deep copy of <see cref="Constraint"/> instance
        /// </summary>
        /// <returns>Deep copy of self</returns>
        public override object Clone()
        {
            return new Constraint(Id, Name, VariableIdentifier, ConstraintRelation, Value, Expression)
                {
                    Properties = (PropertyCollection)Properties.Clone()
                };
        }
    }
}