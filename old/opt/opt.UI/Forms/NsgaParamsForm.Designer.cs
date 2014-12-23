namespace opt.UI.Forms
{
    partial class NsgaParamsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NsgaParamsForm));
            this.btnExit = new System.Windows.Forms.Button();
            this.btnPrevious = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.panWorkspace = new System.Windows.Forms.Panel();
            this.chbShowProcess = new System.Windows.Forms.CheckBox();
            this.label12 = new System.Windows.Forms.Label();
            this.btnChooseFile = new System.Windows.Forms.Button();
            this.txtExternalAppPath = new opt.UI.Helpers.PathTextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.nudMaxGenerationsNumber = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.txtDescendantsCount = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.nudSelectionLimit = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtInitialGenerationCount = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dlgExternalApp = new System.Windows.Forms.OpenFileDialog();
            this.panWorkspace.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaxGenerationsNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSelectionLimit)).BeginInit();
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
            // panWorkspace
            // 
            this.panWorkspace.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panWorkspace.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panWorkspace.BackColor = System.Drawing.SystemColors.Control;
            this.panWorkspace.Controls.Add(this.chbShowProcess);
            this.panWorkspace.Controls.Add(this.label12);
            this.panWorkspace.Controls.Add(this.btnChooseFile);
            this.panWorkspace.Controls.Add(this.txtExternalAppPath);
            this.panWorkspace.Controls.Add(this.label11);
            this.panWorkspace.Controls.Add(this.label9);
            this.panWorkspace.Controls.Add(this.nudMaxGenerationsNumber);
            this.panWorkspace.Controls.Add(this.label10);
            this.panWorkspace.Controls.Add(this.txtDescendantsCount);
            this.panWorkspace.Controls.Add(this.label6);
            this.panWorkspace.Controls.Add(this.label4);
            this.panWorkspace.Controls.Add(this.nudSelectionLimit);
            this.panWorkspace.Controls.Add(this.label3);
            this.panWorkspace.Controls.Add(this.label2);
            this.panWorkspace.Controls.Add(this.txtInitialGenerationCount);
            this.panWorkspace.Controls.Add(this.label1);
            this.panWorkspace.Location = new System.Drawing.Point(12, 12);
            this.panWorkspace.Name = "panWorkspace";
            this.panWorkspace.Size = new System.Drawing.Size(768, 509);
            this.panWorkspace.TabIndex = 0;
            // 
            // chbShowProcess
            // 
            this.chbShowProcess.AutoSize = true;
            this.chbShowProcess.Checked = true;
            this.chbShowProcess.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbShowProcess.Location = new System.Drawing.Point(19, 202);
            this.chbShowProcess.Name = "chbShowProcess";
            this.chbShowProcess.Size = new System.Drawing.Size(220, 17);
            this.chbShowProcess.TabIndex = 7;
            this.chbShowProcess.Text = "Показывать процесс поиска решения";
            this.chbShowProcess.UseVisualStyleBackColor = true;
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label12.Location = new System.Drawing.Point(16, 261);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(749, 217);
            this.label12.TabIndex = 0;
            this.label12.Text = resources.GetString("label12.Text");
            // 
            // btnChooseFile
            // 
            this.btnChooseFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnChooseFile.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnChooseFile.Image = global::opt.UI.Properties.Resources.browse;
            this.btnChooseFile.Location = new System.Drawing.Point(741, 162);
            this.btnChooseFile.Name = "btnChooseFile";
            this.btnChooseFile.Size = new System.Drawing.Size(24, 24);
            this.btnChooseFile.TabIndex = 6;
            this.btnChooseFile.UseVisualStyleBackColor = true;
            this.btnChooseFile.Click += new System.EventHandler(this.btnChooseFile_Click);
            // 
            // txtExternalAppPath
            // 
            this.txtExternalAppPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtExternalAppPath.Location = new System.Drawing.Point(47, 164);
            this.txtExternalAppPath.Name = "txtExternalAppPath";
            this.txtExternalAppPath.Size = new System.Drawing.Size(688, 20);
            this.txtExternalAppPath.TabIndex = 5;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(16, 143);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(211, 13);
            this.label11.TabIndex = 15;
            this.label11.Text = "Путь ко внешней расчетной программе:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.Gray;
            this.label9.Location = new System.Drawing.Point(355, 110);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(47, 13);
            this.label9.TabIndex = 14;
            this.label9.Text = "(min = 1)";
            // 
            // nudMaxGenerationsNumber
            // 
            this.nudMaxGenerationsNumber.Location = new System.Drawing.Point(270, 108);
            this.nudMaxGenerationsNumber.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudMaxGenerationsNumber.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudMaxGenerationsNumber.Name = "nudMaxGenerationsNumber";
            this.nudMaxGenerationsNumber.Size = new System.Drawing.Size(79, 20);
            this.nudMaxGenerationsNumber.TabIndex = 4;
            this.nudMaxGenerationsNumber.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(16, 110);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(197, 13);
            this.label10.TabIndex = 13;
            this.label10.Text = "Количество поколений до остановки:";
            // 
            // txtDescendantsCount
            // 
            this.txtDescendantsCount.Location = new System.Drawing.Point(270, 77);
            this.txtDescendantsCount.Name = "txtDescendantsCount";
            this.txtDescendantsCount.ReadOnly = true;
            this.txtDescendantsCount.Size = new System.Drawing.Size(79, 20);
            this.txtDescendantsCount.TabIndex = 2;
            this.txtDescendantsCount.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 80);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(197, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "Количество потомков у пары особей:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Gray;
            this.label4.Location = new System.Drawing.Point(355, 49);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(303, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "(min = 2; max = Количество особей в начальной популяции)";
            // 
            // nudSelectionLimit
            // 
            this.nudSelectionLimit.Location = new System.Drawing.Point(270, 47);
            this.nudSelectionLimit.Name = "nudSelectionLimit";
            this.nudSelectionLimit.Size = new System.Drawing.Size(79, 20);
            this.nudSelectionLimit.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(248, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Количество особей, отбираемых при селекции:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Gray;
            this.label2.Location = new System.Drawing.Point(355, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(288, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "(Равно количеству экспериментов в матрице решений)";
            // 
            // txtInitialGenerationCount
            // 
            this.txtInitialGenerationCount.Location = new System.Drawing.Point(270, 16);
            this.txtInitialGenerationCount.Name = "txtInitialGenerationCount";
            this.txtInitialGenerationCount.ReadOnly = true;
            this.txtInitialGenerationCount.Size = new System.Drawing.Size(79, 20);
            this.txtInitialGenerationCount.TabIndex = 0;
            this.txtInitialGenerationCount.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(229, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Количество особей в начальной популяции:";
            // 
            // dlgExternalApp
            // 
            this.dlgExternalApp.Filter = "Исполняемый файл Windows (*.exe)|*.exe";
            this.dlgExternalApp.Title = "Выбрать внешнюю расчетную программу";
            // 
            // NsgaParamsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 566);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnPrevious);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.panWorkspace);
            this.Name = "NsgaParamsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Параметры генетического алгоритма";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AdditiveGAParamsForm_FormClosing);
            this.panWorkspace.ResumeLayout(false);
            this.panWorkspace.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaxGenerationsNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSelectionLimit)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnPrevious;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Panel panWorkspace;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtInitialGenerationCount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown nudSelectionLimit;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDescendantsCount;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown nudMaxGenerationsNumber;
        private System.Windows.Forms.Label label10;
        private opt.UI.Helpers.PathTextBox txtExternalAppPath;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnChooseFile;
        private System.Windows.Forms.CheckBox chbShowProcess;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.OpenFileDialog dlgExternalApp;
    }
}