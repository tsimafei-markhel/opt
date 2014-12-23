namespace opt.UI
{
    partial class ModelDefinitionForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvModelEntities = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colParameterName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colParameterIdentifier = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolbar = new System.Windows.Forms.ToolStrip();
            this.buttonAdd = new System.Windows.Forms.ToolStripButton();
            this.buttonEdit = new System.Windows.Forms.ToolStripButton();
            this.buttonDelete = new System.Windows.Forms.ToolStripButton();
            this.panWorkspace.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvModelEntities)).BeginInit();
            this.toolbar.SuspendLayout();
            this.SuspendLayout();
            // 
            // panWorkspace
            // 
            this.panWorkspace.Controls.Add(this.dgvModelEntities);
            this.panWorkspace.Controls.Add(this.toolbar);
            // 
            // dgvModelEntities
            // 
            this.dgvModelEntities.AllowUserToAddRows = false;
            this.dgvModelEntities.AllowUserToDeleteRows = false;
            this.dgvModelEntities.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvModelEntities.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.colParameterName,
            this.colParameterIdentifier});
            this.dgvModelEntities.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvModelEntities.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvModelEntities.Location = new System.Drawing.Point(0, 25);
            this.dgvModelEntities.Name = "dgvModelEntities";
            this.dgvModelEntities.ReadOnly = true;
            this.dgvModelEntities.RowHeadersVisible = false;
            this.dgvModelEntities.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvModelEntities.Size = new System.Drawing.Size(760, 482);
            this.dgvModelEntities.TabIndex = 5;
            // 
            // id
            // 
            this.id.HeaderText = "ID";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.id.Visible = false;
            // 
            // colParameterName
            // 
            this.colParameterName.HeaderText = "Название";
            this.colParameterName.MinimumWidth = 100;
            this.colParameterName.Name = "colParameterName";
            this.colParameterName.ReadOnly = true;
            this.colParameterName.Width = 150;
            // 
            // colParameterIdentifier
            // 
            this.colParameterIdentifier.HeaderText = "Идентификатор";
            this.colParameterIdentifier.MinimumWidth = 100;
            this.colParameterIdentifier.Name = "colParameterIdentifier";
            this.colParameterIdentifier.ReadOnly = true;
            this.colParameterIdentifier.Width = 150;
            // 
            // toolbar
            // 
            this.toolbar.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.buttonAdd,
            this.buttonEdit,
            this.buttonDelete});
            this.toolbar.Location = new System.Drawing.Point(0, 0);
            this.toolbar.Name = "toolbar";
            this.toolbar.Size = new System.Drawing.Size(760, 25);
            this.toolbar.TabIndex = 4;
            // 
            // buttonAdd
            // 
            this.buttonAdd.Image = global::opt.Properties.Resources.add;
            this.buttonAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(88, 22);
            this.buttonAdd.Text = "Добавить...";
            this.buttonAdd.ToolTipText = "Добавить параметр";
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // buttonEdit
            // 
            this.buttonEdit.Image = global::opt.Properties.Resources.pencil;
            this.buttonEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonEdit.Name = "buttonEdit";
            this.buttonEdit.Size = new System.Drawing.Size(116, 22);
            this.buttonEdit.Text = "Редактировать...";
            this.buttonEdit.ToolTipText = "Редактировать выбранный параметр";
            this.buttonEdit.Click += new System.EventHandler(this.buttonEdit_Click);
            // 
            // buttonDelete
            // 
            this.buttonDelete.Image = global::opt.Properties.Resources.delete;
            this.buttonDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(71, 22);
            this.buttonDelete.Text = "Удалить";
            this.buttonDelete.ToolTipText = "Удалить выбранные параметры";
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // ModelDefinitionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Name = "ModelDefinitionForm";
            this.Text = "ModelDefinitionForm";
            this.panWorkspace.ResumeLayout(false);
            this.panWorkspace.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvModelEntities)).EndInit();
            this.toolbar.ResumeLayout(false);
            this.toolbar.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        protected System.Windows.Forms.DataGridView dgvModelEntities;
        protected System.Windows.Forms.ToolStrip toolbar;
        protected System.Windows.Forms.ToolStripButton buttonAdd;
        protected System.Windows.Forms.ToolStripButton buttonEdit;
        protected System.Windows.Forms.ToolStripButton buttonDelete;
        protected System.Windows.Forms.DataGridViewTextBoxColumn id;
        protected System.Windows.Forms.DataGridViewTextBoxColumn colParameterName;
        protected System.Windows.Forms.DataGridViewTextBoxColumn colParameterIdentifier;
    }
}