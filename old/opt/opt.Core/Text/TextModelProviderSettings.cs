
// TODO: Add XML comments

namespace opt.Text
{
    public sealed class TextModelProviderSettings
    {
        public string ParametersFilePath { get; set; }

        public string InformationFilePath { get; set; }

        public string ResultFilePath { get; set; }

        public TextModelProviderSettings()
        {
            ParametersFilePath = SettingsManager.Instance.ParametersFileName;
            InformationFilePath = SettingsManager.Instance.QuantitiesFileName;
            ResultFilePath = SettingsManager.Instance.ResultsFileName;
        }
    }
}