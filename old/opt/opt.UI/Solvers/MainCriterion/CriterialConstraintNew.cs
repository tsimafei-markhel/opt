using System;
using opt.DataModel;

namespace opt.Solvers.MainCriterion
{
    /// <summary>
    /// Represents criterial constraint
    /// </summary>
    public class CriterialConstraintNew : Constraint, ICloneable
    {
        // Currently we don't need to serialize instances of this class, so it is not [Serializable]

        /// <summary>
        /// Gets or sets identifier of the criterion which current constraint relates to
        /// </summary>
        public TId CriterionId { get; set; }

        /// <summary>
        /// Initializes new instance of <see cref="CriterialConstraint"/>
        /// </summary>
        /// <param name="id">Constraint identifier</param>
        /// <param name="criterionId">Identifier of the criterion which current constraint relates to</param>
        /// <param name="relation">Constraint relation</param>
        /// <param name="value">Constraint value</param>
        public CriterialConstraintNew(
            TId id,
            TId criterionId,
            Relation relation,
            double value) 
        : base(id, string.Empty, string.Empty, relation, value)
        {
            CriterionId = criterionId;
        }

        /// <summary>
        /// Creates a deep copy of <see cref="CriterialConstraint"/> instance
        /// </summary>
        /// <returns>Deep copy of self</returns>
        public new object Clone()
        {
            // Not copying Properties for now - currently we don't need them.
            return new CriterialConstraintNew(Id, CriterionId, ConstraintRelation, Value);
        }
    }
}