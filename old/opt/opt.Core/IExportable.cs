namespace opt
{
    /// <summary>
    /// Describes exportable entity
    /// </summary>
    public interface IExportable
    {
        /// <summary>
        /// Exports this instance to specified destination
        /// </summary>
        /// <param name="destination">Export destination (stream, XmlWriter etc.)</param>
        void Export(object destination);
    }
}