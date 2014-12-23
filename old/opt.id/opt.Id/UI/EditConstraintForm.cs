using System;
using System.Windows.Forms;
using opt.DataModel;
using opt.Helpers;

namespace opt.UI
{
    internal partial class EditConstraintForm : Form
    {
        private IdentificationModel model = ModelStorage.Instance.Model;
        private Constraint constraint;

        public EditConstraintForm() 
            : this(null) { /* NOP */ }

        public EditConstraintForm(
            Constraint constraint)
        {
            InitializeComponent();
            this.FillSignsList();
            this.nudConstraintValue.DecimalPlaces = SettingsManager.Instance.ValuesDecimalPlaces;

            if (constraint != null)
            {
                this.Text = "Редактировать функциональное ограничение";
                this.constraint = constraint;
                this.txtConstraintName.Text = constraint.Name;
                this.txtConstraintVariableIdentifier.Text = constraint.VariableIdentifier;
                this.cmbConstraintSign.SelectedItem = RelationManager.GetRelationName(constraint.ConstraintRelation);
                try
                {
                    this.nudConstraintValue.Value = Convert.ToDecimal(constraint.Value);
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    MessageBoxHelper.ShowError("'Value' of 'Constraint' class object is out of range\nOriginal message: " + ex.Message);
                    this.DialogResult = DialogResult.Cancel;
                    this.Close();
                }
            }
            else
            {
                this.Text = "Новое функциональное ограничение";
            }
        }

        private void FillSignsList()
        {
            this.cmbConstraintSign.Items.AddRange(
                RelationManager.GetRelationNames().ToArray());
            this.cmbConstraintSign.SelectedIndex = 0;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            //get values
            string constrName = this.txtConstraintName.Text.Trim();
            string constrVariableIdentifier = this.txtConstraintVariableIdentifier.Text.Trim();
            Relation constrSign = RelationManager.ParseName(this.cmbConstraintSign.Text);
            double constrValue = Convert.ToDouble(this.nudConstraintValue.Value);

            //validation
            if (string.IsNullOrEmpty(constrName))
            {
                MessageBoxHelper.ShowExclamation("Введите имя Функционального ограничения");
                return;
            }

            if (!string.IsNullOrEmpty(constrVariableIdentifier))
            {
                if (!VariableIdentifierChecker.RegExCheck(constrVariableIdentifier))
                {
                    MessageBoxHelper.ShowExclamation("Идентификатор переменной должен наинаться только с заглавной или строчной буквы \nлатинского алфавита и содержать заглавные и строчные буквы латинского алфавита,\n цифры и символ подчеркивания");
                    return;
                }

                if (constraint == null || constraint.VariableIdentifier != constrVariableIdentifier)
                {
                    if (model.CheckConstraintVariableIdentifier(constrVariableIdentifier))
                    {
                        MessageBoxHelper.ShowExclamation("Параметр с таким идентификатором переменной уже существует в модели");
                        return;
                    }
                }
            }

            //init
            if (constraint == null)
            {
                TId constrId = model.FunctionalConstraints.GetFreeConsequentId();
                constraint = new Constraint(
                    constrId,
                    constrName,
                    constrVariableIdentifier,
                    constrSign,
                    constrValue,
                    "");
                model.FunctionalConstraints.Add(constraint);
            }
            else
            { 
                constraint.Name = constrName;
                constraint.VariableIdentifier = constrVariableIdentifier;
                constraint.ConstraintRelation = constrSign;
                constraint.Value = constrValue; 
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}