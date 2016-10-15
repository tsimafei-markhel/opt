namespace opt.UI.Forms
{
    partial class Form25
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
            this.nudExperimentsCount = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.rbnManual = new System.Windows.Forms.RadioButton();
            this.rbnAutomatic = new System.Windows.Forms.RadioButton();
            this.dlgSaveModel = new System.Windows.Forms.SaveFileDialog();
            this.btnSaveMatrix = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnPrevious = new System.Windows.Forms.Button();
            this.panWorkspace.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudExperimentsCount)).BeginInit();
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
            // panWorkspace
            // 
            this.panWorkspace.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panWorkspace.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panWorkspace.BackColor = System.Drawing.SystemColors.Control;
            this.panWorkspace.Controls.Add(this.nudExperimentsCount);
            this.panWorkspace.Controls.Add(this.label1);
            this.panWorkspace.Controls.Add(this.rbnManual);
            this.panWorkspace.Controls.Add(this.rbnAutomatic);
            this.panWorkspace.Location = new System.Drawing.Point(12, 12);
            this.panWorkspace.Name = "panWorkspace";
            this.panWorkspace.Size = new System.Drawing.Size(768, 509);
            this.panWorkspace.TabIndex = 0;
            // 
            // nudExperimentsCount
            // 
            this.nudExperimentsCount.Location = new System.Drawing.Point(205, 46);
            this.nudExperimentsCount.Maximum = new decimal(new int[] {
            32768,
            0,
            0,
            0});
            this.nudExperimentsCount.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.nudExperimentsCount.Name = "nudExperimentsCount";
            this.nudExperimentsCount.Size = new System.Drawing.Size(65, 20);
            this.nudExperimentsCount.TabIndex = 0;
            this.nudExperimentsCount.Value = new decimal(new int[] {
            25,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(48, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(151, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Количество экспериментов:";
            // 
            // rbnManual
            // 
            this.rbnManual.AutoSize = true;
            this.rbnManual.Location = new System.Drawing.Point(51, 124);
            this.rbnManual.Name = "rbnManual";
            this.rbnManual.Size = new System.Drawing.Size(309, 17);
            this.rbnManual.TabIndex = 2;
            this.rbnManual.Text = "Ввести значения оптимизируемых параметров вручную";
            this.rbnManual.UseVisualStyleBackColor = true;
            // 
            // rbnAutomatic
            // 
            this.rbnAutomatic.AutoSize = true;
            this.rbnAutomatic.Checked = true;
            this.rbnAutomatic.Location = new System.Drawing.Point(51, 92);
            this.rbnAutomatic.Name = "rbnAutomatic";
            this.rbnAutomatic.Size = new System.Drawing.Size(386, 17);
            this.rbnAutomatic.TabIndex = 1;
            this.rbnAutomatic.TabStop = true;
            this.rbnAutomatic.Text = "Сгенерировать значения оптимизируемых параметров автоматически";
            this.rbnAutomatic.UseVisualStyleBackColor = true;
            // 
            // dlgSaveModel
            // 
            this.dlgSaveModel.Filter = "Файл матрицы решений (*.xml)|*.xml|Все файлы (*.*)|*.*";
            this.dlgSaveModel.Title = "Сохранить матрицу решений в файл...";
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
            // Form25
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 566);
            this.Controls.Add(this.btnSaveMatrix);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnPrevious);
            this.Controls.Add(this.panWorkspace);
            this.MinimumSize = new System.Drawing.Size(300, 300);
            this.Name = "Form25";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Способ задания значений оптимизируемых параметров";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form25_FormClosing);
            this.panWorkspace.ResumeLayout(false);
            this.panWorkspace.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudExperimentsCount)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnPrevious;
        private System.Windows.Forms.Panel panWorkspace;
        private System.Windows.Forms.RadioButton rbnManual;
        private System.Windows.Forms.RadioButton rbnAutomatic;
        private System.Windows.Forms.NumericUpDown nudExperimentsCount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSaveMatrix;
        private System.Windows.Forms.SaveFileDialog dlgSaveModel;
    }
}