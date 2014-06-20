using System;

namespace opt.Units
{
    /// <summary>
    /// Represents measurable value: some quantity measured in certain units
    /// </summary>
    /// <typeparam name="TValue"></typeparam>
    public interface IMeasurable<TValue> : IComparable<IMeasurable<TValue>>, IEquatable<IMeasurable<TValue>>
        where TValue : IComparable<TValue>, IEquatable<TValue>
    {
        /// <summary>
        /// Gets unit of measurement
        /// </summary>
        IUnit Unit { get; }

        /// <summary>
        /// Gets or sets quantity being measured
        /// </summary>
        TValue Value { get; set; }
    }
}