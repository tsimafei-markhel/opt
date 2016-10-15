namespace opt.UI
{
    partial class ViewCalculatedResults
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
            this.tlbOptions = new System.Windows.Forms.ToolStrip();
            this.buttonRowsOptions = new System.Windows.Forms.ToolStripDropDownButton();
            this.menuApplyFunctionalConstraints = new System.Windows.Forms.ToolStripMenuItem();
            this.menuHideNonFittingExperiments = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.buttonOptimizationParameters = new System.Windows.Forms.ToolStripDropDownButton();
            this.menuOptimizationParametersShowAll = new System.Windows.Forms.ToolStripMenuItem();
            this.menuOptimizationParametersHideAll = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.buttonIdentificationParameters = new System.Windows.Forms.ToolStripDropDownButton();
            this.menuIdentificationParametersShowAll = new System.Windows.Forms.ToolStripMenuItem();
            this.menuIdentificationParametersHideAll = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.buttonFunctionalConstraints = new System.Windows.Forms.ToolStripDropDownButton();
            this.menuFunctionalConstraintsShowAll = new System.Windows.Forms.ToolStripMenuItem();
            this.menuFunctionalConstraintsHideAll = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.buttonRealCriteria = new System.Windows.Forms.ToolStripDropDownButton();
            this.menuRealCriteriaShowAll = new System.Windows.Forms.ToolStripMenuItem();
            this.menuRealCriteriaHideAll = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.buttonMathematicalCriteria = new System.Windows.Forms.ToolStripDropDownButton();
            this.menuMathematicalCriteriaShowAll = new System.Windows.Forms.ToolStripMenuItem();
            this.menuMathematicalCriteriaHideAll = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.buttonAdequacyCriteria = new System.Windows.Forms.ToolStripDropDownButton();
            this.menuAdequacyCriteriaShowAll = new System.Windows.Forms.ToolStripMenuItem();
            this.menuAdequacyCriteriaHideAll = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.buttonRefresh = new System.Windows.Forms.ToolStripButton();
            this.dgvResults = new System.Windows.Forms.DataGridView();
            this.colIdReadExp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIdIdentificationExp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRealExperiment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIndentificationExperiment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonSave = new System.Windows.Forms.Button();
            this.dialogSaveModel = new System.Windows.Forms.SaveFileDialog();
            this.panWorkspace.SuspendLayout();
            this.tlbOptions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResults)).BeginInit();
            this.SuspendLayout();
            // 
            // panWorkspace
            // 
            this.panWorkspace.Controls.Add(this.dgvResults);
            this.panWorkspace.Controls.Add(this.tlbOptions);
            // 
            // tlbOptions
            // 
            this.tlbOptions.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tlbOptions.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.buttonRowsOptions,
            this.toolStripSeparator1,
            this.buttonOptimizationParameters,
            this.buttonIdentificationParameters,
            this.buttonFunctionalConstraints,
            this.buttonRealCriteria,
            this.buttonMathematicalCriteria,
            this.buttonAdequacyCriteria,
            this.toolStripSeparator2,
            this.buttonRefresh});
            this.tlbOptions.Location = new System.Drawing.Point(0, 0);
            this.tlbOptions.Name = "tlbOptions";
            this.tlbOptions.Size = new System.Drawing.Size(760, 25);
            this.tlbOptions.TabIndex = 10;
            this.tlbOptions.Visible = false;
            // 
            // buttonRowsOptions
            // 
            this.buttonRowsOptions.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonRowsOptions.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuApplyFunctionalConstraints,
            this.menuHideNonFittingExperiments});
            this.buttonRowsOptions.Image = global::opt.Properties.Resources.table_edit;
            this.buttonRowsOptions.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonRowsOptions.Name = "buttonRowsOptions";
            this.buttonRowsOptions.Size = new System.Drawing.Size(29, 22);
            this.buttonRowsOptions.Text = "Параметры отображения строк";
            // 
            // menuApplyFunctionalConstraints
            // 
            this.menuApplyFunctionalConstraints.Checked = true;
            this.menuApplyFunctionalConstraints.CheckOnClick = true;
            this.menuApplyFunctionalConstraints.CheckState = System.Windows.Forms.CheckState.Checked;
            this.menuApplyFunctionalConstraints.Name = "menuApplyFunctionalConstraints";
            this.menuApplyFunctionalConstraints.Size = new System.Drawing.Size(523, 22);
            this.menuApplyFunctionalConstraints.Text = "Выделить цветом эксперименты, отсеянные по функциональным ограничениям";
            // 
            // menuHideNonFittingExperiments
            // 
            this.menuHideNonFittingExperiments.CheckOnClick = true;
            this.menuHideNonFittingExperiments.Name = "menuHideNonFittingExperiments";
            this.menuHideNonFittingExperiments.Size = new System.Drawing.Size(523, 22);
            this.menuHideNonFittingExperiments.Text = "Спрятать эксперименты, отсеянные по функциональным ограничениям";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // buttonOptimizationParameters
            // 
            this.buttonOptimizationParameters.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonOptimizationParameters.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuOptimizationParametersShowAll,
            this.menuOptimizationParametersHideAll,
            this.toolStripSeparator3});
            this.buttonOptimizationParameters.Image = global::opt.Properties.Resources.table_param;
            this.buttonOptimizationParameters.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonOptimizationParameters.Name = "buttonOptimizationParameters";
            this.buttonOptimizationParameters.Size = new System.Drawing.Size(29, 22);
            this.buttonOptimizationParameters.Text = "Оптимизируемые параметры";
            // 
            // menuOptimizationParametersShowAll
            // 
            this.menuOptimizationParametersShowAll.Name = "menuOptimizationParametersShowAll";
            this.menuOptimizationParametersShowAll.Size = new System.Drawing.Size(145, 22);
            this.menuOptimizationParametersShowAll.Text = "Показать все";
            // 
            // menuOptimizationParametersHideAll
            // 
            this.menuOptimizationParametersHideAll.Name = "menuOptimizationParametersHideAll";
            this.menuOptimizationParametersHideAll.Size = new System.Drawing.Size(145, 22);
            this.menuOptimizationParametersHideAll.Text = "Скрыть все";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(142, 6);
            // 
            // buttonIdentificationParameters
            // 
            this.buttonIdentificationParameters.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonIdentificationParameters.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuIdentificationParametersShowAll,
            this.menuIdentificationParametersHideAll,
            this.toolStripSeparator4});
            this.buttonIdentificationParameters.Image = global::opt.Properties.Resources.table_param_ident;
            this.buttonIdentificationParameters.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonIdentificationParameters.Name = "buttonIdentificationParameters";
            this.buttonIdentificationParameters.Size = new System.Drawing.Size(29, 22);
            this.buttonIdentificationParameters.Text = "Идентифицируемые параметры";
            // 
            // menuIdentificationParametersShowAll
            // 
            this.menuIdentificationParametersShowAll.Name = "menuIdentificationParametersShowAll";
            this.menuIdentificationParametersShowAll.Size = new System.Drawing.Size(145, 22);
            this.menuIdentificationParametersShowAll.Text = "Показать все";
            // 
            // menuIdentificationParametersHideAll
            // 
            this.menuIdentificationParametersHideAll.Name = "menuIdentificationParametersHideAll";
            this.menuIdentificationParametersHideAll.Size = new System.Drawing.Size(145, 22);
            this.menuIdentificationParametersHideAll.Text = "Скрыть все";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(142, 6);
            // 
            // buttonFunctionalConstraints
            // 
            this.buttonFunctionalConstraints.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonFunctionalConstraints.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuFunctionalConstraintsShowAll,
            this.menuFunctionalConstraintsHideAll,
            this.toolStripSeparator5});
            this.buttonFunctionalConstraints.Image = global::opt.Properties.Resources.table_fc;
            this.buttonFunctionalConstraints.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonFunctionalConstraints.Name = "buttonFunctionalConstraints";
            this.buttonFunctionalConstraints.Size = new System.Drawing.Size(29, 22);
            this.buttonFunctionalConstraints.Text = "Функциональные ограничения";
            // 
            // menuFunctionalConstraintsShowAll
            // 
            this.menuFunctionalConstraintsShowAll.Name = "menuFunctionalConstraintsShowAll";
            this.menuFunctionalConstraintsShowAll.Size = new System.Drawing.Size(145, 22);
            this.menuFunctionalConstraintsShowAll.Text = "Показать все";
            // 
            // menuFunctionalConstraintsHideAll
            // 
            this.menuFunctionalConstraintsHideAll.Name = "menuFunctionalConstraintsHideAll";
            this.menuFunctionalConstraintsHideAll.Size = new System.Drawing.Size(145, 22);
            this.menuFunctionalConstraintsHideAll.Text = "Скрыть все";
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(142, 6);
            // 
            // buttonRealCriteria
            // 
            this.buttonRealCriteria.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonRealCriteria.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuRealCriteriaShowAll,
            this.menuRealCriteriaHideAll,
            this.toolStripSeparator6});
            this.buttonRealCriteria.Image = global::opt.Properties.Resources.table_crit_real;
            this.buttonRealCriteria.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonRealCriteria.Name = "buttonRealCriteria";
            this.buttonRealCriteria.Size = new System.Drawing.Size(29, 22);
            this.buttonRealCriteria.Text = "Экспериментальные значения критериев";
            // 
            // menuRealCriteriaShowAll
            // 
            this.menuRealCriteriaShowAll.Name = "menuRealCriteriaShowAll";
            this.menuRealCriteriaShowAll.Size = new System.Drawing.Size(145, 22);
            this.menuRealCriteriaShowAll.Text = "Показать все";
            // 
            // menuRealCriteriaHideAll
            // 
            this.menuRealCriteriaHideAll.Name = "menuRealCriteriaHideAll";
            this.menuRealCriteriaHideAll.Size = new System.Drawing.Size(145, 22);
            this.menuRealCriteriaHideAll.Text = "Скрыть все";
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(142, 6);
            // 
            // buttonMathematicalCriteria
            // 
            this.buttonMathematicalCriteria.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonMathematicalCriteria.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuMathematicalCriteriaShowAll,
            this.menuMathematicalCriteriaHideAll,
            this.toolStripSeparator7});
            this.buttonMathematicalCriteria.Image = global::opt.Properties.Resources.table_crit_math;
            this.buttonMathematicalCriteria.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonMathematicalCriteria.Name = "buttonMathematicalCriteria";
            this.buttonMathematicalCriteria.Size = new System.Drawing.Size(29, 22);
            this.buttonMathematicalCriteria.Text = "Значения критериев математической модели";
            // 
            // menuMathematicalCriteriaShowAll
            // 
            this.menuMathematicalCriteriaShowAll.Name = "menuMathematicalCriteriaShowAll";
            this.menuMathematicalCriteriaShowAll.Size = new System.Drawing.Size(145, 22);
            this.menuMathematicalCriteriaShowAll.Text = "Показать все";
            // 
            // menuMathematicalCriteriaHideAll
            // 
            this.menuMathematicalCriteriaHideAll.Name = "menuMathematicalCriteriaHideAll";
            this.menuMathematicalCriteriaHideAll.Size = new System.Drawing.Size(145, 22);
            this.menuMathematicalCriteriaHideAll.Text = "Скрыть все";
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(142, 6);
            // 
            // buttonAdequacyCriteria
            // 
            this.buttonAdequacyCriteria.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonAdequacyCriteria.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuAdequacyCriteriaShowAll,
            this.menuAdequacyCriteriaHideAll,
            this.toolStripSeparator8});
            this.buttonAdequacyCriteria.Image = global::opt.Properties.Resources.table_crit_adeq;
            this.buttonAdequacyCriteria.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonAdequacyCriteria.Name = "buttonAdequacyCriteria";
            this.buttonAdequacyCriteria.Size = new System.Drawing.Size(29, 22);
            this.buttonAdequacyCriteria.Text = "Критерии адекватности";
            // 
            // menuAdequacyCriteriaShowAll
            // 
            this.menuAdequacyCriteriaShowAll.Name = "menuAdequacyCriteriaShowAll";
            this.menuAdequacyCriteriaShowAll.Size = new System.Drawing.Size(145, 22);
            this.menuAdequacyCriteriaShowAll.Text = "Показать все";
            // 
            // menuAdequacyCriteriaHideAll
            // 
            this.menuAdequacyCriteriaHideAll.Name = "menuAdequacyCriteriaHideAll";
            this.menuAdequacyCriteriaHideAll.Size = new System.Drawing.Size(145, 22);
            this.menuAdequacyCriteriaHideAll.Text = "Скрыть все";
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(142, 6);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // buttonRefresh
            // 
            this.buttonRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonRefresh.Image = global::opt.Properties.Resources.table_refresh;
            this.buttonRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonRefresh.Name = "buttonRefresh";
            this.buttonRefresh.Size = new System.Drawing.Size(23, 22);
            this.buttonRefresh.Text = "Обновить таблицу";
            // 
            // dgvResults
            // 
            this.dgvResults.AllowUserToAddRows = false;
            this.dgvResults.AllowUserToDeleteRows = false;
            this.dgvResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvResults.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colIdReadExp,
            this.colIdIdentificationExp,
            this.colRealExperiment,
            this.colIndentificationExperiment});
            this.dgvResults.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvResults.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvResults.Location = new System.Drawing.Point(0, 0);
            this.dgvResults.Name = "dgvResults";
            this.dgvResults.ReadOnly = true;
            this.dgvResults.RowHeadersVisible = false;
            this.dgvResults.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvResults.Size = new System.Drawing.Size(760, 507);
            this.dgvResults.TabIndex = 11;
            // 
            // colIdReadExp
            // 
            this.colIdReadExp.HeaderText = "IdReadExp";
            this.colIdReadExp.Name = "colIdReadExp";
            this.colIdReadExp.ReadOnly = true;
            this.colIdReadExp.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colIdReadExp.Visible = false;
            // 
            // colIdIdentificationExp
            // 
            this.colIdIdentificationExp.HeaderText = "IdIdentificationExp";
            this.colIdIdentificationExp.Name = "colIdIdentificationExp";
            this.colIdIdentificationExp.ReadOnly = true;
            this.colIdIdentificationExp.Visible = false;
            // 
            // colRealExperiment
            // 
            this.colRealExperiment.HeaderText = "Номер реального эксперимента";
            this.colRealExperiment.MinimumWidth = 100;
            this.colRealExperiment.Name = "colRealExperiment";
            this.colRealExperiment.ReadOnly = true;
            this.colRealExperiment.Width = 150;
            // 
            // colIndentificationExperiment
            // 
            this.colIndentificationExperiment.HeaderText = "Номер индентификационного эксперимента";
            this.colIndentificationExperiment.MinimumWidth = 100;
            this.colIndentificationExperiment.Name = "colIndentificationExperiment";
            this.colIndentificationExperiment.ReadOnly = true;
            this.colIndentificationExperiment.Width = 150;
            // 
            // buttonSave
            // 
            this.buttonSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSave.Image = global::opt.Properties.Resources.disk;
            this.buttonSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonSave.Location = new System.Drawing.Point(497, 525);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(98, 25);
            this.buttonSave.TabIndex = 4;
            this.buttonSave.Text = "Сохранить...";
            this.buttonSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // dialogSaveModel
            // 
            this.dialogSaveModel.Filter = "Файл модели (*.xml)|*.xml|Файл модели ОРТ (*.xml)|*.xml|Все файлы (*.*)|*.*";
            // 
            // ViewCalculatedResults
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.buttonSave);
            this.Name = "ViewCalculatedResults";
            this.Text = "Результаты расчета - матрица решений";
            this.Controls.SetChildIndex(this.btnExit, 0);
            this.Controls.SetChildIndex(this.btnPrevious, 0);
            this.Controls.SetChildIndex(this.btnNext, 0);
            this.Controls.SetChildIndex(this.panWorkspace, 0);
            this.Controls.SetChildIndex(this.buttonSave, 0);
            this.panWorkspace.ResumeLayout(false);
            this.panWorkspace.PerformLayout();
            this.tlbOptions.ResumeLayout(false);
            this.tlbOptions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResults)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvResults;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdReadExp;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdIdentificationExp;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRealExperiment;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIndentificationExperiment;
        private System.Windows.Forms.ToolStrip tlbOptions;
        private System.Windows.Forms.ToolStripDropDownButton buttonRowsOptions;
        private System.Windows.Forms.ToolStripMenuItem menuApplyFunctionalConstraints;
        private System.Windows.Forms.ToolStripMenuItem menuHideNonFittingExperiments;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripDropDownButton buttonOptimizationParameters;
        private System.Windows.Forms.ToolStripDropDownButton buttonIdentificationParameters;
        private System.Windows.Forms.ToolStripDropDownButton buttonFunctionalConstraints;
        private System.Windows.Forms.ToolStripDropDownButton buttonRealCriteria;
        private System.Windows.Forms.ToolStripDropDownButton buttonMathematicalCriteria;
        private System.Windows.Forms.ToolStripDropDownButton buttonAdequacyCriteria;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton buttonRefresh;
        private System.Windows.Forms.ToolStripMenuItem menuOptimizationParametersShowAll;
        private System.Windows.Forms.ToolStripMenuItem menuOptimizationParametersHideAll;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem menuIdentificationParametersShowAll;
        private System.Windows.Forms.ToolStripMenuItem menuIdentificationParametersHideAll;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem menuFunctionalConstraintsShowAll;
        private System.Windows.Forms.ToolStripMenuItem menuFunctionalConstraintsHideAll;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem menuRealCriteriaShowAll;
        private System.Windows.Forms.ToolStripMenuItem menuRealCriteriaHideAll;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripMenuItem menuMathematicalCriteriaShowAll;
        private System.Windows.Forms.ToolStripMenuItem menuMathematicalCriteriaHideAll;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripMenuItem menuAdequacyCriteriaShowAll;
        private System.Windows.Forms.ToolStripMenuItem menuAdequacyCriteriaHideAll;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.SaveFileDialog dialogSaveModel;


    }
}