namespace opt.UI.Forms
{
    partial class CriterionForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CriterionForm));
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.txtCriterionVariableIdentifier = new System.Windows.Forms.TextBox();
            this.txtCriterionName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbCriterionType = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCriterionExpression = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.pbVariableIdentifierInfo = new System.Windows.Forms.PictureBox();
            this.ttpVariableIdentifierInfo = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pbVariableIdentifierInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Image = global::opt.UI.Properties.Resources.cancel;
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(358, 228);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(101, 30);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Image = global::opt.UI.Properties.Resources.accept;
            this.btnOK.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOK.Location = new System.Drawing.Point(251, 228);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(101, 30);
            this.btnOK.TabIndex = 4;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // txtCriterionVariableIdentifier
            // 
            this.txtCriterionVariableIdentifier.Location = new System.Drawing.Point(188, 60);
            this.txtCriterionVariableIdentifier.Name = "txtCriterionVariableIdentifier";
            this.txtCriterionVariableIdentifier.Size = new System.Drawing.Size(271, 20);
            this.txtCriterionVariableIdentifier.TabIndex = 1;
            // 
            // txtCriterionName
            // 
            this.txtCriterionName.Location = new System.Drawing.Point(188, 29);
            this.txtCriterionName.Name = "txtCriterionName";
            this.txtCriterionName.Size = new System.Drawing.Size(271, 20);
            this.txtCriterionName.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Тип критерия *:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(155, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Идентификатор переменной:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Название критерия *:";
            // 
            // cmbCriterionType
            // 
            this.cmbCriterionType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCriterionType.DropDownWidth = 180;
            this.cmbCriterionType.FormattingEnabled = true;
            this.cmbCriterionType.Location = new System.Drawing.Point(188, 90);
            this.cmbCriterionType.Name = "cmbCriterionType";
            this.cmbCriterionType.Size = new System.Drawing.Size(271, 21);
            this.cmbCriterionType.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label5.Location = new System.Drawing.Point(27, 228);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(127, 30);
            this.label5.TabIndex = 14;
            this.label5.Text = "* - обязательные для заполнения поля";
            // 
            // txtCriterionExpression
            // 
            this.txtCriterionExpression.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtCriterionExpression.Location = new System.Drawing.Point(188, 122);
            this.txtCriterionExpression.Multiline = true;
            this.txtCriterionExpression.Name = "txtCriterionExpression";
            this.txtCriterionExpression.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtCriterionExpression.Size = new System.Drawing.Size(271, 79);
            this.txtCriterionExpression.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(27, 125);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "Выражение:";
            // 
            // pbVariableIdentifierInfo
            // 
            this.pbVariableIdentifierInfo.Image = global::opt.UI.Properties.Resources.information;
            this.pbVariableIdentifierInfo.Location = new System.Drawing.Point(465, 62);
            this.pbVariableIdentifierInfo.Name = "pbVariableIdentifierInfo";
            this.pbVariableIdentifierInfo.Size = new System.Drawing.Size(16, 16);
            this.pbVariableIdentifierInfo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbVariableIdentifierInfo.TabIndex = 20;
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
            // CriterionForm
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(506, 288);
            this.Controls.Add(this.pbVariableIdentifierInfo);
            this.Controls.Add(this.txtCriterionExpression);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cmbCriterionType);
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
            this.Name = "CriterionForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)(this.pbVariableIdentifierInfo)).EndInit();
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
        private System.Windows.Forms.ComboBox cmbCriterionType;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtCriterionExpression;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pbVariableIdentifierInfo;
        private System.Windows.Forms.ToolTip ttpVariableIdentifierInfo;
    }
}