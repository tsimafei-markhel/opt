namespace opt.UI
{
    partial class RunCalculationForm
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
            this.radioExternalApp = new System.Windows.Forms.RadioButton();
            this.textExchangeFilePath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textExternalAppPath = new System.Windows.Forms.TextBox();
            this.buttonChooseExchangeFile = new System.Windows.Forms.Button();
            this.buttonChooseExternalApp = new System.Windows.Forms.Button();
            this.radioManual = new System.Windows.Forms.RadioButton();
            this.dialogExternalApp = new System.Windows.Forms.OpenFileDialog();
            this.dialogExchangeFile = new System.Windows.Forms.SaveFileDialog();
            this.panWorkspace.SuspendLayout();
            this.SuspendLayout();
            // 
            // panWorkspace
            // 
            this.panWorkspace.Controls.Add(this.radioManual);
            this.panWorkspace.Controls.Add(this.buttonChooseExchangeFile);
            this.panWorkspace.Controls.Add(this.textExternalAppPath);
            this.panWorkspace.Controls.Add(this.label2);
            this.panWorkspace.Controls.Add(this.label1);
            this.panWorkspace.Controls.Add(this.textExchangeFilePath);
            this.panWorkspace.Controls.Add(this.radioExternalApp);
            // 
            // radioExternalApp
            // 
            this.radioExternalApp.AutoSize = true;
            this.radioExternalApp.Checked = true;
            this.radioExternalApp.Location = new System.Drawing.Point(46, 50);
            this.radioExternalApp.Name = "radioExternalApp";
            this.radioExternalApp.Size = new System.Drawing.Size(443, 17);
            this.radioExternalApp.TabIndex = 0;
            this.radioExternalApp.TabStop = true;
            this.radioExternalApp.Text = "Рассчитать значения критериев и ограничений с помощью расчетной программы";
            this.radioExternalApp.UseVisualStyleBackColor = true;
            // 
            // textExchangeFilePath
            // 
            this.textExchangeFilePath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textExchangeFilePath.Location = new System.Drawing.Point(106, 101);
            this.textExchangeFilePath.Name = "textExchangeFilePath";
            this.textExchangeFilePath.Size = new System.Drawing.Size(621, 20);
            this.textExchangeFilePath.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(103, 85);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(280, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Файл для обмена данными с расчетной программой:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(103, 129);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(228, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Исполняемый файл расчетной программы:";
            // 
            // textExternalAppPath
            // 
            this.textExternalAppPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textExternalAppPath.Location = new System.Drawing.Point(106, 145);
            this.textExternalAppPath.Name = "textExternalAppPath";
            this.textExternalAppPath.Size = new System.Drawing.Size(621, 20);
            this.textExternalAppPath.TabIndex = 3;
            // 
            // buttonChooseExchangeFile
            // 
            this.buttonChooseExchangeFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonChooseExchangeFile.Image = global::opt.Properties.Resources.magnifier;
            this.buttonChooseExchangeFile.Location = new System.Drawing.Point(733, 98);
            this.buttonChooseExchangeFile.Name = "buttonChooseExchangeFile";
            this.buttonChooseExchangeFile.Size = new System.Drawing.Size(24, 24);
            this.buttonChooseExchangeFile.TabIndex = 2;
            this.buttonChooseExchangeFile.UseVisualStyleBackColor = true;
            this.buttonChooseExchangeFile.Click += new System.EventHandler(this.buttonChooseExchangeFile_Click);
            // 
            // buttonChooseExternalApp
            // 
            this.buttonChooseExternalApp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonChooseExternalApp.Image = global::opt.Properties.Resources.magnifier;
            this.buttonChooseExternalApp.Location = new System.Drawing.Point(745, 155);
            this.buttonChooseExternalApp.Name = "buttonChooseExternalApp";
            this.buttonChooseExternalApp.Size = new System.Drawing.Size(24, 23);
            this.buttonChooseExternalApp.TabIndex = 4;
            this.buttonChooseExternalApp.UseVisualStyleBackColor = true;
            this.buttonChooseExternalApp.Click += new System.EventHandler(this.buttonChooseExternalApp_Click);
            // 
            // radioManual
            // 
            this.radioManual.AutoSize = true;
            this.radioManual.Enabled = false;
            this.radioManual.Location = new System.Drawing.Point(46, 205);
            this.radioManual.Name = "radioManual";
            this.radioManual.Size = new System.Drawing.Size(457, 17);
            this.radioManual.TabIndex = 5;
            this.radioManual.Text = "Ввести значения критериев оптимальности и функциональных ограничений вручную";
            this.radioManual.UseVisualStyleBackColor = true;
            // 
            // dialogExternalApp
            // 
            this.dialogExternalApp.Filter = "Исполняемый файл Windows (*.exe)|*.exe|Все файлы (*.*)|*.*";
            this.dialogExternalApp.Title = "Выбрать внешнюю расчетную программу";
            // 
            // dialogExchangeFile
            // 
            this.dialogExchangeFile.Filter = "Файл модели (*.xml)|*.xml|Все файлы (*.*)|*.*";
            this.dialogExchangeFile.Title = "Выбрать файл для обмена данными";
            // 
            // RunCalculationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.buttonChooseExternalApp);
            this.Name = "RunCalculationForm";
            this.Text = "Выбор способа задания значений критериев и ограничений";
            this.Controls.SetChildIndex(this.btnExit, 0);
            this.Controls.SetChildIndex(this.btnPrevious, 0);
            this.Controls.SetChildIndex(this.btnNext, 0);
            this.Controls.SetChildIndex(this.panWorkspace, 0);
            this.Controls.SetChildIndex(this.buttonChooseExternalApp, 0);
            this.panWorkspace.ResumeLayout(false);
            this.panWorkspace.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RadioButton radioExternalApp;
        private System.Windows.Forms.RadioButton radioManual;
        private System.Windows.Forms.Button buttonChooseExchangeFile;
        private System.Windows.Forms.TextBox textExternalAppPath;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textExchangeFilePath;
        private System.Windows.Forms.Button buttonChooseExternalApp;
        private System.Windows.Forms.OpenFileDialog dialogExternalApp;
        private System.Windows.Forms.SaveFileDialog dialogExchangeFile;
    }
}