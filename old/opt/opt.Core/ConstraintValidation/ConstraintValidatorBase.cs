using System;
using opt.Comparers;
using opt.DataModel.New;

namespace opt.ConstraintValidation
{
    /// <summary>
    /// Base class for constraint validators. Idea is to have one validator derived
    /// from <see cref="ConstraintValidatorBase"/> for each constraint type (i.e.
    /// derived from <see cref="Constraint"/>)
    /// </summary>
    public abstract class ConstraintValidatorBase
    {
        public AggregateComparer Comparer { get; private set; }

        protected ConstraintValidatorBase(AggregateComparer comparer)
        {
            if (comparer == null)
            {
                throw new ArgumentNullException("comparer");
            }

            Comparer = comparer;
        }

        public abstract Boolean Validate(Constraint constraint, Real valueToCheck);
    }
}