namespace opt.UI
{
    partial class StartForm
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
            this.radioCreate = new System.Windows.Forms.RadioButton();
            this.radioLoad = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.textModelFile = new System.Windows.Forms.TextBox();
            this.buttonChooseModelFile = new System.Windows.Forms.Button();
            this.dialogModelFile = new System.Windows.Forms.OpenFileDialog();
            this.panWorkspace.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnPrevious
            // 
            this.btnPrevious.Enabled = false;
            // 
            // panWorkspace
            // 
            this.panWorkspace.Controls.Add(this.buttonChooseModelFile);
            this.panWorkspace.Controls.Add(this.textModelFile);
            this.panWorkspace.Controls.Add(this.label1);
            this.panWorkspace.Controls.Add(this.radioLoad);
            this.panWorkspace.Controls.Add(this.radioCreate);
            // 
            // radioCreate
            // 
            this.radioCreate.AutoSize = true;
            this.radioCreate.Checked = true;
            this.radioCreate.Location = new System.Drawing.Point(46, 50);
            this.radioCreate.Name = "radioCreate";
            this.radioCreate.Size = new System.Drawing.Size(218, 17);
            this.radioCreate.TabIndex = 0;
            this.radioCreate.TabStop = true;
            this.radioCreate.Text = "Создать новую операционную модель";
            this.radioCreate.UseVisualStyleBackColor = true;
            // 
            // radioLoad
            // 
            this.radioLoad.AutoSize = true;
            this.radioLoad.Location = new System.Drawing.Point(46, 103);
            this.radioLoad.Name = "radioLoad";
            this.radioLoad.Size = new System.Drawing.Size(244, 17);
            this.radioLoad.TabIndex = 1;
            this.radioLoad.Text = "Загрузить операционную модель из файла";
            this.radioLoad.UseVisualStyleBackColor = true;
            this.radioLoad.CheckedChanged += new System.EventHandler(this.radioLoad_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Enabled = false;
            this.label1.Location = new System.Drawing.Point(103, 138);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(282, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Файл идентификационной или операционной модели:";
            // 
            // textModelFile
            // 
            this.textModelFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textModelFile.Enabled = false;
            this.textModelFile.Location = new System.Drawing.Point(106, 154);
            this.textModelFile.Name = "textModelFile";
            this.textModelFile.Size = new System.Drawing.Size(621, 20);
            this.textModelFile.TabIndex = 2;
            // 
            // buttonChooseModelFile
            // 
            this.buttonChooseModelFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonChooseModelFile.Enabled = false;
            this.buttonChooseModelFile.Image = global::opt.Properties.Resources.magnifier;
            this.buttonChooseModelFile.Location = new System.Drawing.Point(733, 152);
            this.buttonChooseModelFile.Name = "buttonChooseModelFile";
            this.buttonChooseModelFile.Size = new System.Drawing.Size(24, 23);
            this.buttonChooseModelFile.TabIndex = 3;
            this.buttonChooseModelFile.UseVisualStyleBackColor = true;
            this.buttonChooseModelFile.Click += new System.EventHandler(this.buttonChooseModelFile_Click);
            // 
            // dialogModelFile
            // 
            this.dialogModelFile.Filter = "Файл модели (*.xml)|*.xml|Все файлы (*.*)|*.*";
            this.dialogModelFile.Title = "Выбрать внешнюю расчетную программу";
            // 
            // StartForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Name = "StartForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Выбор режима работы";
            this.panWorkspace.ResumeLayout(false);
            this.panWorkspace.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RadioButton radioCreate;
        private System.Windows.Forms.RadioButton radioLoad;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textModelFile;
        private System.Windows.Forms.Button buttonChooseModelFile;
        private System.Windows.Forms.OpenFileDialog dialogModelFile;

    }
}