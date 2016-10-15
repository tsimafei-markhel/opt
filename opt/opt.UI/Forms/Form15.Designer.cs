namespace opt.UI.Forms
{
    partial class Form15
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
            this.btnExit = new System.Windows.Forms.Button();
            this.btnDeleteCriteria = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnAddCriteria = new System.Windows.Forms.Button();
            this.btnEditCriteria = new System.Windows.Forms.Button();
            this.panWorkspace = new System.Windows.Forms.Panel();
            this.dgvCriteria = new System.Windows.Forms.DataGridView();
            this.colCriterionId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCriterionName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCriterionVariableIdentifier = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCriterionType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCriterionExpression = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnPrevious = new System.Windows.Forms.Button();
            this.panWorkspace.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCriteria)).BeginInit();
            this.SuspendLayout();
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnExit.Location = new System.Drawing.Point(12, 527);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 27);
            this.btnExit.TabIndex = 4;
            this.btnExit.Text = "Выход";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnDeleteCriteria
            // 
            this.btnDeleteCriteria.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeleteCriteria.Image = global::opt.UI.Properties.Resources.delete;
            this.btnDeleteCriteria.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDeleteCriteria.Location = new System.Drawing.Point(625, 75);
            this.btnDeleteCriteria.Name = "btnDeleteCriteria";
            this.btnDeleteCriteria.Size = new System.Drawing.Size(141, 30);
            this.btnDeleteCriteria.TabIndex = 3;
            this.btnDeleteCriteria.Text = "Удалить";
            this.btnDeleteCriteria.UseVisualStyleBackColor = true;
            this.btnDeleteCriteria.Click += new System.EventHandler(this.btnDeleteCriteria_Click);
            // 
            // btnNext
            // 
            this.btnNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNext.Image = global::opt.UI.Properties.Resources.next;
            this.btnNext.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNext.Location = new System.Drawing.Point(705, 527);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(75, 27);
            this.btnNext.TabIndex = 3;
            this.btnNext.Text = "Далее";
            this.btnNext.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnAddCriteria
            // 
            this.btnAddCriteria.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddCriteria.Image = global::opt.UI.Properties.Resources.add;
            this.btnAddCriteria.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddCriteria.Location = new System.Drawing.Point(625, 3);
            this.btnAddCriteria.Name = "btnAddCriteria";
            this.btnAddCriteria.Size = new System.Drawing.Size(140, 30);
            this.btnAddCriteria.TabIndex = 1;
            this.btnAddCriteria.Text = "Добавить...";
            this.btnAddCriteria.UseVisualStyleBackColor = true;
            this.btnAddCriteria.Click += new System.EventHandler(this.btnAddCriteria_Click);
            // 
            // btnEditCriteria
            // 
            this.btnEditCriteria.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEditCriteria.Image = global::opt.UI.Properties.Resources.edit;
            this.btnEditCriteria.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEditCriteria.Location = new System.Drawing.Point(625, 39);
            this.btnEditCriteria.Name = "btnEditCriteria";
            this.btnEditCriteria.Size = new System.Drawing.Size(140, 30);
            this.btnEditCriteria.TabIndex = 2;
            this.btnEditCriteria.Text = "Редактировать...";
            this.btnEditCriteria.UseVisualStyleBackColor = true;
            this.btnEditCriteria.Click += new System.EventHandler(this.btnEditCriteria_Click);
            // 
            // panWorkspace
            // 
            this.panWorkspace.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panWorkspace.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panWorkspace.BackColor = System.Drawing.SystemColors.Control;
            this.panWorkspace.Controls.Add(this.btnDeleteCriteria);
            this.panWorkspace.Controls.Add(this.btnEditCriteria);
            this.panWorkspace.Controls.Add(this.btnAddCriteria);
            this.panWorkspace.Controls.Add(this.dgvCriteria);
            this.panWorkspace.Location = new System.Drawing.Point(12, 12);
            this.panWorkspace.Name = "panWorkspace";
            this.panWorkspace.Size = new System.Drawing.Size(768, 509);
            this.panWorkspace.TabIndex = 1;
            // 
            // dgvCriteria
            // 
            this.dgvCriteria.AllowUserToAddRows = false;
            this.dgvCriteria.AllowUserToDeleteRows = false;
            this.dgvCriteria.AllowUserToResizeRows = false;
            this.dgvCriteria.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvCriteria.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvCriteria.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCriteria.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colCriterionId,
            this.colCriterionName,
            this.colCriterionVariableIdentifier,
            this.colCriterionType,
            this.colCriterionExpression});
            this.dgvCriteria.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvCriteria.Location = new System.Drawing.Point(3, 3);
            this.dgvCriteria.Name = "dgvCriteria";
            this.dgvCriteria.RowHeadersVisible = false;
            this.dgvCriteria.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCriteria.Size = new System.Drawing.Size(616, 503);
            this.dgvCriteria.TabIndex = 0;
            // 
            // colCriterionId
            // 
            this.colCriterionId.HeaderText = "ID";
            this.colCriterionId.Name = "colCriterionId";
            this.colCriterionId.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colCriterionId.Visible = false;
            this.colCriterionId.Width = 24;
            // 
            // colCriterionName
            // 
            this.colCriterionName.HeaderText = "Название критерия";
            this.colCriterionName.Name = "colCriterionName";
            this.colCriterionName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colCriterionName.Width = 102;
            // 
            // colCriterionVariableIdentifier
            // 
            this.colCriterionVariableIdentifier.HeaderText = "Идентификатор переменной критерия";
            this.colCriterionVariableIdentifier.Name = "colCriterionVariableIdentifier";
            this.colCriterionVariableIdentifier.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colCriterionVariableIdentifier.Width = 145;
            // 
            // colCriterionType
            // 
            this.colCriterionType.HeaderText = "Тип критерия";
            this.colCriterionType.Name = "colCriterionType";
            this.colCriterionType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colCriterionType.Width = 74;
            // 
            // colCriterionExpression
            // 
            this.colCriterionExpression.HeaderText = "Выражение";
            this.colCriterionExpression.Name = "colCriterionExpression";
            this.colCriterionExpression.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colCriterionExpression.Width = 72;
            // 
            // btnPrevious
            // 
            this.btnPrevious.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrevious.Image = global::opt.UI.Properties.Resources.previous;
            this.btnPrevious.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPrevious.Location = new System.Drawing.Point(624, 527);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(75, 27);
            this.btnPrevious.TabIndex = 2;
            this.btnPrevious.Text = "Назад";
            this.btnPrevious.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPrevious.UseVisualStyleBackColor = true;
            this.btnPrevious.Click += new System.EventHandler(this.btnPrevious_Click);
            // 
            // Form15
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 566);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.panWorkspace);
            this.Controls.Add(this.btnPrevious);
            this.MinimumSize = new System.Drawing.Size(300, 300);
            this.Name = "Form15";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Критерии оптимальности";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form15_FormClosing);
            this.panWorkspace.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCriteria)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnDeleteCriteria;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnAddCriteria;
        private System.Windows.Forms.Button btnEditCriteria;
        private System.Windows.Forms.Panel panWorkspace;
        private System.Windows.Forms.DataGridView dgvCriteria;
        private System.Windows.Forms.Button btnPrevious;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCriterionId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCriterionName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCriterionVariableIdentifier;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCriterionType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCriterionExpression;
    }
}