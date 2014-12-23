using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using opt.Solvers.MainCriterion;
using opt.DataModel;
using opt.UI.Helpers.DataModel;
using opt.UI.Helpers;

namespace opt.UI.Forms
{
    public partial class CriterialConstraintForm : Form
    {
        private CriterialConstraint _constraint;
        public CriterialConstraint Constraint
        {
            get { return this._constraint; }
        }
        private Dictionary<TId, Criterion> _criteria;
        private TId _mainCriterionId;

        public CriterialConstraintForm()
        {
            InitializeComponent();
            this._constraint = null;
            this.Text = "Ошибка! Вызван неверный конструктор!";
        }

        public CriterialConstraintForm(
            Dictionary<TId, Criterion> criteria,
            TId mainCriterionId)
        {
            InitializeComponent();
            this._constraint = null;
            this._criteria = criteria;
            this._mainCriterionId = mainCriterionId;
            this.Text = "Новое критериальное ограничение";
            this.FillCriteriaList();
            this.FillSignsList();
            this.nudConstraintValue.DecimalPlaces = Program.ApplicationSettings.ValuesDecimalPlaces;
        }

        public CriterialConstraintForm(
            Dictionary<TId, Criterion> criteria,
            TId mainCriterionId,
            CriterialConstraint constraint)
        {
            InitializeComponent();
            this._constraint = constraint;
            this._criteria = criteria;
            this._mainCriterionId = mainCriterionId;
            this.Text = "Редактировать критериальное ограничение";
            this.FillCriteriaList();
            this.FillSignsList();
            this.nudConstraintValue.DecimalPlaces = Program.ApplicationSettings.ValuesDecimalPlaces;

            this.SelectProperCriterion();
            this.cmbConstraintSign.SelectedItem = RelationManager.GetRelationName(this._constraint.Relation);
            try
            {
                this.nudConstraintValue.Value = Convert.ToDecimal(this._constraint.Value);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                MessageBoxHelper.ShowError("'Value' of 'Constraint' class object is out of range\nOriginal message: " + ex.Message);
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
        }

        private void FillCriteriaList()
        {
            this.cmbCriterion.Items.Clear();

            foreach (Criterion crit in this._criteria.Values)
            {
                if (crit.Id != this._mainCriterionId)
                {
                    CriterionComboBoxItem item =
                        new CriterionComboBoxItem(crit.Id, crit.Name);
                    this.cmbCriterion.Items.Add(item);
                }
            }

            this.cmbCriterion.SelectedIndex = 0;
            this._mainCriterionId =
                ((CriterionComboBoxItem)this.cmbCriterion.SelectedItem).criterionId;
        }

        private void SelectProperCriterion()
        {
            foreach (object item in this.cmbCriterion.Items)
            {
                TId criterionId = ((CriterionComboBoxItem)item).criterionId;
                if (criterionId == this._constraint.CriterionId)
                {
                    this.cmbCriterion.SelectedItem = item;
                    break;
                }
            }
        }

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
            TId criterionId = ((CriterionComboBoxItem)this.cmbCriterion.SelectedItem).criterionId;
            Relation constrSign = RelationManager.ParseName(this.cmbConstraintSign.Text);
            double constrValue = Convert.ToDouble(this.nudConstraintValue.Value);

            if (this._constraint == null)
            {
                this._constraint = new CriterialConstraint(
                    criterionId,
                    constrSign,
                    constrValue);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                this._constraint.CriterionId = criterionId;
                this._constraint.Relation = constrSign;
                this._constraint.Value = constrValue;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

    }
}