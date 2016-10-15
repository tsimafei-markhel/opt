
// TODO: Add XML comments

namespace opt.UI.Exporters
{
    public sealed class TextResultExporterSettings
    {
        private const string defaultFilePath = "results.txt";

        public string FilePath { get; set; }

        public ExportableData ExportWhat { get; set; }

        public TextResultExporterSettings()
        {
            FilePath = defaultFilePath;
            ExportWhat = ExportableData.None;
        }
    }
}