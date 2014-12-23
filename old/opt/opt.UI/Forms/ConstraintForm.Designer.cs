namespace opt.UI.Forms
{
    partial class ConstraintForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConstraintForm));
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.nudConstraintValue = new System.Windows.Forms.NumericUpDown();
            this.txtConstraintVariableIdentifier = new System.Windows.Forms.TextBox();
            this.txtConstraintName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbConstraintSign = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtConstraintExpression = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.pbVariableIdentifierInfo = new System.Windows.Forms.PictureBox();
            this.ttpVariableIdentifierInfo = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.nudConstraintValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbVariableIdentifierInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Image = global::opt.UI.Properties.Resources.cancel;
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(413, 261);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(101, 30);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Image = global::opt.UI.Properties.Resources.accept;
            this.btnOK.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOK.Location = new System.Drawing.Point(306, 261);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(101, 30);
            this.btnOK.TabIndex = 5;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // nudConstraintValue
            // 
            this.nudConstraintValue.Location = new System.Drawing.Point(263, 119);
            this.nudConstraintValue.Maximum = new decimal(new int[] {
            -1,
            -1,
            -1,
            0});
            this.nudConstraintValue.Minimum = new decimal(new int[] {
            -1,
            -1,
            -1,
            -2147483648});
            this.nudConstraintValue.Name = "nudConstraintValue";
            this.nudConstraintValue.Size = new System.Drawing.Size(80, 20);
            this.nudConstraintValue.TabIndex = 3;
            // 
            // txtConstraintVariableIdentifier
            // 
            this.txtConstraintVariableIdentifier.Location = new System.Drawing.Point(263, 56);
            this.txtConstraintVariableIdentifier.Name = "txtConstraintVariableIdentifier";
            this.txtConstraintVariableIdentifier.Size = new System.Drawing.Size(251, 20);
            this.txtConstraintVariableIdentifier.TabIndex = 1;
            // 
            // txtConstraintName
            // 
            this.txtConstraintName.Location = new System.Drawing.Point(263, 25);
            this.txtConstraintName.Name = "txtConstraintName";
            this.txtConstraintName.Size = new System.Drawing.Size(251, 20);
            this.txtConstraintName.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(30, 121);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Значение *:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(30, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Знак *:";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(30, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(220, 30);
            this.label2.TabIndex = 9;
            this.label2.Text = "Идентификатор переменной функционального ограничения:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(227, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Название функционального ограничения *:";
            // 
            // cmbConstraintSign
            // 
            this.cmbConstraintSign.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbConstraintSign.FormattingEnabled = true;
            this.cmbConstraintSign.Location = new System.Drawing.Point(263, 87);
            this.cmbConstraintSign.Name = "cmbConstraintSign";
            this.cmbConstraintSign.Size = new System.Drawing.Size(80, 21);
            this.cmbConstraintSign.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label5.Location = new System.Drawing.Point(30, 261);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(199, 30);
            this.label5.TabIndex = 13;
            this.label5.Text = "* - обязательные для заполнения поля";
            // 
            // txtConstraintExpression
            // 
            this.txtConstraintExpression.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtConstraintExpression.Location = new System.Drawing.Point(263, 150);
            this.txtConstraintExpression.Multiline = true;
            this.txtConstraintExpression.Name = "txtConstraintExpression";
            this.txtConstraintExpression.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtConstraintExpression.Size = new System.Drawing.Size(251, 79);
            this.txtConstraintExpression.TabIndex = 4;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(30, 154);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 13);
            this.label6.TabIndex = 18;
            this.label6.Text = "Выражение:";
            // 
            // pbVariableIdentifierInfo
            // 
            this.pbVariableIdentifierInfo.Image = global::opt.UI.Properties.Resources.information;
            this.pbVariableIdentifierInfo.Location = new System.Drawing.Point(520, 58);
            this.pbVariableIdentifierInfo.Name = "pbVariableIdentifierInfo";
            this.pbVariableIdentifierInfo.Size = new System.Drawing.Size(16, 16);
            this.pbVariableIdentifierInfo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbVariableIdentifierInfo.TabIndex = 19;
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
            // ConstraintForm
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(557, 318);
            this.Controls.Add(this.pbVariableIdentifierInfo);
            this.Controls.Add(this.txtConstraintExpression);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cmbConstraintSign);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.nudConstraintValue);
            this.Controls.Add(this.txtConstraintVariableIdentifier);
            this.Controls.Add(this.txtConstraintName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ConstraintForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)(this.nudConstraintValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbVariableIdentifierInfo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.NumericUpDown nudConstraintValue;
        private System.Windows.Forms.TextBox txtConstraintVariableIdentifier;
        private System.Windows.Forms.TextBox txtConstraintName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbConstraintSign;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtConstraintExpression;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.PictureBox pbVariableIdentifierInfo;
        private System.Windows.Forms.ToolTip ttpVariableIdentifierInfo;
    }
}