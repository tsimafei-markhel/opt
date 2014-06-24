using System;

namespace opt.Relations
{
    /// <summary>
    /// Represents a relation between two values (e.g. a &lt; b)
    /// </summary>
    /// <typeparam name="TLeft">Type of the left value</typeparam>
    /// <typeparam name="TRight">Type of the right value</typeparam>
    public interface IBinaryRelation<TLeft, TRight>
    {
        /// <summary>
        /// Gets relation name
        /// </summary>
        String Name { get; }

        /// <summary>
        /// Gets math symbol representing a relation
        /// </summary>
        String Symbol { get; }

        /// <summary>
        /// Checks whether the current relation is true for two specified values
        /// (e.g. whether 'a &lt; b' is true or not)
        /// </summary>
        /// <param name="left">Left value of the relation expression
        /// (e.g. 'a' in 'a &lt; b')</param>
        /// <param name="right">Right value of the relation expression
        /// (e.g. 'b' in 'a &lt; b')</param>
        /// <returns>True if relation is valid (e.g. if a is less than b for 'a &lt; b');
        /// otherwise false</returns>
        Boolean Exists(TLeft left, TRight right);
    }
}