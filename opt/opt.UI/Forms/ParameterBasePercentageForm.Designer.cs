namespace opt.UI.Forms
{
    partial class ParameterBasePercentageForm
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
            this.nudParameterDeviationPercentageValue = new System.Windows.Forms.NumericUpDown();
            this.nudParameterBaseValue = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.lblMinValue = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblMaxValue = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nudParameterDeviationPercentageValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudParameterBaseValue)).BeginInit();
            this.SuspendLayout();
            // 
            // nudParameterDeviationPercentageValue
            // 
            this.nudParameterDeviationPercentageValue.DecimalPlaces = 2;
            this.nudParameterDeviationPercentageValue.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.nudParameterDeviationPercentageValue.Location = new System.Drawing.Point(158, 43);
            this.nudParameterDeviationPercentageValue.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudParameterDeviationPercentageValue.Name = "nudParameterDeviationPercentageValue";
            this.nudParameterDeviationPercentageValue.Size = new System.Drawing.Size(80, 20);
            this.nudParameterDeviationPercentageValue.TabIndex = 1;
            this.nudParameterDeviationPercentageValue.ValueChanged += new System.EventHandler(this.nudParameterBaseValue_ValueChanged);
            // 
            // nudParameterBaseValue
            // 
            this.nudParameterBaseValue.Location = new System.Drawing.Point(158, 12);
            this.nudParameterBaseValue.Maximum = new decimal(new int[] {
            -1,
            -1,
            -1,
            0});
            this.nudParameterBaseValue.Minimum = new decimal(new int[] {
            -1,
            -1,
            -1,
            -2147483648});
            this.nudParameterBaseValue.Name = "nudParameterBaseValue";
            this.nudParameterBaseValue.Size = new System.Drawing.Size(80, 20);
            this.nudParameterBaseValue.TabIndex = 0;
            this.nudParameterBaseValue.ValueChanged += new System.EventHandler(this.nudParameterBaseValue_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 45);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(94, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Отклонение, ± %:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Базовое значение:";
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Image = global::opt.UI.Properties.Resources.cancel;
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(137, 125);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(101, 30);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Image = global::opt.UI.Properties.Resources.accept;
            this.btnOK.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOK.Location = new System.Drawing.Point(30, 125);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(101, 30);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // lblMinValue
            // 
            this.lblMinValue.AutoSize = true;
            this.lblMinValue.Location = new System.Drawing.Point(155, 76);
            this.lblMinValue.Name = "lblMinValue";
            this.lblMinValue.Size = new System.Drawing.Size(13, 13);
            this.lblMinValue.TabIndex = 8;
            this.lblMinValue.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(131, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Минимальное значение:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 99);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(137, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Максимальное значение:";
            // 
            // lblMaxValue
            // 
            this.lblMaxValue.AutoSize = true;
            this.lblMaxValue.Location = new System.Drawing.Point(155, 99);
            this.lblMaxValue.Name = "lblMaxValue";
            this.lblMaxValue.Size = new System.Drawing.Size(13, 13);
            this.lblMaxValue.TabIndex = 10;
            this.lblMaxValue.Text = "0";
            // 
            // ParameterBasePercentageForm
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(251, 168);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblMaxValue);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblMinValue);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.nudParameterDeviationPercentageValue);
            this.Controls.Add(this.nudParameterBaseValue);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ParameterBasePercentageForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            ((System.ComponentModel.ISupportInitialize)(this.nudParameterDeviationPercentageValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudParameterBaseValue)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown nudParameterDeviationPercentageValue;
        private System.Windows.Forms.NumericUpDown nudParameterBaseValue;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label lblMinValue;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblMaxValue;
    }
}