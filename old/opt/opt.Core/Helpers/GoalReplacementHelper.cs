using System;
using System.Collections.Generic;
using opt.DataModel;

// TODO: Use where necessary
// TODO: Add XML comments

namespace opt.Helpers
{
    public static class GoalReplacementHelper
    {
        public static IDictionary<TId, Real> InvertGoal(IDictionary<TId, Real> valuesToInvert)
        {
            if (valuesToInvert == null)
            {
                throw new ArgumentNullException("valuesToInvert");
            }

            // No need to invert empty collection
            if (valuesToInvert.Count < 1)
            {
                return new Dictionary<TId, Real>(valuesToInvert);
            }

            Dictionary<TId, Real> invertedValues = new Dictionary<TId, Real>(valuesToInvert.Count);
            foreach (KeyValuePair<TId, Real> element in valuesToInvert)
            {
                invertedValues.Add(element.Key, -element.Value);
            }

            return invertedValues;
        }
    }
}