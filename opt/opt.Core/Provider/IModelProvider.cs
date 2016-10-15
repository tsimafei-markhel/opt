using opt.DataModel;

namespace opt.Provider
{
    /// <summary>
    /// Entity capable of loading and saving instances of <see cref="Model"/>.
    /// </summary>
    public interface IModelProvider
    {
        /// <summary>
        /// Reads <see cref="Model"/> from a file.
        /// </summary>
        /// <param name="filePath">Full path to model file.</param>
        /// <returns><see cref="Model"/> instance read from the <paramref name="filePath"/>.</returns>
        Model Load(string filePath);

        /// <summary>
        /// Writes <paramref name="model"/> to a file.
        /// </summary>
        /// <param name="model"><see cref="Model"/> instance to be written to a file.</param>
        /// <param name="filePath">Full path to target model file.</param>
        void Save(Model model, string filePath);
    }
}