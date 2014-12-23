using System;
namespace opt.UI.Forms
{
    partial class ParameterForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ParameterForm));
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
            this.pbVariableIdentifierInfo = new System.Windows.Forms.PictureBox();
            this.ttpVariableIdentifierInfo = new System.Windows.Forms.ToolTip(this.components);
            this.btnGetValuesUsingBaseAndPercentage = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nudParameterMinValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudParameterMaxValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbVariableIdentifierInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Название параметра *:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(155, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Идентификатор переменной:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 96);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(138, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Минимальное значение *:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(25, 127);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(144, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Максимальное значение *:";
            // 
            // txtParameterName
            // 
            this.txtParameterName.Location = new System.Drawing.Point(186, 32);
            this.txtParameterName.Name = "txtParameterName";
            this.txtParameterName.Size = new System.Drawing.Size(180, 20);
            this.txtParameterName.TabIndex = 0;
            // 
            // txtParameterVariableIdentifier
            // 
            this.txtParameterVariableIdentifier.Location = new System.Drawing.Point(186, 63);
            this.txtParameterVariableIdentifier.Name = "txtParameterVariableIdentifier";
            this.txtParameterVariableIdentifier.Size = new System.Drawing.Size(180, 20);
            this.txtParameterVariableIdentifier.TabIndex = 1;
            // 
            // nudParameterMinValue
            // 
            this.nudParameterMinValue.Location = new System.Drawing.Point(186, 94);
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
            this.nudParameterMaxValue.Location = new System.Drawing.Point(186, 125);
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
            this.btnOK.Image = global::opt.UI.Properties.Resources.accept;
            this.btnOK.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOK.Location = new System.Drawing.Point(158, 193);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(101, 30);
            this.btnOK.TabIndex = 5;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Image = global::opt.UI.Properties.Resources.cancel;
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(265, 193);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(101, 30);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label5
            // 
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label5.Location = new System.Drawing.Point(25, 193);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(127, 30);
            this.label5.TabIndex = 14;
            this.label5.Text = "* - обязательные для заполнения поля";
            // 
            // pbVariableIdentifierInfo
            // 
            this.pbVariableIdentifierInfo.Image = global::opt.UI.Properties.Resources.information;
            this.pbVariableIdentifierInfo.Location = new System.Drawing.Point(372, 65);
            this.pbVariableIdentifierInfo.Name = "pbVariableIdentifierInfo";
            this.pbVariableIdentifierInfo.Size = new System.Drawing.Size(16, 16);
            this.pbVariableIdentifierInfo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbVariableIdentifierInfo.TabIndex = 21;
            this.pbVariableIdentifierInfo.TabStop = false;
            this.ttpVariableIdentifierInfo.SetToolTip(this.pbVariableIdentifierInfo, resources.GetString("pbVariableIdentifierInfo.ToolTip"));
            // 
            // ttpVariableIdentifierInfo
            // 
            this.ttpVariableIdentifierInfo.AutoPopDelay = 10000;
            this.ttpVariableIdentifierInfo.InitialDelay = 500;
            this.ttpVariableIdentifierInfo.ReshowDelay = 100;
            this.ttpVariableIdentifierInfo.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.ttpVariableIdentifierInfo.ToolTipTitle = "Правила задания идентификатора переменной";
            // 
            // btnGetValuesUsingBaseAndPercentage
            // 
            this.btnGetValuesUsingBaseAndPercentage.Location = new System.Drawing.Point(272, 94);
            this.btnGetValuesUsingBaseAndPercentage.Name = "btnGetValuesUsingBaseAndPercentage";
            this.btnGetValuesUsingBaseAndPercentage.Size = new System.Drawing.Size(20, 20);
            this.btnGetValuesUsingBaseAndPercentage.TabIndex = 4;
            this.btnGetValuesUsingBaseAndPercentage.Text = "%";
            this.btnGetValuesUsingBaseAndPercentage.UseVisualStyleBackColor = true;
            this.btnGetValuesUsingBaseAndPercentage.Click += new System.EventHandler(this.btnGetValuesUsingBaseAndPercentage_Click);
            // 
            // ParameterForm
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(414, 244);
            this.Controls.Add(this.btnGetValuesUsingBaseAndPercentage);
            this.Controls.Add(this.pbVariableIdentifierInfo);
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
            this.Name = "ParameterForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)(this.nudParameterMinValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudParameterMaxValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbVariableIdentifierInfo)).EndInit();
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
        private System.Windows.Forms.PictureBox pbVariableIdentifierInfo;
        private System.Windows.Forms.ToolTip ttpVariableIdentifierInfo;
        private System.Windows.Forms.Button btnGetValuesUsingBaseAndPercentage;
    }
}