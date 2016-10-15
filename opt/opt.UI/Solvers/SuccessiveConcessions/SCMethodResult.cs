using System;
using System.Collections.Generic;
using opt.DataModel;

namespace opt.Solvers.SuccessiveConcessions
{
    [Serializable]
    public sealed class ScMethodResult : OptimizationMethodResult
    {
        private ScMethodResult() : this(string.Empty) { }

        public ScMethodResult(string methodName) : base(methodName) { }

        public override CustomProperty Clone()
        {
            return new ScMethodResult()
            {
                AdditionalData = new Dictionary<TId, double>(this.AdditionalData),
                AdditionalDataDescription = this.AdditionalDataDescription,
                MethodName = this.MethodName,
                SortedPoints = new List<TId>(this.SortedPoints)
            };
        }
    }
}