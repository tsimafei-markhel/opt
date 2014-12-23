namespace opt.UI.Forms
{
    partial class AdmissibleSetForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnPrevious = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.panWorkspace = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnResetAdmissibleSet = new System.Windows.Forms.Button();
            this.btnRefreshAdmissibleSet = new System.Windows.Forms.Button();
            this.dgvBoundaryPoints = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewComboBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.lblSelectedMethod = new System.Windows.Forms.Label();
            this.btnOptions = new System.Windows.Forms.Button();
            this.optionsMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuRepeatParams = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuShowConstraints = new System.Windows.Forms.ToolStripMenuItem();
            this.panWorkspace.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBoundaryPoints)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.optionsMenu.SuspendLayout();
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
            this.panWorkspace.Controls.Add(this.label1);
            this.panWorkspace.Controls.Add(this.btnResetAdmissibleSet);
            this.panWorkspace.Controls.Add(this.btnRefreshAdmissibleSet);
            this.panWorkspace.Controls.Add(this.dgvBoundaryPoints);
            this.panWorkspace.Controls.Add(this.dgvData);
            this.panWorkspace.Location = new System.Drawing.Point(12, 12);
            this.panWorkspace.Name = "panWorkspace";
            this.panWorkspace.Size = new System.Drawing.Size(768, 509);
            this.panWorkspace.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(3, 461);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(300, 45);
            this.label1.TabIndex = 4;
            this.label1.Text = "Все эксперименты, значение критерия для которых хуже, чем для эксперимента со вве" +
    "денным номером, будут отброшены и не войдут в допустимое множество";
            // 
            // btnResetAdmissibleSet
            // 
            this.btnResetAdmissibleSet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnResetAdmissibleSet.Location = new System.Drawing.Point(150, 430);
            this.btnResetAdmissibleSet.Name = "btnResetAdmissibleSet";
            this.btnResetAdmissibleSet.Size = new System.Drawing.Size(75, 23);
            this.btnResetAdmissibleSet.TabIndex = 3;
            this.btnResetAdmissibleSet.Text = "Сначала";
            this.btnResetAdmissibleSet.UseVisualStyleBackColor = true;
            this.btnResetAdmissibleSet.Click += new System.EventHandler(this.btnResetAdmissibleSet_Click);
            // 
            // btnRefreshAdmissibleSet
            // 
            this.btnRefreshAdmissibleSet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRefreshAdmissibleSet.Location = new System.Drawing.Point(69, 430);
            this.btnRefreshAdmissibleSet.Name = "btnRefreshAdmissibleSet";
            this.btnRefreshAdmissibleSet.Size = new System.Drawing.Size(75, 23);
            this.btnRefreshAdmissibleSet.TabIndex = 2;
            this.btnRefreshAdmissibleSet.Text = "Обновить";
            this.btnRefreshAdmissibleSet.UseVisualStyleBackColor = true;
            this.btnRefreshAdmissibleSet.Click += new System.EventHandler(this.btnRefreshAdmissibleSet_Click);
            // 
            // dgvBoundaryPoints
            // 
            this.dgvBoundaryPoints.AllowUserToAddRows = false;
            this.dgvBoundaryPoints.AllowUserToDeleteRows = false;
            this.dgvBoundaryPoints.AllowUserToResizeRows = false;
            this.dgvBoundaryPoints.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dgvBoundaryPoints.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvBoundaryPoints.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBoundaryPoints.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewComboBoxColumn1});
            this.dgvBoundaryPoints.Location = new System.Drawing.Point(3, 3);
            this.dgvBoundaryPoints.Name = "dgvBoundaryPoints";
            this.dgvBoundaryPoints.RowHeadersVisible = false;
            this.dgvBoundaryPoints.Size = new System.Drawing.Size(300, 421);
            this.dgvBoundaryPoints.TabIndex = 1;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "ID";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn1.Visible = false;
            this.dataGridViewTextBoxColumn1.Width = 24;
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightGray;
            this.dataGridViewTextBoxColumn2.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewTextBoxColumn2.HeaderText = "Название критерия";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn2.Width = 102;
            // 
            // dataGridViewComboBoxColumn1
            // 
            this.dataGridViewComboBoxColumn1.HeaderText = "Номер граничного эксперимента";
            this.dataGridViewComboBoxColumn1.Name = "dataGridViewComboBoxColumn1";
            this.dataGridViewComboBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewComboBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewComboBoxColumn1.Width = 165;
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
            this.dgvData.Location = new System.Drawing.Point(309, 3);
            this.dgvData.Name = "dgvData";
            this.dgvData.RowHeadersVisible = false;
            this.dgvData.Size = new System.Drawing.Size(456, 503);
            this.dgvData.TabIndex = 4;
            // 
            // lblSelectedMethod
            // 
            this.lblSelectedMethod.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSelectedMethod.Location = new System.Drawing.Point(93, 527);
            this.lblSelectedMethod.Name = "lblSelectedMethod";
            this.lblSelectedMethod.Size = new System.Drawing.Size(373, 30);
            this.lblSelectedMethod.TabIndex = 14;
            this.lblSelectedMethod.Text = "Выбранный метод поиска окончательного решения:";
            // 
            // btnOptions
            // 
            this.btnOptions.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOptions.Image = global::opt.UI.Properties.Resources.cog;
            this.btnOptions.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOptions.Location = new System.Drawing.Point(472, 527);
            this.btnOptions.Name = "btnOptions";
            this.btnOptions.Size = new System.Drawing.Size(136, 27);
            this.btnOptions.TabIndex = 1;
            this.btnOptions.Text = "Опции отображения";
            this.btnOptions.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnOptions.UseVisualStyleBackColor = true;
            this.btnOptions.Click += new System.EventHandler(this.btnOptions_Click);
            // 
            // optionsMenu
            // 
            this.optionsMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuRepeatParams,
            this.mnuShowConstraints});
            this.optionsMenu.Name = "optionsMenu";
            this.optionsMenu.Size = new System.Drawing.Size(387, 48);
            // 
            // mnuRepeatParams
            // 
            this.mnuRepeatParams.CheckOnClick = true;
            this.mnuRepeatParams.Name = "mnuRepeatParams";
            this.mnuRepeatParams.Size = new System.Drawing.Size(386, 22);
            this.mnuRepeatParams.Text = "Показать значения параметров после каждого критерия";
            this.mnuRepeatParams.Click += new System.EventHandler(this.mnuRepeatParams_Click);
            // 
            // mnuShowConstraints
            // 
            this.mnuShowConstraints.CheckOnClick = true;
            this.mnuShowConstraints.Name = "mnuShowConstraints";
            this.mnuShowConstraints.Size = new System.Drawing.Size(386, 22);
            this.mnuShowConstraints.Text = "Показать значения функциональных ограничений";
            this.mnuShowConstraints.Click += new System.EventHandler(this.mnuShowConstraints_Click);
            // 
            // AdmissibleSetForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 566);
            this.Controls.Add(this.btnOptions);
            this.Controls.Add(this.lblSelectedMethod);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnPrevious);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.panWorkspace);
            this.MinimumSize = new System.Drawing.Size(500, 500);
            this.Name = "AdmissibleSetForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Формирование допустимого множества";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AdmissibleSetForm_FormClosing);
            this.panWorkspace.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBoundaryPoints)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.optionsMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnPrevious;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Panel panWorkspace;
        private System.Windows.Forms.DataGridView dgvData;
        private System.Windows.Forms.DataGridView dgvBoundaryPoints;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnResetAdmissibleSet;
        private System.Windows.Forms.Button btnRefreshAdmissibleSet;
        private System.Windows.Forms.Label lblSelectedMethod;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewComboBoxColumn1;
        private System.Windows.Forms.Button btnOptions;
        private System.Windows.Forms.ContextMenuStrip optionsMenu;
        private System.Windows.Forms.ToolStripMenuItem mnuRepeatParams;
        private System.Windows.Forms.ToolStripMenuItem mnuShowConstraints;
    }
}