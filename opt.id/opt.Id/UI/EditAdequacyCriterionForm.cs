using System;
using System.Windows.Forms;
using opt.DataModel;
using opt.Helpers;

namespace opt.UI
{
    internal partial class EditAdequacyCriterionForm : Form
    {
        private IdentificationModel model = ModelStorage.Instance.Model;
        private AdequacyCriterion criterion;

        public EditAdequacyCriterionForm() 
            : this(null) { /* NOP */ }

        public EditAdequacyCriterionForm(AdequacyCriterion criterion)
        {
            InitializeComponent();
            this.FillAdequacyCriterionTypesList();
            AdequacyCriterionType type;

            if (criterion != null)
            {
                this.Text = "Редактировать критерий адекватности";
                this.criterion = criterion;
                this.txtCriterionName.Text = criterion.Name;
                this.txtCriterionVariableIdentifier.Text = criterion.VariableIdentifier;
                type = criterion.AdequacyType;
            }
            else
            {
                this.Text = "Новый критерий адекватности";
                //taking value of previous criterion if possible
                if (model.Criteria.Count != 0)
                {
                    type = model.Criteria[model.Criteria.Count - 1].AdequacyType;
                }
                else
                {
                    //defaulf value
                    type = AdequacyCriterionType.DifferenceInSquare;
                }
            }
            this.cmbAdequacyCriterionType.SelectedItem =
                        AdequacyCriterionTypeManager.GetFriendlyName(type);
            this.pbAdequacyCriterionFunction.Image =
                AdequacyCriterionTypeManager.GetImage(type);
        }

        private void FillAdequacyCriterionTypesList()
        {
            this.cmbAdequacyCriterionType.Items.AddRange(
                AdequacyCriterionTypeManager.GetCriterionTypeNames().ToArray());
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
            AdequacyCriterionType critType = AdequacyCriterionTypeManager.ParseName(this.cmbAdequacyCriterionType.Text);

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

                if (criterion == null || criterion.VariableIdentifier != critVariableIdentifier)
                {
                    if (model.CheckCriterionVariableIdentifier(critVariableIdentifier))
                    {
                        MessageBoxHelper.ShowExclamation("Параметр с таким идентификатором переменной уже существует в модели");
                        return;
                    }
                }
            }

            if (criterion == null)
            {
                TId criterionId = model.Criteria.GetFreeConsequentId();
                criterion = new AdequacyCriterion(
                    criterionId,
                    critName,
                    critVariableIdentifier,
                    critType);
                model.Criteria.Add(criterion);
            }
            else
            {
                criterion.Name = critName;
                criterion.VariableIdentifier = critVariableIdentifier;
                criterion.AdequacyType = critType;
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void cmbAdequacyCriterionType_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.pbAdequacyCriterionFunction.Image =
                AdequacyCriterionTypeManager.GetImage(
                    AdequacyCriterionTypeManager.ParseName(
                         this.cmbAdequacyCriterionType.Text));
        }
    }
}