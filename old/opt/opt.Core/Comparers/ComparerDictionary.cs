using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace opt.Comparers
{
    /// <summary>
    /// Stores comparer functions for different kinds of relations united under 
    /// <typeparamref name="TRelation"/> type
    /// </summary>
    /// <typeparam name="TRelation">Type that enumerates possible relations between 
    /// <typeparamref name="TLeft"/> and <typeparamref name="TRight"/></typeparam>
    /// <typeparam name="TLeft">Type of the left value to be compared</typeparam>
    /// <typeparam name="TRight">Type of the right value to be compared</typeparam>
    [SuppressMessage("Microsoft.Usage", "CA2237:MarkISerializableTypesWithSerializable",
        Justification = "This type is not expected to be serialized")]
    [SuppressMessage("Microsoft.Design", "CA1005:AvoidExcessiveParametersOnGenericTypes",
        Justification = "Design requires exactly three type parameters")]
    public abstract class ComparerDictionary<TRelation, TLeft, TRight> : Dictionary<TRelation, Func<TLeft, TRight, Boolean>>, IComparer<TRelation, TLeft, TRight>
    {
        /// <summary>
        /// Checks whether <paramref name="leftValue"/> and <paramref name="rightValue"/>
        /// are related in a way described by <paramref name="relation"/>
        /// </summary>
        /// <param name="relation">Relation between <paramref name="leftValue"/> 
        /// and <paramref name="rightValue"/> that is to be checked</param>
        /// <param name="leftValue">Left value to be compared</param>
        /// <param name="rightValue">Right value to be compared</param>
        /// <returns>True if <paramref name="leftValue"/> and <paramref name="rightValue"/>
        /// are related in a way described by <paramref name="relation"/> (i.e. together
        /// they form a valid inequality). Otherwise False</returns>
        /// <exception cref="ArgumentException">If a comparer for given <paramref name="relation"/>
        /// is not registered (i.e. not added to the dictionary)</exception>
        /// <exception cref="InvalidOperationException">If a comparer delegate for given 
        /// <paramref name="relation"/> is null</exception>
        public virtual Boolean Compare(TRelation relation, TLeft leftValue, TRight rightValue)
        {
            if (!ContainsKey(relation))
            {
                throw new ArgumentException("No comparer for this relation.", "relation");
            }

            if (this[relation] == null)
            {
                throw new InvalidOperationException("Comparer for this relation is null.");
            }

            return this[relation](leftValue, rightValue);
        }
    }
}