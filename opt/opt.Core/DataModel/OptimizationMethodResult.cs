using System;
using System.Collections.Generic;

namespace opt.DataModel
{
    /// <summary>
    /// Defines a result of optimization method
    /// </summary>
    [Serializable]
    public abstract class OptimizationMethodResult : CustomProperty
    {
        /// <summary>
        /// Gets a list of experiment IDs sorted in accordance with 
        /// chosen decision-making method
        /// </summary>
        public List<TId> SortedPoints { get; protected set; }

        /// <summary>
        /// Gets additional data used to find the solution
        /// Key - experiment ID, Value - corresponding additional data value
        /// </summary>
        public Dictionary<TId, double> AdditionalData { get; protected set; }

        /// <summary>
        /// Gets or sets additional data human-compatible description
        /// </summary>
        public string AdditionalDataDescription { get; set; }

        /// <summary>
        /// Get or sets name of the method that was used to find result
        /// </summary>
        public string MethodName { get; set; }

        /// <summary>
        /// Gets name of the custom property
        /// </summary>
        public override string Name
        {
            get { return OptimizationMethodResult.PropertyName; }
        }

        /// <summary>
        /// Gets name of the custom property
        /// </summary>
        public static string PropertyName
        {
            get { return typeof(OptimizationMethodResult).Name; }
        }

        /// <summary>
        /// Initializes new instance of <see cref="OptimizationMethodResult"/>
        /// </summary>
        private OptimizationMethodResult() : this(string.Empty, string.Empty) { }

        /// <summary>
        /// Initializes new instance of <see cref="OptimizationMethodResult"/> with
        /// specified optimization method name
        /// </summary>
        /// <param name="methodName">Name of the method that was used to find result</param>
        protected OptimizationMethodResult(string methodName) : this(methodName, string.Empty) { }

        /// <summary>
        /// Initializes new instance of <see cref="OptimizationMethodResult"/> with
        /// specified optimization method name and additional data description
        /// </summary>
        /// <param name="methodName">Name of the method that was used to find result</param>
        /// <param name="additionalDataDescription">Additional data human-compatible description</param>
        protected OptimizationMethodResult(string methodName, string additionalDataDescription)
        {
            SortedPoints = new List<TId>();
            AdditionalData = new Dictionary<TId, double>();
            AdditionalDataDescription = additionalDataDescription ?? string.Empty;
            MethodName = methodName ?? string.Empty;
        }
    }
}