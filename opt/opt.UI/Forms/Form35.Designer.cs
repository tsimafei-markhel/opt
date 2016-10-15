namespace opt.UI.Forms
{
    partial class Form35
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
            this.dlgSaveModel = new System.Windows.Forms.SaveFileDialog();
            this.panWorkspace = new System.Windows.Forms.Panel();
            this.btnChooseModelExecutable = new System.Windows.Forms.Button();
            this.txtModelExecutable = new opt.UI.Helpers.PathTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lblNCalcVersion = new System.Windows.Forms.Label();
            this.pbExpressionEvaluateOption = new System.Windows.Forms.PictureBox();
            this.lblNCalcLink = new System.Windows.Forms.LinkLabel();
            this.lblNCalc = new System.Windows.Forms.Label();
            this.rbnExpressionsEvaluate = new System.Windows.Forms.RadioButton();
            this.btnChooseExternalApp = new System.Windows.Forms.Button();
            this.txtExternalApplicationExecutable = new opt.UI.Helpers.PathTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnChooseDataFile = new System.Windows.Forms.Button();
            this.txtDataFileName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.rbnManual = new System.Windows.Forms.RadioButton();
            this.rbnAutomatic = new System.Windows.Forms.RadioButton();
            this.dlgDataFile = new System.Windows.Forms.SaveFileDialog();
            this.dlgExternalApp = new System.Windows.Forms.OpenFileDialog();
            this.ttpExpressionEvaluationOption = new System.Windows.Forms.ToolTip(this.components);
            this.btnSaveMatrix = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnPrevious = new System.Windows.Forms.Button();
            this.panWorkspace.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbExpressionEvaluateOption)).BeginInit();
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
            // dlgSaveModel
            // 
            this.dlgSaveModel.Filter = "Файл матрицы решений (*.xml)|*.xml|Все файлы (*.*)|*.*";
            this.dlgSaveModel.Title = "Сохранить матрицу решений в файл...";
            // 
            // panWorkspace
            // 
            this.panWorkspace.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panWorkspace.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panWorkspace.BackColor = System.Drawing.SystemColors.Control;
            this.panWorkspace.Controls.Add(this.btnChooseModelExecutable);
            this.panWorkspace.Controls.Add(this.txtModelExecutable);
            this.panWorkspace.Controls.Add(this.label3);
            this.panWorkspace.Controls.Add(this.lblNCalcVersion);
            this.panWorkspace.Controls.Add(this.pbExpressionEvaluateOption);
            this.panWorkspace.Controls.Add(this.lblNCalcLink);
            this.panWorkspace.Controls.Add(this.lblNCalc);
            this.panWorkspace.Controls.Add(this.rbnExpressionsEvaluate);
            this.panWorkspace.Controls.Add(this.btnChooseExternalApp);
            this.panWorkspace.Controls.Add(this.txtExternalApplicationExecutable);
            this.panWorkspace.Controls.Add(this.label2);
            this.panWorkspace.Controls.Add(this.btnChooseDataFile);
            this.panWorkspace.Controls.Add(this.txtDataFileName);
            this.panWorkspace.Controls.Add(this.label1);
            this.panWorkspace.Controls.Add(this.rbnManual);
            this.panWorkspace.Controls.Add(this.rbnAutomatic);
            this.panWorkspace.Location = new System.Drawing.Point(12, 12);
            this.panWorkspace.Name = "panWorkspace";
            this.panWorkspace.Size = new System.Drawing.Size(768, 509);
            this.panWorkspace.TabIndex = 0;
            // 
            // btnChooseModelExecutable
            // 
            this.btnChooseModelExecutable.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnChooseModelExecutable.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnChooseModelExecutable.Image = global::opt.UI.Properties.Resources.browse;
            this.btnChooseModelExecutable.Location = new System.Drawing.Point(741, 99);
            this.btnChooseModelExecutable.Name = "btnChooseModelExecutable";
            this.btnChooseModelExecutable.Size = new System.Drawing.Size(24, 24);
            this.btnChooseModelExecutable.TabIndex = 6;
            this.btnChooseModelExecutable.UseVisualStyleBackColor = true;
            this.btnChooseModelExecutable.Visible = false;
            this.btnChooseModelExecutable.Click += new System.EventHandler(this.btnChooseModelExecutable_Click);
            // 
            // txtModelExecutable
            // 
            this.txtModelExecutable.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtModelExecutable.Location = new System.Drawing.Point(106, 101);
            this.txtModelExecutable.Name = "txtModelExecutable";
            this.txtModelExecutable.Size = new System.Drawing.Size(629, 20);
            this.txtModelExecutable.TabIndex = 5;
            this.txtModelExecutable.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(103, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(365, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Исполняемый файл модели, который будет использован для расчета:";
            this.label3.Visible = false;
            // 
            // lblNCalcVersion
            // 
            this.lblNCalcVersion.AutoSize = true;
            this.lblNCalcVersion.Enabled = false;
            this.lblNCalcVersion.Location = new System.Drawing.Point(341, 263);
            this.lblNCalcVersion.Name = "lblNCalcVersion";
            this.lblNCalcVersion.Size = new System.Drawing.Size(31, 13);
            this.lblNCalcVersion.TabIndex = 10;
            this.lblNCalcVersion.Text = "1.3.8";
            // 
            // pbExpressionEvaluateOption
            // 
            this.pbExpressionEvaluateOption.Image = global::opt.UI.Properties.Resources.information;
            this.pbExpressionEvaluateOption.Location = new System.Drawing.Point(660, 239);
            this.pbExpressionEvaluateOption.Name = "pbExpressionEvaluateOption";
            this.pbExpressionEvaluateOption.Size = new System.Drawing.Size(16, 16);
            this.pbExpressionEvaluateOption.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbExpressionEvaluateOption.TabIndex = 9;
            this.pbExpressionEvaluateOption.TabStop = false;
            this.pbExpressionEvaluateOption.Visible = false;
            // 
            // lblNCalcLink
            // 
            this.lblNCalcLink.AutoSize = true;
            this.lblNCalcLink.Enabled = false;
            this.lblNCalcLink.Location = new System.Drawing.Point(307, 263);
            this.lblNCalcLink.Name = "lblNCalcLink";
            this.lblNCalcLink.Size = new System.Drawing.Size(36, 13);
            this.lblNCalcLink.TabIndex = 9;
            this.lblNCalcLink.TabStop = true;
            this.lblNCalcLink.Text = "NCalc";
            this.lblNCalcLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblNCalcLink_LinkClicked);
            // 
            // lblNCalc
            // 
            this.lblNCalc.AutoSize = true;
            this.lblNCalc.Enabled = false;
            this.lblNCalc.Location = new System.Drawing.Point(103, 263);
            this.lblNCalc.Name = "lblNCalc";
            this.lblNCalc.Size = new System.Drawing.Size(206, 13);
            this.lblNCalc.TabIndex = 7;
            this.lblNCalc.Text = "Для расчета используется библиотека";
            // 
            // rbnExpressionsEvaluate
            // 
            this.rbnExpressionsEvaluate.AutoSize = true;
            this.rbnExpressionsEvaluate.Location = new System.Drawing.Point(46, 238);
            this.rbnExpressionsEvaluate.Name = "rbnExpressionsEvaluate";
            this.rbnExpressionsEvaluate.Size = new System.Drawing.Size(608, 17);
            this.rbnExpressionsEvaluate.TabIndex = 8;
            this.rbnExpressionsEvaluate.Text = "Рассчитать значения критериев оптимальности и функциональных ограничений на основ" +
    "е введенных выражений";
            this.rbnExpressionsEvaluate.UseVisualStyleBackColor = true;
            this.rbnExpressionsEvaluate.CheckedChanged += new System.EventHandler(this.rbnExpressionsEvaluate_CheckedChanged);
            // 
            // btnChooseExternalApp
            // 
            this.btnChooseExternalApp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnChooseExternalApp.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnChooseExternalApp.Image = global::opt.UI.Properties.Resources.browse;
            this.btnChooseExternalApp.Location = new System.Drawing.Point(741, 143);
            this.btnChooseExternalApp.Name = "btnChooseExternalApp";
            this.btnChooseExternalApp.Size = new System.Drawing.Size(24, 24);
            this.btnChooseExternalApp.TabIndex = 4;
            this.btnChooseExternalApp.UseVisualStyleBackColor = true;
            this.btnChooseExternalApp.Click += new System.EventHandler(this.btnChooseExternalApp_Click);
            // 
            // txtExternalApplicationExecutable
            // 
            this.txtExternalApplicationExecutable.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtExternalApplicationExecutable.Location = new System.Drawing.Point(106, 145);
            this.txtExternalApplicationExecutable.Name = "txtExternalApplicationExecutable";
            this.txtExternalApplicationExecutable.Size = new System.Drawing.Size(629, 20);
            this.txtExternalApplicationExecutable.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(103, 129);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(228, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Исполняемый файл расчетной программы:";
            // 
            // btnChooseDataFile
            // 
            this.btnChooseDataFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnChooseDataFile.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnChooseDataFile.Image = global::opt.UI.Properties.Resources.browse;
            this.btnChooseDataFile.Location = new System.Drawing.Point(741, 99);
            this.btnChooseDataFile.Name = "btnChooseDataFile";
            this.btnChooseDataFile.Size = new System.Drawing.Size(24, 24);
            this.btnChooseDataFile.TabIndex = 2;
            this.btnChooseDataFile.UseVisualStyleBackColor = true;
            this.btnChooseDataFile.Click += new System.EventHandler(this.btnChooseDataFile_Click);
            // 
            // txtDataFileName
            // 
            this.txtDataFileName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDataFileName.Location = new System.Drawing.Point(106, 101);
            this.txtDataFileName.Name = "txtDataFileName";
            this.txtDataFileName.Size = new System.Drawing.Size(629, 20);
            this.txtDataFileName.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(103, 85);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(417, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Файл для обмена данными между этим приложением и расчетной программой:";
            // 
            // rbnManual
            // 
            this.rbnManual.AutoSize = true;
            this.rbnManual.Location = new System.Drawing.Point(46, 205);
            this.rbnManual.Name = "rbnManual";
            this.rbnManual.Size = new System.Drawing.Size(457, 17);
            this.rbnManual.TabIndex = 7;
            this.rbnManual.Text = "Ввести значения критериев оптимальности и функциональных ограничений вручную";
            this.rbnManual.UseVisualStyleBackColor = true;
            // 
            // rbnAutomatic
            // 
            this.rbnAutomatic.AutoSize = true;
            this.rbnAutomatic.Checked = true;
            this.rbnAutomatic.Location = new System.Drawing.Point(46, 50);
            this.rbnAutomatic.Name = "rbnAutomatic";
            this.rbnAutomatic.Size = new System.Drawing.Size(515, 17);
            this.rbnAutomatic.TabIndex = 0;
            this.rbnAutomatic.TabStop = true;
            this.rbnAutomatic.Text = "Рассчитать значения критериев оптимальности и функциональных ограничений автомати" +
    "чески";
            this.rbnAutomatic.UseVisualStyleBackColor = true;
            this.rbnAutomatic.CheckedChanged += new System.EventHandler(this.rbnAutomatic_CheckedChanged);
            // 
            // dlgDataFile
            // 
            this.dlgDataFile.Filter = "Файл матрицы решений (*.xml)|*.xml|Все файлы (*.*)|*.*";
            this.dlgDataFile.Title = "Создать файл для обмена данными";
            // 
            // dlgExternalApp
            // 
            this.dlgExternalApp.Filter = "Исполняемый файл Windows (*.exe)|*.exe";
            this.dlgExternalApp.Title = "Выбрать внешнюю расчетную программу";
            // 
            // ttpExpressionEvaluationOption
            // 
            this.ttpExpressionEvaluationOption.AutoPopDelay = 10000;
            this.ttpExpressionEvaluationOption.InitialDelay = 500;
            this.ttpExpressionEvaluationOption.ReshowDelay = 100;
            this.ttpExpressionEvaluationOption.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.ttpExpressionEvaluationOption.ToolTipTitle = "Этот вариант недоступен";
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
            // btnPrevious
            // 
            this.btnPrevious.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrevious.Image = global::opt.UI.Properties.Resources.previous;
            this.btnPrevious.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPrevious.Location = new System.Drawing.Point(624, 527);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(75, 27);
            this.btnPrevious.TabIndex = 1;
            this.btnPrevious.Text = "Назад";
            this.btnPrevious.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPrevious.UseVisualStyleBackColor = true;
            this.btnPrevious.Click += new System.EventHandler(this.btnPrevious_Click);
            // 
            // Form35
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 566);
            this.Controls.Add(this.btnSaveMatrix);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.panWorkspace);
            this.Controls.Add(this.btnPrevious);
            this.MinimumSize = new System.Drawing.Size(300, 300);
            this.Name = "Form35";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Способ задания значений критериев оптимальности и функциональных ограничений";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form35_FormClosing);
            this.panWorkspace.ResumeLayout(false);
            this.panWorkspace.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbExpressionEvaluateOption)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSaveMatrix;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.SaveFileDialog dlgSaveModel;
        private System.Windows.Forms.Panel panWorkspace;
        private System.Windows.Forms.RadioButton rbnManual;
        private System.Windows.Forms.RadioButton rbnAutomatic;
        private System.Windows.Forms.Button btnPrevious;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnChooseExternalApp;
        private opt.UI.Helpers.PathTextBox txtExternalApplicationExecutable;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnChooseDataFile;
        private System.Windows.Forms.TextBox txtDataFileName;
        private System.Windows.Forms.SaveFileDialog dlgDataFile;
        private System.Windows.Forms.OpenFileDialog dlgExternalApp;
        private System.Windows.Forms.RadioButton rbnExpressionsEvaluate;
        private System.Windows.Forms.LinkLabel lblNCalcLink;
        private System.Windows.Forms.Label lblNCalc;
        private System.Windows.Forms.ToolTip ttpExpressionEvaluationOption;
        private System.Windows.Forms.PictureBox pbExpressionEvaluateOption;
        private System.Windows.Forms.Label lblNCalcVersion;
        private System.Windows.Forms.Button btnChooseModelExecutable;
        private opt.UI.Helpers.PathTextBox txtModelExecutable;
        private System.Windows.Forms.Label label3;
    }
}