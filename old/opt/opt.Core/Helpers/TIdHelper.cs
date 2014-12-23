using System;
using System.Collections.Generic;
using System.Linq;
using opt.DataModel.New;

namespace opt.Helpers
{
    /// <summary>
    /// Contains helper methods for <see cref="TId"/> generation and usage
    /// </summary>
    public static class TIdHelper
    {
        /// <summary>
        /// Returns an ID that is not used in the collection of taken IDs passed as a parameter
        /// </summary>
        /// <param name="takenIds">Collection of IDs that are already in use</param>
        /// <returns><see cref="TId"/> instance that is not present in <paramref name="takenIds"/> collection</returns>
        public static TId GetFreeConsequentId(IEnumerable<TId> takenIds)
        {
            if (takenIds == null)
            {
                throw new ArgumentNullException("takenIds");
            }

            if (takenIds.Count() == 0)
            {
                return 0;
            }

            int keysMax = takenIds.Max();
            if (keysMax == Int32.MaxValue)
            {
                throw new InvalidOperationException();
            }

            return ++keysMax;
        }
    }
}