namespace opt.Drafter.UI
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
            this.mainToolbar = new System.Windows.Forms.ToolStrip();
            this.separator1 = new System.Windows.Forms.ToolStripSeparator();
            this.separator2 = new System.Windows.Forms.ToolStripSeparator();
            this.mainTabContainer = new System.Windows.Forms.TabControl();
            this.constantsTabPage = new System.Windows.Forms.TabPage();
            this.constantsDataGridView = new System.Windows.Forms.DataGridView();
            this.criteriaTabPage = new System.Windows.Forms.TabPage();
            this.criteriaDataGridView = new System.Windows.Forms.DataGridView();
            this.newButton = new System.Windows.Forms.ToolStripButton();
            this.openButton = new System.Windows.Forms.ToolStripButton();
            this.saveSplitButton = new System.Windows.Forms.ToolStripSplitButton();
            this.saveDraftMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveOptModelMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.separator11 = new System.Windows.Forms.ToolStripSeparator();
            this.saveConstantsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveRunOptButton = new System.Windows.Forms.ToolStripButton();
            this.removeSelectedButton = new System.Windows.Forms.ToolStripButton();
            this.promoteSelectedButton = new System.Windows.Forms.ToolStripButton();
            this.downgradeSelectedButton = new System.Windows.Forms.ToolStripButton();
            this.settingsButton = new System.Windows.Forms.ToolStripButton();
            this.exitButton = new System.Windows.Forms.ToolStripButton();
            this.mainToolbar.SuspendLayout();
            this.mainTabContainer.SuspendLayout();
            this.constantsTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.constantsDataGridView)).BeginInit();
            this.criteriaTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.criteriaDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // mainToolbar
            // 
            this.mainToolbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newButton,
            this.openButton,
            this.saveSplitButton,
            this.saveRunOptButton,
            this.separator1,
            this.removeSelectedButton,
            this.promoteSelectedButton,
            this.downgradeSelectedButton,
            this.separator2,
            this.settingsButton,
            this.exitButton});
            this.mainToolbar.Location = new System.Drawing.Point(0, 0);
            this.mainToolbar.Name = "mainToolbar";
            this.mainToolbar.Size = new System.Drawing.Size(784, 25);
            this.mainToolbar.TabIndex = 0;
            this.mainToolbar.Text = "toolStrip1";
            // 
            // separator1
            // 
            this.separator1.Name = "separator1";
            this.separator1.Size = new System.Drawing.Size(6, 25);
            // 
            // separator2
            // 
            this.separator2.Name = "separator2";
            this.separator2.Size = new System.Drawing.Size(6, 25);
            // 
            // mainTabContainer
            // 
            this.mainTabContainer.Controls.Add(this.constantsTabPage);
            this.mainTabContainer.Controls.Add(this.criteriaTabPage);
            this.mainTabContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainTabContainer.Location = new System.Drawing.Point(0, 25);
            this.mainTabContainer.Name = "mainTabContainer";
            this.mainTabContainer.SelectedIndex = 0;
            this.mainTabContainer.Size = new System.Drawing.Size(784, 537);
            this.mainTabContainer.TabIndex = 1;
            // 
            // constantsTabPage
            // 
            this.constantsTabPage.Controls.Add(this.constantsDataGridView);
            this.constantsTabPage.Location = new System.Drawing.Point(4, 22);
            this.constantsTabPage.Name = "constantsTabPage";
            this.constantsTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.constantsTabPage.Size = new System.Drawing.Size(776, 511);
            this.constantsTabPage.TabIndex = 0;
            this.constantsTabPage.Text = "Constants and Parameters";
            this.constantsTabPage.UseVisualStyleBackColor = true;
            // 
            // constantsDataGridView
            // 
            this.constantsDataGridView.AllowUserToResizeRows = false;
            this.constantsDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.constantsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.constantsDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.constantsDataGridView.Location = new System.Drawing.Point(3, 3);
            this.constantsDataGridView.Name = "constantsDataGridView";
            this.constantsDataGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.constantsDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.constantsDataGridView.Size = new System.Drawing.Size(770, 505);
            this.constantsDataGridView.TabIndex = 1;
            // 
            // criteriaTabPage
            // 
            this.criteriaTabPage.Controls.Add(this.criteriaDataGridView);
            this.criteriaTabPage.Location = new System.Drawing.Point(4, 22);
            this.criteriaTabPage.Name = "criteriaTabPage";
            this.criteriaTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.criteriaTabPage.Size = new System.Drawing.Size(776, 511);
            this.criteriaTabPage.TabIndex = 1;
            this.criteriaTabPage.Text = "Criteria and Functional constraints";
            this.criteriaTabPage.UseVisualStyleBackColor = true;
            // 
            // criteriaDataGridView
            // 
            this.criteriaDataGridView.AllowUserToResizeRows = false;
            this.criteriaDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.criteriaDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.criteriaDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.criteriaDataGridView.Location = new System.Drawing.Point(3, 3);
            this.criteriaDataGridView.Name = "criteriaDataGridView";
            this.criteriaDataGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.criteriaDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.criteriaDataGridView.Size = new System.Drawing.Size(770, 505);
            this.criteriaDataGridView.TabIndex = 3;
            // 
            // newButton
            // 
            this.newButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.newButton.Image = global::opt.Drafter.Properties.Resources.page;
            this.newButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.newButton.Name = "newButton";
            this.newButton.Size = new System.Drawing.Size(23, 22);
            this.newButton.Text = "New model draft";
            // 
            // openButton
            // 
            this.openButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.openButton.Image = global::opt.Drafter.Properties.Resources.folder;
            this.openButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openButton.Name = "openButton";
            this.openButton.Size = new System.Drawing.Size(23, 22);
            this.openButton.Text = "Open model draft...";
            // 
            // saveSplitButton
            // 
            this.saveSplitButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.saveSplitButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveDraftMenuItem,
            this.saveOptModelMenuItem,
            this.separator11,
            this.saveConstantsMenuItem});
            this.saveSplitButton.Image = global::opt.Drafter.Properties.Resources.disk;
            this.saveSplitButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveSplitButton.Name = "saveSplitButton";
            this.saveSplitButton.Size = new System.Drawing.Size(32, 22);
            this.saveSplitButton.Text = "Save model draft...";
            // 
            // saveDraftMenuItem
            // 
            this.saveDraftMenuItem.Image = global::opt.Drafter.Properties.Resources.disk;
            this.saveDraftMenuItem.Name = "saveDraftMenuItem";
            this.saveDraftMenuItem.Size = new System.Drawing.Size(180, 22);
            this.saveDraftMenuItem.Text = "Save model draft...";
            // 
            // saveOptModelMenuItem
            // 
            this.saveOptModelMenuItem.Image = global::opt.Drafter.Properties.Resources.disk_multiple;
            this.saveOptModelMenuItem.Name = "saveOptModelMenuItem";
            this.saveOptModelMenuItem.Size = new System.Drawing.Size(180, 22);
            this.saveOptModelMenuItem.Text = "Save OPT model...";
            // 
            // separator11
            // 
            this.separator11.Name = "separator11";
            this.separator11.Size = new System.Drawing.Size(177, 6);
            // 
            // saveConstantsMenuItem
            // 
            this.saveConstantsMenuItem.Name = "saveConstantsMenuItem";
            this.saveConstantsMenuItem.Size = new System.Drawing.Size(180, 22);
            this.saveConstantsMenuItem.Text = "Save constants file...";
            // 
            // saveRunOptButton
            // 
            this.saveRunOptButton.Image = global::opt.Drafter.Properties.Resources.application_go;
            this.saveRunOptButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveRunOptButton.Name = "saveRunOptButton";
            this.saveRunOptButton.Size = new System.Drawing.Size(167, 22);
            this.saveRunOptButton.Text = "Save model and run OPT...";
            // 
            // removeSelectedButton
            // 
            this.removeSelectedButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.removeSelectedButton.Image = global::opt.Drafter.Properties.Resources.delete;
            this.removeSelectedButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.removeSelectedButton.Name = "removeSelectedButton";
            this.removeSelectedButton.Size = new System.Drawing.Size(23, 22);
            this.removeSelectedButton.Text = "Remove selected entity";
            // 
            // promoteSelectedButton
            // 
            this.promoteSelectedButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.promoteSelectedButton.Image = global::opt.Drafter.Properties.Resources.arrow_up;
            this.promoteSelectedButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.promoteSelectedButton.Name = "promoteSelectedButton";
            this.promoteSelectedButton.Size = new System.Drawing.Size(23, 22);
            this.promoteSelectedButton.Text = "Promote selected";
            // 
            // downgradeSelectedButton
            // 
            this.downgradeSelectedButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.downgradeSelectedButton.Image = global::opt.Drafter.Properties.Resources.arrow_down;
            this.downgradeSelectedButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.downgradeSelectedButton.Name = "downgradeSelectedButton";
            this.downgradeSelectedButton.Size = new System.Drawing.Size(23, 22);
            this.downgradeSelectedButton.Text = "Downgrade selected";
            // 
            // settingsButton
            // 
            this.settingsButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.settingsButton.Image = global::opt.Drafter.Properties.Resources.cog;
            this.settingsButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.settingsButton.Name = "settingsButton";
            this.settingsButton.Size = new System.Drawing.Size(23, 22);
            this.settingsButton.Text = "Settings...";
            // 
            // exitButton
            // 
            this.exitButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.exitButton.Image = global::opt.Drafter.Properties.Resources.door_in;
            this.exitButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(23, 22);
            this.exitButton.Text = "Exit";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.mainTabContainer);
            this.Controls.Add(this.mainToolbar);
            this.Name = "MainForm";
            this.Text = "OPT model drafter";
            this.mainToolbar.ResumeLayout(false);
            this.mainToolbar.PerformLayout();
            this.mainTabContainer.ResumeLayout(false);
            this.constantsTabPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.constantsDataGridView)).EndInit();
            this.criteriaTabPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.criteriaDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip mainToolbar;
        private System.Windows.Forms.TabControl mainTabContainer;
        private System.Windows.Forms.TabPage constantsTabPage;
        private System.Windows.Forms.DataGridView constantsDataGridView;
        private System.Windows.Forms.TabPage criteriaTabPage;
        private System.Windows.Forms.DataGridView criteriaDataGridView;
        private System.Windows.Forms.ToolStripButton newButton;
        private System.Windows.Forms.ToolStripButton openButton;
        private System.Windows.Forms.ToolStripSplitButton saveSplitButton;
        private System.Windows.Forms.ToolStripMenuItem saveDraftMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveOptModelMenuItem;
        private System.Windows.Forms.ToolStripSeparator separator11;
        private System.Windows.Forms.ToolStripMenuItem saveConstantsMenuItem;
        private System.Windows.Forms.ToolStripButton saveRunOptButton;
        private System.Windows.Forms.ToolStripSeparator separator1;
        private System.Windows.Forms.ToolStripButton settingsButton;
        private System.Windows.Forms.ToolStripButton exitButton;
        private System.Windows.Forms.ToolStripSeparator separator2;
        private System.Windows.Forms.ToolStripButton removeSelectedButton;
        private System.Windows.Forms.ToolStripButton promoteSelectedButton;
        private System.Windows.Forms.ToolStripButton downgradeSelectedButton;
    }
}

