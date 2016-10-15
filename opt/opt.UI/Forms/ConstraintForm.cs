using System;
using System.Windows.Forms;
using opt.Helpers;
using opt.DataModel;
using opt.UI.Helpers.DataModel;
using opt.UI.Helpers;

namespace opt.UI.Forms
{
    internal partial class ConstraintForm : Form
    {
        private Model _model;

        private TId _constraintId;

        public ConstraintForm()
        {
            InitializeComponent();
            this._model = null;
            this._constraintId = -1;
            this.Text = "Ошибка! Вызван неверный конструктор!";
        }

        public ConstraintForm(
            Model model)
        {
            InitializeComponent();
            this._model = model;
            this._constraintId = -1;
            this.Text = "Новое функциональное ограничение";
            this.FillSignsList();
            this.nudConstraintValue.DecimalPlaces = Program.ApplicationSettings.ValuesDecimalPlaces;
#if DUMMY
            this.DummyMode();
#endif
        }

        public ConstraintForm(
            Model model,
            TId constraintId)
        {
            InitializeComponent();
            this._model = model;
            this._constraintId = constraintId;
            this.Text = "Редактировать функциональное ограничение";
            this.FillSignsList();
            this.nudConstraintValue.DecimalPlaces = Program.ApplicationSettings.ValuesDecimalPlaces;
#if DUMMY
            this.DummyMode();
#endif

            // Заполним поля данными
            Constraint constraint = this._model.FunctionalConstraints[this._constraintId];
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
            this.txtConstraintExpression.Text = constraint.Expression;
        }

#if DUMMY
        private void DummyMode()
        {
            // Поотключаем все, что не надо дурачкам
            this.label6.Visible = false;
            this.txtConstraintExpression.Visible = false;
        }
#endif

        private void FillSignsList()
        {
            this.cmbConstraintSign.Items.AddRange(RelationManager.GetRelationNames().ToArray());
            this.cmbConstraintSign.SelectedIndex = 0;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            string constrName = this.txtConstraintName.Text.Trim();
            string constrVariableIdentifier = this.txtConstraintVariableIdentifier.Text.Trim();
            Relation constrSign = RelationManager.ParseName(this.cmbConstraintSign.Text);
            double constrValue = Convert.ToDouble(this.nudConstraintValue.Value);

#if DUMMY
            string constrExpression = string.Empty;
#else
            string constrExpression = this.txtConstraintExpression.Text.Trim();
#endif

            if (string.IsNullOrEmpty(constrName))
            {
                MessageBoxHelper.ShowExclamation("Введите имя Функционального ограничения");
                return;
            }
            if (!string.IsNullOrEmpty(constrVariableIdentifier))
            {
                if (!VariableIdentifierChecker.RegExCheck(constrVariableIdentifier))
                {
                    MessageBoxHelper.ShowExclamation("Идентификатор переменной должен начинаться только с заглавной или строчной буквы \nлатинского алфавита и содержать заглавные и строчные буквы латинского алфавита,\n цифры и символ подчеркивания");
                    return;
                }
                if (VariableIdentifierChecker.IsInRestrictedList(constrVariableIdentifier, Program.ApplicationSettings.RestrictedVariableIdentifiers))
                {
                    MessageBoxHelper.ShowExclamation("Идентификатор переменной совпадает с одним из запрещенных вариантов");
                    return;
                }
                if (this._constraintId == -1)
                {
                    // Если это новое ограничение, то надо безусловно проверить 
                    // идентификатор
                    if (this._model.CheckConstraintVariableIdentifier(constrVariableIdentifier))
                    {
                        MessageBoxHelper.ShowExclamation("Функциональное ограничение с таким идентификатором переменной уже существует в модели");
                        return;
                    }
                }
                else
                {
                    // Если ограничение редактируется, то если идентификатор 
                    // не изменялся, то можно его не проверять
                    if (this._model.FunctionalConstraints[this._constraintId].VariableIdentifier != constrVariableIdentifier &&
                        this._model.CheckConstraintVariableIdentifier(constrVariableIdentifier))
                    {
                        MessageBoxHelper.ShowExclamation("Функциональное ограничение с таким идентификатором переменной уже существует в модели");
                        return;
                    }
                }
            }

            if (this._constraintId == -1)
            {
                this._constraintId = this._model.FunctionalConstraints.GetFreeConsequentId();
                Constraint constraint = new Constraint(
                    this._constraintId,
                    constrName,
                    constrVariableIdentifier,
                    constrSign,
                    constrValue,
                    constrExpression);
                this._model.FunctionalConstraints.Add(constraint);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                Constraint constraint = this._model.FunctionalConstraints[this._constraintId];
                constraint.Name = constrName;
                constraint.VariableIdentifier = constrVariableIdentifier;
                constraint.ConstraintRelation = constrSign;
                constraint.Value = constrValue;
                constraint.Expression = constrExpression;

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}