using System;
using System.Collections.Generic;

// TODO: Replace opt.Helpers.Comparer with this class

namespace opt.Comparers
{
    /// <summary>
    /// A comparer that acts as a storage for <see cref="IComparer<TRelation, TLeft, TRight>"/>
    /// instances and chooses one of them for comparison based on the parameter types
    /// </summary>
    public sealed class AggregateComparer
    {
        /// <summary>
        /// Comparer storage
        /// </summary>
        private readonly Dictionary<Type, Object> comparers;

        /// <summary>
        /// Initializes new instance of <see cref="AggreagteComparer"/>
        /// </summary>
        public AggregateComparer()
        {
            comparers = new Dictionary<Type, Object>();
        }

        /// <summary>
        /// Registers a comparer. Type of <typeparamref name="TRelation"/> is used as a key
        /// </summary>
        /// <typeparam name="TRelation">Type of the relation this comparer can be used for</typeparam>
        /// <typeparam name="TLeft">Type of the left-hand value in the comparison</typeparam>
        /// <typeparam name="TRight">Type of the right-hand value in the comparison</typeparam>
        /// <param name="comparer">Instance of a comparer to be used for given combination of types</param>
        /// <exception cref="ArgumentNullException">If <paramref name="comparer"/> is null</exception>
        /// <exception cref="ArgumentException">If a comparer for given <typeparamref name="TRelation"/>
        /// type is already registered</exception>
        public void AddComparer<TRelation, TLeft, TRight>(IComparer<TRelation, TLeft, TRight> comparer)
        {
            if (comparer == null)
            {
                throw new ArgumentNullException("comparer");
            }

            Type relationType = typeof(TRelation);
            if (comparers.ContainsKey(relationType))
            {
                throw new ArgumentException("Comparer with the same relation already exists.", "comparer");
            }

            comparers.Add(relationType, comparer);
        }

        /// <summary>
        /// Unregisters a comparer
        /// </summary>
        /// <param name="relationType">Type of the relation to remove comparer for</param>
        public void RemoveComparer(Type relationType)
        {
            if (relationType == null)
            {
                throw new ArgumentNullException("relationType");
            }

            if (!comparers.ContainsKey(relationType))
            {
                throw new InvalidOperationException("Comparer with such relation does not exist.");
            }

            comparers.Remove(relationType);
        }

        /// <summary>
        /// Checks whether a comparer for given relation type is registered
        /// </summary>
        /// <param name="relationType">Type of the relation to check comparer existence for</param>
        /// <returns>True if a comparer for given relation type is already registered. 
        /// Otherwise False</returns>
        public Boolean ContainsComparer(Type relationType)
        {
            if (relationType == null)
            {
                throw new ArgumentNullException("relationType");
            }

            return comparers.ContainsKey(relationType);
        }

        /// <summary>
        /// Performs comparison of <paramref name="leftValue"/> and <paramref name="rightValue"/>
        /// with respect to <paramref name="relation"/>
        /// </summary>
        /// <typeparam name="TRelation">Type of the relation to be checked</typeparam>
        /// <typeparam name="TLeft">Type of the left-hand value in the comparison</typeparam>
        /// <typeparam name="TRight">Type of the right-hand value in the comparison</typeparam>
        /// <param name="relation">Relation between <paramref name="leftValue"/> and <paramref name="rightValue"/>
        /// to be checked</param>
        /// <param name="leftValue">Left-hand value to be compared</param>
        /// <param name="rightValue">Right-hand value to be compared</param>
        /// <returns>True if <paramref name="leftValue"/> and <paramref name="rightValue"/>
        /// relate in a way specified by <paramref name="relation"/> (i.e. together they form
        /// true inequality). Otherwise False</returns>
        /// <exception cref="InvalidOperationException">If a comparer for given
        /// <typeparamref name="TRelation"/> is not registered</exception>
        /// <exception cref="InvalidCastException">If <typeparamref name="TLeft"/> and/or
        /// <typeparamref name="TRight"/> differ for the comparer registered for given
        /// <typeparamref name="TRelation"/> type</exception>
        public Boolean Compare<TRelation, TLeft, TRight>(TRelation relation, TLeft leftValue, TRight rightValue)
        {
            Type relationType = typeof(TRelation);
            Object relationComparerObject = null;
            if (!comparers.TryGetValue(relationType, out relationComparerObject))
            {
                throw new InvalidOperationException("Comparer with such relation does not exist.");
            }

            IComparer<TRelation, TLeft, TRight> comparer = relationComparerObject as IComparer<TRelation, TLeft, TRight>;
            if (comparer == null)
            {
                throw new InvalidCastException("Comparer type mismatch.");
            }

            return comparer.Compare(relation, leftValue, rightValue);
        }
    }
}