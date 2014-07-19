namespace opt.Samples.Relations
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.buttonTestInequalityDouble = new System.Windows.Forms.Button();
            this.numericInequalityRightDouble = new System.Windows.Forms.NumericUpDown();
            this.numericInequalityLeftDouble = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.textNotMember = new System.Windows.Forms.TextBox();
            this.textMember = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textGreaterOrEqual = new System.Windows.Forms.TextBox();
            this.textGreater = new System.Windows.Forms.TextBox();
            this.textLessOrEqual = new System.Windows.Forms.TextBox();
            this.textLess = new System.Windows.Forms.TextBox();
            this.textNotEqual = new System.Windows.Forms.TextBox();
            this.textEqual = new System.Windows.Forms.TextBox();
            this.buttonReset = new System.Windows.Forms.Button();
            this.listSetDouble = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.numericSetAddDouble = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.buttonSetAddDouble = new System.Windows.Forms.Button();
            this.buttonSetTestDouble = new System.Windows.Forms.Button();
            this.numericSetTestDouble = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericInequalityRightDouble)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericInequalityLeftDouble)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericSetAddDouble)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericSetTestDouble)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(438, 418);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.buttonSetTestDouble);
            this.tabPage1.Controls.Add(this.numericSetTestDouble);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.buttonSetAddDouble);
            this.tabPage1.Controls.Add(this.numericSetAddDouble);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.listSetDouble);
            this.tabPage1.Controls.Add(this.buttonTestInequalityDouble);
            this.tabPage1.Controls.Add(this.numericInequalityRightDouble);
            this.tabPage1.Controls.Add(this.numericInequalityLeftDouble);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(430, 392);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Double";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // buttonTestInequalityDouble
            // 
            this.buttonTestInequalityDouble.Location = new System.Drawing.Point(182, 37);
            this.buttonTestInequalityDouble.Name = "buttonTestInequalityDouble";
            this.buttonTestInequalityDouble.Size = new System.Drawing.Size(75, 23);
            this.buttonTestInequalityDouble.TabIndex = 2;
            this.buttonTestInequalityDouble.Text = "Test!";
            this.buttonTestInequalityDouble.UseVisualStyleBackColor = true;
            this.buttonTestInequalityDouble.Click += new System.EventHandler(this.buttonTestInequalityDouble_Click);
            // 
            // numericInequalityRightDouble
            // 
            this.numericInequalityRightDouble.Location = new System.Drawing.Point(76, 40);
            this.numericInequalityRightDouble.Name = "numericInequalityRightDouble";
            this.numericInequalityRightDouble.Size = new System.Drawing.Size(100, 20);
            this.numericInequalityRightDouble.TabIndex = 1;
            // 
            // numericInequalityLeftDouble
            // 
            this.numericInequalityLeftDouble.Location = new System.Drawing.Point(76, 14);
            this.numericInequalityLeftDouble.Name = "numericInequalityLeftDouble";
            this.numericInequalityLeftDouble.Size = new System.Drawing.Size(100, 20);
            this.numericInequalityLeftDouble.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 42);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Right value:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Left value:";
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(430, 392);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Double Measurable";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.textNotMember);
            this.panel1.Controls.Add(this.textMember);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.textGreaterOrEqual);
            this.panel1.Controls.Add(this.textGreater);
            this.panel1.Controls.Add(this.textLessOrEqual);
            this.panel1.Controls.Add(this.textLess);
            this.panel1.Controls.Add(this.textNotEqual);
            this.panel1.Controls.Add(this.textEqual);
            this.panel1.Location = new System.Drawing.Point(456, 34);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(156, 367);
            this.panel1.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 244);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Set";
            // 
            // textNotMember
            // 
            this.textNotMember.BackColor = System.Drawing.SystemColors.ControlLight;
            this.textNotMember.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textNotMember.Location = new System.Drawing.Point(3, 292);
            this.textNotMember.Name = "textNotMember";
            this.textNotMember.ReadOnly = true;
            this.textNotMember.Size = new System.Drawing.Size(150, 26);
            this.textNotMember.TabIndex = 8;
            this.textNotMember.TabStop = false;
            this.textNotMember.Text = "Not Member";
            this.textNotMember.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textNotMember.WordWrap = false;
            // 
            // textMember
            // 
            this.textMember.BackColor = System.Drawing.SystemColors.ControlLight;
            this.textMember.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textMember.Location = new System.Drawing.Point(3, 260);
            this.textMember.Name = "textMember";
            this.textMember.ReadOnly = true;
            this.textMember.Size = new System.Drawing.Size(150, 26);
            this.textMember.TabIndex = 7;
            this.textMember.TabStop = false;
            this.textMember.Text = "Member";
            this.textMember.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textMember.WordWrap = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Inequality";
            // 
            // textGreaterOrEqual
            // 
            this.textGreaterOrEqual.BackColor = System.Drawing.SystemColors.ControlLight;
            this.textGreaterOrEqual.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textGreaterOrEqual.Location = new System.Drawing.Point(3, 176);
            this.textGreaterOrEqual.Name = "textGreaterOrEqual";
            this.textGreaterOrEqual.ReadOnly = true;
            this.textGreaterOrEqual.Size = new System.Drawing.Size(150, 26);
            this.textGreaterOrEqual.TabIndex = 5;
            this.textGreaterOrEqual.TabStop = false;
            this.textGreaterOrEqual.Text = "Greater Or Equal";
            this.textGreaterOrEqual.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textGreaterOrEqual.WordWrap = false;
            // 
            // textGreater
            // 
            this.textGreater.BackColor = System.Drawing.SystemColors.ControlLight;
            this.textGreater.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textGreater.Location = new System.Drawing.Point(3, 144);
            this.textGreater.Name = "textGreater";
            this.textGreater.ReadOnly = true;
            this.textGreater.Size = new System.Drawing.Size(150, 26);
            this.textGreater.TabIndex = 4;
            this.textGreater.TabStop = false;
            this.textGreater.Text = "Greater";
            this.textGreater.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textGreater.WordWrap = false;
            // 
            // textLessOrEqual
            // 
            this.textLessOrEqual.BackColor = System.Drawing.SystemColors.ControlLight;
            this.textLessOrEqual.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textLessOrEqual.Location = new System.Drawing.Point(3, 112);
            this.textLessOrEqual.Name = "textLessOrEqual";
            this.textLessOrEqual.ReadOnly = true;
            this.textLessOrEqual.Size = new System.Drawing.Size(150, 26);
            this.textLessOrEqual.TabIndex = 3;
            this.textLessOrEqual.TabStop = false;
            this.textLessOrEqual.Text = "Less Or Equal";
            this.textLessOrEqual.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textLessOrEqual.WordWrap = false;
            // 
            // textLess
            // 
            this.textLess.BackColor = System.Drawing.SystemColors.ControlLight;
            this.textLess.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textLess.Location = new System.Drawing.Point(3, 80);
            this.textLess.Name = "textLess";
            this.textLess.ReadOnly = true;
            this.textLess.Size = new System.Drawing.Size(150, 26);
            this.textLess.TabIndex = 2;
            this.textLess.TabStop = false;
            this.textLess.Text = "Less";
            this.textLess.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textLess.WordWrap = false;
            // 
            // textNotEqual
            // 
            this.textNotEqual.BackColor = System.Drawing.SystemColors.ControlLight;
            this.textNotEqual.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textNotEqual.Location = new System.Drawing.Point(3, 48);
            this.textNotEqual.Name = "textNotEqual";
            this.textNotEqual.ReadOnly = true;
            this.textNotEqual.Size = new System.Drawing.Size(150, 26);
            this.textNotEqual.TabIndex = 1;
            this.textNotEqual.TabStop = false;
            this.textNotEqual.Text = "Not Equal";
            this.textNotEqual.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textNotEqual.WordWrap = false;
            // 
            // textEqual
            // 
            this.textEqual.BackColor = System.Drawing.SystemColors.ControlLight;
            this.textEqual.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textEqual.Location = new System.Drawing.Point(3, 16);
            this.textEqual.Name = "textEqual";
            this.textEqual.ReadOnly = true;
            this.textEqual.Size = new System.Drawing.Size(150, 26);
            this.textEqual.TabIndex = 0;
            this.textEqual.TabStop = false;
            this.textEqual.Text = "Equal";
            this.textEqual.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textEqual.WordWrap = false;
            // 
            // buttonReset
            // 
            this.buttonReset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonReset.Location = new System.Drawing.Point(456, 407);
            this.buttonReset.Name = "buttonReset";
            this.buttonReset.Size = new System.Drawing.Size(156, 23);
            this.buttonReset.TabIndex = 2;
            this.buttonReset.Text = "Reset";
            this.buttonReset.UseVisualStyleBackColor = true;
            this.buttonReset.Click += new System.EventHandler(this.buttonReset_Click);
            // 
            // listSetDouble
            // 
            this.listSetDouble.FormattingEnabled = true;
            this.listSetDouble.Location = new System.Drawing.Point(9, 262);
            this.listSetDouble.Name = "listSetDouble";
            this.listSetDouble.Size = new System.Drawing.Size(61, 121);
            this.listSetDouble.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 244);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(26, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Set:";
            // 
            // numericSetAddDouble
            // 
            this.numericSetAddDouble.Location = new System.Drawing.Point(140, 260);
            this.numericSetAddDouble.Name = "numericSetAddDouble";
            this.numericSetAddDouble.Size = new System.Drawing.Size(100, 20);
            this.numericSetAddDouble.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(76, 262);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "Add to set:";
            // 
            // buttonSetAddDouble
            // 
            this.buttonSetAddDouble.Location = new System.Drawing.Point(246, 257);
            this.buttonSetAddDouble.Name = "buttonSetAddDouble";
            this.buttonSetAddDouble.Size = new System.Drawing.Size(75, 23);
            this.buttonSetAddDouble.TabIndex = 4;
            this.buttonSetAddDouble.Text = "Add";
            this.buttonSetAddDouble.UseVisualStyleBackColor = true;
            this.buttonSetAddDouble.Click += new System.EventHandler(this.buttonSetAddDouble_Click);
            // 
            // buttonSetTestDouble
            // 
            this.buttonSetTestDouble.Location = new System.Drawing.Point(246, 283);
            this.buttonSetTestDouble.Name = "buttonSetTestDouble";
            this.buttonSetTestDouble.Size = new System.Drawing.Size(75, 23);
            this.buttonSetTestDouble.TabIndex = 6;
            this.buttonSetTestDouble.Text = "Test!";
            this.buttonSetTestDouble.UseVisualStyleBackColor = true;
            this.buttonSetTestDouble.Click += new System.EventHandler(this.buttonSetTestDouble_Click);
            // 
            // numericSetTestDouble
            // 
            this.numericSetTestDouble.Location = new System.Drawing.Point(140, 286);
            this.numericSetTestDouble.Name = "numericSetTestDouble";
            this.numericSetTestDouble.Size = new System.Drawing.Size(100, 20);
            this.numericSetTestDouble.TabIndex = 5;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(73, 288);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(60, 13);
            this.label7.TabIndex = 10;
            this.label7.Text = "Test value:";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 442);
            this.Controls.Add(this.buttonReset);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tabControl1);
            this.MinimumSize = new System.Drawing.Size(640, 480);
            this.Name = "MainForm";
            this.Text = "Relations Sample";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericInequalityRightDouble)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericInequalityLeftDouble)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericSetAddDouble)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericSetTestDouble)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox textEqual;
        private System.Windows.Forms.TextBox textGreaterOrEqual;
        private System.Windows.Forms.TextBox textGreater;
        private System.Windows.Forms.TextBox textLessOrEqual;
        private System.Windows.Forms.TextBox textLess;
        private System.Windows.Forms.TextBox textNotEqual;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textNotMember;
        private System.Windows.Forms.TextBox textMember;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonTestInequalityDouble;
        private System.Windows.Forms.NumericUpDown numericInequalityRightDouble;
        private System.Windows.Forms.NumericUpDown numericInequalityLeftDouble;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonReset;
        private System.Windows.Forms.Button buttonSetTestDouble;
        private System.Windows.Forms.NumericUpDown numericSetTestDouble;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button buttonSetAddDouble;
        private System.Windows.Forms.NumericUpDown numericSetAddDouble;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListBox listSetDouble;
    }
}

