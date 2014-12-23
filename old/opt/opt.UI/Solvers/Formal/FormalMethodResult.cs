using System;
using System.Collections.Generic;
using opt.DataModel;

namespace opt.Solvers.Formal
{
    [Serializable]
    public sealed class FormalMethodResult : OptimizationMethodResult
    {
        private FormalMethodResult() : this(string.Empty, string.Empty) { }

        public FormalMethodResult(string methodName) : this(methodName, string.Empty) { }

        public FormalMethodResult(string methodName, string additionalDataDescription) : base (methodName, additionalDataDescription) { }

        public override CustomProperty Clone()
        {
            return new FormalMethodResult()
            {
                AdditionalData = new Dictionary<TId, double>(this.AdditionalData),
                AdditionalDataDescription = this.AdditionalDataDescription,
                MethodName = this.MethodName,
                SortedPoints = new List<TId>(this.SortedPoints)
            };
        }
    }
}