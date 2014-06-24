using System;

namespace opt.Relations
{
    /// <summary>
    /// Entity that checks whether a specified relation between two values exists or not
    /// </summary>
    /// <typeparam name="TLeft">Type of a left-hand value</typeparam>
    /// <typeparam name="TRight">Type of a right-hand value</typeparam>
    public interface IBinaryRelationValidator<TLeft, TRight>
    {
        /// <summary>
        /// Checks whether <paramref name="left"/> and <paramref name="right"/> values
        /// are related in a way <paramref name="relation"/> requires
        /// </summary>
        /// <param name="relation">Relation to be checked</param>
        /// <param name="left">Left-hand value in the relation expression</param>
        /// <param name="right">Right-hand value in the relation expression</param>
        /// <returns>True if <paramref name="left"/> and <paramref name="right"/> values
        /// are related in a way required by <paramref name="relation"/>; otherwise false</returns>
        Boolean Validate(IRelation relation, TLeft left, TRight right);
    }
}