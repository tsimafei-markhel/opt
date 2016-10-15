using System;
namespace opt.UI
{
    partial class EditParameterForm
    {
        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtParameterName = new System.Windows.Forms.TextBox();
            this.txtParameterVariableIdentifier = new System.Windows.Forms.TextBox();
            this.nudParameterMinValue = new System.Windows.Forms.NumericUpDown();
            this.nudParameterMaxValue = new System.Windows.Forms.NumericUpDown();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nudParameterMinValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudParameterMaxValue)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Название параметра *:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(155, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Идентификатор переменной:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(138, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Минимальное значение *:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 107);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(144, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Максимальное значение *:";
            // 
            // txtParameterName
            // 
            this.txtParameterName.Location = new System.Drawing.Point(171, 12);
            this.txtParameterName.Name = "txtParameterName";
            this.txtParameterName.Size = new System.Drawing.Size(216, 20);
            this.txtParameterName.TabIndex = 0;
            // 
            // txtParameterVariableIdentifier
            // 
            this.txtParameterVariableIdentifier.Location = new System.Drawing.Point(171, 43);
            this.txtParameterVariableIdentifier.Name = "txtParameterVariableIdentifier";
            this.txtParameterVariableIdentifier.Size = new System.Drawing.Size(216, 20);
            this.txtParameterVariableIdentifier.TabIndex = 1;
            // 
            // nudParameterMinValue
            // 
            this.nudParameterMinValue.Location = new System.Drawing.Point(171, 74);
            this.nudParameterMinValue.Maximum = new decimal(new int[] {
            -1,
            -1,
            -1,
            0});
            this.nudParameterMinValue.Minimum = new decimal(new int[] {
            -1,
            -1,
            -1,
            -2147483648});
            this.nudParameterMinValue.Name = "nudParameterMinValue";
            this.nudParameterMinValue.Size = new System.Drawing.Size(80, 20);
            this.nudParameterMinValue.TabIndex = 2;
            // 
            // nudParameterMaxValue
            // 
            this.nudParameterMaxValue.Location = new System.Drawing.Point(171, 105);
            this.nudParameterMaxValue.Maximum = new decimal(new int[] {
            -1,
            -1,
            -1,
            0});
            this.nudParameterMaxValue.Minimum = new decimal(new int[] {
            -1,
            -1,
            -1,
            -2147483648});
            this.nudParameterMaxValue.Name = "nudParameterMaxValue";
            this.nudParameterMaxValue.Size = new System.Drawing.Size(80, 20);
            this.nudParameterMaxValue.TabIndex = 3;
            // 
            // btnOK
            // 
            this.btnOK.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOK.Location = new System.Drawing.Point(231, 154);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 5;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(312, 154);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label5
            // 
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label5.Location = new System.Drawing.Point(12, 155);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(213, 23);
            this.label5.TabIndex = 14;
            this.label5.Text = "* - обязательные для заполнения поля";
            // 
            // EditParameterForm
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(399, 187);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.nudParameterMaxValue);
            this.Controls.Add(this.nudParameterMinValue);
            this.Controls.Add(this.txtParameterVariableIdentifier);
            this.Controls.Add(this.txtParameterName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditParameterForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)(this.nudParameterMinValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudParameterMaxValue)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtParameterName;
        private System.Windows.Forms.TextBox txtParameterVariableIdentifier;
        private System.Windows.Forms.NumericUpDown nudParameterMinValue;
        private System.Windows.Forms.NumericUpDown nudParameterMaxValue;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label5;
    }
}