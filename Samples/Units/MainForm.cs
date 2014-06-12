using System.Windows.Forms;
using opt.Units;

namespace Units
{
    public partial class MainForm : Form
    {
        private sealed class UnitsComboBoxItem
        {
            public IUnit Unit { get; set; }

            public override string ToString()
            {
                if (Unit != null)
                {
                    if (Unit is PrefixedUnit)
                    {
                        return " - " + Unit.Name;
                    }
                    else
                    {
                        return Unit.Name;
                    }
                }

                return base.ToString();
            }
        }

        private UnitCollection units;

        public MainForm()
        {
            InitializeComponent();
            InitializeUnits();

            FillTree();
            FillComboBox();
            InitNumericField();
        }

        private void InitNumericField()
        {
            numericValue.Minimum = decimal.MinValue;
            numericValue.Maximum = decimal.MaxValue;
            numericValue.DecimalPlaces = 1;
        }

        private void FillComboBox()
        {
            foreach (IUnit unit in units)
            {
                comboUnits.Items.Add(new UnitsComboBoxItem() { Unit = unit });
                foreach (IPrefixedUnit prefixedUnit in ((Unit)unit).PrefixedUnits)
                {
                    comboUnits.Items.Add(new UnitsComboBoxItem() { Unit = prefixedUnit });
                }
            }
        }

        private void FillTree()
        {
            foreach (IUnit unit in units)
            {
                TreeNode unitNode = new TreeNode(unit.Name);
                unitNode.Tag = unit;
                treeUnits.Nodes.Add(unitNode);
                foreach (IPrefixedUnit prefixedUnit in ((Unit)unit).PrefixedUnits)
                {
                    TreeNode prefixedUnitNode = new TreeNode(prefixedUnit.Name);
                    prefixedUnitNode.Tag = prefixedUnit;
                    unitNode.Nodes.Add(prefixedUnitNode);
                }
            }
        }

        private void InitializeUnits()
        {
            units = XmlUnitLoader.Load("SI-Units.xml");
        }

        private void treeUnits_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            IUnit unit = e.Node.Tag as IUnit;
            IPrefixedUnit prefixedUnit = e.Node.Tag as IPrefixedUnit;

            if (unit != null)
            {
                labelUnitName.Text = unit.Name;
                labelUnitSymbol.Text = unit.Symbol;
            }

            if (prefixedUnit != null)
            {
                labelUnitBaseUnit.Text = prefixedUnit.BaseUnit.Name;
                labelUnitMultiplier.Text = prefixedUnit.Multiplier.ToString();
            }
            else
            {
                labelUnitBaseUnit.Text = "-";
                labelUnitMultiplier.Text = "-";
            }
        }

        private void buttonConvert_Click(object sender, System.EventArgs e)
        {

        }
    }
}
