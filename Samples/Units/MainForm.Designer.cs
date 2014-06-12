namespace Units
{
    partial class MainForm
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
            this.treeUnits = new System.Windows.Forms.TreeView();
            this.label1 = new System.Windows.Forms.Label();
            this.labelUnitName = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.labelUnitSymbol = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.labelUnitBaseUnit = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.labelUnitMultiplier = new System.Windows.Forms.Label();
            this.comboUnits = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.numericValue = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.labelResult = new System.Windows.Forms.Label();
            this.buttonConvert = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericValue)).BeginInit();
            this.SuspendLayout();
            // 
            // treeUnits
            // 
            this.treeUnits.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.treeUnits.Location = new System.Drawing.Point(12, 12);
            this.treeUnits.Name = "treeUnits";
            this.treeUnits.Size = new System.Drawing.Size(186, 418);
            this.treeUnits.TabIndex = 0;
            this.treeUnits.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeUnits_NodeMouseClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(204, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Unit name:";
            // 
            // labelUnitName
            // 
            this.labelUnitName.AutoSize = true;
            this.labelUnitName.Location = new System.Drawing.Point(274, 12);
            this.labelUnitName.Name = "labelUnitName";
            this.labelUnitName.Size = new System.Drawing.Size(10, 13);
            this.labelUnitName.TabIndex = 2;
            this.labelUnitName.Text = " ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(204, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Unit symbol:";
            // 
            // labelUnitSymbol
            // 
            this.labelUnitSymbol.AutoSize = true;
            this.labelUnitSymbol.Location = new System.Drawing.Point(274, 34);
            this.labelUnitSymbol.Name = "labelUnitSymbol";
            this.labelUnitSymbol.Size = new System.Drawing.Size(10, 13);
            this.labelUnitSymbol.TabIndex = 4;
            this.labelUnitSymbol.Text = " ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(204, 56);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Base unit:";
            // 
            // labelUnitBaseUnit
            // 
            this.labelUnitBaseUnit.AutoSize = true;
            this.labelUnitBaseUnit.Location = new System.Drawing.Point(274, 56);
            this.labelUnitBaseUnit.Name = "labelUnitBaseUnit";
            this.labelUnitBaseUnit.Size = new System.Drawing.Size(10, 13);
            this.labelUnitBaseUnit.TabIndex = 6;
            this.labelUnitBaseUnit.Text = " ";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(204, 78);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(51, 13);
            this.label7.TabIndex = 7;
            this.label7.Text = "Multiplier:";
            // 
            // labelUnitMultiplier
            // 
            this.labelUnitMultiplier.AutoSize = true;
            this.labelUnitMultiplier.Location = new System.Drawing.Point(274, 78);
            this.labelUnitMultiplier.Name = "labelUnitMultiplier";
            this.labelUnitMultiplier.Size = new System.Drawing.Size(10, 13);
            this.labelUnitMultiplier.TabIndex = 8;
            this.labelUnitMultiplier.Text = " ";
            // 
            // comboUnits
            // 
            this.comboUnits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboUnits.FormattingEnabled = true;
            this.comboUnits.Location = new System.Drawing.Point(277, 147);
            this.comboUnits.Name = "comboUnits";
            this.comboUnits.Size = new System.Drawing.Size(186, 21);
            this.comboUnits.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(204, 150);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Convert to:";
            // 
            // numericValue
            // 
            this.numericValue.Location = new System.Drawing.Point(277, 174);
            this.numericValue.Name = "numericValue";
            this.numericValue.Size = new System.Drawing.Size(186, 20);
            this.numericValue.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(204, 176);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Value:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(204, 235);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Result:";
            // 
            // labelResult
            // 
            this.labelResult.AutoSize = true;
            this.labelResult.Location = new System.Drawing.Point(274, 235);
            this.labelResult.Name = "labelResult";
            this.labelResult.Size = new System.Drawing.Size(10, 13);
            this.labelResult.TabIndex = 14;
            this.labelResult.Text = " ";
            // 
            // buttonConvert
            // 
            this.buttonConvert.Location = new System.Drawing.Point(277, 200);
            this.buttonConvert.Name = "buttonConvert";
            this.buttonConvert.Size = new System.Drawing.Size(75, 23);
            this.buttonConvert.TabIndex = 15;
            this.buttonConvert.Text = "Convert";
            this.buttonConvert.UseVisualStyleBackColor = true;
            this.buttonConvert.Click += new System.EventHandler(this.buttonConvert_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 442);
            this.Controls.Add(this.buttonConvert);
            this.Controls.Add(this.labelResult);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.numericValue);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboUnits);
            this.Controls.Add(this.labelUnitMultiplier);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.labelUnitBaseUnit);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.labelUnitSymbol);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.labelUnitName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.treeUnits);
            this.MinimumSize = new System.Drawing.Size(640, 480);
            this.Name = "MainForm";
            this.Text = "Units Sample";
            ((System.ComponentModel.ISupportInitialize)(this.numericValue)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView treeUnits;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelUnitName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labelUnitSymbol;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label labelUnitBaseUnit;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label labelUnitMultiplier;
        private System.Windows.Forms.ComboBox comboUnits;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numericValue;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label labelResult;
        private System.Windows.Forms.Button buttonConvert;
    }
}

