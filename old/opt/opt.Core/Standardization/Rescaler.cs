using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using opt.DataModel;

namespace opt.Standardization
{
    /// <summary>
    /// Helper class, container for rescaling routines (http://en.wikipedia.org/wiki/Feature_scaling)
    /// </summary>
    [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Rescaler",
        Justification = "Spelling is correct, 'rescaler' from 'rescale'")]
    public sealed class Rescaler : IStandardizer
    {
        /// <summary>
        /// Performs rescaling on a data sample passed in <paramref name="valuesToStandardize"/>
        /// </summary>
        /// <param name="valuesToStandardize">Collection of values to rescale</param>
        /// <returns>Collection of rescaled values. Returned collection is always new instance</returns>
        /// <remarks>Caller code has to guarantee that <paramref name="valuesToStandardize"/>
        /// does not contain <see cref="Double.NaN"/>, <see cref="Double.PositiveInfinity"/> or
        /// <see cref="Double.NegativeInfinity"/></remarks>
        public IDictionary<TId, double> Standardize(IDictionary<TId, double> valuesToStandardize)
        {
            if (valuesToStandardize == null)
            {
                throw new ArgumentNullException("valuesToStandardize", "Collection of values to rescale cannot be null");
            }

            // No need to rescale empty collection or one value
            if (valuesToStandardize.Count < 2)
            {
                return new Dictionary<TId, double>(valuesToStandardize);
            }

            // Pre-calculations
            double maxValue = valuesToStandardize.Values.Max();
            double minValue = valuesToStandardize.Values.Min();

            // No need to rescale a collection of equal values
            // Note: this clause is equivalent to (variationRange == 0) check but 
            //       does not require to calculate variationRange (see below)
            if (minValue == maxValue)
            {
                return new Dictionary<TId, double>(valuesToStandardize);
            }

            double variationRange = maxValue - minValue;

            // Actual rescaling
            Dictionary<TId, double> rescaledValues = new Dictionary<TId, double>(valuesToStandardize.Count);
            foreach (KeyValuePair<TId, double> element in valuesToStandardize)
            {
                rescaledValues.Add(element.Key, Rescale(element.Value, minValue, variationRange));
            }

            return rescaledValues;
        }

        /// <summary>
        /// Rescales single value
        /// </summary>
        /// <param name="valueToRescale">Value to be rescaled</param>
        /// <param name="minValue">Value to use as a minimum</param>
        /// <param name="variationRange">Rescaling range</param>
        /// <returns></returns>
        /// <remarks>Caller code has to guarantee that a) <paramref name="minValue"/> is 
        /// less than <paramref name="valueToRescale"/> and b) <paramref name="variationRange"/> 
        /// is not zero</remarks>
        private static double Rescale(double valueToRescale, double minValue, double variationRange)
        {
            return (valueToRescale - minValue) / variationRange;
        }
    }
}