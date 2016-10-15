namespace opt.UI.Forms
{
    partial class Form45
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
            this.btnExit = new System.Windows.Forms.Button();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.panWorkspace = new System.Windows.Forms.Panel();
            this.btnOptions = new System.Windows.Forms.Button();
            this.optionsMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuRepeatParams = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEnableSorting = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuApplyConstraints = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuHideInactiveExperiments = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuChangeConstraints = new System.Windows.Forms.ToolStripMenuItem();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnPrevious = new System.Windows.Forms.Button();
            this.btnSaveMatrix = new System.Windows.Forms.Button();
            this.dlgSaveModel = new System.Windows.Forms.SaveFileDialog();
            this.btnCorrelations = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.panWorkspace.SuspendLayout();
            this.optionsMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnExit.CausesValidation = false;
            this.btnExit.Location = new System.Drawing.Point(12, 527);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 27);
            this.btnExit.TabIndex = 6;
            this.btnExit.Text = "Выход";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // dgvData
            // 
            this.dgvData.AllowUserToAddRows = false;
            this.dgvData.AllowUserToDeleteRows = false;
            this.dgvData.AllowUserToResizeRows = false;
            this.dgvData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvData.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvData.Location = new System.Drawing.Point(0, 0);
            this.dgvData.Name = "dgvData";
            this.dgvData.RowHeadersVisible = false;
            this.dgvData.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dgvData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvData.ShowEditingIcon = false;
            this.dgvData.Size = new System.Drawing.Size(768, 509);
            this.dgvData.TabIndex = 0;
            // 
            // panWorkspace
            // 
            this.panWorkspace.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panWorkspace.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panWorkspace.BackColor = System.Drawing.SystemColors.Control;
            this.panWorkspace.Controls.Add(this.dgvData);
            this.panWorkspace.Location = new System.Drawing.Point(12, 12);
            this.panWorkspace.Name = "panWorkspace";
            this.panWorkspace.Size = new System.Drawing.Size(768, 509);
            this.panWorkspace.TabIndex = 0;
            // 
            // btnOptions
            // 
            this.btnOptions.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnOptions.Image = global::opt.UI.Properties.Resources.cog;
            this.btnOptions.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOptions.Location = new System.Drawing.Point(160, 527);
            this.btnOptions.Name = "btnOptions";
            this.btnOptions.Size = new System.Drawing.Size(135, 27);
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
            this.mnuEnableSorting,
            this.mnuApplyConstraints,
            this.mnuHideInactiveExperiments,
            this.toolStripSeparator1,
            this.mnuChangeConstraints});
            this.optionsMenu.Name = "optionsMenu";
            this.optionsMenu.Size = new System.Drawing.Size(512, 120);
            // 
            // mnuRepeatParams
            // 
            this.mnuRepeatParams.Checked = true;
            this.mnuRepeatParams.CheckOnClick = true;
            this.mnuRepeatParams.CheckState = System.Windows.Forms.CheckState.Checked;
            this.mnuRepeatParams.Name = "mnuRepeatParams";
            this.mnuRepeatParams.Size = new System.Drawing.Size(511, 22);
            this.mnuRepeatParams.Text = "Показать значения параметров после каждого критерия";
            this.mnuRepeatParams.Click += new System.EventHandler(this.mnuRepeatParams_Click);
            // 
            // mnuEnableSorting
            // 
            this.mnuEnableSorting.Checked = true;
            this.mnuEnableSorting.CheckOnClick = true;
            this.mnuEnableSorting.CheckState = System.Windows.Forms.CheckState.Checked;
            this.mnuEnableSorting.Name = "mnuEnableSorting";
            this.mnuEnableSorting.Size = new System.Drawing.Size(511, 22);
            this.mnuEnableSorting.Text = "Сортировать эксперименты согласно типа критерия";
            this.mnuEnableSorting.Click += new System.EventHandler(this.mnuEnableSorting_Click);
            // 
            // mnuApplyConstraints
            // 
            this.mnuApplyConstraints.Checked = true;
            this.mnuApplyConstraints.CheckOnClick = true;
            this.mnuApplyConstraints.CheckState = System.Windows.Forms.CheckState.Checked;
            this.mnuApplyConstraints.Name = "mnuApplyConstraints";
            this.mnuApplyConstraints.Size = new System.Drawing.Size(511, 22);
            this.mnuApplyConstraints.Text = "Отсеять эксперименты по функциональным ограничениям";
            this.mnuApplyConstraints.ToolTipText = "Отсеянные эксперименты отображаются другим цветом";
            this.mnuApplyConstraints.Click += new System.EventHandler(this.mnuApplyConstraints_Click);
            // 
            // mnuHideInactiveExperiments
            // 
            this.mnuHideInactiveExperiments.CheckOnClick = true;
            this.mnuHideInactiveExperiments.Name = "mnuHideInactiveExperiments";
            this.mnuHideInactiveExperiments.Size = new System.Drawing.Size(511, 22);
            this.mnuHideInactiveExperiments.Text = "Скрыть эксперименты, не удовлетворяющие функциональным ограничениям";
            this.mnuHideInactiveExperiments.Click += new System.EventHandler(this.mnuHideInactiveExperiments_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(508, 6);
            // 
            // mnuChangeConstraints
            // 
            this.mnuChangeConstraints.Name = "mnuChangeConstraints";
            this.mnuChangeConstraints.Size = new System.Drawing.Size(511, 22);
            this.mnuChangeConstraints.Text = "Переопределить функциональные ограничения...";
            this.mnuChangeConstraints.Click += new System.EventHandler(this.mnuChangeConstraints_Click);
            // 
            // btnNext
            // 
            this.btnNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNext.Image = global::opt.UI.Properties.Resources.next;
            this.btnNext.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNext.Location = new System.Drawing.Point(705, 527);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(75, 27);
            this.btnNext.TabIndex = 5;
            this.btnNext.Text = "Далее";
            this.btnNext.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnPrevious
            // 
            this.btnPrevious.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrevious.CausesValidation = false;
            this.btnPrevious.Image = global::opt.UI.Properties.Resources.previous;
            this.btnPrevious.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPrevious.Location = new System.Drawing.Point(624, 527);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(75, 27);
            this.btnPrevious.TabIndex = 4;
            this.btnPrevious.Text = "Назад";
            this.btnPrevious.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPrevious.UseVisualStyleBackColor = true;
            this.btnPrevious.Click += new System.EventHandler(this.btnPrevious_Click);
            // 
            // btnSaveMatrix
            // 
            this.btnSaveMatrix.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveMatrix.Image = global::opt.UI.Properties.Resources.disk;
            this.btnSaveMatrix.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSaveMatrix.Location = new System.Drawing.Point(521, 527);
            this.btnSaveMatrix.Name = "btnSaveMatrix";
            this.btnSaveMatrix.Size = new System.Drawing.Size(87, 27);
            this.btnSaveMatrix.TabIndex = 3;
            this.btnSaveMatrix.Text = "Сохранить";
            this.btnSaveMatrix.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSaveMatrix.UseVisualStyleBackColor = true;
            this.btnSaveMatrix.Click += new System.EventHandler(this.btnSaveMatrix_Click);
            // 
            // dlgSaveModel
            // 
            this.dlgSaveModel.Filter = "Файл матрицы решений (*.xml)|*.xml|Книга Excel (*.xlsx)|*.xlsx|Все файлы (*.*)|*." +
    "*";
            this.dlgSaveModel.Title = "Сохранить матрицу решений в файл...";
            // 
            // btnCorrelations
            // 
            this.btnCorrelations.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCorrelations.Location = new System.Drawing.Point(301, 527);
            this.btnCorrelations.Name = "btnCorrelations";
            this.btnCorrelations.Size = new System.Drawing.Size(135, 27);
            this.btnCorrelations.TabIndex = 2;
            this.btnCorrelations.Text = "Корреляция критериев";
            this.btnCorrelations.UseVisualStyleBackColor = true;
            this.btnCorrelations.Click += new System.EventHandler(this.btnCorrelations_Click);
            // 
            // Form45
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 566);
            this.Controls.Add(this.btnCorrelations);
            this.Controls.Add(this.btnSaveMatrix);
            this.Controls.Add(this.btnOptions);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.panWorkspace);
            this.Controls.Add(this.btnPrevious);
            this.MinimumSize = new System.Drawing.Size(800, 300);
            this.Name = "Form45";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Матрица решений";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form45_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.panWorkspace.ResumeLayout(false);
            this.optionsMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.DataGridView dgvData;
        private System.Windows.Forms.Panel panWorkspace;
        private System.Windows.Forms.Button btnPrevious;
        private System.Windows.Forms.Button btnOptions;
        private System.Windows.Forms.ContextMenuStrip optionsMenu;
        private System.Windows.Forms.ToolStripMenuItem mnuRepeatParams;
        private System.Windows.Forms.ToolStripMenuItem mnuEnableSorting;
        private System.Windows.Forms.ToolStripMenuItem mnuApplyConstraints;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem mnuChangeConstraints;
        private System.Windows.Forms.Button btnSaveMatrix;
        private System.Windows.Forms.SaveFileDialog dlgSaveModel;
        private System.Windows.Forms.Button btnCorrelations;
        private System.Windows.Forms.ToolStripMenuItem mnuHideInactiveExperiments;
    }
}