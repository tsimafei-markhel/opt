namespace opt.Solvers.Formal
{
    partial class IdealPointForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.colCriterionId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCriterionName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnOK = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(337, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Введите значения критериев оптимальности для идеальной точки:";
            // 
            // dgvData
            // 
            this.dgvData.AllowUserToAddRows = false;
            this.dgvData.AllowUserToDeleteRows = false;
            this.dgvData.AllowUserToResizeRows = false;
            this.dgvData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colCriterionId,
            this.colCriterionName,
            this.colValue});
            this.dgvData.Location = new System.Drawing.Point(15, 25);
            this.dgvData.MultiSelect = false;
            this.dgvData.Name = "dgvData";
            this.dgvData.RowHeadersVisible = false;
            this.dgvData.Size = new System.Drawing.Size(400, 392);
            this.dgvData.TabIndex = 0;
            // 
            // colCriterionId
            // 
            this.colCriterionId.HeaderText = "ID";
            this.colCriterionId.Name = "colCriterionId";
            this.colCriterionId.Visible = false;
            this.colCriterionId.Width = 24;
            // 
            // colCriterionName
            // 
            this.colCriterionName.HeaderText = "Название критерия";
            this.colCriterionName.Name = "colCriterionName";
            this.colCriterionName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colCriterionName.Width = 102;
            // 
            // colValue
            // 
            this.colValue.HeaderText = "Значения критерия";
            this.colValue.Name = "colValue";
            this.colValue.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(340, 431);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "ОК";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(12, 420);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(319, 37);
            this.label2.TabIndex = 3;
            this.label2.Text = "В качестве значений по умолчанию взяты лучшие значения критериев оптимальности из м" +
                "атрицы решений";
            // 
            // IdealPointForm
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(427, 466);
            this.ControlBox = false;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.dgvData);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "IdealPointForm";
            this.Text = "Координаты идеальной точки";
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvData;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCriterionId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCriterionName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colValue;
    }
}