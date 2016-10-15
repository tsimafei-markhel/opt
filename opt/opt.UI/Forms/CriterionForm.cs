using System;
using System.Windows.Forms;
using opt.Helpers;
using opt.DataModel;
using opt.UI.Helpers.DataModel;
using opt.UI.Helpers;

namespace opt.UI.Forms
{
    internal partial class CriterionForm : Form
    {
        private Model _model;

        private TId _criterionId;

        public CriterionForm()
        {
            InitializeComponent();
            this._model = null;
            this._criterionId = -1;
            this.Text = "Ошибка! Вызван неверный конструктор!";
        }

        public CriterionForm(
            Model model)
        {
            InitializeComponent();
            this._model = model;
            this._criterionId = -1;
            this.Text = "Новый критерий оптимальности";
            this.FillCriterionTypesList();
#if DUMMY
            this.DummyMode();
#endif
        }

        public CriterionForm(
            Model model,
            TId criterionId)
        {
            InitializeComponent();
            this._model = model;
            this._criterionId = criterionId;
            this.Text = "Редактировать критерий оптимальности";
            this.FillCriterionTypesList();
#if DUMMY
            this.DummyMode();
#endif

            // Заполним поля информацией
            Criterion criterion = this._model.Criteria[this._criterionId];
            this.txtCriterionName.Text = criterion.Name;
            this.txtCriterionVariableIdentifier.Text = criterion.VariableIdentifier;
            this.cmbCriterionType.SelectedItem = 
                CriterionTypeManager.GetCriterionTypeName(criterion.Type);
            this.txtCriterionExpression.Text = criterion.Expression;
        }

#if DUMMY
        private void DummyMode()
        {
            this.label4.Visible = false;
            this.txtCriterionExpression.Visible = false;
        }
#endif

        private void FillCriterionTypesList()
        {
            this.cmbCriterionType.Items.AddRange(CriterionTypeManager.GetCriterionTypeNames().ToArray());
            this.cmbCriterionType.SelectedIndex = 0;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            string critName = this.txtCriterionName.Text.Trim();
            string critVariableIdentifier = this.txtCriterionVariableIdentifier.Text.Trim();
            CriterionType critType = CriterionTypeManager.ParseName(this.cmbCriterionType.Text);

#if DUMMY
            string critExpression = string.Empty;
#else
            string critExpression = this.txtCriterionExpression.Text.Trim();
#endif

            if (string.IsNullOrEmpty(critName))
            {
                MessageBoxHelper.ShowExclamation("Введите имя критерия оптимальности");
                return;
            }
            if (!string.IsNullOrEmpty(critVariableIdentifier))
            {
                if (!VariableIdentifierChecker.RegExCheck(critVariableIdentifier))
                {
                    MessageBoxHelper.ShowExclamation("Идентификатор переменной должен начинаться только с заглавной или строчной буквы \nлатинского алфавита и содержать заглавные и строчные буквы латинского алфавита,\n цифры и символ подчеркивания");
                    return;
                }
                if (VariableIdentifierChecker.IsInRestrictedList(critVariableIdentifier, Program.ApplicationSettings.RestrictedVariableIdentifiers))
                {
                    MessageBoxHelper.ShowExclamation("Идентификатор переменной совпадает с одним из запрещенных вариантов");
                    return;
                }
                if (this._criterionId == -1)
                {
                    // Если это новый критерий, то надо безусловно проверить 
                    // идентификатор
                    if (this._model.CheckCriterionVariableIdentifier(critVariableIdentifier))
                    {
                        MessageBoxHelper.ShowExclamation("Критерий оптимальности с таким идентификатором переменной уже существует в модели");
                        return;
                    }
                }
                else
                {
                    // Если критерий редактируется, то если идентификатор 
                    // не изменялся, то можно его не проверять
                    if (this._model.Criteria[this._criterionId].VariableIdentifier != critVariableIdentifier &&
                        this._model.CheckCriterionVariableIdentifier(critVariableIdentifier))
                    {
                        MessageBoxHelper.ShowExclamation("Критерий оптимальности с таким идентификатором переменной уже существует в модели");
                        return;
                    }
                }
            }

            if (this._criterionId == -1)
            {
                this._criterionId = this._model.Criteria.GetFreeConsequentId();
                Criterion criterion = new Criterion(
                    this._criterionId,
                    critName,
                    critVariableIdentifier,
                    critType,
                    critExpression);
                this._model.Criteria.Add(criterion);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                Criterion criterion = this._model.Criteria[this._criterionId];
                criterion.Name = critName;
                criterion.VariableIdentifier = critVariableIdentifier;
                criterion.Type = critType;
                criterion.Expression = critExpression;

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}