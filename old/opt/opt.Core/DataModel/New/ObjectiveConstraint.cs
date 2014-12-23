using System;

namespace opt.DataModel.New
{
    /// <summary>
    /// Represents an objective constraint
    /// </summary>
    [Serializable]
    public class ObjectiveConstraint : Constraint
    {
        /// <summary>
        /// Gets or sets an identifier of an <see cref="Objective"/> this constraint 
        /// relates to
        /// </summary>
        public TId ObjectiveId { get; private set; }

        /// <summary>
        /// Initializes new instance of <see cref="ObjectiveConstraint"/>
        /// </summary>
        /// <param name="id">Constraint identifier</param>
        /// <param name="properties">A collection of entity properties</param>
        /// <param name="relation">Constraint relation</param>
        /// <param name="value">Constraint limitation value</param>
        protected ObjectiveConstraint(
            TId id,
            PropertyDictionary properties,
            TId objectiveId,
            Relation relation,
            Real value)
            : base(id, properties, relation, value)
        {
            ObjectiveId = objectiveId;
        }

        /// <summary>
        /// Initializes new instance of <see cref="ObjectiveConstraint"/>
        /// </summary>
        /// <param name="id">Constraint identifier</param>
        /// <param name="relation">Constraint relation</param>
        /// <param name="value">Constraint limitation value</param>
        public ObjectiveConstraint(
            TId id,
            TId objectiveId,
            Relation relation,
            Real value)
            : this(id, new PropertyDictionary(), objectiveId, relation, value)
        {
        }

        /// <summary>
        /// Creates a deep copy of <see cref="ObjectiveConstraint"/> instance
        /// </summary>
        /// <returns>Deep copy of self</returns>
        public override object Clone()
        {
            return new ObjectiveConstraint(Id, (PropertyDictionary)Properties.Clone(), ObjectiveId, Relation, Value);
        }
    }
}