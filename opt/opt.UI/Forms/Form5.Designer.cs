namespace opt.UI.Forms
{
    partial class Form5
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
            this.chbRedefineModel = new System.Windows.Forms.CheckBox();
            this.btnChooseFile = new System.Windows.Forms.Button();
            this.txtFileName = new opt.UI.Helpers.PathTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.rbnLoadSavedModel = new System.Windows.Forms.RadioButton();
            this.rbnCreateNewModel = new System.Windows.Forms.RadioButton();
            this.btnNext = new System.Windows.Forms.Button();
            this.dlgOpenModelFile = new System.Windows.Forms.OpenFileDialog();
            this.panWorkspace.SuspendLayout();
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
            this.panWorkspace.Controls.Add(this.chbRedefineModel);
            this.panWorkspace.Controls.Add(this.btnChooseFile);
            this.panWorkspace.Controls.Add(this.txtFileName);
            this.panWorkspace.Controls.Add(this.label1);
            this.panWorkspace.Controls.Add(this.rbnLoadSavedModel);
            this.panWorkspace.Controls.Add(this.rbnCreateNewModel);
            this.panWorkspace.Location = new System.Drawing.Point(12, 12);
            this.panWorkspace.Name = "panWorkspace";
            this.panWorkspace.Size = new System.Drawing.Size(768, 509);
            this.panWorkspace.TabIndex = 0;
            // 
            // chbRedefineModel
            // 
            this.chbRedefineModel.AutoSize = true;
            this.chbRedefineModel.CheckAlign = System.Drawing.ContentAlignment.TopLeft;
            this.chbRedefineModel.Enabled = false;
            this.chbRedefineModel.Location = new System.Drawing.Point(73, 150);
            this.chbRedefineModel.Name = "chbRedefineModel";
            this.chbRedefineModel.Size = new System.Drawing.Size(528, 30);
            this.chbRedefineModel.TabIndex = 4;
            this.chbRedefineModel.Text = "Изменить оптимизируемые параметры, критерии оптимальности и функциональные ограни" +
    "чения\r\n(очистит матрицу решений)";
            this.chbRedefineModel.UseVisualStyleBackColor = true;
            // 
            // btnChooseFile
            // 
            this.btnChooseFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnChooseFile.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnChooseFile.Enabled = false;
            this.btnChooseFile.Image = global::opt.UI.Properties.Resources.browse;
            this.btnChooseFile.Location = new System.Drawing.Point(741, 119);
            this.btnChooseFile.Name = "btnChooseFile";
            this.btnChooseFile.Size = new System.Drawing.Size(24, 24);
            this.btnChooseFile.TabIndex = 3;
            this.btnChooseFile.UseVisualStyleBackColor = true;
            this.btnChooseFile.Click += new System.EventHandler(this.btnChooseFile_Click);
            // 
            // txtFileName
            // 
            this.txtFileName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFileName.Enabled = false;
            this.txtFileName.Location = new System.Drawing.Point(115, 121);
            this.txtFileName.Name = "txtFileName";
            this.txtFileName.Size = new System.Drawing.Size(620, 20);
            this.txtFileName.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Enabled = false;
            this.label1.Location = new System.Drawing.Point(70, 124);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Файл:";
            // 
            // rbnLoadSavedModel
            // 
            this.rbnLoadSavedModel.AutoSize = true;
            this.rbnLoadSavedModel.Location = new System.Drawing.Point(50, 96);
            this.rbnLoadSavedModel.Name = "rbnLoadSavedModel";
            this.rbnLoadSavedModel.Size = new System.Drawing.Size(219, 17);
            this.rbnLoadSavedModel.TabIndex = 1;
            this.rbnLoadSavedModel.Text = "Загрузить матрицу решений из файла";
            this.rbnLoadSavedModel.UseVisualStyleBackColor = true;
            this.rbnLoadSavedModel.CheckedChanged += new System.EventHandler(this.rbnLoadSavedModel_CheckedChanged);
            // 
            // rbnCreateNewModel
            // 
            this.rbnCreateNewModel.AutoSize = true;
            this.rbnCreateNewModel.Checked = true;
            this.rbnCreateNewModel.Location = new System.Drawing.Point(50, 64);
            this.rbnCreateNewModel.Name = "rbnCreateNewModel";
            this.rbnCreateNewModel.Size = new System.Drawing.Size(193, 17);
            this.rbnCreateNewModel.TabIndex = 0;
            this.rbnCreateNewModel.TabStop = true;
            this.rbnCreateNewModel.Text = "Создать новую матрицу решений";
            this.rbnCreateNewModel.UseVisualStyleBackColor = true;
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
            // dlgOpenModelFile
            // 
            this.dlgOpenModelFile.Filter = "Файл матрицы решений (*.xml)|*.xml|Все файлы (*.*)|*.*";
            this.dlgOpenModelFile.Title = "Выберите файл матрицы решений";
            // 
            // Form5
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 566);
            this.Controls.Add(this.panWorkspace);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnNext);
            this.MinimumSize = new System.Drawing.Size(300, 300);
            this.Name = "Form5";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Выбор режима работы";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form5_FormClosing);
            this.panWorkspace.ResumeLayout(false);
            this.panWorkspace.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Panel panWorkspace;
        private System.Windows.Forms.RadioButton rbnLoadSavedModel;
        private System.Windows.Forms.RadioButton rbnCreateNewModel;
        private System.Windows.Forms.Button btnChooseFile;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.OpenFileDialog dlgOpenModelFile;
        private System.Windows.Forms.CheckBox chbRedefineModel;
        private opt.UI.Helpers.PathTextBox txtFileName;
    }
}