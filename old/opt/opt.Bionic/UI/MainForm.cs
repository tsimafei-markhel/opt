using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using opt.Bionic.DataModel;
using opt.Bionic.Helpers;
using opt.Bionic.Solver;
using opt.DataModel;
using opt.Extensions;
using opt.Helpers;
using opt.Xml;

namespace opt.Bionic.UI
{
    public partial class MainForm : Form
    {
        private Model optModel;
        private BionicModel bionicModel;
        private Tray tray;

        public MainForm()
        {
            InitializeComponent();
            optModel = null;
            bionicModel = null;
            tray = null;
        }

        private void buttonBrowseOptFile_Click(object sender, EventArgs e)
        {
            dialogBrowse.Filter = "OPT model files (*.xml)|*.xml|All files (*.*)|*.*";
            dialogBrowse.Title = "Choose OPT model file";
            if (dialogBrowse.ShowDialog() == DialogResult.OK)
            {
                textOptFile.Text = dialogBrowse.FileName;
                dialogBrowse.FileName = string.Empty;
            }
        }

        private void buttonBrowseCalcApp_Click(object sender, EventArgs e)
        {
            dialogBrowse.Filter = "Executable files (*.exe)|*.exe|All files (*.*)|*.*";
            dialogBrowse.Title = "Choose Calculation application executable";
            if (dialogBrowse.ShowDialog() == DialogResult.OK)
            {
                textCalcApp.Text = dialogBrowse.FileName;
                dialogBrowse.FileName = string.Empty;
            }
        }

        private void buttonLoad_Click(object sender, EventArgs e)
        {
            string optFilePath = textOptFile.Text.Trim();
            if (string.IsNullOrEmpty(optFilePath))
            {
                // TODO: Handle this properly
                return;
            }

            ClearAll();
            // Restore OPT model file path
            textOptFile.Text = optFilePath;

            try
            {
                optModel = XmlModelProvider.Open(optFilePath);
            }
            catch (Exception ex)
            {
                // TODO: Move application name to settings
                MessageBox.Show(ex.Message, "opt.Bionic", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (optModel == null)
            {
                // TODO: Handle this properly
                return;
            }

            ListCriteria();
        }

        private void ClearAll()
        {
            textOptFile.Clear();
            optModel = null;

            ClearBionicModel();
            ResetTray();

            listCriteria.Items.Clear();
            listParameters.Items.Clear();
            textCalcApp.Clear();

            GC.Collect();
        }

        private void ClearBionicModel()
        {
            bionicModel = null;
            tableResults.Rows.Clear();
            tableResults.Columns.Clear();
        }

        private void ResetTray()
        {
            if (tray != null)
            {
                tray.Close();
                tray = null;
            }
        }

        private void ListCriteria()
        {
            foreach (Criterion criterion in optModel.Criteria.Values)
            {
                string text = string.IsNullOrEmpty(criterion.VariableIdentifier) ?
                    criterion.Name :
                    criterion.VariableIdentifier + " - " + criterion.Name;
                listCriteria.Items.Add(new CriteriaListItem(text, criterion.Id));
            }
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            ClearAll();
        }

        private void listCriteria_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            listCriteria_SelectedIndexChanged(sender, new EventArgs());
        }

        private void listCriteria_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listCriteria.SelectedIndices.Count > 0)
            {
                // This is possible because listCriteria.SelectionMode == One
                int selectedIndex = listCriteria.SelectedIndices[0];

                foreach (int checkedIndex in listCriteria.CheckedIndices)
                {
                    listCriteria.SetItemCheckState(checkedIndex, CheckState.Unchecked);
                }

                listCriteria.SetItemCheckState(selectedIndex, CheckState.Checked);

                RefreshBionicModel(((CriteriaListItem)listCriteria.Items[selectedIndex]).CriterionId);
                ResetTray();
            }
        }

