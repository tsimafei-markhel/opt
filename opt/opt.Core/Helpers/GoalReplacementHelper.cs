using System;
using System.Collections.Generic;
using opt.DataModel;

// TODO: Use where necessary
// TODO: Add XML comments

namespace opt.Helpers
{
    public static class GoalReplacementHelper
    {
        public static IDictionary<TId, double> InvertGoal(IDictionary<TId, double> valuesToInvert)
        {
            if (valuesToInvert == null)
            {
                throw new ArgumentNullException("valuesToInvert");
            }

            // No need to invert empty collection
            if (valuesToInvert.Count < 1)
            {
                return new Dictionary<TId, double>(valuesToInvert);
            }

            Dictionary<TId, double> invertedValues = new Dictionary<TId, double>(valuesToInvert.Count);
            foreach (KeyValuePair<TId, double> element in valuesToInvert)
            {
                invertedValues.Add(element.Key, -element.Value);
            }

            return invertedValues;
        }
    }
}