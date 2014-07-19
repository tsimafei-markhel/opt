using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using opt.Relations;
using opt.Units;

namespace opt.Samples.Relations
{
    public partial class MainForm : Form
    {
        private InequalityRelationValidator<Double> doubleRelationValidator;
        private SetRelationValidator<Double, HashSet<Double>> setRelationValidator;
        // TODO: private InequalityRelationValidator<DoubleMeasurable> doubleMeasurableRelationValidator;
        private SetRelationValidator<DoubleMeasurable, HashSet<DoubleMeasurable>> setMeasurableRelationValidator;

        private HashSet<Double> doubleSet;
        private HashSet<DoubleMeasurable> doubleMeasurableSet;

        public MainForm()
        {
            InitializeComponent();

            // Validators initialization
            InitializeValidators();

            InitializeSets();

            // UI initialization
            InitializeNumericFields();
        }

        private void InitializeValidators()
        {
            doubleRelationValidator = new InequalityRelationValidator<double>();
            setRelationValidator = new SetRelationValidator<double, HashSet<double>>();
            // TODO: doubleMeasurableRelationValidator = new InequalityRelationValidator<DoubleMeasurable>();
            setMeasurableRelationValidator = new SetRelationValidator<DoubleMeasurable, HashSet<DoubleMeasurable>>();
        }

        private void InitializeSets()
        {
            doubleSet = new HashSet<Double>();
            doubleMeasurableSet = new HashSet<DoubleMeasurable>();
        }

        private void InitializeNumericFields()
        {
            numericInequalityLeftDouble.Minimum = decimal.MinValue;
            numericInequalityLeftDouble.Maximum = decimal.MaxValue;
            numericInequalityLeftDouble.DecimalPlaces = 1;

            numericInequalityRightDouble.Minimum = decimal.MinValue;
            numericInequalityRightDouble.Maximum = decimal.MaxValue;
            numericInequalityRightDouble.DecimalPlaces = 1;

            numericSetAddDouble.Minimum = decimal.MinValue;
            numericSetAddDouble.Maximum = decimal.MaxValue;
            numericSetAddDouble.DecimalPlaces = 1;

            numericSetTestDouble.Minimum = decimal.MinValue;
            numericSetTestDouble.Maximum = decimal.MaxValue;
            numericSetTestDouble.DecimalPlaces = 1;
        }

        private void UpdateListSetDouble()
        {
            listSetDouble.SuspendLayout();
            listSetDouble.Items.Clear();

            foreach (Double value in doubleSet)
            {
                listSetDouble.Items.Add(value);
            }

            listSetDouble.ResumeLayout();
        }

        private void ResetRelationFields()
        {
            textEqual.BackColor = SystemColors.ControlLight;
            textNotEqual.BackColor = SystemColors.ControlLight;
            textLess.BackColor = SystemColors.ControlLight;
            textLessOrEqual.BackColor = SystemColors.ControlLight;
            textGreater.BackColor = SystemColors.ControlLight;
            textGreaterOrEqual.BackColor = SystemColors.ControlLight;

            textMember.BackColor = SystemColors.ControlLight;
            textNotMember.BackColor = SystemColors.ControlLight;
        }

        private void buttonTestInequalityDouble_Click(object sender, EventArgs e)
        {
            ResetRelationFields();

            double left = Convert.ToDouble(numericInequalityLeftDouble.Value);
            double right = Convert.ToDouble(numericInequalityRightDouble.Value);

            // TODO: Move the below to a generic method, p-haps add mapping between text field and a relation
            textEqual.BackColor = 
                doubleRelationValidator.Validate(InequalityRelation.Equal, left, right) ? Color.LightGreen : Color.OrangeRed;
            textNotEqual.BackColor =
                doubleRelationValidator.Validate(InequalityRelation.NotEqual, left, right) ? Color.LightGreen : Color.OrangeRed;
            textLess.BackColor =
                doubleRelationValidator.Validate(InequalityRelation.Less, left, right) ? Color.LightGreen : Color.OrangeRed;
            textLessOrEqual.BackColor =
                doubleRelationValidator.Validate(InequalityRelation.LessOrEqual, left, right) ? Color.LightGreen : Color.OrangeRed;
            textGreater.BackColor =
                doubleRelationValidator.Validate(InequalityRelation.Greater, left, right) ? Color.LightGreen : Color.OrangeRed;
            textGreaterOrEqual.BackColor =
                doubleRelationValidator.Validate(InequalityRelation.GreaterOrEqual, left, right) ? Color.LightGreen : Color.OrangeRed;
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            ResetRelationFields();
        }

        private void buttonSetAddDouble_Click(object sender, EventArgs e)
        {
            double value = Convert.ToDouble(numericSetAddDouble.Value);
            doubleSet.Add(value);

            UpdateListSetDouble();
        }

        private void buttonSetTestDouble_Click(object sender, EventArgs e)
        {
            ResetRelationFields();

            double value = Convert.ToDouble(numericSetTestDouble.Value);

            // TODO: Move the below to a generic method, p-haps add mapping between text field and a relation
            textMember.BackColor =
                setRelationValidator.Validate(SetRelation.Member, value, doubleSet) ? Color.LightGreen : Color.OrangeRed;
            textNotMember.BackColor =
                setRelationValidator.Validate(SetRelation.NotMember, value, doubleSet) ? Color.LightGreen : Color.OrangeRed;
        }
    }
}
