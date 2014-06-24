using System;

namespace opt.Relations
{
    public interface IBinaryRelationChecker<TLeft, TRight>
    {
        Boolean IsRelated(IRelation relation, TLeft left, TRight right);
    }
}