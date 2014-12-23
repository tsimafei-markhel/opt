
// TODO: Add XML comments

namespace opt.UI.Exporters
{
    public sealed class ExcelExporterSettings
    {
        private const string defaultFilePath = "model.xlsx";

        public string FilePath { get; set; }

        public ExportableData ExportWhat { get; set; }

        public ExcelExporterSettings()
        {
            FilePath = defaultFilePath;
            ExportWhat = ExportableData.None;
        }
    }
}