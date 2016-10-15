namespace opt.UI
{
    partial class EditAdequacyCriterionForm
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
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.txtCriterionVariableIdentifier = new System.Windows.Forms.TextBox();
            this.txtCriterionName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbAdequacyCriterionType = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.pbAdequacyCriterionFunction = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbAdequacyCriterionFunction)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(373, 205);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOK.Location = new System.Drawing.Point(292, 205);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 4;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // txtCriterionVariableIdentifier
            // 
            this.txtCriterionVariableIdentifier.Location = new System.Drawing.Point(177, 43);
            this.txtCriterionVariableIdentifier.Name = "txtCriterionVariableIdentifier";
            this.txtCriterionVariableIdentifier.Size = new System.Drawing.Size(271, 20);
            this.txtCriterionVariableIdentifier.TabIndex = 1;
            // 
            // txtCriterionName
            // 
            this.txtCriterionName.Location = new System.Drawing.Point(177, 12);
            this.txtCriterionName.Name = "txtCriterionName";
            this.txtCriterionName.Size = new System.Drawing.Size(271, 20);
            this.txtCriterionName.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(138, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Тип функции от невязки*:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(155, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Идентификатор переменной:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Название критерия *:";
            // 
            // cmbAdequacyCriterionType
            // 
            this.cmbAdequacyCriterionType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAdequacyCriterionType.DropDownWidth = 180;
            this.cmbAdequacyCriterionType.FormattingEnabled = true;
            this.cmbAdequacyCriterionType.Location = new System.Drawing.Point(177, 73);
            this.cmbAdequacyCriterionType.Name = "cmbAdequacyCriterionType";
            this.cmbAdequacyCriterionType.Size = new System.Drawing.Size(271, 21);
            this.cmbAdequacyCriterionType.TabIndex = 2;
            this.cmbAdequacyCriterionType.SelectedIndexChanged += new System.EventHandler(this.cmbAdequacyCriterionType_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label5.Location = new System.Drawing.Point(12, 205);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(274, 23);
            this.label5.TabIndex = 14;
            this.label5.Text = "* - обязательные для заполнения поля";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 108);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "Функция:";
            // 
            // pbAdequacyCriterionFunction
            // 
            this.pbAdequacyCriterionFunction.Location = new System.Drawing.Point(177, 108);
            this.pbAdequacyCriterionFunction.Name = "pbAdequacyCriterionFunction";
            this.pbAdequacyCriterionFunction.Size = new System.Drawing.Size(271, 76);
            this.pbAdequacyCriterionFunction.TabIndex = 17;
            this.pbAdequacyCriterionFunction.TabStop = false;
            // 
            // EditAdequacyCriterionForm
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(459, 237);
            this.Controls.Add(this.pbAdequacyCriterionFunction);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cmbAdequacyCriterionType);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.txtCriterionVariableIdentifier);
            this.Controls.Add(this.txtCriterionName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditAdequacyCriterionForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)(this.pbAdequacyCriterionFunction)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.TextBox txtCriterionVariableIdentifier;
        private System.Windows.Forms.TextBox txtCriterionName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbAdequacyCriterionType;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pbAdequacyCriterionFunction;
    }
}