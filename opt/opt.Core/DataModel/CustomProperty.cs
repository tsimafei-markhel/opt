using System;

namespace opt.DataModel
{
    /// <summary>
    /// Base for custom properties of the <see cref="Model"/> and its components
    /// </summary>
    [Serializable]
    public abstract class CustomProperty
    {
        /// <summary>
        /// Gets name of the custom property (can be used as a key)
        /// </summary>
        public abstract string Name { get; }

        /// <summary>
        /// Creates a deep copy of <see cref="CustomProperty"/> instance
        /// </summary>
        /// <returns>Deep copy of self</returns>
        public abstract CustomProperty Clone();
    }
}