using System;
using System.Collections.Generic;
using opt.DataModel;

namespace opt.Solvers.Genetics.Additive
{
    [Serializable]
    public sealed class AdditiveMethodResult : OptimizationMethodResult
    {
        private AdditiveMethodResult() : this(string.Empty, string.Empty) { }

        public AdditiveMethodResult(string methodName) : this(methodName, string.Empty) { }

        public AdditiveMethodResult(string methodName, string additionalDataDescription) : base (methodName, additionalDataDescription) { }

        public override CustomProperty Clone()
        {
            return new AdditiveMethodResult()
            {
                AdditionalData = new Dictionary<TId, double>(this.AdditionalData),
                AdditionalDataDescription = this.AdditionalDataDescription,
                MethodName = this.MethodName,
                SortedPoints = new List<TId>(this.SortedPoints)
            };
        }
    }
}