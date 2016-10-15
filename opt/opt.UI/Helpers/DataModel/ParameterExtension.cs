using opt.DataModel;

// TODO: Add XML comments

namespace opt.UI.Helpers.DataModel
{
    public static class ParameterExtension
    {
        public static string GetDescription(this Parameter parameter)
        {
            return "Идентификатор переменной: " + parameter.VariableIdentifier +
                   "\nМинимальное допустимое значение: " + parameter.MinValue.ToString(SettingsManager.Instance.DoubleStringFormat) +
                   "\nМаксимальное допустимое значение: " + parameter.MaxValue.ToString(SettingsManager.Instance.DoubleStringFormat);
        }
    }
}