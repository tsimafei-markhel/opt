using System;
using System.Collections.Generic;
using opt.DataModel;

namespace opt.Solvers.MainCriterion
{
    [Serializable]
    public sealed class MainCriterionMethodResult : OptimizationMethodResult
    {
        /// <summary>
        /// ID главного критерия (по которому отсортированы 
        /// эксперименты в модели)
        /// </summary>
        public TId MainCriterionId { get; private set; }

        private MainCriterionMethodResult() : this(string.Empty, -1) { }

        public MainCriterionMethodResult(string methodName, TId mainCriterionId)
            : base(methodName)
        {
            MainCriterionId = mainCriterionId;
        }

        public override CustomProperty Clone()
        {
            return new MainCriterionMethodResult()
            {
                AdditionalData = new Dictionary<TId, double>(this.AdditionalData),
                AdditionalDataDescription = this.AdditionalDataDescription,
                MainCriterionId = this.MainCriterionId,
                MethodName = this.MethodName,
                SortedPoints = new List<TId>(this.SortedPoints)
            };
        }
    }
}