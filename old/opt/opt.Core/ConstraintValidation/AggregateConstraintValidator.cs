using System;
using System.Collections.Generic;
using opt.DataModel.New;

namespace opt.ConstraintValidation
{
    public sealed class AggregateConstraintValidator
    {
        private readonly Dictionary<Type, Object> validators;

        public AggregateConstraintValidator()
        {
            validators = new Dictionary<Type, Object>();
        }

        public void AddValidator<TConstraint>(ConstraintValidatorBase validator) where TConstraint : Constraint
        {
            if (validator == null)
            {
                throw new ArgumentNullException("validator");
            }

            Type constraintType = typeof(TConstraint);
            if (validators.ContainsKey(constraintType))
            {
                throw new ArgumentException("Constraint validator with the same constraint type already exists.", "validator");
            }

            validators.Add(constraintType, validator);
        }

        public void RemoveValidator(Type constraintType)
        {
            if (constraintType == null)
            {
                throw new ArgumentNullException("constraintType");
            }

            if (!validators.ContainsKey(constraintType))
            {
                throw new InvalidOperationException("Constraint validator with such constraint type does not exist.");
            }

            validators.Remove(constraintType);
        }

        public Boolean ContainsValidator(Type validatorType)
        {
            if (validatorType == null)
            {
                throw new ArgumentNullException("validatorType");
            }

            return validators.ContainsKey(validatorType);
        }

        public Boolean Validate(Constraint constraint, Real value)
        {
            Type constraintType = constraint.GetType();
            Object validatorObject = null;
            if (!validators.TryGetValue(constraintType, out validatorObject))
            {
                throw new InvalidOperationException("Constraint validator with such constraint type does not exist.");
            }

            ConstraintValidatorBase validator = validatorObject as ConstraintValidatorBase;
            if (validator == null)
            {
                throw new InvalidCastException("Constraint validator type mismatch.");
            }

            return validator.Validate(constraint, value);
        }
    }
}