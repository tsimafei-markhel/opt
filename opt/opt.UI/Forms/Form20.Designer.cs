namespace opt.UI.Forms
{
    partial class Form20
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
            this.panWorkspace = new System.Windows.Forms.Panel();
            this.btnDeleteConstraint = new System.Windows.Forms.Button();
            this.btnEditCriteriaConstraint = new System.Windows.Forms.Button();
            this.btnAddConstraint = new System.Windows.Forms.Button();
            this.dgvConstraints = new System.Windows.Forms.DataGridView();
            this.colCriterionId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colConstraintName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colConstraintVariableIdentifier = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colConstraintSign = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colConstraintValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colConstraintExpression = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnPrevious = new System.Windows.Forms.Button();
            this.panWorkspace.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvConstraints)).BeginInit();
            this.SuspendLayout();
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnExit.Location = new System.Drawing.Point(12, 527);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 27);
            this.btnExit.TabIndex = 3;
            this.btnExit.Text = "Выход";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // panWorkspace
            // 
            this.panWorkspace.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panWorkspace.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panWorkspace.BackColor = System.Drawing.SystemColors.Control;
            this.panWorkspace.Controls.Add(this.btnDeleteConstraint);
            this.panWorkspace.Controls.Add(this.btnEditCriteriaConstraint);
            this.panWorkspace.Controls.Add(this.btnAddConstraint);
            this.panWorkspace.Controls.Add(this.dgvConstraints);
            this.panWorkspace.Location = new System.Drawing.Point(12, 12);
            this.panWorkspace.Name = "panWorkspace";
            this.panWorkspace.Size = new System.Drawing.Size(768, 509);
            this.panWorkspace.TabIndex = 0;
            // 
            // btnDeleteConstraint
            // 
            this.btnDeleteConstraint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeleteConstraint.Image = global::opt.UI.Properties.Resources.delete;
            this.btnDeleteConstraint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDeleteConstraint.Location = new System.Drawing.Point(625, 75);
            this.btnDeleteConstraint.Name = "btnDeleteConstraint";
            this.btnDeleteConstraint.Size = new System.Drawing.Size(141, 30);
            this.btnDeleteConstraint.TabIndex = 3;
            this.btnDeleteConstraint.Text = "Удалить";
            this.btnDeleteConstraint.UseVisualStyleBackColor = true;
            this.btnDeleteConstraint.Click += new System.EventHandler(this.btnDeleteConstraint_Click);
            // 
            // btnEditCriteriaConstraint
            // 
            this.btnEditCriteriaConstraint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEditCriteriaConstraint.Image = global::opt.UI.Properties.Resources.edit;
            this.btnEditCriteriaConstraint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEditCriteriaConstraint.Location = new System.Drawing.Point(625, 39);
            this.btnEditCriteriaConstraint.Name = "btnEditCriteriaConstraint";
            this.btnEditCriteriaConstraint.Size = new System.Drawing.Size(140, 30);
            this.btnEditCriteriaConstraint.TabIndex = 2;
            this.btnEditCriteriaConstraint.Text = "Редактировать...";
            this.btnEditCriteriaConstraint.UseVisualStyleBackColor = true;
            this.btnEditCriteriaConstraint.Click += new System.EventHandler(this.btnEditCriteriaConstraint_Click);
            // 
            // btnAddConstraint
            // 
            this.btnAddConstraint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddConstraint.Image = global::opt.UI.Properties.Resources.add;
            this.btnAddConstraint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddConstraint.Location = new System.Drawing.Point(625, 3);
            this.btnAddConstraint.Name = "btnAddConstraint";
            this.btnAddConstraint.Size = new System.Drawing.Size(140, 30);
            this.btnAddConstraint.TabIndex = 1;
            this.btnAddConstraint.Text = "Добавить...";
            this.btnAddConstraint.UseVisualStyleBackColor = true;
            this.btnAddConstraint.Click += new System.EventHandler(this.btnAddConstraint_Click);
            // 
            // dgvConstraints
            // 
            this.dgvConstraints.AllowUserToAddRows = false;
            this.dgvConstraints.AllowUserToDeleteRows = false;
            this.dgvConstraints.AllowUserToResizeRows = false;
            this.dgvConstraints.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvConstraints.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvConstraints.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvConstraints.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colCriterionId,
            this.colConstraintName,
            this.colConstraintVariableIdentifier,
            this.colConstraintSign,
            this.colConstraintValue,
            this.colConstraintExpression});
            this.dgvConstraints.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvConstraints.Location = new System.Drawing.Point(3, 3);
            this.dgvConstraints.Name = "dgvConstraints";
            this.dgvConstraints.RowHeadersVisible = false;
            this.dgvConstraints.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvConstraints.Size = new System.Drawing.Size(616, 503);
            this.dgvConstraints.TabIndex = 0;
            // 
            // colCriterionId
            // 
            this.colCriterionId.HeaderText = "ID";
            this.colCriterionId.Name = "colCriterionId";
            this.colCriterionId.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colCriterionId.Visible = false;
            this.colCriterionId.Width = 24;
            // 
            // colConstraintName
            // 
            this.colConstraintName.HeaderText = "Название функционального ограничения";
            this.colConstraintName.Name = "colConstraintName";
            this.colConstraintName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colConstraintName.Width = 143;
            // 
            // colConstraintVariableIdentifier
            // 
            this.colConstraintVariableIdentifier.HeaderText = "Идентификатор переменной функционального ограничения";
            this.colConstraintVariableIdentifier.Name = "colConstraintVariableIdentifier";
            this.colConstraintVariableIdentifier.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colConstraintVariableIdentifier.Width = 153;
            // 
            // colConstraintSign
            // 
            this.colConstraintSign.HeaderText = "Знак";
            this.colConstraintSign.Name = "colConstraintSign";
            this.colConstraintSign.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colConstraintSign.Width = 38;
            // 
            // colConstraintValue
            // 
            this.colConstraintValue.HeaderText = "Значение";
            this.colConstraintValue.Name = "colConstraintValue";
            this.colConstraintValue.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colConstraintValue.Width = 61;
            // 
            // colConstraintExpression
            // 
            this.colConstraintExpression.HeaderText = "Выражение";
            this.colConstraintExpression.Name = "colConstraintExpression";
            this.colConstraintExpression.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colConstraintExpression.Width = 72;
            // 
            // btnNext
            // 
            this.btnNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNext.Image = global::opt.UI.Properties.Resources.next;
            this.btnNext.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNext.Location = new System.Drawing.Point(705, 527);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(75, 27);
            this.btnNext.TabIndex = 2;
            this.btnNext.Text = "Далее";
            this.btnNext.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnPrevious
            // 
            this.btnPrevious.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrevious.Image = global::opt.UI.Properties.Resources.previous;
            this.btnPrevious.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPrevious.Location = new System.Drawing.Point(624, 527);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(75, 27);
            this.btnPrevious.TabIndex = 1;
            this.btnPrevious.Text = "Назад";
            this.btnPrevious.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPrevious.UseVisualStyleBackColor = true;
            this.btnPrevious.Click += new System.EventHandler(this.btnPrevious_Click);
            // 
            // Form20
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 566);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.panWorkspace);
            this.Controls.Add(this.btnPrevious);
            this.MinimumSize = new System.Drawing.Size(300, 300);
            this.Name = "Form20";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Функциональные ограничения";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form20_FormClosing);
            this.panWorkspace.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvConstraints)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Panel panWorkspace;
        private System.Windows.Forms.Button btnDeleteConstraint;
        private System.Windows.Forms.Button btnEditCriteriaConstraint;
        private System.Windows.Forms.Button btnAddConstraint;
        private System.Windows.Forms.DataGridView dgvConstraints;
        private System.Windows.Forms.Button btnPrevious;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCriterionId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colConstraintName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colConstraintVariableIdentifier;
        private System.Windows.Forms.DataGridViewTextBoxColumn colConstraintSign;
        private System.Windows.Forms.DataGridViewTextBoxColumn colConstraintValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn colConstraintExpression;
    }
}