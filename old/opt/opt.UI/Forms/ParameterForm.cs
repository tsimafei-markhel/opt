using System;
using System.Windows.Forms;
using opt.Helpers;
using opt.DataModel;
using opt.UI.Helpers;

namespace opt.UI.Forms
{
    internal partial class ParameterForm : Form
    {
        private Model _model;

        private TId _parameterId;

        public ParameterForm()
        {
            InitializeComponent();
            _parameterId = -1;
            _model = null;
            Text = "Ошибка! Вызван неверный конструктор!";
        }

        public ParameterForm(Model model)
        {
            InitializeComponent();
            _parameterId = -1;
            _model = model;
            Text = "Новый оптимизируемый параметр";
            nudParameterMinValue.DecimalPlaces = Program.ApplicationSettings.ValuesDecimalPlaces;
            nudParameterMaxValue.DecimalPlaces = Program.ApplicationSettings.ValuesDecimalPlaces;
        }

        public ParameterForm(Model model, TId parameterId)
        {
            InitializeComponent();
            _parameterId = parameterId;
            _model = model;
            Text = "Редактировать оптимизируемый параметр";
            nudParameterMinValue.DecimalPlaces = Program.ApplicationSettings.ValuesDecimalPlaces;
            nudParameterMaxValue.DecimalPlaces = Program.ApplicationSettings.ValuesDecimalPlaces;

            // Заполним поля значениями
            Parameter parameter = _model.Parameters[_parameterId];
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
                    MessageBoxHelper.ShowExclamation("Идентификатор переменной должен начинаться только с заглавной или строчной буквы \nлатинского алфавита и содержать заглавные и строчные буквы латинского алфавита,\n цифры и символ подчеркивания");
                    return;
                }

                if (VariableIdentifierChecker.IsInRestrictedList(paramVariableIdentifier, Program.ApplicationSettings.RestrictedVariableIdentifiers))
                {
                    MessageBoxHelper.ShowExclamation("Идентификатор переменной совпадает с одним из запрещенных вариантов");
                    return;
                }

                if (_parameterId == -1)
                {
                    // Если это новый параметр, то надо безусловно проверить 
                    // идентификатор
                    if (_model.CheckParameterVariableIdentifier(paramVariableIdentifier))
                    {
                        MessageBoxHelper.ShowExclamation("Оптимизируемый параметр с таким идентификатором переменной уже существует в модели");
                        return;
                    }
                }
                else
                {
                    // Если параметр редактируется, то если идентификатор 
                    // не изменялся, то можно его не проверять
                    if (_model.Parameters[this._parameterId].VariableIdentifier != paramVariableIdentifier &&
                        _model.CheckParameterVariableIdentifier(paramVariableIdentifier))
                    {
                        MessageBoxHelper.ShowExclamation("Оптимизируемый параметр с таким идентификатором переменной уже существует в модели");
                        return;
                    }
                }
            }

            if (paramMinValue >= paramMaxValue)
            {
                MessageBoxHelper.ShowExclamation("Минимальное значение оптимизируемого параметра должно быть меньше максимального");
                return;
            }

            if (_parameterId == -1)
            {
                _parameterId = _model.Parameters.GetFreeConsequentId();
                Parameter parameter = new Parameter(
                    _parameterId,
                    paramName,
                    paramVariableIdentifier,
                    paramMinValue,
                    paramMaxValue);
                _model.Parameters.Add(parameter);

                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                Parameter parameter = _model.Parameters[_parameterId];
                parameter.Name = paramName;
                parameter.VariableIdentifier = paramVariableIdentifier;
                parameter.MinValue = paramMinValue;
                parameter.MaxValue = paramMaxValue;

                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void btnGetValuesUsingBaseAndPercentage_Click(object sender, EventArgs e)
        {
            ParameterBasePercentageForm percentageForm = new ParameterBasePercentageForm();
            if (percentageForm.ShowDialog() == DialogResult.OK)
            {
                nudParameterMinValue.Value = Convert.ToDecimal(percentageForm.MinValue);
                nudParameterMaxValue.Value = Convert.ToDecimal(percentageForm.MaxValue);
            }
        }
    }
}