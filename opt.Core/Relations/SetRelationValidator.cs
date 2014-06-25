using System;
using System.Collections.Generic;

namespace opt.Relations
{
    public sealed class SetRelationValidator<TItem, TSet> : IBinaryRelationValidator<TItem, TSet>
        where TSet : ISet<TItem>
    {
        private static readonly Dictionary<IRelation, Func<TItem, TSet, Boolean>> validatorFuncs
            = new Dictionary<IRelation, Func<TItem, TSet, Boolean>>()
        {
            { SetRelation.Member, ValidateMember },
            { SetRelation.NotMember, ValidateNotMember }
        };

        public bool Validate(IRelation relation, TItem left, TSet right)
        {
            if (relation == null)
            {
                throw new ArgumentNullException("relation");
            }

            if (!(relation is SetRelation))
            {
                throw new InvalidOperationException();
            }

            if (right == null)
            {
                throw new ArgumentNullException("right");
            }

            return validatorFuncs[relation](left, right);
        }

        private static Boolean ValidateMember(TItem left, TSet right)
        {
            return right.Contains(left);
        }

        private static Boolean ValidateNotMember(TItem left, TSet right)
        {
            return !right.Contains(left);
        }
    }
}