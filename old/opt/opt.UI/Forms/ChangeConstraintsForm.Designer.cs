namespace opt.UI.Forms
{
    partial class ChangeConstraintsForm
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
            this.components = new System.ComponentModel.Container();
            this.btnCancel = new System.Windows.Forms.Button();
            this.panWorkspace = new System.Windows.Forms.Panel();
            this.btnDeleteConstraint = new System.Windows.Forms.Button();
            this.dgvConstraints = new System.Windows.Forms.DataGridView();
            this.btnOK = new System.Windows.Forms.Button();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.colCriterionId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colConstraintName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colConstraintVariableIdentifier = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colConstraintSign = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colConstraintValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colConstraintExpression = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panWorkspace.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvConstraints)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.CausesValidation = false;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancel.Location = new System.Drawing.Point(705, 527);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 27);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // panWorkspace
            // 
            this.panWorkspace.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panWorkspace.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panWorkspace.BackColor = System.Drawing.SystemColors.Control;
            this.panWorkspace.Controls.Add(this.btnDeleteConstraint);
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
            this.btnDeleteConstraint.Location = new System.Drawing.Point(735, 3);
            this.btnDeleteConstraint.Name = "btnDeleteConstraint";
            this.btnDeleteConstraint.Size = new System.Drawing.Size(30, 30);
            this.btnDeleteConstraint.TabIndex = 1;
            this.toolTip.SetToolTip(this.btnDeleteConstraint, "Удалить выбранные функциональные ограничения");
            this.btnDeleteConstraint.UseVisualStyleBackColor = true;
            this.btnDeleteConstraint.Click += new System.EventHandler(this.btnDeleteConstraint_Click);
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
            this.dgvConstraints.CausesValidation = false;
            this.dgvConstraints.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvConstraints.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colCriterionId,
            this.colConstraintName,
            this.colConstraintVariableIdentifier,
            this.colConstraintSign,
            this.colConstraintValue,
            this.colConstraintExpression});
            this.dgvConstraints.Location = new System.Drawing.Point(3, 3);
            this.dgvConstraints.Name = "dgvConstraints";
            this.dgvConstraints.RowHeadersVisible = false;
            this.dgvConstraints.Size = new System.Drawing.Size(726, 503);
            this.dgvConstraints.TabIndex = 0;
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOK.Location = new System.Drawing.Point(624, 527);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 27);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 534);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Ячейки с ";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.LightGray;
            this.label2.Location = new System.Drawing.Point(74, 534);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "серым";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(121, 534);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(143, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "фоном - только для чтения";
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
            this.colConstraintName.ReadOnly = true;
            this.colConstraintName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colConstraintName.Width = 201;
            // 
            // colConstraintVariableIdentifier
            // 
            this.colConstraintVariableIdentifier.HeaderText = "Идентификатор переменной функционального ограничения";
            this.colConstraintVariableIdentifier.Name = "colConstraintVariableIdentifier";
            this.colConstraintVariableIdentifier.ReadOnly = true;
            this.colConstraintVariableIdentifier.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colConstraintVariableIdentifier.Width = 153;
            // 
            // colConstraintSign
            // 
            this.colConstraintSign.HeaderText = "Знак";
            this.colConstraintSign.MaxDropDownItems = 6;
            this.colConstraintSign.Name = "colConstraintSign";
            this.colConstraintSign.Resizable = System.Windows.Forms.DataGridViewTriState.True;
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
            this.colConstraintExpression.ReadOnly = true;
            this.colConstraintExpression.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colConstraintExpression.Width = 72;
            // 
            // ChangeConstraintsForm
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(792, 566);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.panWorkspace);
            this.Controls.Add(this.btnOK);
            this.MinimumSize = new System.Drawing.Size(300, 300);
            this.Name = "ChangeConstraintsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Изменить функциональные ограничения";
            this.panWorkspace.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvConstraints)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Panel panWorkspace;
        private System.Windows.Forms.DataGridView dgvConstraints;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnDeleteConstraint;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCriterionId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colConstraintName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colConstraintVariableIdentifier;
        private System.Windows.Forms.DataGridViewComboBoxColumn colConstraintSign;
        private System.Windows.Forms.DataGridViewTextBoxColumn colConstraintValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn colConstraintExpression;
    }
}