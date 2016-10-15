using System;
using opt.DataModel;

namespace opt.Drafter.DataModel
{
    /// <summary>
    /// Represents a promotable criterion - entity, that can represent a criterion (in non-promoted state) 
    /// or a functional constraint (in promoted state)
    /// </summary>
    public sealed class PromotableCriterion : Criterion, ICloneable
    {
        // Not making this [Serializable] for now as we probably won't need it

        /// <summary>
        /// Gets or sets constraint relation - how a constraint relates to the limiting value
        /// </summary>
        public Relation ConstraintRelation { get; set; }

        /// <summary>
        /// Gets or sets constraint limiting value
        /// </summary>
        public double Value { get; set; }

        /// <summary>
        /// Gets or sets <see cref="PromotableCriterion"/> state - whether it is promoted to 
        /// <see cref="Constraint"/> (True) or not (False)
        /// </summary>
        public bool IsPromoted { get; set; }

        /// <summary>
        /// Initializes new instance of <see cref="PromotableCriterion"/>
        /// </summary>
        /// <param name="id">Promotable criterion identifier</param>
        /// <param name="name">Promotable criterion name</param>
        /// <param name="variableIdentifier">Promotable criterion variable identifier</param>
        /// <param name="criterionType">Promotable criterion type</param>
        /// <remarks>New instance is in non-promoted state; ConstraintRelation is Equal, Value is 0.0</remarks>
        public PromotableCriterion(
            TId id,
            string name,
            string variableIdentifier,
            CriterionType criterionType)
            : base(id, name, variableIdentifier, criterionType)
        {
            ConstraintRelation = Relation.Equal;
            Value = 0.0;
            IsPromoted = false;
        }

        /// <summary>
        /// Creates new <see cref="Criterion"/> instance based on the current state of 
        /// the non-promoted <see cref="PromotableCriterion"/> instance
        /// </summary>
        /// <returns>New <see cref="Criterion"/> instance</returns>
        /// <exception cref="InvalidOperationException">If an attempt to get <see cref="Criterion"/> 
        /// instance from the promoted state was made</exception>
        public Criterion GetCriterion()
        {
            if (IsPromoted)
            {
                throw new InvalidOperationException("Cannot get Criterion from the promoted Promotable criterion");
            }

            return (Criterion)((Criterion)this).Clone();
        }

        /// <summary>
        /// Creates new <see cref="Constraint"/> instance based on the current state of 
        /// the promoted <see cref="PromotableCriterion"/> instance
        /// </summary>
        /// <returns>New <see cref="Constraint"/> instance</returns>
        /// <exception cref="InvalidOperationException">If an attempt to get <see cref="Constraint"/> 
        /// instance from the non-promoted state was made</exception>
        public Constraint GetConstraint()
        {
            if (!IsPromoted)
            {
                throw new InvalidOperationException("Cannot get Constraint from the non-promoted Promotable criterion");
            }

            return new Constraint(Id, Name, VariableIdentifier, ConstraintRelation, Value);
        }

        /// <summary>
        /// Creates a deep copy of <see cref="PromotableCriterion"/> instance
        /// </summary>
        /// <returns>Deep copy of self</returns>
        public new object Clone()
        {
            return new PromotableCriterion(Id, Name, VariableIdentifier, Type)
            {
                ConstraintRelation = ConstraintRelation,
                Value = Value,
                IsPromoted = IsPromoted,
                Properties = (PropertyCollection)Properties.Clone()
            };
        }
    }
}