using System;

namespace opt.DataModel.New
{
    /// <summary>
    /// Represents an inequality constraint
    /// </summary>
    /// <remarks>Inequality is: [Limiting Value] [Relation] (constraint value)</remarks>
    [Serializable]
    public class Constraint : ModelEntity
    {
        /// <summary>
        /// Gets or sets constraint relation - how a limiting value relates to constraint value
        /// </summary>
        public Relation Relation { get; private set; }

        /// <summary>
        /// Gets or sets constraint limiting value (LEFT part of inequality)
        /// </summary>
        public Real Value { get; private set; }

        /// <summary>
        /// Initializes new instance of <see cref="Constraint"/>
        /// </summary>
        /// <param name="id">Constraint identifier</param>
        /// <param name="properties">A collection of entity properties</param>
        /// <param name="relation">Constraint relation</param>
        /// <param name="value">Constraint limitation value</param>
        protected Constraint(
            TId id,
            PropertyDictionary properties,
            Relation relation,
            Real value)
            : base(id, properties)
        {
            Relation = relation;
            Value = value;
        }

        /// <summary>
        /// Initializes new instance of <see cref="Constraint"/>
        /// </summary>
        /// <param name="id">Constraint identifier</param>
        /// <param name="relation">Constraint relation</param>
        /// <param name="value">Constraint limitation value</param>
        public Constraint(
            TId id,
            Relation relation,
            Real value)
            : this(id, new PropertyDictionary(), relation, value)
        {
        }

        /// <summary>
        /// Creates a deep copy of <see cref="Constraint"/> instance
        /// </summary>
        /// <returns>Deep copy of self</returns>
        public override object Clone()
        {
            return new Constraint(Id, (PropertyDictionary)Properties.Clone(), Relation, Value);
        }
    }
}