        private void RefreshBionicModel(TId fitnessCriterionId)
        {
            ClearBionicModel();

            ModelsConverterSettings conversionSettings = new ModelsConverterSettings()
            {
                FitnessCriterionId = fitnessCriterionId,
                NeighborhoodSizePercent = Program.ApplicationSettings.NeighborhoodSizePercent,
                UseRecordPoint = Program.ApplicationSettings.UseRecordPoint
            };

            try
            {
                bionicModel = ModelsConverter.ModelToBionicModel(optModel, conversionSettings);
            }
            catch (Exception ex)
            {
                // TODO: Move application name to settings
                MessageBox.Show(ex.Message, "opt.Bionic", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (bionicModel == null)
            {
                // TODO: Handle this properly
                return;
            }

            ListParameters();
        }

        private void ListParameters()
        {
            listParameters.Items.Clear();

            foreach (Parameter attribute in bionicModel.Attributes.Values)
            {
                ListViewItem attributeItem = new ListViewItem();
                attributeItem.Text = attribute.Name;
                attributeItem.SubItems.Add(attribute.MinValue.ToStringInvariant(SettingsManager.Instance.DoubleStringFormat));
                attributeItem.SubItems.Add(attribute.MaxValue.ToStringInvariant(SettingsManager.Instance.DoubleStringFormat));

                listParameters.Items.Add(attributeItem);
            }
        }

        private void buttonRun_Click(object sender, EventArgs e)
        {
            if (listCriteria.SelectedIndices.Count <= 0)
            {
                // TODO: Handle this properly
                return;
            }

            int selectedIndex = listCriteria.SelectedIndices[0];
            RefreshBionicModel(((CriteriaListItem)listCriteria.Items[selectedIndex]).CriterionId);

            if (bionicModel == null)
            {
                // TODO: Handle this properly
                return;
            }

            string calcAppPath = textCalcApp.Text.Trim();
            if (string.IsNullOrEmpty(calcAppPath))
            {
                // TODO: Handle this properly
                return;
            }

            InitResultTable(tableResults);
            if (tray == null)
            {
                tray = new Tray();
                InitResultTable(tray.tableResults);
            }

            BionicSolverSettings solverSettings = new BionicSolverSettings()
            {
                ApplyElitism = Program.ApplicationSettings.ApplyElitism,
                CalcApplicationCommandLineArgumentsFormat = Program.ApplicationSettings.CalcAppCommandLineArgsFormat,
                CalcApplicationPath = calcAppPath,
                DescendantsNum = Program.ApplicationSettings.DescendantsNum,
                DescendantsRangePercent = Program.ApplicationSettings.DescendantsRangePercent,
                InitialPopulationSize = Program.ApplicationSettings.InitialPopulationSize,
                MaxGenerations = Program.ApplicationSettings.MaxGenerations,
                SelectionCap = Program.ApplicationSettings.SelectionCap
            };

            BionicSolver solver = InitSolver();
            solver.Solve(bionicModel, solverSettings);
        }

        private BionicSolver InitSolver()
        {
            BionicSolver solver = new BionicSolver();
            solver.PopulationUpdated += solver_PopulationUpdated;
            solver.SolverFinished += solver_SolverFinished;

            return solver;
        }

        private void InitResultTable(DataGridView targetTable)
        {
            DataGridViewColumn idColumn = DataGridViewHelper.CreateColumn("id", "ID", null, "Individual ID");
            targetTable.Columns.Add(idColumn);

            DataGridViewColumn generationNumColumn = DataGridViewHelper.CreateColumn("generation", "Generation");
            targetTable.Columns.Add(generationNumColumn);

            DataGridViewColumn fitnessColumn = DataGridViewHelper.CreateColumn("fitness", "Fitness");
            targetTable.Columns.Add(fitnessColumn);

            foreach (Parameter attribute in bionicModel.Attributes.Values)
            {
                string toolTip = "Variable identifier: " + attribute.VariableIdentifier +
                    "\nMin value: " + attribute.MinValue.ToString(SettingsManager.Instance.DoubleStringFormat) +
                    "\nMax value: " + attribute.MaxValue.ToString(SettingsManager.Instance.DoubleStringFormat);

                DataGridViewColumn attributeColumn = DataGridViewHelper.CreateColumn(
                    "attribute_" + attribute.Id, attribute.Name, null, toolTip);
                targetTable.Columns.Add(attributeColumn);
            }
        }

        void solver_SolverFinished(object sender, SolverFinishedEventArgs e)
        {
            if (!string.IsNullOrEmpty(e.Message))
            {
                // TODO: Move application name to settings
                MessageBox.Show(e.Message, "opt.Bionic", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        void solver_PopulationUpdated(object sender, EventArgs e)
        {
            List<SortableDouble> sortedIndividuals = bionicModel.CurrentPopulation.Values.Select<Individual, SortableDouble>(
                    ind => new SortableDouble() { Direction = bionicModel.FitnessCriterion.SortDirection, Id = ind.Id, Value = ind.FitnessValue }
                ).ToList();
            sortedIndividuals.Sort();

            foreach (SortableDouble sortedIndividual in sortedIndividuals)
            {
                Individual individual = bionicModel.CurrentPopulation[sortedIndividual.Id];

                int rowId = tableResults.Rows.Add();
                DataGridViewRow row = tableResults.Rows[rowId];
                if (!individual.IsActive)
                {
                    row.DefaultCellStyle.ForeColor = Color.DimGray;
                }

                row.Cells["id"].Value = individual.Id.ToString();
                row.Cells["generation"].Value = individual.GenerationNumber.ToString();
                row.Cells["fitness"].Value = individual.FitnessValue.ToStringInvariant(SettingsManager.Instance.DoubleStringFormat);
                foreach (Parameter attribute in bionicModel.Attributes.Values)
                {
                    row.Cells["attribute_" + attribute.Id].Value = 
                        individual.AttributeValues[attribute.Id].ToStringInvariant(SettingsManager.Instance.DoubleStringFormat);
                }
            }

            DataGridViewRow delimiterRow = new DataGridViewRow();
            delimiterRow.Height = 10;
            delimiterRow.DefaultCellStyle.BackColor = tableResults.GridColor;
            tableResults.Rows.Add(delimiterRow);
        }

        private void buttonShowTray_Click(object sender, EventArgs e)
        {
            if (tray != null)
            {
                tray.Show();
            }
        }

        private void buttonToTray_Click(object sender, EventArgs e)
        {
            if (tableResults.SelectedRows != null &&
                tableResults.SelectedRows.Count > 0)
            {
                if (tray != null)
                {
                    tray.AddRows(tableResults.SelectedRows);
                }
            }
        }
    }

    internal sealed class CriteriaListItem
    {
        public string Text { get; set; }
        public TId CriterionId { get; set; }

        public CriteriaListItem(
            string text,
            TId criterionId)
        {
            Text = text;
            CriterionId = criterionId;
        }

        public override string ToString()
        {
            return Text;
        }

        public override int GetHashCode()
        {
            return (33 + Text.GetHashCode()) * 33 + CriterionId.GetHashCode();
        }

        public override bool Equals(object other)
        {
            if (other == null)
            {
                return false;
            }

            CriteriaListItem otherListItem = other as CriteriaListItem;
            if (otherListItem == null)
            {
                return false;
            }

            return Text.Equals(otherListItem.Text, StringComparison.InvariantCulture) &&
                   CriterionId == otherListItem.CriterionId;
        }
    }
}