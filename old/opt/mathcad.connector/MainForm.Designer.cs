namespace mathcad.connector
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.mathcadFile = new System.Windows.Forms.TextBox();
            this.chooseMathcadFile = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.optFile = new System.Windows.Forms.TextBox();
            this.chooseOptFile = new System.Windows.Forms.Button();
            this.exit = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.start = new System.Windows.Forms.Button();
            this.stop = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.actionLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mathcad 15 file:";
            // 
            // mathcadFile
            // 
            this.mathcadFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mathcadFile.Location = new System.Drawing.Point(104, 14);
            this.mathcadFile.Name = "mathcadFile";
            this.mathcadFile.Size = new System.Drawing.Size(425, 20);
            this.mathcadFile.TabIndex = 1;
            this.mathcadFile.Validating += new System.ComponentModel.CancelEventHandler(this.mathcadFile_Validating);
            this.mathcadFile.Validated += new System.EventHandler(this.mathcadFile_Validated);
            // 
            // chooseMathcadFile
            // 
            this.chooseMathcadFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chooseMathcadFile.CausesValidation = false;
            this.chooseMathcadFile.Location = new System.Drawing.Point(547, 14);
            this.chooseMathcadFile.Name = "chooseMathcadFile";
            this.chooseMathcadFile.Size = new System.Drawing.Size(25, 20);
            this.chooseMathcadFile.TabIndex = 2;
            this.chooseMathcadFile.Text = "...";
            this.chooseMathcadFile.UseVisualStyleBackColor = true;
            this.chooseMathcadFile.Click += new System.EventHandler(this.chooseMathcadFile_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "OPT model file:";
            // 
            // optFile
            // 
            this.optFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.optFile.Location = new System.Drawing.Point(104, 43);
            this.optFile.Name = "optFile";
            this.optFile.Size = new System.Drawing.Size(425, 20);
            this.optFile.TabIndex = 3;
            this.optFile.Validating += new System.ComponentModel.CancelEventHandler(this.optFile_Validating);
            this.optFile.Validated += new System.EventHandler(this.optFile_Validated);
            // 
            // chooseOptFile
            // 
            this.chooseOptFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chooseOptFile.CausesValidation = false;
            this.chooseOptFile.Location = new System.Drawing.Point(547, 43);
            this.chooseOptFile.Name = "chooseOptFile";
            this.chooseOptFile.Size = new System.Drawing.Size(25, 20);
            this.chooseOptFile.TabIndex = 4;
            this.chooseOptFile.Text = "...";
            this.chooseOptFile.UseVisualStyleBackColor = true;
            this.chooseOptFile.Click += new System.EventHandler(this.chooseOptFile_Click);
            // 
            // exit
            // 
            this.exit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.exit.CausesValidation = false;
            this.exit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.exit.Location = new System.Drawing.Point(497, 147);
            this.exit.Name = "exit";
            this.exit.Size = new System.Drawing.Size(75, 23);
            this.exit.TabIndex = 7;
            this.exit.Text = "Exit";
            this.exit.UseVisualStyleBackColor = true;
            this.exit.Click += new System.EventHandler(this.exit_Click);
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // start
            // 
            this.start.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.start.Location = new System.Drawing.Point(416, 79);
            this.start.Name = "start";
            this.start.Size = new System.Drawing.Size(75, 23);
            this.start.TabIndex = 5;
            this.start.Text = "Start";
            this.start.UseVisualStyleBackColor = true;
            this.start.Click += new System.EventHandler(this.start_Click);
            // 
            // stop
            // 
            this.stop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.stop.CausesValidation = false;
            this.stop.Enabled = false;
            this.stop.Location = new System.Drawing.Point(497, 79);
            this.stop.Name = "stop";
            this.stop.Size = new System.Drawing.Size(75, 23);
            this.stop.TabIndex = 6;
            this.stop.Text = "Stop";
            this.stop.UseVisualStyleBackColor = true;
            this.stop.Click += new System.EventHandler(this.stop_Click);
            // 
            // progressBar
            // 
            this.progressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar.Enabled = false;
            this.progressBar.Location = new System.Drawing.Point(18, 112);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(554, 24);
            this.progressBar.TabIndex = 8;
            this.progressBar.Visible = false;
            // 
            // actionLabel
            // 
            this.actionLabel.AutoSize = true;
            this.actionLabel.Location = new System.Drawing.Point(15, 84);
            this.actionLabel.Name = "actionLabel";
            this.actionLabel.Size = new System.Drawing.Size(0, 13);
            this.actionLabel.TabIndex = 9;
            // 
            // MainForm
            // 
            this.AcceptButton = this.start;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.exit;
            this.ClientSize = new System.Drawing.Size(584, 182);
            this.Controls.Add(this.actionLabel);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.stop);
            this.Controls.Add(this.start);
            this.Controls.Add(this.exit);
            this.Controls.Add(this.chooseOptFile);
            this.Controls.Add(this.optFile);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.chooseMathcadFile);
            this.Controls.Add(this.mathcadFile);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox mathcadFile;
        private System.Windows.Forms.Button chooseMathcadFile;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox optFile;
        private System.Windows.Forms.Button chooseOptFile;
        private System.Windows.Forms.Button exit;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Button stop;
        private System.Windows.Forms.Button start;
        private System.Windows.Forms.Label actionLabel;
    }
}

