using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;
using opt.DataModel.New;

namespace opt.Comparers
{
    /// <summary>
    /// A comparer for <see cref="Real"/> scalar value and a <see cref="ISet<Real>"/> with 
    /// <see cref="SetRelation"/> relation type
    /// </summary>
    [SuppressMessage("Microsoft.Naming", "CA1710:IdentifiersShouldHaveCorrectSuffix",
        Justification = "Name ending with 'Comparer' suits this class better, its dictionary nature is not primal in its usage context")]
    public sealed class SetRelationComparer : ComparerDictionary<SetRelation, Real, ISet<Real>>
    {
        /// <summary>
        /// Initializes new instance of <see cref="SetRelationComparer"/> and adds
        /// comparer functions for all types of <see cref="SetRelation"/>s
        /// </summary>
        public SetRelationComparer()
        {
            Add(SetRelation.Contained, ContainedComparer);
            Add(SetRelation.NotContained, NotContainedComparer);
        }

        /// <summary>
        /// Checks whether <paramref name="rightValue"/> contains <paramref name="leftValue"/>
        /// (i.e. <see cref="SetRelation.Contained"/>)
        /// </summary>
        /// <param name="leftValue">Left value (scalar) for comparison</param>
        /// <param name="rightValue">Right value (set) for comparison</param>
        /// <returns>True if <paramref name="rightValue"/> contains <paramref name="leftValue"/>
        /// (i.e. <see cref="SetRelation.Contained"/>). Otherwise False</returns>
        /// <exception cref="ArgumentNullException">If <paramref name="rightValue"/> is null
        /// </exception>
        private static Boolean ContainedComparer(Real leftValue, ISet<Real> rightValue)
        {
            if (rightValue == null)
            {
                throw new ArgumentNullException("rightValue");
            }

            return rightValue.Contains(leftValue);
        }

        /// <summary>
        /// Checks whether <paramref name="rightValue"/> does not contain 
        /// <paramref name="leftValue"/> (i.e. <see cref="SetRelation.Contained"/>)
        /// </summary>
        /// <param name="leftValue">Left value (scalar) for comparison</param>
        /// <param name="rightValue">Right value (set) for comparison</param>
        /// <returns>True if <paramref name="rightValue"/> does not contain 
        /// <paramref name="leftValue"/> (i.e. <see cref="SetRelation.Contained"/>). 
        /// Otherwise False</returns>
        /// <exception cref="ArgumentNullException">If <paramref name="rightValue"/> is null
        /// </exception>
        private static Boolean NotContainedComparer(Real leftValue, ISet<Real> rightValue)
        {
            if (rightValue == null)
            {
                throw new ArgumentNullException("rightValue");
            }

            return !rightValue.Contains(leftValue);
        }
    }
}