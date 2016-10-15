using System;
using System.Collections.Generic;
using opt.DataModel;

namespace opt.Solvers.Genetics.Nsga
{
    [Serializable]
    public sealed class NsgaMethodResult : OptimizationMethodResult
    {
        private NsgaMethodResult() : this(string.Empty) { }

        public NsgaMethodResult(string methodName) : base(methodName) { }

        public override CustomProperty Clone()
        {
            return new NsgaMethodResult()
            {
                AdditionalData = new Dictionary<TId, double>(this.AdditionalData),
                AdditionalDataDescription = this.AdditionalDataDescription,
                MethodName = this.MethodName,
                SortedPoints = new List<TId>(this.SortedPoints)
            };
        }
    }
}