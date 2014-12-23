using System;
using System.Windows.Forms;
using opt.DataModel;
using opt.Helpers;

namespace opt.UI
{
    internal partial class EditParameterForm : Form
    {
        public enum ParameterType { Identification, Optimization }

        private IdentificationModel model = ModelStorage.Instance.Model;
        private Parameter parameter;
        private ParameterType parameterType;

        public EditParameterForm(ParameterType paramType)
            : this(paramType, null) { }

        public EditParameterForm(ParameterType paramType, Parameter parameter)
        {
            InitializeComponent();
            parameterType = paramType;
            nudParameterMinValue.DecimalPlaces = SettingsManager.Instance.ValuesDecimalPlaces;
            nudParameterMaxValue.DecimalPlaces = SettingsManager.Instance.ValuesDecimalPlaces;

            if (parameter != null)
            {
                Text = "Редактировать параметр";

                this.parameter = parameter;
                // filling form
                txtParameterName.Text = parameter.Name;
                txtParameterVariableIdentifier.Text = parameter.VariableIdentifier;
                try
                {
                    nudParameterMinValue.Value = Convert.ToDecimal(parameter.MinValue);
                    nudParameterMaxValue.Value = Convert.ToDecimal(parameter.MaxValue);
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    MessageBoxHelper.ShowError("'MinValue' or 'MaxValue' of 'Parameter' class object is out of range\nOriginal message: " + ex.Message);
                    DialogResult = DialogResult.Cancel;
                    Close();
                }
            }
            else
            {
                Text = "Новый параметр";
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            string paramName = txtParameterName.Text.Trim();
            string paramVariableIdentifier = txtParameterVariableIdentifier.Text.Trim();
            double paramMinValue = Convert.ToDouble(nudParameterMinValue.Value);
            double paramMaxValue = Convert.ToDouble(nudParameterMaxValue.Value);

            if (string.IsNullOrEmpty(paramName))
            {
                MessageBoxHelper.ShowExclamation("Введите имя оптимизируемого параметра");
                return;
            }

            if (!string.IsNullOrEmpty(paramVariableIdentifier))
            {
                if (!VariableIdentifierChecker.RegExCheck(paramVariableIdentifier))
                {
                    MessageBoxHelper.ShowExclamation("Идентификатор переменной должен наинаться только с заглавной или строчной буквы \nлатинского алфавита и содержать заглавные и строчные буквы латинского алфавита,\n цифры и символ подчеркивания");
                    return;
                }

                if (parameter == null || parameter.VariableIdentifier != paramVariableIdentifier)
                {
                    if (CheckExistence(paramVariableIdentifier))
                    {
                        MessageBoxHelper.ShowExclamation("Параметр с таким идентификатором переменной уже существует в модели");
                        return;
                    }
                }
            }

            if (paramMinValue >= paramMaxValue)
            {
                MessageBoxHelper.ShowExclamation("Минимальное значение оптимизируемого параметра должно быть меньше максимального");
                return;
            }

            //can change if an empty constructor will be - Parameter()
            if (parameter == null)
            {
                TId parameterId = -1;
                switch (parameterType)
                {
                    case ParameterType.Identification:
                        parameterId = model.IdentificationParameters.GetFreeConsequentId();
                        break;
                    case ParameterType.Optimization:
                        parameterId = model.OptimizationParameters.GetFreeConsequentId();
                        break;
                }

                parameter = new Parameter(
                    parameterId,
                    paramName,
                    paramVariableIdentifier,
                    paramMinValue,
                    paramMaxValue);

                switch (parameterType)
                {
                    case ParameterType.Identification:
                        model.IdentificationParameters.Add(parameter);
                        break;
                    case ParameterType.Optimization:
                        model.OptimizationParameters.Add(parameter);
                        break;
                }
            }
            else
            {
                parameter.Name = paramName;
                parameter.VariableIdentifier = paramVariableIdentifier;
                parameter.MinValue = paramMinValue;
                parameter.MaxValue = paramMaxValue;   
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        /// <summary>
        /// Checks existence of VariableIdentifier
        /// </summary>
        /// <param name="paramVariableIdentifier">VariableIdentifier of parameter</param>
        private bool CheckExistence(string paramVariableIdentifier)
        {
            bool checkResult = false;
            switch (parameterType)
            {
                case ParameterType.Identification:
                    checkResult = model.CheckIdentificationParameterVariableIdentifier(paramVariableIdentifier);
                    break;
                case ParameterType.Optimization:
                    checkResult = model.CheckOptimizationParameterVariableIdentifier(paramVariableIdentifier);
                    break;
            }

            return checkResult;
        }
    }
}