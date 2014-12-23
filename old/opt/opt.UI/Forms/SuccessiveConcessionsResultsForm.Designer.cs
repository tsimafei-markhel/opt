namespace opt.UI.Forms
{
    partial class SuccessiveConcessionsResultsForm
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
            this.btnSaveMatrix = new System.Windows.Forms.Button();
            this.btnPrevious = new System.Windows.Forms.Button();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.dlgSaveResults = new System.Windows.Forms.SaveFileDialog();
            this.panWorkspace = new System.Windows.Forms.Panel();
            this.btnFinish = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.panWorkspace.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSaveMatrix
            // 
            this.btnSaveMatrix.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveMatrix.Image = global::opt.UI.Properties.Resources.disk;
            this.btnSaveMatrix.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSaveMatrix.Location = new System.Drawing.Point(460, 527);
            this.btnSaveMatrix.Name = "btnSaveMatrix";
            this.btnSaveMatrix.Size = new System.Drawing.Size(148, 27);
            this.btnSaveMatrix.TabIndex = 2;
            this.btnSaveMatrix.Text = "Сохранить результаты";
            this.btnSaveMatrix.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSaveMatrix.UseVisualStyleBackColor = true;
            this.btnSaveMatrix.Click += new System.EventHandler(this.btnSaveMatrix_Click);
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
            this.btnPrevious.TabIndex = 3;
            this.btnPrevious.Text = "Назад";
            this.btnPrevious.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPrevious.UseVisualStyleBackColor = true;
            this.btnPrevious.Click += new System.EventHandler(this.btnPrevious_Click);
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
            this.dgvData.ReadOnly = true;
            this.dgvData.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dgvData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvData.ShowEditingIcon = false;
            this.dgvData.Size = new System.Drawing.Size(768, 509);
            this.dgvData.TabIndex = 0;
            // 
            // dlgSaveResults
            // 
            this.dlgSaveResults.Filter = "Книга Excel (*.xlsx)|*.xlsx|Текстовый файл (*.txt)|*.txt|Все файлы (*.*)|*.*";
            this.dlgSaveResults.Title = "Сохранить результаты в файл...";
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
            // btnFinish
            // 
            this.btnFinish.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnFinish.Image = global::opt.UI.Properties.Resources.accept;
            this.btnFinish.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFinish.Location = new System.Drawing.Point(12, 527);
            this.btnFinish.Name = "btnFinish";
            this.btnFinish.Size = new System.Drawing.Size(75, 27);
            this.btnFinish.TabIndex = 1;
            this.btnFinish.Text = "Готово";
            this.btnFinish.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnFinish.UseVisualStyleBackColor = true;
            this.btnFinish.Click += new System.EventHandler(this.btnFinish_Click);
            // 
            // SuccessiveConcessionsResultsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 566);
            this.Controls.Add(this.btnSaveMatrix);
            this.Controls.Add(this.btnPrevious);
            this.Controls.Add(this.panWorkspace);
            this.Controls.Add(this.btnFinish);
            this.MinimumSize = new System.Drawing.Size(300, 300);
            this.Name = "SuccessiveConcessionsResultsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Результаты поиска окончательного решения";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SuccessiveConcessionsResultsForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.panWorkspace.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSaveMatrix;
        private System.Windows.Forms.Button btnPrevious;
        private System.Windows.Forms.DataGridView dgvData;
        private System.Windows.Forms.SaveFileDialog dlgSaveResults;
        private System.Windows.Forms.Panel panWorkspace;
        private System.Windows.Forms.Button btnFinish;
    }
}