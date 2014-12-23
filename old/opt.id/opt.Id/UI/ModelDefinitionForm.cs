using System;
using System.Windows.Forms;
using opt.DataModel;
using opt.Helpers;
using opt.Id;

namespace opt.UI
{
    public partial class ModelDefinitionForm : OptIdFormBase
    {
        public ModelDefinitionForm()
        {
            InitializeComponent();
        }

        public ModelDefinitionForm(OptIdFormBase previous) : base(previous)
        {
            InitializeComponent();
        }

        /// <summary>
        /// no operators, just stub
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void buttonAdd_Click(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// no operators, just stub
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void buttonEdit_Click(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// no operators, just stub
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void buttonDelete_Click(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// Shows addForm and update DataGrid
        /// </summary>
        /// <typeparam name="T">inheritors of NamedModelEntity</typeparam>
        /// <param name="addForm">form for adding entity</param>
        /// <param name="entities">collection of model which will be shown in the DataGrid</param>
        protected void AddEntity<T>(Form addForm, NamedModelEntityCollection<T> entities) 
            where T : NamedModelEntity
        {
            if (addForm.ShowDialog() == DialogResult.OK)
            {
                this.UpdateParametersDataGrid(entities);
            }

            addForm.Dispose();
        }

        /// <summary>
        /// Shows editForm and update DataGrid
        /// </summary>
        /// <typeparam name="T">inheritors of NamedModelEntity</typeparam>
        /// <param name="editForm">form for editing entity</param>
        /// <param name="entities">collection of model which will be shown in the DataGrid</param>
        /// <param name="index">index of the row to be edited <seealso cref="GetSelectedEntityId()"/></param>
        protected void EditEntity<T>(Form editForm, NamedModelEntityCollection<T> entities, int index)
            where T : NamedModelEntity
        {
            if (editForm.ShowDialog() == DialogResult.OK)
            {
                this.UpdateParametersDataGrid(entities);
                SelectDataGridViewRow(index);
            }

            editForm.Dispose();
        }

        /// <summary>
        /// Deletes selected row
        /// </summary>
        /// <typeparam name="T">inheritors of NamedModelEntity</typeparam>
        /// <param name="entities">collection of model which will be shown in the DataGrid</param>
        protected void DeleteEntities<T>(NamedModelEntityCollection<T> entities)
            where T : NamedModelEntity
        {
            if (this.dgvModelEntities.SelectedRows.Count == 0)
            {
                MessageBoxHelper.ShowExclamation("Выберите в списке хотя бы один элемент для удаления");
                return;
            }

            DialogResult result = MessageBox.Show("Удалить выбранные элементы?", Program.ApplicationSettings.ApplicationName, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                foreach (DataGridViewRow selRow in this.dgvModelEntities.SelectedRows)
                {
                    TId entityId = TId.Parse((string)selRow.Cells[0].Value);
                    entities.Remove(entityId);
                }

                this.UpdateParametersDataGrid(entities);
            }
        }

        /// <summary>
        /// Gets the ID of entity which is currently selected in the DataGridView
        /// </summary>
        /// <returns>Index of selected entity or -1 if several or none rows are selected</returns>
        protected TId GetSelectedEntityId()
        {
            if (this.dgvModelEntities.SelectedRows.Count == 0 ||
                this.dgvModelEntities.SelectedRows.Count > 1)
            {
                MessageBoxHelper.ShowExclamation("Выберите в списке только один элемент");
                return -1;
            }

            string result = this.dgvModelEntities.SelectedRows[0].Cells[0].Value as string;
            if (result == null)
            {
                return (TId)this.dgvModelEntities.SelectedRows[0].Cells[0].Value;
            }
            else
            {
                return TId.Parse((string)this.dgvModelEntities.SelectedRows[0].Cells[0].Value);
            }
        }

        /// <summary>
        /// Selects a row in DataGridView by index. Other rows are unselected
        /// </summary>
        /// <param name="rowIndex">Index of a row that will be selected</param>
        protected void SelectDataGridViewRow(int rowIndex)
        {
            dgvModelEntities.ClearSelection();
            foreach (DataGridViewRow row in dgvModelEntities.Rows)
            {
                if (row.Index == rowIndex)
                {
                    row.Selected = true;
                    break;
                }
            }
        }

        /// <summary>
        /// TODO: Still doesn't work (
        /// </summary>
        /// <typeparam name="T">inheritors of NamedModelEntity</typeparam>
        /// <param name="entities">collection of model which will be shown in the DataGrid</param>
        protected virtual void UpdateParametersDataGrid<T>(NamedModelEntityCollection<T> entities)
            where T : NamedModelEntity
        {
            this.dgvModelEntities.SuspendLayout();

            this.dgvModelEntities.Rows.Clear();
            foreach (NamedModelEntity entity in entities.Values)
            {
                int ind = this.dgvModelEntities.Rows.Add();

                this.dgvModelEntities[0, ind].Value = entity.Id;
                this.dgvModelEntities[1, ind].Value = entity.Name;
                this.dgvModelEntities[2, ind].Value = entity.VariableIdentifier;
            }

            this.dgvModelEntities.ResumeLayout();
        }
    }
}