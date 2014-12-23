using System;
using opt.Comparers;
using opt.DataModel.New;

namespace opt.ConstraintValidation
{
    public sealed class ConstraintValidator : ConstraintValidatorBase
    {
        public ConstraintValidator(AggregateComparer validationComparer)
            : base(validationComparer)
        {
        }

        public override Boolean Validate(Constraint constraint, Real valueToCheck)
        {
            if (constraint == null)
            {
                throw new ArgumentNullException("constraint");
            }

            return Comparer.Compare<Relation, Real, Real>(constraint.Relation, constraint.Value, valueToCheck);
        }
    }
}