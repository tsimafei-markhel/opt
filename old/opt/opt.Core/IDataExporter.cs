using opt.DataModel;

namespace opt
{
    /// <summary>
    /// Interface for various <see cref="Model"/> exporters
    /// </summary>
    public interface IDataExporter
    {
        /// <summary>
        /// Exports <paramref name="model"/> to specified format
        /// </summary>
        /// <param name="model"><see cref="Model"/> to be exported</param>
        void Export(Model model);
    }
}