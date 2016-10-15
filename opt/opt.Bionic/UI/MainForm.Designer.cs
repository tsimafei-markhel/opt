namespace opt.Bionic.UI
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
            this.panelMain = new System.Windows.Forms.Panel();
            this.buttonClear = new System.Windows.Forms.Button();
            this.buttonLoad = new System.Windows.Forms.Button();
            this.buttonBrowseOptFile = new System.Windows.Forms.Button();
            this.textOptFile = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.splitMain = new System.Windows.Forms.SplitContainer();
            this.textCalcApp = new System.Windows.Forms.TextBox();
            this.buttonBrowseCalcApp = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonRun = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.listParameters = new System.Windows.Forms.ListView();
            this.colParameterName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colParameterMinValue = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colParameterMaxValue = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.listCriteria = new System.Windows.Forms.CheckedListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tableResults = new System.Windows.Forms.DataGridView();
            this.toolbarResults = new System.Windows.Forms.ToolStrip();
            this.buttonShowTray = new System.Windows.Forms.ToolStripButton();
            this.buttonToTray = new System.Windows.Forms.ToolStripButton();
            this.dialogBrowse = new System.Windows.Forms.OpenFileDialog();
            this.panelMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitMain)).BeginInit();
            this.splitMain.Panel1.SuspendLayout();
            this.splitMain.Panel2.SuspendLayout();
            this.splitMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tableResults)).BeginInit();
            this.toolbarResults.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelMain.Controls.Add(this.buttonClear);
            this.panelMain.Controls.Add(this.buttonLoad);
            this.panelMain.Controls.Add(this.buttonBrowseOptFile);
            this.panelMain.Controls.Add(this.textOptFile);
            this.panelMain.Controls.Add(this.label1);
            this.panelMain.Location = new System.Drawing.Point(12, 12);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(760, 57);
            this.panelMain.TabIndex = 0;
            // 
            // buttonClear
            // 
            this.buttonClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonClear.Location = new System.Drawing.Point(601, 31);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(75, 23);
            this.buttonClear.TabIndex = 3;
            this.buttonClear.Text = "Clear";
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // buttonLoad
            // 
            this.buttonLoad.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonLoad.Location = new System.Drawing.Point(682, 31);
            this.buttonLoad.Name = "buttonLoad";
            this.buttonLoad.Size = new System.Drawing.Size(75, 23);
            this.buttonLoad.TabIndex = 4;
            this.buttonLoad.Text = "Load";
            this.buttonLoad.UseVisualStyleBackColor = true;
            this.buttonLoad.Click += new System.EventHandler(this.buttonLoad_Click);
            // 
            // buttonBrowseOptFile
            // 
            this.buttonBrowseOptFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonBrowseOptFile.Image = global::opt.Bionic.Properties.Resources.magnifier;
            this.buttonBrowseOptFile.Location = new System.Drawing.Point(735, 3);
            this.buttonBrowseOptFile.Name = "buttonBrowseOptFile";
            this.buttonBrowseOptFile.Size = new System.Drawing.Size(22, 22);
            this.buttonBrowseOptFile.TabIndex = 2;
            this.buttonBrowseOptFile.UseVisualStyleBackColor = true;
            this.buttonBrowseOptFile.Click += new System.EventHandler(this.buttonBrowseOptFile_Click);
            // 
            // textOptFile
            // 
            this.textOptFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textOptFile.Location = new System.Drawing.Point(72, 5);
            this.textOptFile.Name = "textOptFile";
            this.textOptFile.Size = new System.Drawing.Size(657, 20);
            this.textOptFile.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "OPT model:";
            // 
            // splitMain
            // 
            this.splitMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitMain.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitMain.Location = new System.Drawing.Point(12, 75);
            this.splitMain.Name = "splitMain";
            // 
            // splitMain.Panel1
            // 
            this.splitMain.Panel1.Controls.Add(this.textCalcApp);
            this.splitMain.Panel1.Controls.Add(this.buttonBrowseCalcApp);
            this.splitMain.Panel1.Controls.Add(this.label3);
            this.splitMain.Panel1.Controls.Add(this.buttonRun);
            this.splitMain.Panel1.Controls.Add(this.label4);
            this.splitMain.Panel1.Controls.Add(this.listParameters);
            this.splitMain.Panel1.Controls.Add(this.listCriteria);
            this.splitMain.Panel1.Controls.Add(this.label2);
            this.splitMain.Panel1MinSize = 200;
            // 
            // splitMain.Panel2
            // 
            this.splitMain.Panel2.Controls.Add(this.tableResults);
            this.splitMain.Panel2.Controls.Add(this.toolbarResults);
            this.splitMain.Size = new System.Drawing.Size(760, 475);
            this.splitMain.SplitterDistance = 250;
            this.splitMain.TabIndex = 1;
            this.splitMain.TabStop = false;
            // 
            // textCalcApp
            // 
            this.textCalcApp.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textCalcApp.Location = new System.Drawing.Point(3, 423);
            this.textCalcApp.Name = "textCalcApp";
            this.textCalcApp.Size = new System.Drawing.Size(216, 20);
            this.textCalcApp.TabIndex = 7;
            // 
            // buttonBrowseCalcApp
            // 
            this.buttonBrowseCalcApp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonBrowseCalcApp.Image = global::opt.Bionic.Properties.Resources.magnifier;
            this.buttonBrowseCalcApp.Location = new System.Drawing.Point(225, 421);
            this.buttonBrowseCalcApp.Name = "buttonBrowseCalcApp";
            this.buttonBrowseCalcApp.Size = new System.Drawing.Size(22, 22);
            this.buttonBrowseCalcApp.TabIndex = 8;
            this.buttonBrowseCalcApp.UseVisualStyleBackColor = true;
            this.buttonBrowseCalcApp.Click += new System.EventHandler(this.buttonBrowseCalcApp_Click);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(0, 407);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(116, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Calculation application:";
            // 
            // buttonRun
            // 
            this.buttonRun.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonRun.Location = new System.Drawing.Point(172, 449);
            this.buttonRun.Name = "buttonRun";
            this.buttonRun.Size = new System.Drawing.Size(75, 23);
            this.buttonRun.TabIndex = 9;
            this.buttonRun.Text = "Run";
            this.buttonRun.UseVisualStyleBackColor = true;
            this.buttonRun.Click += new System.EventHandler(this.buttonRun_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(0, 128);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(115, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Parameters (attributes):";
            // 
            // listParameters
            // 
            this.listParameters.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listParameters.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colParameterName,
            this.colParameterMinValue,
            this.colParameterMaxValue});
            this.listParameters.GridLines = true;
            this.listParameters.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listParameters.Location = new System.Drawing.Point(3, 144);
            this.listParameters.MultiSelect = false;
            this.listParameters.Name = "listParameters";
            this.listParameters.Size = new System.Drawing.Size(244, 260);
            this.listParameters.TabIndex = 6;
            this.listParameters.UseCompatibleStateImageBehavior = false;
            this.listParameters.View = System.Windows.Forms.View.Details;
            // 
            // colParameterName
            // 
            this.colParameterName.Text = "Name";
            this.colParameterName.Width = 90;
            // 
            // colParameterMinValue
            // 
            this.colParameterMinValue.Text = "Min Value";
            // 
            // colParameterMaxValue
            // 
            this.colParameterMaxValue.Text = "MaxValue";
            // 
            // listCriteria
            // 
            this.listCriteria.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listCriteria.CheckOnClick = true;
            this.listCriteria.FormattingEnabled = true;
            this.listCriteria.Location = new System.Drawing.Point(3, 16);
            this.listCriteria.Name = "listCriteria";
            this.listCriteria.Size = new System.Drawing.Size(244, 109);
            this.listCriteria.TabIndex = 5;
            this.listCriteria.SelectedIndexChanged += new System.EventHandler(this.listCriteria_SelectedIndexChanged);
            this.listCriteria.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listCriteria_MouseDoubleClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Choose fitness criterion:";
            // 
            // tableResults
            // 
            this.tableResults.AllowUserToAddRows = false;
            this.tableResults.AllowUserToDeleteRows = false;
            this.tableResults.AllowUserToResizeRows = false;
            this.tableResults.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.tableResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tableResults.Cursor = System.Windows.Forms.Cursors.Default;
            this.tableResults.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableResults.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.tableResults.Location = new System.Drawing.Point(0, 0);
            this.tableResults.Name = "tableResults";
            this.tableResults.ReadOnly = true;
            this.tableResults.RowHeadersVisible = false;
            this.tableResults.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tableResults.Size = new System.Drawing.Size(474, 475);
            this.tableResults.TabIndex = 10;
            // 
            // toolbarResults
            // 
            this.toolbarResults.Dock = System.Windows.Forms.DockStyle.Right;
            this.toolbarResults.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolbarResults.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.buttonShowTray,
            this.buttonToTray});
            this.toolbarResults.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow;
            this.toolbarResults.Location = new System.Drawing.Point(474, 0);
            this.toolbarResults.Name = "toolbarResults";
            this.toolbarResults.Size = new System.Drawing.Size(32, 475);
            this.toolbarResults.TabIndex = 9;
            // 
            // buttonShowTray
            // 
            this.buttonShowTray.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonShowTray.Image = global::opt.Bionic.Properties.Resources.table_go;
            this.buttonShowTray.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonShowTray.Name = "buttonShowTray";
            this.buttonShowTray.Size = new System.Drawing.Size(29, 20);
            this.buttonShowTray.Text = "Show tray...";
            this.buttonShowTray.Click += new System.EventHandler(this.buttonShowTray_Click);
            // 
            // buttonToTray
            // 
            this.buttonToTray.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonToTray.Image = global::opt.Bionic.Properties.Resources.table_add;
            this.buttonToTray.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonToTray.Name = "buttonToTray";
            this.buttonToTray.Size = new System.Drawing.Size(29, 20);
            this.buttonToTray.Text = "Send selected individuals to tray...";
            this.buttonToTray.Click += new System.EventHandler(this.buttonToTray_Click);
            // 
            // dialogBrowse
            // 
            this.dialogBrowse.ReadOnlyChecked = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.splitMain);
            this.Controls.Add(this.panelMain);
            this.MinimumSize = new System.Drawing.Size(400, 500);
            this.Name = "MainForm";
            this.Text = "opt.Bionic";
            this.panelMain.ResumeLayout(false);
            this.panelMain.PerformLayout();
            this.splitMain.Panel1.ResumeLayout(false);
            this.splitMain.Panel1.PerformLayout();
            this.splitMain.Panel2.ResumeLayout(false);
            this.splitMain.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitMain)).EndInit();
            this.splitMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tableResults)).EndInit();
            this.toolbarResults.ResumeLayout(false);
            this.toolbarResults.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.Button buttonLoad;
        private System.Windows.Forms.Button buttonBrowseOptFile;
        private System.Windows.Forms.TextBox textOptFile;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.SplitContainer splitMain;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckedListBox listCriteria;
        private System.Windows.Forms.Button buttonRun;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListView listParameters;
        private System.Windows.Forms.ColumnHeader colParameterName;
        private System.Windows.Forms.ColumnHeader colParameterMinValue;
        private System.Windows.Forms.ColumnHeader colParameterMaxValue;
        private System.Windows.Forms.TextBox textCalcApp;
        private System.Windows.Forms.Button buttonBrowseCalcApp;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.OpenFileDialog dialogBrowse;
        private System.Windows.Forms.DataGridView tableResults;
        private System.Windows.Forms.ToolStrip toolbarResults;
        private System.Windows.Forms.ToolStripButton buttonShowTray;
        private System.Windows.Forms.ToolStripButton buttonToTray;
    }
}