namespace opt
{
    /// <summary>
    /// Describes importable entity
    /// </summary>
    public interface IImportable
    {
        /// <summary>
        /// Imports an instance from specified source
        /// </summary>
        /// <param name="source">Import source (stream, XmlReader etc.)</param>
        /// <returns>Imported instance</returns>
        object Import(object source);
    }
}