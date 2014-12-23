namespace opt.UI
{
    partial class ViewGeneratedExperimentsForm
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
            this.dgvGeneratedExp = new System.Windows.Forms.DataGridView();
            this.colIdReadExp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIdIdentificationExp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRealExperiment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIndentificationExperiment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dialogSaveModel = new System.Windows.Forms.SaveFileDialog();
            this.buttonSave = new System.Windows.Forms.Button();
            this.panWorkspace.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGeneratedExp)).BeginInit();
            this.SuspendLayout();
            // 
            // panWorkspace
            // 
            this.panWorkspace.Controls.Add(this.dgvGeneratedExp);
            // 
            // dgvGeneratedExp
            // 
            this.dgvGeneratedExp.AllowUserToAddRows = false;
            this.dgvGeneratedExp.AllowUserToDeleteRows = false;
            this.dgvGeneratedExp.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGeneratedExp.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colIdReadExp,
            this.colIdIdentificationExp,
            this.colRealExperiment,
            this.colIndentificationExperiment});
            this.dgvGeneratedExp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvGeneratedExp.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvGeneratedExp.Location = new System.Drawing.Point(0, 0);
            this.dgvGeneratedExp.Name = "dgvGeneratedExp";
            this.dgvGeneratedExp.ReadOnly = true;
            this.dgvGeneratedExp.RowHeadersVisible = false;
            this.dgvGeneratedExp.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvGeneratedExp.Size = new System.Drawing.Size(760, 507);
            this.dgvGeneratedExp.TabIndex = 8;
            // 
            // colIdReadExp
            // 
            this.colIdReadExp.HeaderText = "IdReadExp";
            this.colIdReadExp.Name = "colIdReadExp";
            this.colIdReadExp.ReadOnly = true;
            this.colIdReadExp.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colIdReadExp.Visible = false;
            // 
            // colIdIdentificationExp
            // 
            this.colIdIdentificationExp.HeaderText = "IdIdentificationExp";
            this.colIdIdentificationExp.Name = "colIdIdentificationExp";
            this.colIdIdentificationExp.ReadOnly = true;
            this.colIdIdentificationExp.Visible = false;
            // 
            // colRealExperiment
            // 
            this.colRealExperiment.HeaderText = "Номер реального эксперимента";
            this.colRealExperiment.MinimumWidth = 100;
            this.colRealExperiment.Name = "colRealExperiment";
            this.colRealExperiment.ReadOnly = true;
            this.colRealExperiment.Width = 150;
            // 
            // colIndentificationExperiment
            // 
            this.colIndentificationExperiment.HeaderText = "Номер индентификационного эксперимента";
            this.colIndentificationExperiment.MinimumWidth = 100;
            this.colIndentificationExperiment.Name = "colIndentificationExperiment";
            this.colIndentificationExperiment.ReadOnly = true;
            this.colIndentificationExperiment.Width = 150;
            // 
            // dialogSaveModel
            // 
            this.dialogSaveModel.Filter = "Файл модели (*.xml)|*.xml|Все файлы (*.*)|*.*";
            // 
            // buttonSave
            // 
            this.buttonSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSave.Image = global::opt.Properties.Resources.disk;
            this.buttonSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonSave.Location = new System.Drawing.Point(497, 525);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(98, 25);
            this.buttonSave.TabIndex = 4;
            this.buttonSave.Text = "Сохранить...";
            this.buttonSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // ViewGeneratedExperimentsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.buttonSave);
            this.Name = "ViewGeneratedExperimentsForm";
            this.Text = "Просмотр сгенерированных идентифицируемых параметров";
            this.Controls.SetChildIndex(this.btnExit, 0);
            this.Controls.SetChildIndex(this.btnPrevious, 0);
            this.Controls.SetChildIndex(this.btnNext, 0);
            this.Controls.SetChildIndex(this.panWorkspace, 0);
            this.Controls.SetChildIndex(this.buttonSave, 0);
            this.panWorkspace.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvGeneratedExp)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvGeneratedExp;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdReadExp;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdIdentificationExp;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRealExperiment;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIndentificationExperiment;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.SaveFileDialog dialogSaveModel;
    }
}