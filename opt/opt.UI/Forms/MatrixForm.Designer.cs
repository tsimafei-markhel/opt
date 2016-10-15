namespace opt.UI.Forms
{
    partial class MatrixForm
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
            this.btnSaveMatrix = new System.Windows.Forms.Button();
            this.mnuEnableSorting = new System.Windows.Forms.ToolStripMenuItem();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.btnOptions = new System.Windows.Forms.Button();
            this.mnuRepeatParams = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuHideInactiveExperiments = new System.Windows.Forms.ToolStripMenuItem();
            this.dlgSaveModel = new System.Windows.Forms.SaveFileDialog();
            this.panWorkspace = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.optionsMenu.SuspendLayout();
            this.panWorkspace.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSaveMatrix
            // 
            this.btnSaveMatrix.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveMatrix.Image = global::opt.UI.Properties.Resources.disk;
            this.btnSaveMatrix.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSaveMatrix.Location = new System.Drawing.Point(522, 528);
            this.btnSaveMatrix.Name = "btnSaveMatrix";
            this.btnSaveMatrix.Size = new System.Drawing.Size(87, 27);
            this.btnSaveMatrix.TabIndex = 2;
            this.btnSaveMatrix.Text = "Сохранить";
            this.btnSaveMatrix.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSaveMatrix.UseVisualStyleBackColor = true;
            this.btnSaveMatrix.Click += new System.EventHandler(this.btnSaveMatrix_Click);
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
            // btnOptions
            // 
            this.btnOptions.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnOptions.Image = global::opt.UI.Properties.Resources.cog;
            this.btnOptions.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOptions.Location = new System.Drawing.Point(13, 529);
            this.btnOptions.Name = "btnOptions";
            this.btnOptions.Size = new System.Drawing.Size(136, 27);
            this.btnOptions.TabIndex = 1;
            this.btnOptions.Text = "Опции отображения";
            this.btnOptions.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnOptions.UseVisualStyleBackColor = true;
            this.btnOptions.Click += new System.EventHandler(this.btnOptions_Click);
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
            // optionsMenu
            // 
            this.optionsMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuRepeatParams,
            this.mnuEnableSorting,
            this.mnuHideInactiveExperiments});
            this.optionsMenu.Name = "optionsMenu";
            this.optionsMenu.Size = new System.Drawing.Size(512, 70);
            // 
            // mnuHideInactiveExperiments
            // 
            this.mnuHideInactiveExperiments.CheckOnClick = true;
            this.mnuHideInactiveExperiments.Name = "mnuHideInactiveExperiments";
            this.mnuHideInactiveExperiments.Size = new System.Drawing.Size(511, 22);
            this.mnuHideInactiveExperiments.Text = "Скрыть эксперименты, не удовлетворяющие функциональным ограничениям";
            this.mnuHideInactiveExperiments.Click += new System.EventHandler(this.mnuHideInactiveExperiments_Click);
            // 
            // dlgSaveModel
            // 
            this.dlgSaveModel.Filter = "Файл матрицы решений (*.xml)|*.xml|Книга Excel (*.xlsx)|*.xlsx|Все файлы (*.*)|*." +
    "*";
            this.dlgSaveModel.Title = "Сохранить матрицу решений в файл...";
            // 
            // panWorkspace
            // 
            this.panWorkspace.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panWorkspace.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panWorkspace.BackColor = System.Drawing.SystemColors.Control;
            this.panWorkspace.Controls.Add(this.dgvData);
            this.panWorkspace.Location = new System.Drawing.Point(13, 13);
            this.panWorkspace.Name = "panWorkspace";
            this.panWorkspace.Size = new System.Drawing.Size(768, 509);
            this.panWorkspace.TabIndex = 0;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.Location = new System.Drawing.Point(694, 528);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(87, 27);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "Закрыть";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // MatrixForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(794, 568);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSaveMatrix);
            this.Controls.Add(this.btnOptions);
            this.Controls.Add(this.panWorkspace);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MinimumSize = new System.Drawing.Size(300, 300);
            this.Name = "MatrixForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Матрица решений";
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.optionsMenu.ResumeLayout(false);
            this.panWorkspace.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSaveMatrix;
        private System.Windows.Forms.ToolStripMenuItem mnuEnableSorting;
        private System.Windows.Forms.DataGridView dgvData;
        private System.Windows.Forms.Button btnOptions;
        private System.Windows.Forms.ToolStripMenuItem mnuRepeatParams;
        private System.Windows.Forms.ContextMenuStrip optionsMenu;
        private System.Windows.Forms.SaveFileDialog dlgSaveModel;
        private System.Windows.Forms.Panel panWorkspace;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ToolStripMenuItem mnuHideInactiveExperiments;
    }
}