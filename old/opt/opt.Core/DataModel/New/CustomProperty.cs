using System;

namespace opt.DataModel.New
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
        public virtual String Name { get; private set; }

        /// <summary>
        /// Initializes new instance of <see cref="CustomProperty"/> with specified name
        /// </summary>
        /// <param name="name">Name of the property</param>
        protected CustomProperty(String name)
        {
            Name = name;
        }

        /// <summary>
        /// Creates a deep copy of <see cref="CustomProperty"/> instance
        /// </summary>
        /// <returns>Deep copy of self</returns>
        public abstract Object Clone();
    }
}