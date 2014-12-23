using System;
using opt.Comparers;
using opt.DataModel.New;

namespace opt.ConstraintValidation
{
    public sealed class ObjectiveConstraintValidator : ConstraintValidatorBase
    {
        public ObjectiveConstraintValidator(AggregateComparer validationComparer)
            : base(validationComparer)
        {
        }

        public override Boolean Validate(Constraint constraint, Real valueToCheck)
        {
            if (constraint == null)
            {
                throw new ArgumentNullException("constraint");
            }

            ObjectiveConstraint typedConstraint = constraint as ObjectiveConstraint;
            if (typedConstraint == null)
            {
                throw new InvalidCastException("Constraint is of invalid type.");
            }

            return Comparer.Compare<Relation, Real, Real>(constraint.Relation, constraint.Value, valueToCheck);
        }
    }
}