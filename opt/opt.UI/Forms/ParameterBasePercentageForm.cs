using System;
using System.Windows.Forms;
using opt.Extensions;
using opt.UI.Helpers;

namespace opt.UI.Forms
{
    public partial class ParameterBasePercentageForm : Form
    {
        public double MinValue;
        public double MaxValue;

        public ParameterBasePercentageForm()
        {
            InitializeComponent();
            nudParameterBaseValue.DecimalPlaces = Program.ApplicationSettings.ValuesDecimalPlaces;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                UpdateValues();

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBoxHelper.ShowError("Ошбика при расчете минимального и максимального значений:\n" + ex.Message);
            }
        }

        private void UpdateValues()
        {
            double baseValue = Convert.ToDouble(nudParameterBaseValue.Value);
            double deviationPercentage = Convert.ToDouble(nudParameterDeviationPercentageValue.Value);

            MinValue = baseValue - baseValue * deviationPercentage / 100.0;
            MaxValue = baseValue + baseValue * deviationPercentage / 100.0;

            lblMinValue.Text = MinValue.ToStringInvariant(SettingsManager.Instance.DoubleStringFormat);
            lblMaxValue.Text = MaxValue.ToStringInvariant(SettingsManager.Instance.DoubleStringFormat);
        }

        private void nudParameterBaseValue_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                UpdateValues();
            }
            catch (Exception ex)
            {
                MessageBoxHelper.ShowError("Ошбика при расчете минимального и максимального значений:\n" + ex.Message);
            }
        }
    }
}