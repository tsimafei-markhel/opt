using System;

namespace opt.Units
{
    /// <summary>
    /// Represents measurable value: some quantity measured in certain units
    /// </summary>
    /// <typeparam name="TValue">Type that represents quantity (e.g. <see cref="Double"/>)</typeparam>
    public interface IMeasurable<TValue> : IComparable<IMeasurable<TValue>>, IEquatable<IMeasurable<TValue>>
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