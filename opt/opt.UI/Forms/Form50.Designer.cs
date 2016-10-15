namespace opt.UI.Forms
{
    partial class Form50
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
            this.rbnNsga2 = new System.Windows.Forms.RadioButton();
            this.grpCriteriaConvolution = new System.Windows.Forms.GroupBox();
            this.rbnSuccessiveConcessionsMethod = new System.Windows.Forms.RadioButton();
            this.rbnFlexiblePriority = new System.Windows.Forms.RadioButton();
            this.rbnMainCriterionMethod = new System.Windows.Forms.RadioButton();
            this.grpFormalMethods = new System.Windows.Forms.GroupBox();
            this.rbnMaximalPower = new System.Windows.Forms.RadioButton();
            this.rbnBinaryRelations = new System.Windows.Forms.RadioButton();
            this.rbnIdealPoint = new System.Windows.Forms.RadioButton();
            this.rbnCriteriaConvolution = new System.Windows.Forms.RadioButton();
            this.rbnFormalMethods = new System.Windows.Forms.RadioButton();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnPrevious = new System.Windows.Forms.Button();
            this.btnShowMatrixForm = new System.Windows.Forms.Button();
            this.panWorkspace.SuspendLayout();
            this.grpCriteriaConvolution.SuspendLayout();
            this.grpFormalMethods.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnExit.Location = new System.Drawing.Point(12, 523);
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
            this.panWorkspace.Controls.Add(this.rbnNsga2);
            this.panWorkspace.Controls.Add(this.grpCriteriaConvolution);
            this.panWorkspace.Controls.Add(this.grpFormalMethods);
            this.panWorkspace.Controls.Add(this.rbnCriteriaConvolution);
            this.panWorkspace.Controls.Add(this.rbnFormalMethods);
            this.panWorkspace.Location = new System.Drawing.Point(12, 12);
            this.panWorkspace.Name = "panWorkspace";
            this.panWorkspace.Size = new System.Drawing.Size(760, 505);
            this.panWorkspace.TabIndex = 0;
            // 
            // rbnNsga2
            // 
            this.rbnNsga2.AutoSize = true;
            this.rbnNsga2.Location = new System.Drawing.Point(41, 368);
            this.rbnNsga2.Name = "rbnNsga2";
            this.rbnNsga2.Size = new System.Drawing.Size(375, 17);
            this.rbnNsga2.TabIndex = 4;
            this.rbnNsga2.TabStop = true;
            this.rbnNsga2.Text = "Генетический алгоритм многокритериальной оптимизации (NSGA-II)";
            this.rbnNsga2.UseVisualStyleBackColor = true;
            // 
            // grpCriteriaConvolution
            // 
            this.grpCriteriaConvolution.Controls.Add(this.rbnSuccessiveConcessionsMethod);
            this.grpCriteriaConvolution.Controls.Add(this.rbnFlexiblePriority);
            this.grpCriteriaConvolution.Controls.Add(this.rbnMainCriterionMethod);
            this.grpCriteriaConvolution.Enabled = false;
            this.grpCriteriaConvolution.Location = new System.Drawing.Point(60, 221);
            this.grpCriteriaConvolution.Name = "grpCriteriaConvolution";
            this.grpCriteriaConvolution.Size = new System.Drawing.Size(416, 126);
            this.grpCriteriaConvolution.TabIndex = 3;
            this.grpCriteriaConvolution.TabStop = false;
            // 
            // rbnSuccessiveConcessionsMethod
            // 
            this.rbnSuccessiveConcessionsMethod.AutoSize = true;
            this.rbnSuccessiveConcessionsMethod.Location = new System.Drawing.Point(22, 86);
            this.rbnSuccessiveConcessionsMethod.Name = "rbnSuccessiveConcessionsMethod";
            this.rbnSuccessiveConcessionsMethod.Size = new System.Drawing.Size(198, 17);
            this.rbnSuccessiveConcessionsMethod.TabIndex = 2;
            this.rbnSuccessiveConcessionsMethod.Text = "Метод последовательных уступок";
            this.rbnSuccessiveConcessionsMethod.UseVisualStyleBackColor = true;
            // 
            // rbnFlexiblePriority
            // 
            this.rbnFlexiblePriority.AutoSize = true;
            this.rbnFlexiblePriority.Checked = true;
            this.rbnFlexiblePriority.Location = new System.Drawing.Point(22, 26);
            this.rbnFlexiblePriority.Name = "rbnFlexiblePriority";
            this.rbnFlexiblePriority.Size = new System.Drawing.Size(265, 17);
            this.rbnFlexiblePriority.TabIndex = 0;
            this.rbnFlexiblePriority.TabStop = true;
            this.rbnFlexiblePriority.Text = "Задать весовые коэффициенты для критериев";
            this.rbnFlexiblePriority.UseVisualStyleBackColor = true;
            // 
            // rbnMainCriterionMethod
            // 
            this.rbnMainCriterionMethod.AutoSize = true;
            this.rbnMainCriterionMethod.Location = new System.Drawing.Point(22, 56);
            this.rbnMainCriterionMethod.Name = "rbnMainCriterionMethod";
            this.rbnMainCriterionMethod.Size = new System.Drawing.Size(156, 17);
            this.rbnMainCriterionMethod.TabIndex = 1;
            this.rbnMainCriterionMethod.Text = "Метод главного критерия";
            this.rbnMainCriterionMethod.UseVisualStyleBackColor = true;
            // 
            // grpFormalMethods
            // 
            this.grpFormalMethods.Controls.Add(this.rbnMaximalPower);
            this.grpFormalMethods.Controls.Add(this.rbnBinaryRelations);
            this.grpFormalMethods.Controls.Add(this.rbnIdealPoint);
            this.grpFormalMethods.Location = new System.Drawing.Point(60, 66);
            this.grpFormalMethods.Name = "grpFormalMethods";
            this.grpFormalMethods.Size = new System.Drawing.Size(416, 113);
            this.grpFormalMethods.TabIndex = 1;
            this.grpFormalMethods.TabStop = false;
            // 
            // rbnMaximalPower
            // 
            this.rbnMaximalPower.AutoSize = true;
            this.rbnMaximalPower.Location = new System.Drawing.Point(22, 79);
            this.rbnMaximalPower.Name = "rbnMaximalPower";
            this.rbnMaximalPower.Size = new System.Drawing.Size(239, 17);
            this.rbnMaximalPower.TabIndex = 2;
            this.rbnMaximalPower.TabStop = true;
            this.rbnMaximalPower.Text = "Поиск точки с максимальной мощностью";
            this.rbnMaximalPower.UseVisualStyleBackColor = true;
            // 
            // rbnBinaryRelations
            // 
            this.rbnBinaryRelations.AutoSize = true;
            this.rbnBinaryRelations.Location = new System.Drawing.Point(22, 51);
            this.rbnBinaryRelations.Name = "rbnBinaryRelations";
            this.rbnBinaryRelations.Size = new System.Drawing.Size(167, 17);
            this.rbnBinaryRelations.TabIndex = 1;
            this.rbnBinaryRelations.Text = "Метод бинарных отношений";
            this.rbnBinaryRelations.UseVisualStyleBackColor = true;
            // 
            // rbnIdealPoint
            // 
            this.rbnIdealPoint.AutoSize = true;
            this.rbnIdealPoint.Checked = true;
            this.rbnIdealPoint.Location = new System.Drawing.Point(22, 23);
            this.rbnIdealPoint.Name = "rbnIdealPoint";
            this.rbnIdealPoint.Size = new System.Drawing.Size(303, 17);
            this.rbnIdealPoint.TabIndex = 0;
            this.rbnIdealPoint.TabStop = true;
            this.rbnIdealPoint.Text = "Поиск точки с минимальным удалением от идеальной";
            this.rbnIdealPoint.UseVisualStyleBackColor = true;
            // 
            // rbnCriteriaConvolution
            // 
            this.rbnCriteriaConvolution.AutoSize = true;
            this.rbnCriteriaConvolution.Location = new System.Drawing.Point(41, 198);
            this.rbnCriteriaConvolution.Name = "rbnCriteriaConvolution";
            this.rbnCriteriaConvolution.Size = new System.Drawing.Size(234, 17);
            this.rbnCriteriaConvolution.TabIndex = 3;
            this.rbnCriteriaConvolution.Text = "Информация о важности критериев есть";
            this.rbnCriteriaConvolution.UseVisualStyleBackColor = true;
            this.rbnCriteriaConvolution.CheckedChanged += new System.EventHandler(this.rbnCriteriaConvolution_CheckedChanged);
            // 
            // rbnFormalMethods
            // 
            this.rbnFormalMethods.AutoSize = true;
            this.rbnFormalMethods.Checked = true;
            this.rbnFormalMethods.Location = new System.Drawing.Point(41, 43);
            this.rbnFormalMethods.Name = "rbnFormalMethods";
            this.rbnFormalMethods.Size = new System.Drawing.Size(228, 17);
            this.rbnFormalMethods.TabIndex = 0;
            this.rbnFormalMethods.TabStop = true;
            this.rbnFormalMethods.Text = "Информации о важности критериев нет";
            this.rbnFormalMethods.UseVisualStyleBackColor = true;
            this.rbnFormalMethods.CheckedChanged += new System.EventHandler(this.rbnFormalMethods_CheckedChanged);
            // 
            // btnNext
            // 
            this.btnNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNext.Image = global::opt.UI.Properties.Resources.next;
            this.btnNext.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNext.Location = new System.Drawing.Point(697, 523);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(75, 27);
            this.btnNext.TabIndex = 3;
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
            this.btnPrevious.Location = new System.Drawing.Point(616, 523);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(75, 27);
            this.btnPrevious.TabIndex = 2;
            this.btnPrevious.Text = "Назад";
            this.btnPrevious.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPrevious.UseVisualStyleBackColor = true;
            this.btnPrevious.Click += new System.EventHandler(this.btnPrevious_Click);
            // 
            // btnShowMatrixForm
            // 
            this.btnShowMatrixForm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnShowMatrixForm.Image = global::opt.UI.Properties.Resources.table;
            this.btnShowMatrixForm.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnShowMatrixForm.Location = new System.Drawing.Point(443, 523);
            this.btnShowMatrixForm.Name = "btnShowMatrixForm";
            this.btnShowMatrixForm.Size = new System.Drawing.Size(124, 27);
            this.btnShowMatrixForm.TabIndex = 1;
            this.btnShowMatrixForm.Text = "Матрица решений";
            this.btnShowMatrixForm.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnShowMatrixForm.UseVisualStyleBackColor = true;
            this.btnShowMatrixForm.Click += new System.EventHandler(this.btnShowMatrixForm_Click);
            // 
            // Form50
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.btnShowMatrixForm);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnPrevious);
            this.Controls.Add(this.panWorkspace);
            this.MinimumSize = new System.Drawing.Size(500, 500);
            this.Name = "Form50";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Выбор схемы компромисса";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form50_FormClosing);
            this.panWorkspace.ResumeLayout(false);
            this.panWorkspace.PerformLayout();
            this.grpCriteriaConvolution.ResumeLayout(false);
            this.grpCriteriaConvolution.PerformLayout();
            this.grpFormalMethods.ResumeLayout(false);
            this.grpFormalMethods.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnPrevious;
        private System.Windows.Forms.Panel panWorkspace;
        private System.Windows.Forms.RadioButton rbnCriteriaConvolution;
        private System.Windows.Forms.RadioButton rbnFormalMethods;
        private System.Windows.Forms.Button btnShowMatrixForm;
        private System.Windows.Forms.GroupBox grpFormalMethods;
        private System.Windows.Forms.RadioButton rbnIdealPoint;
        private System.Windows.Forms.RadioButton rbnMaximalPower;
        private System.Windows.Forms.RadioButton rbnBinaryRelations;
        private System.Windows.Forms.GroupBox grpCriteriaConvolution;
        private System.Windows.Forms.RadioButton rbnFlexiblePriority;
        private System.Windows.Forms.RadioButton rbnMainCriterionMethod;
        private System.Windows.Forms.RadioButton rbnSuccessiveConcessionsMethod;
        private System.Windows.Forms.RadioButton rbnNsga2;
    }
}