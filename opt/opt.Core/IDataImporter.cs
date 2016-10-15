using opt.DataModel;

namespace opt
{
    /// <summary>
    /// Interface for various <see cref="Model"/> importers
    /// </summary>
    public interface IDataImporter
    {
        /// <summary>
        /// Imports <paramref name="model"/> from <paramref name="dataSource">
        /// </summary>
        /// <param name="dataSource">Source to import <see cref="Model"/> from</param>
        /// <returns>Imported <see cref="Model"/></returns>
        Model Import(object dataSource);
    }
}