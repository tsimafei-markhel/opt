using System;
using opt.DataModel.New;

namespace opt.ConstraintValidation
{
    public class ValueDictionaryValidator
    {
        public AggregateConstraintValidator Validator { get; private set; }

        public ValueDictionaryValidator(AggregateConstraintValidator aggregateValidator)
        {
            if (aggregateValidator == null)
            {
                throw new ArgumentNullException("aggregateValidator");
            }

            Validator = aggregateValidator;
        }

        public virtual Boolean ValidateConstraint(ValueDictionary values, Constraint constraint)
        {
            if (values == null)
            {
                throw new ArgumentNullException("values");
            }

            if (constraint == null)
            {
                throw new ArgumentNullException("constraint");
            }

            Real constraintValue;
            if (!values.TryGetValue(constraint.Id, out constraintValue))
            {
                throw new InvalidOperationException("Constraint value is missing in the collection.");
            }

            return Validator.Validate(constraint, constraintValue);
        }
    }
}