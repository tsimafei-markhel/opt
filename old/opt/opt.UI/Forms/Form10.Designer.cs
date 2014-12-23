namespace opt.UI.Forms
{
    partial class Form10
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
            this.btnDeleteParameter = new System.Windows.Forms.Button();
            this.btnEditParameter = new System.Windows.Forms.Button();
            this.btnAddParameter = new System.Windows.Forms.Button();
            this.dgvParameters = new System.Windows.Forms.DataGridView();
            this.colParameterId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colParameterName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colParameterVariableIdentifier = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colParameterMinValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colParameterMaxValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnPrevious = new System.Windows.Forms.Button();
            this.panWorkspace.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvParameters)).BeginInit();
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
            this.panWorkspace.Controls.Add(this.btnDeleteParameter);
            this.panWorkspace.Controls.Add(this.btnEditParameter);
            this.panWorkspace.Controls.Add(this.btnAddParameter);
            this.panWorkspace.Controls.Add(this.dgvParameters);
            this.panWorkspace.Location = new System.Drawing.Point(12, 12);
            this.panWorkspace.Name = "panWorkspace";
            this.panWorkspace.Size = new System.Drawing.Size(768, 509);
            this.panWorkspace.TabIndex = 0;
            // 
            // btnDeleteParameter
            // 
            this.btnDeleteParameter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeleteParameter.Image = global::opt.UI.Properties.Resources.delete;
            this.btnDeleteParameter.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDeleteParameter.Location = new System.Drawing.Point(625, 75);
            this.btnDeleteParameter.Name = "btnDeleteParameter";
            this.btnDeleteParameter.Size = new System.Drawing.Size(141, 30);
            this.btnDeleteParameter.TabIndex = 3;
            this.btnDeleteParameter.Text = "Удалить";
            this.btnDeleteParameter.UseVisualStyleBackColor = true;
            this.btnDeleteParameter.Click += new System.EventHandler(this.btnDeleteParameter_Click);
            // 
            // btnEditParameter
            // 
            this.btnEditParameter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEditParameter.Image = global::opt.UI.Properties.Resources.edit;
            this.btnEditParameter.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEditParameter.Location = new System.Drawing.Point(625, 39);
            this.btnEditParameter.Name = "btnEditParameter";
            this.btnEditParameter.Size = new System.Drawing.Size(140, 30);
            this.btnEditParameter.TabIndex = 2;
            this.btnEditParameter.Text = "Редактировать...";
            this.btnEditParameter.UseVisualStyleBackColor = true;
            this.btnEditParameter.Click += new System.EventHandler(this.btnEditParameter_Click);
            // 
            // btnAddParameter
            // 
            this.btnAddParameter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddParameter.Image = global::opt.UI.Properties.Resources.add;
            this.btnAddParameter.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddParameter.Location = new System.Drawing.Point(625, 3);
            this.btnAddParameter.Name = "btnAddParameter";
            this.btnAddParameter.Size = new System.Drawing.Size(140, 30);
            this.btnAddParameter.TabIndex = 1;
            this.btnAddParameter.Text = "Добавить...";
            this.btnAddParameter.UseVisualStyleBackColor = true;
            this.btnAddParameter.Click += new System.EventHandler(this.btnAddParameter_Click);
            // 
            // dgvParameters
            // 
            this.dgvParameters.AllowUserToAddRows = false;
            this.dgvParameters.AllowUserToDeleteRows = false;
            this.dgvParameters.AllowUserToResizeRows = false;
            this.dgvParameters.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvParameters.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvParameters.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvParameters.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colParameterId,
            this.colParameterName,
            this.colParameterVariableIdentifier,
            this.colParameterMinValue,
            this.colParameterMaxValue});
            this.dgvParameters.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvParameters.Location = new System.Drawing.Point(3, 3);
            this.dgvParameters.Name = "dgvParameters";
            this.dgvParameters.RowHeadersVisible = false;
            this.dgvParameters.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvParameters.Size = new System.Drawing.Size(616, 503);
            this.dgvParameters.TabIndex = 0;
            // 
            // colParameterId
            // 
            this.colParameterId.HeaderText = "ID";
            this.colParameterId.Name = "colParameterId";
            this.colParameterId.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colParameterId.Visible = false;
            this.colParameterId.Width = 24;
            // 
            // colParameterName
            // 
            this.colParameterName.HeaderText = "Название параметра";
            this.colParameterName.Name = "colParameterName";
            this.colParameterName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colParameterName.Width = 109;
            // 
            // colParameterVariableIdentifier
            // 
            this.colParameterVariableIdentifier.HeaderText = "Идентификатор переменной параметра";
            this.colParameterVariableIdentifier.Name = "colParameterVariableIdentifier";
            this.colParameterVariableIdentifier.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colParameterVariableIdentifier.Width = 145;
            // 
            // colParameterMinValue
            // 
            this.colParameterMinValue.HeaderText = "Минимальное значение";
            this.colParameterMinValue.Name = "colParameterMinValue";
            this.colParameterMinValue.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colParameterMinValue.Width = 121;
            // 
            // colParameterMaxValue
            // 
            this.colParameterMaxValue.HeaderText = "Максимальное значение";
            this.colParameterMaxValue.Name = "colParameterMaxValue";
            this.colParameterMaxValue.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colParameterMaxValue.Width = 126;
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
            // Form10
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 566);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnPrevious);
            this.Controls.Add(this.panWorkspace);
            this.MinimumSize = new System.Drawing.Size(300, 300);
            this.Name = "Form10";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Оптимизируемые параметры";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form10_FormClosing);
            this.panWorkspace.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvParameters)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnPrevious;
        private System.Windows.Forms.Panel panWorkspace;
        private System.Windows.Forms.DataGridView dgvParameters;
        private System.Windows.Forms.Button btnDeleteParameter;
        private System.Windows.Forms.Button btnEditParameter;
        private System.Windows.Forms.Button btnAddParameter;
        private System.Windows.Forms.DataGridViewTextBoxColumn colParameterId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colParameterName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colParameterVariableIdentifier;
        private System.Windows.Forms.DataGridViewTextBoxColumn colParameterMinValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn colParameterMaxValue;
    }
}