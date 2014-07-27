using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using opt.Relations;

namespace opt.Samples.Relations
{
    public partial class MainForm : Form
    {
        private static readonly Color validRelationColor = Color.LightGreen;
        private static readonly Color invalidRelationColor = Color.OrangeRed;
        private static readonly Color defaultRelationColor = SystemColors.ControlLight;

        private Dictionary<IRelation, TextBox> relationFields;

        private InequalityRelationValidator<Double> doubleRelationValidator;
        private SetRelationValidator<Double, HashSet<Double>> setRelationValidator;

        private HashSet<Double> doubleSet;

        public MainForm()
        {
            InitializeComponent();

            // Validators initialization
            InitializeValidators();

            InitializeSets();

            // UI initialization
            InitializeNumericFields();
            InitializeFieldsMapping();
        }

        private void InitializeValidators()
        {
            doubleRelationValidator = new InequalityRelationValidator<double>();
            setRelationValidator = new SetRelationValidator<double, HashSet<double>>();
        }

        private void InitializeSets()
        {
            doubleSet = new HashSet<Double>();
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

        private void InitializeFieldsMapping()
        {
            relationFields = new Dictionary<IRelation, TextBox>();
            relationFields.Add(InequalityRelation.Equal, textEqual);
            relationFields.Add(InequalityRelation.NotEqual, textNotEqual);
            relationFields.Add(InequalityRelation.Less, textLess);
            relationFields.Add(InequalityRelation.LessOrEqual, textLessOrEqual);
            relationFields.Add(InequalityRelation.Greater, textGreater);
            relationFields.Add(InequalityRelation.GreaterOrEqual, textGreaterOrEqual);
            relationFields.Add(SetRelation.Member, textMember);
            relationFields.Add(SetRelation.NotMember, textNotMember);
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
            textEqual.BackColor = defaultRelationColor;
            textNotEqual.BackColor = defaultRelationColor;
            textLess.BackColor = defaultRelationColor;
            textLessOrEqual.BackColor = defaultRelationColor;
            textGreater.BackColor = defaultRelationColor;
            textGreaterOrEqual.BackColor = defaultRelationColor;

            textMember.BackColor = defaultRelationColor;
            textNotMember.BackColor = defaultRelationColor;
        }

        private void buttonTestInequalityDouble_Click(object sender, EventArgs e)
        {
            ResetRelationFields();

            double left = Convert.ToDouble(numericInequalityLeftDouble.Value);
            double right = Convert.ToDouble(numericInequalityRightDouble.Value);

            // It is possible to iterate over all relation defined in a certain relation container
            foreach (IRelation relation in InequalityRelation.AllRelations())
            {
                relationFields[relation].BackColor =
                    doubleRelationValidator.Validate(relation, left, right) ? validRelationColor : invalidRelationColor;
            }
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

            // It is also possible to address relations defined in a relation container in an
            // enumeration way
            relationFields[SetRelation.Member].BackColor =
                setRelationValidator.Validate(SetRelation.Member, value, doubleSet) ? Color.LightGreen : Color.OrangeRed;
            relationFields[SetRelation.NotMember].BackColor =
                setRelationValidator.Validate(SetRelation.NotMember, value, doubleSet) ? Color.LightGreen : Color.OrangeRed;
        }
    }
}
