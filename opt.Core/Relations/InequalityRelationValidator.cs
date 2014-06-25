using System;
using System.Collections.Generic;

namespace opt.Relations
{
    public sealed class InequalityRelationValidator<TValue> : IBinaryRelationValidator<TValue, TValue>
        where TValue : IEquatable<TValue>, IComparable<TValue>
    {
        private static readonly Dictionary<IRelation, Func<TValue, TValue, Boolean>> validatorFuncs
            = new Dictionary<IRelation, Func<TValue, TValue, Boolean>>()
        {
            { InequalityRelation.Equal, ValidateEqual },
            { InequalityRelation.NotEqual, ValidateNotEqual },
            { InequalityRelation.Less, ValidateLess },
            { InequalityRelation.LessOrEqual, ValidateLessOrEqual },
            { InequalityRelation.Greater, ValidateGreater },
            { InequalityRelation.GreaterOrEqual, ValidateGreaterOrEqual }
        };

        public Boolean Validate(IRelation relation, TValue left, TValue right)
        {
            if (relation == null)
            {
                throw new ArgumentNullException("relation");
            }

            if (!(relation is InequalityRelation))
            {
                throw new InvalidOperationException();
            }

            return validatorFuncs[relation](left, right);
        }

        private static Boolean ValidateEqual(TValue left, TValue right)
        {
            if (object.ReferenceEquals((object)left, (object)null))
            {
                return object.ReferenceEquals((object)right, (object)null);
            }

            return left.Equals(right);
        }

        private static Boolean ValidateNotEqual(TValue left, TValue right)
        {
            if (object.ReferenceEquals((object)left, (object)null))
            {
                return !object.ReferenceEquals((object)right, (object)null);
            }

            return !left.Equals(right);
        }

        private static Boolean ValidateLess(TValue left, TValue right)
        {
            if (object.ReferenceEquals((object)left, (object)null) ||
                object.ReferenceEquals((object)right, (object)null))
            {
                return false;
            }

            return left.CompareTo(right) < 0;
        }

        private static Boolean ValidateLessOrEqual(TValue left, TValue right)
        {
            if (object.ReferenceEquals((object)left, (object)null) ||
                object.ReferenceEquals((object)right, (object)null))
            {
                return false;
            }

            return left.CompareTo(right) <= 0;
        }

        private static Boolean ValidateGreater(TValue left, TValue right)
        {
            if (object.ReferenceEquals((object)left, (object)null) ||
                object.ReferenceEquals((object)right, (object)null))
            {
                return false;
            }

            return left.CompareTo(right) > 0;
        }

        private static Boolean ValidateGreaterOrEqual(TValue left, TValue right)
        {
            if (object.ReferenceEquals((object)left, (object)null) ||
                object.ReferenceEquals((object)right, (object)null))
            {
                return false;
            }

            return left.CompareTo(right) >= 0;
        }
    }
}