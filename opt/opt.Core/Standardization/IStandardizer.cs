using System.Collections.Generic;
using opt.DataModel;

// Putting this to the 'opt' namespace because
// it will be used across the solution - no need to add one more non-obvious using.
namespace opt
{
    /// <summary>
    /// An entity capable of performing standardization of any kind
    /// </summary>
    public interface IStandardizer
    {
        /// <summary>
        /// Performs standardization of a collection of <see cref="double"/> values
        /// </summary>
        /// <param name="valuesToStandardize">A collection of <see cref="double"/> values
        /// to standardize. Each value has to have an identifier</param>
        /// <returns>A collection of standardized values</returns>
        IDictionary<TId, double> Standardize(IDictionary<TId, double> valuesToStandardize);
    }
}