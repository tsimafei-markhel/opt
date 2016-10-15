namespace opt.UI
{
    partial class RealExperimentResultsForm
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
            this.dgvExperimentsResults = new System.Windows.Forms.DataGridView();
            this.dialogSaveModel = new System.Windows.Forms.SaveFileDialog();
            this.buttonReadXls = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.panWorkspace.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExperimentsResults)).BeginInit();
            this.SuspendLayout();
            // 
            // panWorkspace
            // 
            this.panWorkspace.Controls.Add(this.dgvExperimentsResults);
            // 
            // dgvExperimentsResults
            // 
            this.dgvExperimentsResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvExperimentsResults.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvExperimentsResults.Location = new System.Drawing.Point(0, 0);
            this.dgvExperimentsResults.Name = "dgvExperimentsResults";
            this.dgvExperimentsResults.Size = new System.Drawing.Size(760, 507);
            this.dgvExperimentsResults.TabIndex = 0;
            // 
            // dialogSaveModel
            // 
            this.dialogSaveModel.Filter = "Файл модели (*.xml)|*.xml|Все файлы (*.*)|*.*";
            // 
            // buttonReadXls
            // 
            this.buttonReadXls.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonReadXls.Image = global::opt.Properties.Resources.xls_file;
            this.buttonReadXls.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonReadXls.Location = new System.Drawing.Point(337, 525);
            this.buttonReadXls.Name = "buttonReadXls";
            this.buttonReadXls.Size = new System.Drawing.Size(138, 25);
            this.buttonReadXls.TabIndex = 4;
            this.buttonReadXls.Text = "Загрузить из excel...";
            this.buttonReadXls.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonReadXls.UseVisualStyleBackColor = true;
            this.buttonReadXls.Click += new System.EventHandler(this.buttonReadXls_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSave.Image = global::opt.Properties.Resources.disk;
            this.buttonSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonSave.Location = new System.Drawing.Point(497, 525);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(98, 25);
            this.buttonSave.TabIndex = 3;
            this.buttonSave.Text = "Сохранить...";
            this.buttonSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // RealExperimentResultsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.buttonReadXls);
            this.Controls.Add(this.buttonSave);
            this.Name = "RealExperimentResultsForm";
            this.Text = "Ввод результатов испытаний";
            this.VisibleChanged += new System.EventHandler(this.RealExperimentResultsForm_VisibleChanged);
            this.Controls.SetChildIndex(this.buttonSave, 0);
            this.Controls.SetChildIndex(this.btnExit, 0);
            this.Controls.SetChildIndex(this.btnPrevious, 0);
            this.Controls.SetChildIndex(this.btnNext, 0);
            this.Controls.SetChildIndex(this.panWorkspace, 0);
            this.Controls.SetChildIndex(this.buttonReadXls, 0);
            this.panWorkspace.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvExperimentsResults)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvExperimentsResults;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.SaveFileDialog dialogSaveModel;
        private System.Windows.Forms.Button buttonReadXls;
    }
}