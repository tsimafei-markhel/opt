using System;
using System.Diagnostics.CodeAnalysis;
using opt.DataModel.New;

namespace opt.Comparers
{
    /// <summary>
    /// A comparer for <see cref="Real"/> values and <see cref="Relation"/> relation type
    /// </summary>
    [SuppressMessage("Microsoft.Naming", "CA1710:IdentifiersShouldHaveCorrectSuffix",
        Justification = "Name ending with 'Comparer' suits this class better, its dictionary nature is not primal in its usage context")]
    public sealed class RealRelationComparer : ComparerDictionary<Relation, Real, Real>
    {
        /// <summary>
        /// Initializes new instance of <see cref="RealRelationComparer"/> and adds
        /// comparer functions for all types of <see cref="Relation"/>s
        /// </summary>
        public RealRelationComparer()
        {
            Add(Relation.Equal, EqualComparer);
            Add(Relation.NotEqual, NotEqualComparer);
            Add(Relation.Less, LessComparer);
            Add(Relation.LessOrEqual, LessOrEqualComparer);
            Add(Relation.Greater, GreaterComparer);
            Add(Relation.GreaterOrEqual, GreaterOrEqualComparer);
        }

        /// <summary>
        /// Checks whether <paramref name="leftValue"/> and <paramref name="rightValue"/>
        /// are equal (i.e. <see cref="Relation.Equal"/>)
        /// </summary>
        /// <param name="leftValue">Left value for comparison</param>
        /// <param name="rightValue">Right value for comparison</param>
        /// <returns>True if <paramref name="leftValue"/> and <paramref name="rightValue"/>
        /// are equal (i.e. <see cref="Relation.Equal"/>). Otherwise False</returns>
        private static Boolean EqualComparer(Real leftValue, Real rightValue)
        {
            return leftValue == rightValue;
        }

        /// <summary>
        /// Checks whether <paramref name="leftValue"/> and <paramref name="rightValue"/>
        /// are not equal (i.e. <see cref="Relation.NotEqual"/>)
        /// </summary>
        /// <param name="leftValue">Left value for comparison</param>
        /// <param name="rightValue">Right value for comparison</param>
        /// <returns>True if <paramref name="leftValue"/> and <paramref name="rightValue"/>
        /// are not equal (i.e. <see cref="Relation.Equal"/>). Otherwise False</returns>
        private static Boolean NotEqualComparer(Real leftValue, Real rightValue)
        {
            return leftValue != rightValue;
        }

        /// <summary>
        /// Checks whether <paramref name="leftValue"/> is less than <paramref name="rightValue"/>
        /// (i.e. <see cref="Relation.Less"/>)
        /// </summary>
        /// <param name="leftValue">Left value for comparison</param>
        /// <param name="rightValue">Right value for comparison</param>
        /// <returns>True if <paramref name="leftValue"/> is less than <paramref name="rightValue"/>
        /// (i.e. <see cref="Relation.Less"/>). Otherwise False</returns>
        private static Boolean LessComparer(Real leftValue, Real rightValue)
        {
            return leftValue < rightValue;
        }

        /// <summary>
        /// Checks whether <paramref name="leftValue"/> is less than or equal to 
        /// <paramref name="rightValue"/> (i.e. <see cref="Relation.LessOrEqual"/>)
        /// </summary>
        /// <param name="leftValue">Left value for comparison</param>
        /// <param name="rightValue">Right value for comparison</param>
        /// <returns>True if <paramref name="leftValue"/> is less than or equal to 
        /// <paramref name="rightValue"/> (i.e. <see cref="Relation.LessOrEqual"/>). 
        /// Otherwise False</returns>
        private static Boolean LessOrEqualComparer(Real leftValue, Real rightValue)
        {
            return leftValue <= rightValue;
        }

        /// <summary>
        /// Checks whether <paramref name="leftValue"/> is greater than <paramref name="rightValue"/>
        /// (i.e. <see cref="Relation.Greater"/>)
        /// </summary>
        /// <param name="leftValue">Left value for comparison</param>
        /// <param name="rightValue">Right value for comparison</param>
        /// <returns>True if <paramref name="leftValue"/> is greater than <paramref name="rightValue"/>
        /// (i.e. <see cref="Relation.Greater"/>). Otherwise False</returns>
        private static Boolean GreaterComparer(Real leftValue, Real rightValue)
        {
            return leftValue > rightValue;
        }

        /// <summary>
        /// Checks whether <paramref name="leftValue"/> is greater than or equal to 
        /// <paramref name="rightValue"/> (i.e. <see cref="Relation.GreaterOrEqual"/>)
        /// </summary>
        /// <param name="leftValue">Left value for comparison</param>
        /// <param name="rightValue">Right value for comparison</param>
        /// <returns>True if <paramref name="leftValue"/> is greater than or equal to 
        /// <paramref name="rightValue"/> (i.e. <see cref="Relation.GreaterOrEqual"/>). 
        /// Otherwise False</returns>
        private static Boolean GreaterOrEqualComparer(Real leftValue, Real rightValue)
        {
            return leftValue >= rightValue;
        }
    }
}