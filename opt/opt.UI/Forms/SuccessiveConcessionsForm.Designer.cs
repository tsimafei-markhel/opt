namespace opt.UI.Forms
{
    partial class SuccessiveConcessionsForm
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
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.optionsMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuShowParams = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuShowConstraints = new System.Windows.Forms.ToolStripMenuItem();
            this.btnExit = new System.Windows.Forms.Button();
            this.panWorkspace = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnResetToSelection = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.dgvConcessions = new System.Windows.Forms.DataGridView();
            this.colCritId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCritName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCritConcession = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnOptions = new System.Windows.Forms.Button();
            this.btnPrevious = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.optionsMenu.SuspendLayout();
            this.panWorkspace.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvConcessions)).BeginInit();
            this.SuspendLayout();
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
            this.dgvData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.ColumnHeaderSelect;
            this.dgvData.Size = new System.Drawing.Size(456, 503);
            this.dgvData.TabIndex = 4;
            // 
            // optionsMenu
            // 
            this.optionsMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuShowParams,
            this.mnuShowConstraints});
            this.optionsMenu.Name = "optionsMenu";
            this.optionsMenu.Size = new System.Drawing.Size(354, 48);
            // 
            // mnuShowParams
            // 
            this.mnuShowParams.CheckOnClick = true;
            this.mnuShowParams.Name = "mnuShowParams";
            this.mnuShowParams.Size = new System.Drawing.Size(353, 22);
            this.mnuShowParams.Text = "Показать значения оптимизируемых параметров";
            this.mnuShowParams.Click += new System.EventHandler(this.mnuShowParams_Click);
            // 
            // mnuShowConstraints
            // 
            this.mnuShowConstraints.CheckOnClick = true;
            this.mnuShowConstraints.Name = "mnuShowConstraints";
            this.mnuShowConstraints.Size = new System.Drawing.Size(353, 22);
            this.mnuShowConstraints.Text = "Показать значения функциональных ограничений";
            this.mnuShowConstraints.Click += new System.EventHandler(this.mnuShowConstraints_Click);
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnExit.Location = new System.Drawing.Point(12, 526);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 27);
            this.btnExit.TabIndex = 4;
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
            this.panWorkspace.Controls.Add(this.label1);
            this.panWorkspace.Controls.Add(this.btnResetToSelection);
            this.panWorkspace.Controls.Add(this.btnRefresh);
            this.panWorkspace.Controls.Add(this.dgvConcessions);
            this.panWorkspace.Controls.Add(this.dgvData);
            this.panWorkspace.Location = new System.Drawing.Point(12, 11);
            this.panWorkspace.Name = "panWorkspace";
            this.panWorkspace.Size = new System.Drawing.Size(768, 509);
            this.panWorkspace.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(3, 476);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(300, 30);
            this.label1.TabIndex = 5;
            this.label1.Text = "Значения уступок необходимо задавать строго по порядку, не пропуская отдельные кр" +
    "итерии";
            // 
            // btnResetToSelection
            // 
            this.btnResetToSelection.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnResetToSelection.Location = new System.Drawing.Point(137, 450);
            this.btnResetToSelection.Name = "btnResetToSelection";
            this.btnResetToSelection.Size = new System.Drawing.Size(121, 23);
            this.btnResetToSelection.TabIndex = 3;
            this.btnResetToSelection.Text = "Откат к выбранному";
            this.btnResetToSelection.UseVisualStyleBackColor = true;
            this.btnResetToSelection.Click += new System.EventHandler(this.btnResetToSelection_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRefresh.Location = new System.Drawing.Point(56, 450);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 2;
            this.btnRefresh.Text = "Обновить";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // dgvConcessions
            // 
            this.dgvConcessions.AllowUserToAddRows = false;
            this.dgvConcessions.AllowUserToDeleteRows = false;
            this.dgvConcessions.AllowUserToResizeRows = false;
            this.dgvConcessions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dgvConcessions.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvConcessions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvConcessions.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colCritId,
            this.colCritName,
            this.colCritConcession});
            this.dgvConcessions.Location = new System.Drawing.Point(3, 3);
            this.dgvConcessions.MultiSelect = false;
            this.dgvConcessions.Name = "dgvConcessions";
            this.dgvConcessions.RowHeadersVisible = false;
            this.dgvConcessions.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvConcessions.Size = new System.Drawing.Size(300, 441);
            this.dgvConcessions.TabIndex = 1;
            // 
            // colCritId
            // 
            this.colCritId.HeaderText = "ID";
            this.colCritId.Name = "colCritId";
            this.colCritId.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colCritId.Visible = false;
            this.colCritId.Width = 24;
            // 
            // colCritName
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightGray;
            this.colCritName.DefaultCellStyle = dataGridViewCellStyle1;
            this.colCritName.HeaderText = "Название критерия";
            this.colCritName.Name = "colCritName";
            this.colCritName.ReadOnly = true;
            this.colCritName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colCritName.Width = 102;
            // 
            // colCritConcession
            // 
            this.colCritConcession.HeaderText = "Абсолютная величина уступки";
            this.colCritConcession.Name = "colCritConcession";
            this.colCritConcession.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colCritConcession.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colCritConcession.Width = 115;
            // 
            // btnOptions
            // 
            this.btnOptions.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOptions.Image = global::opt.UI.Properties.Resources.cog;
            this.btnOptions.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOptions.Location = new System.Drawing.Point(472, 526);
            this.btnOptions.Name = "btnOptions";
            this.btnOptions.Size = new System.Drawing.Size(136, 27);
            this.btnOptions.TabIndex = 1;
            this.btnOptions.Text = "Опции отображения";
            this.btnOptions.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnOptions.UseVisualStyleBackColor = true;
            this.btnOptions.Click += new System.EventHandler(this.btnOptions_Click);
            // 
            // btnPrevious
            // 
            this.btnPrevious.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrevious.Image = global::opt.UI.Properties.Resources.previous;
            this.btnPrevious.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPrevious.Location = new System.Drawing.Point(624, 526);
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
            this.btnNext.Location = new System.Drawing.Point(705, 526);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(75, 27);
            this.btnNext.TabIndex = 3;
            this.btnNext.Text = "Далее";
            this.btnNext.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // SuccessiveConcessionsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 566);
            this.Controls.Add(this.btnOptions);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnPrevious);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.panWorkspace);
            this.MinimumSize = new System.Drawing.Size(500, 500);
            this.Name = "SuccessiveConcessionsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Задание уступок по критериям оптимальности";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SuccessiveConcessionsForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.optionsMenu.ResumeLayout(false);
            this.panWorkspace.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvConcessions)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvData;
        private System.Windows.Forms.Button btnOptions;
        private System.Windows.Forms.ContextMenuStrip optionsMenu;
        private System.Windows.Forms.ToolStripMenuItem mnuShowParams;
        private System.Windows.Forms.ToolStripMenuItem mnuShowConstraints;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnPrevious;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Panel panWorkspace;
        private System.Windows.Forms.Button btnResetToSelection;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.DataGridView dgvConcessions;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCritId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCritName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCritConcession;
        private System.Windows.Forms.Label label1;
    }
}