namespace opt.UI.Forms
{
    partial class MainCriterionForm
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
            this.btnPrevious = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.panWorkspace = new System.Windows.Forms.Panel();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.colCriterionId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCriterionName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCriterionVariableIdentifier = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSign = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnDeleteCriterialConstraint = new System.Windows.Forms.Button();
            this.btnEditCriterialConstraint = new System.Windows.Forms.Button();
            this.btnAddCriterialConstraint = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbMainCriterion = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnShowMatrixForm = new System.Windows.Forms.Button();
            this.panWorkspace.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
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
            // panWorkspace
            // 
            this.panWorkspace.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panWorkspace.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panWorkspace.BackColor = System.Drawing.SystemColors.Control;
            this.panWorkspace.Controls.Add(this.dgvData);
            this.panWorkspace.Controls.Add(this.btnDeleteCriterialConstraint);
            this.panWorkspace.Controls.Add(this.btnEditCriterialConstraint);
            this.panWorkspace.Controls.Add(this.btnAddCriterialConstraint);
            this.panWorkspace.Controls.Add(this.label2);
            this.panWorkspace.Controls.Add(this.cmbMainCriterion);
            this.panWorkspace.Controls.Add(this.label1);
            this.panWorkspace.Location = new System.Drawing.Point(12, 12);
            this.panWorkspace.Name = "panWorkspace";
            this.panWorkspace.Size = new System.Drawing.Size(768, 509);
            this.panWorkspace.TabIndex = 0;
            // 
            // dgvData
            // 
            this.dgvData.AllowUserToAddRows = false;
            this.dgvData.AllowUserToDeleteRows = false;
            this.dgvData.AllowUserToResizeRows = false;
            this.dgvData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colCriterionId,
            this.colCriterionName,
            this.colCriterionVariableIdentifier,
            this.colSign,
            this.colValue});
            this.dgvData.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvData.Location = new System.Drawing.Point(3, 40);
            this.dgvData.Name = "dgvData";
            this.dgvData.RowHeadersVisible = false;
            this.dgvData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvData.Size = new System.Drawing.Size(619, 466);
            this.dgvData.TabIndex = 7;
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
            // colSign
            // 
            this.colSign.HeaderText = "Знак";
            this.colSign.Name = "colSign";
            this.colSign.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colSign.Width = 38;
            // 
            // colValue
            // 
            this.colValue.HeaderText = "Значение";
            this.colValue.Name = "colValue";
            this.colValue.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colValue.Width = 61;
            // 
            // btnDeleteCriterialConstraint
            // 
            this.btnDeleteCriterialConstraint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeleteCriterialConstraint.Image = global::opt.UI.Properties.Resources.delete;
            this.btnDeleteCriterialConstraint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDeleteCriterialConstraint.Location = new System.Drawing.Point(625, 112);
            this.btnDeleteCriterialConstraint.Name = "btnDeleteCriterialConstraint";
            this.btnDeleteCriterialConstraint.Size = new System.Drawing.Size(141, 30);
            this.btnDeleteCriterialConstraint.TabIndex = 6;
            this.btnDeleteCriterialConstraint.Text = "Удалить";
            this.btnDeleteCriterialConstraint.UseVisualStyleBackColor = true;
            this.btnDeleteCriterialConstraint.Click += new System.EventHandler(this.btnDeleteCriterialConstraint_Click);
            // 
            // btnEditCriterialConstraint
            // 
            this.btnEditCriterialConstraint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEditCriterialConstraint.Image = global::opt.UI.Properties.Resources.edit;
            this.btnEditCriterialConstraint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEditCriterialConstraint.Location = new System.Drawing.Point(625, 76);
            this.btnEditCriterialConstraint.Name = "btnEditCriterialConstraint";
            this.btnEditCriterialConstraint.Size = new System.Drawing.Size(140, 30);
            this.btnEditCriterialConstraint.TabIndex = 5;
            this.btnEditCriterialConstraint.Text = "Редактировать...";
            this.btnEditCriterialConstraint.UseVisualStyleBackColor = true;
            this.btnEditCriterialConstraint.Click += new System.EventHandler(this.btnEditCriterialConstraint_Click);
            // 
            // btnAddCriterialConstraint
            // 
            this.btnAddCriterialConstraint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddCriterialConstraint.Image = global::opt.UI.Properties.Resources.add;
            this.btnAddCriterialConstraint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddCriterialConstraint.Location = new System.Drawing.Point(625, 40);
            this.btnAddCriterialConstraint.Name = "btnAddCriterialConstraint";
            this.btnAddCriterialConstraint.Size = new System.Drawing.Size(140, 30);
            this.btnAddCriterialConstraint.TabIndex = 4;
            this.btnAddCriterialConstraint.Text = "Добавить...";
            this.btnAddCriterialConstraint.UseVisualStyleBackColor = true;
            this.btnAddCriterialConstraint.Click += new System.EventHandler(this.btnAddCriterialConstraint_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(254, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Ограничения на значения остальных критериев:";
            // 
            // cmbMainCriterion
            // 
            this.cmbMainCriterion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbMainCriterion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMainCriterion.FormattingEnabled = true;
            this.cmbMainCriterion.Location = new System.Drawing.Point(113, 0);
            this.cmbMainCriterion.Name = "cmbMainCriterion";
            this.cmbMainCriterion.Size = new System.Drawing.Size(655, 21);
            this.cmbMainCriterion.TabIndex = 1;
            this.cmbMainCriterion.SelectedIndexChanged += new System.EventHandler(this.cmbMainCriterion_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Главный критерий:";
            // 
            // btnShowMatrixForm
            // 
            this.btnShowMatrixForm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnShowMatrixForm.Image = global::opt.UI.Properties.Resources.table;
            this.btnShowMatrixForm.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnShowMatrixForm.Location = new System.Drawing.Point(451, 527);
            this.btnShowMatrixForm.Name = "btnShowMatrixForm";
            this.btnShowMatrixForm.Size = new System.Drawing.Size(124, 27);
            this.btnShowMatrixForm.TabIndex = 1;
            this.btnShowMatrixForm.Text = "Матрица решений";
            this.btnShowMatrixForm.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnShowMatrixForm.UseVisualStyleBackColor = true;
            this.btnShowMatrixForm.Click += new System.EventHandler(this.btnShowMatrixForm_Click);
            // 
            // MainCriterionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 566);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnPrevious);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.panWorkspace);
            this.Controls.Add(this.btnShowMatrixForm);
            this.MinimumSize = new System.Drawing.Size(500, 500);
            this.Name = "MainCriterionForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Выбор главного критерия и ограничений на значения остальных критериев";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainCriterionForm_FormClosing);
            this.panWorkspace.ResumeLayout(false);
            this.panWorkspace.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnPrevious;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Panel panWorkspace;
        private System.Windows.Forms.Button btnShowMatrixForm;
        private System.Windows.Forms.ComboBox cmbMainCriterion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnDeleteCriterialConstraint;
        private System.Windows.Forms.Button btnEditCriterialConstraint;
        private System.Windows.Forms.Button btnAddCriterialConstraint;
        private System.Windows.Forms.DataGridView dgvData;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCriterionId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCriterionName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCriterionVariableIdentifier;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSign;
        private System.Windows.Forms.DataGridViewTextBoxColumn colValue;
    }
}