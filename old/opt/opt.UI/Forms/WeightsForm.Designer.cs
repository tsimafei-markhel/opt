namespace opt.UI.Forms
{
    partial class WeightsForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.panWorkspace = new System.Windows.Forms.Panel();
            this.rbnGeneticAlgorithm = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.rbnMiniMax = new System.Windows.Forms.RadioButton();
            this.rbnMultiplicativeCriterion = new System.Windows.Forms.RadioButton();
            this.rbnAdditiveCriterion = new System.Windows.Forms.RadioButton();
            this.chbUtilityFunction = new System.Windows.Forms.CheckBox();
            this.dgvWeights = new System.Windows.Forms.DataGridView();
            this.colCriterionId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCriterionName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCriterionWeight = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.btnPrevious = new System.Windows.Forms.Button();
            this.btnShowMatrixForm = new System.Windows.Forms.Button();
            this.btnSaveMatrix = new System.Windows.Forms.Button();
            this.dlgSaveModel = new System.Windows.Forms.SaveFileDialog();
            this.panWorkspace.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvWeights)).BeginInit();
            this.SuspendLayout();
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnExit.Location = new System.Drawing.Point(12, 527);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 27);
            this.btnExit.TabIndex = 5;
            this.btnExit.Text = "Выход";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnNext
            // 
            this.btnNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNext.Image = global::opt.UI.Properties.Resources.next;
            this.btnNext.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNext.Location = new System.Drawing.Point(705, 527);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(75, 27);
            this.btnNext.TabIndex = 4;
            this.btnNext.Text = "Далее";
            this.btnNext.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // panWorkspace
            // 
            this.panWorkspace.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panWorkspace.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panWorkspace.BackColor = System.Drawing.SystemColors.Control;
            this.panWorkspace.Controls.Add(this.rbnGeneticAlgorithm);
            this.panWorkspace.Controls.Add(this.label1);
            this.panWorkspace.Controls.Add(this.rbnMiniMax);
            this.panWorkspace.Controls.Add(this.rbnMultiplicativeCriterion);
            this.panWorkspace.Controls.Add(this.rbnAdditiveCriterion);
            this.panWorkspace.Controls.Add(this.chbUtilityFunction);
            this.panWorkspace.Controls.Add(this.dgvWeights);
            this.panWorkspace.Location = new System.Drawing.Point(12, 12);
            this.panWorkspace.Name = "panWorkspace";
            this.panWorkspace.Size = new System.Drawing.Size(768, 509);
            this.panWorkspace.TabIndex = 0;
            // 
            // rbnGeneticAlgorithm
            // 
            this.rbnGeneticAlgorithm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rbnGeneticAlgorithm.AutoSize = true;
            this.rbnGeneticAlgorithm.Location = new System.Drawing.Point(474, 209);
            this.rbnGeneticAlgorithm.Name = "rbnGeneticAlgorithm";
            this.rbnGeneticAlgorithm.Size = new System.Drawing.Size(221, 17);
            this.rbnGeneticAlgorithm.TabIndex = 5;
            this.rbnGeneticAlgorithm.Text = "Использовать генетический алгоритм";
            this.rbnGeneticAlgorithm.UseVisualStyleBackColor = true;
            this.rbnGeneticAlgorithm.CheckedChanged += new System.EventHandler(this.rbnGeneticAlgorithm_CheckedChanged);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(471, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(199, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Выберите способ свертки критериев:";
            // 
            // rbnMiniMax
            // 
            this.rbnMiniMax.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rbnMiniMax.AutoSize = true;
            this.rbnMiniMax.Location = new System.Drawing.Point(474, 158);
            this.rbnMiniMax.Name = "rbnMiniMax";
            this.rbnMiniMax.Size = new System.Drawing.Size(118, 17);
            this.rbnMiniMax.TabIndex = 4;
            this.rbnMiniMax.Text = "Метод минимакса";
            this.rbnMiniMax.UseVisualStyleBackColor = true;
            // 
            // rbnMultiplicativeCriterion
            // 
            this.rbnMultiplicativeCriterion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rbnMultiplicativeCriterion.AutoSize = true;
            this.rbnMultiplicativeCriterion.Location = new System.Drawing.Point(487, 73);
            this.rbnMultiplicativeCriterion.Name = "rbnMultiplicativeCriterion";
            this.rbnMultiplicativeCriterion.Size = new System.Drawing.Size(179, 17);
            this.rbnMultiplicativeCriterion.TabIndex = 2;
            this.rbnMultiplicativeCriterion.Text = "Мультипликативный критерий";
            this.rbnMultiplicativeCriterion.UseVisualStyleBackColor = true;
            // 
            // rbnAdditiveCriterion
            // 
            this.rbnAdditiveCriterion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rbnAdditiveCriterion.AutoSize = true;
            this.rbnAdditiveCriterion.Checked = true;
            this.rbnAdditiveCriterion.Location = new System.Drawing.Point(487, 45);
            this.rbnAdditiveCriterion.Name = "rbnAdditiveCriterion";
            this.rbnAdditiveCriterion.Size = new System.Drawing.Size(137, 17);
            this.rbnAdditiveCriterion.TabIndex = 1;
            this.rbnAdditiveCriterion.TabStop = true;
            this.rbnAdditiveCriterion.Text = "Аддитивный критерий";
            this.rbnAdditiveCriterion.UseVisualStyleBackColor = true;
            // 
            // chbUtilityFunction
            // 
            this.chbUtilityFunction.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chbUtilityFunction.AutoSize = true;
            this.chbUtilityFunction.Location = new System.Drawing.Point(487, 107);
            this.chbUtilityFunction.Name = "chbUtilityFunction";
            this.chbUtilityFunction.Size = new System.Drawing.Size(278, 17);
            this.chbUtilityFunction.TabIndex = 3;
            this.chbUtilityFunction.Text = "Задать функцию полезности на следующем шаге";
            this.chbUtilityFunction.UseVisualStyleBackColor = true;
            // 
            // dgvWeights
            // 
            this.dgvWeights.AllowUserToAddRows = false;
            this.dgvWeights.AllowUserToDeleteRows = false;
            this.dgvWeights.AllowUserToResizeRows = false;
            this.dgvWeights.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvWeights.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvWeights.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvWeights.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colCriterionId,
            this.colCriterionName,
            this.colCriterionWeight});
            this.dgvWeights.Location = new System.Drawing.Point(3, 3);
            this.dgvWeights.Name = "dgvWeights";
            this.dgvWeights.RowHeadersVisible = false;
            this.dgvWeights.Size = new System.Drawing.Size(450, 503);
            this.dgvWeights.TabIndex = 0;
            this.dgvWeights.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dgvWeights_CellValidating);
            // 
            // colCriterionId
            // 
            this.colCriterionId.HeaderText = "ID";
            this.colCriterionId.Name = "colCriterionId";
            this.colCriterionId.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colCriterionId.Visible = false;
            this.colCriterionId.Width = 24;
            // 
            // colCriterionName
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightGray;
            this.colCriterionName.DefaultCellStyle = dataGridViewCellStyle1;
            this.colCriterionName.HeaderText = "Название критерия";
            this.colCriterionName.Name = "colCriterionName";
            this.colCriterionName.ReadOnly = true;
            this.colCriterionName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colCriterionName.Width = 102;
            // 
            // colCriterionWeight
            // 
            this.colCriterionWeight.HeaderText = "Весовой коэффициент";
            this.colCriterionWeight.MaxDropDownItems = 10;
            this.colCriterionWeight.Name = "colCriterionWeight";
            this.colCriterionWeight.Width = 115;
            // 
            // btnPrevious
            // 
            this.btnPrevious.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrevious.Image = global::opt.UI.Properties.Resources.previous;
            this.btnPrevious.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPrevious.Location = new System.Drawing.Point(624, 527);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(75, 27);
            this.btnPrevious.TabIndex = 3;
            this.btnPrevious.Text = "Назад";
            this.btnPrevious.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPrevious.UseVisualStyleBackColor = true;
            this.btnPrevious.Click += new System.EventHandler(this.btnPrevious_Click);
            // 
            // btnShowMatrixForm
            // 
            this.btnShowMatrixForm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnShowMatrixForm.Image = global::opt.UI.Properties.Resources.table;
            this.btnShowMatrixForm.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnShowMatrixForm.Location = new System.Drawing.Point(366, 527);
            this.btnShowMatrixForm.Name = "btnShowMatrixForm";
            this.btnShowMatrixForm.Size = new System.Drawing.Size(124, 27);
            this.btnShowMatrixForm.TabIndex = 1;
            this.btnShowMatrixForm.Text = "Матрица решений";
            this.btnShowMatrixForm.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnShowMatrixForm.UseVisualStyleBackColor = true;
            this.btnShowMatrixForm.Click += new System.EventHandler(this.btnShowMatrixForm_Click);
            // 
            // btnSaveMatrix
            // 
            this.btnSaveMatrix.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveMatrix.Image = global::opt.UI.Properties.Resources.disk;
            this.btnSaveMatrix.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSaveMatrix.Location = new System.Drawing.Point(496, 527);
            this.btnSaveMatrix.Name = "btnSaveMatrix";
            this.btnSaveMatrix.Size = new System.Drawing.Size(87, 27);
            this.btnSaveMatrix.TabIndex = 2;
            this.btnSaveMatrix.Text = "Сохранить";
            this.btnSaveMatrix.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSaveMatrix.UseVisualStyleBackColor = true;
            this.btnSaveMatrix.Click += new System.EventHandler(this.btnSaveMatrix_Click);
            // 
            // dlgSaveModel
            // 
            this.dlgSaveModel.Filter = "Файл матрицы решений (*.xml)|*.xml|Все файлы (*.*)|*.*";
            this.dlgSaveModel.Title = "Сохранить матрицу решений в файл...";
            // 
            // WeightsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 566);
            this.Controls.Add(this.btnSaveMatrix);
            this.Controls.Add(this.btnShowMatrixForm);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.panWorkspace);
            this.Controls.Add(this.btnPrevious);
            this.MinimumSize = new System.Drawing.Size(500, 500);
            this.Name = "WeightsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Весовые коэффициенты критериев оптимальности";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.WeightsForm_FormClosing);
            this.panWorkspace.ResumeLayout(false);
            this.panWorkspace.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvWeights)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Panel panWorkspace;
        private System.Windows.Forms.DataGridView dgvWeights;
        private System.Windows.Forms.Button btnPrevious;
        private System.Windows.Forms.Button btnShowMatrixForm;
        private System.Windows.Forms.Button btnSaveMatrix;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rbnMiniMax;
        private System.Windows.Forms.RadioButton rbnMultiplicativeCriterion;
        private System.Windows.Forms.RadioButton rbnAdditiveCriterion;
        private System.Windows.Forms.CheckBox chbUtilityFunction;
        private System.Windows.Forms.SaveFileDialog dlgSaveModel;
        private System.Windows.Forms.RadioButton rbnGeneticAlgorithm;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCriterionId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCriterionName;
        private System.Windows.Forms.DataGridViewComboBoxColumn colCriterionWeight;
    }
}