using System;
using System.Windows.Forms;
using opt.Samples.Units.CustomUnit;
using opt.Units;

namespace opt.Samples.Units
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

        // Here all units (loaded or created on runtime) will be stored
        private UnitCollection units;

        // Storage for custom conversion rules
        private UnitConversionDictionary<double> conversions;

        // Provider to handle conversions between prefixed units
        private DoublePrefixedUnitConversionProvider prefixedConversions;

        // Single access point to all existing conversion rules, will be used to convert values
        private UnitConverter<double> converter;

        private string conversionResultFormat = "{0} {1}   is   {2} {3}";

        public MainForm()
        {
            InitializeComponent();

            // First, initialize units
            InitializeUnits();
            // Second, initialize conversion rules and converter
            InitializeConversions();
            InitializeConverter();

            // UI initialization
            FillTree();
            FillComboBox();
            InitializeNumericField();
        }

        private void InitializeUnits()
        {
            // 1. Load predefined units from external source
            units = XmlUnitLoader.Load("SI-Units.xml");

            // 2. Define units in code
            Unit pound = new Unit("pound", "lb");
            units.Add(pound);

            // 3. Define custom class for unit and use it
            MyUnit parrot = new MyUnit("parrot", "prt", "made up unit of measurement");
            MyUnit boa = new MyUnit("boa", "boa", "another made up unit of measurement");
            units.Add(parrot);
            units.Add(boa);
        }

        private void InitializeConversions()
        {
            // 1. For prefixed units, use predefined prefixed unit converter
            prefixedConversions = new DoublePrefixedUnitConversionProvider();

            // 2. Load conversions from external source
            conversions = XmlConversionLoader.Load("Conversions.xml", units);

            // 3. Define conversions in code
            IUnit degreeCelsius = units.Contains("degree Celsius") ? units["degree Celsius"] : null;
            IUnit kelvin = units.Contains("kelvin") ? units["kelvin"] : null;
            if (degreeCelsius != null && kelvin != null)
            {
                conversions.Add(degreeCelsius, kelvin, CustomConversions.CelsiusToKelvin);
                conversions.Add(kelvin, degreeCelsius, CustomConversions.KelvinToCelsius);
            }

            // 4. Even for custom unit types
            IUnit parrot = units.Contains("parrot") ? units["parrot"] : null;
            IUnit boa = units.Contains("boa") ? units["boa"] : null;
            if (parrot != null && boa != null)
            {
                conversions.Add(parrot, boa, CustomConversions.ParrotToBoa);
                conversions.Add(boa, parrot, CustomConversions.BoaToParrot);
            }
        }

        private void InitializeConverter()
        {
            // Just create a converter and give it all possible sources to look for conversion rules in
            converter = new UnitConverter<double>(prefixedConversions, conversions);
        }

        private void InitializeNumericField()
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

                if (unit is Unit)
                {
                    foreach (IPrefixedUnit prefixedUnit in ((Unit)unit).PrefixedUnits)
                    {
                        comboUnits.Items.Add(new UnitsComboBoxItem() { Unit = prefixedUnit });
                    }
                }
            }
        }

        private void FillTree()
        {
            foreach (IUnit unit in units)
            {
                TreeNode unitNode = CreateUnitNode(unit);
                treeUnits.Nodes.Add(unitNode);

                if (unit is Unit)
                {
                    foreach (IPrefixedUnit prefixedUnit in ((Unit)unit).PrefixedUnits)
                    {
                        unitNode.Nodes.Add(CreateUnitNode(prefixedUnit));
                    }
                }
            }
        }

        private TreeNode CreateUnitNode(IUnit unit)
        {
            TreeNode unitNode = new TreeNode(unit.Name);
            unitNode.Tag = unit;
            return unitNode;
        }

        private void treeUnits_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            IUnit unit = e.Node.Tag as IUnit;
            IPrefixedUnit prefixedUnit = e.Node.Tag as IPrefixedUnit;
            IMyUnit myUnit = e.Node.Tag as IMyUnit;

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

            if (myUnit != null)
            {
                labelDescription.Text = myUnit.Description;
            }
            else
            {
                labelDescription.Text = "-";
            }
        }

        private void buttonConvert_Click(object sender, System.EventArgs e)
        {
            IUnit fromUnit = treeUnits.SelectedNode == null ? null : treeUnits.SelectedNode.Tag as IUnit;
            IUnit toUnit = comboUnits.SelectedItem == null ? null : ((UnitsComboBoxItem)comboUnits.SelectedItem).Unit;

            if (fromUnit != null && toUnit != null)
            {
                labelResult.Text = string.Empty;

                double value = Convert.ToDouble(numericValue.Value);
                try
                {
                    labelResult.Text = string.Format(conversionResultFormat, value.ToString(), fromUnit.Symbol,
                        converter.Convert(fromUnit, toUnit, value).ToString(), toUnit.Symbol);
                }
                catch (InvalidOperationException)
                {
                    MessageBox.Show("Conversion not found!", "Units Sample", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }
    }
}
