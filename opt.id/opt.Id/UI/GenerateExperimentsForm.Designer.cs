namespace opt.UI
{
    partial class GenerateExperimentsForm
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
            this.numericNumberOfExperiments = new System.Windows.Forms.NumericUpDown();
            this.radioAutomatic = new System.Windows.Forms.RadioButton();
            this.radioManual = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.panWorkspace.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericNumberOfExperiments)).BeginInit();
            this.SuspendLayout();
            // 
            // panWorkspace
            // 
            this.panWorkspace.Controls.Add(this.label2);
            this.panWorkspace.Controls.Add(this.radioManual);
            this.panWorkspace.Controls.Add(this.radioAutomatic);
            this.panWorkspace.Controls.Add(this.numericNumberOfExperiments);
            this.panWorkspace.Controls.Add(this.label1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(46, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(151, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Количество экспериментов:";
            // 
            // numericNumberOfExperiments
            // 
            this.numericNumberOfExperiments.Location = new System.Drawing.Point(203, 48);
            this.numericNumberOfExperiments.Maximum = new decimal(new int[] {
            3000,
            0,
            0,
            0});
            this.numericNumberOfExperiments.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numericNumberOfExperiments.Name = "numericNumberOfExperiments";
            this.numericNumberOfExperiments.Size = new System.Drawing.Size(60, 20);
            this.numericNumberOfExperiments.TabIndex = 0;
            this.numericNumberOfExperiments.Value = new decimal(new int[] {
            25,
            0,
            0,
            0});
            // 
            // radioAutomatic
            // 
            this.radioAutomatic.AutoSize = true;
            this.radioAutomatic.Checked = true;
            this.radioAutomatic.Location = new System.Drawing.Point(49, 95);
            this.radioAutomatic.Name = "radioAutomatic";
            this.radioAutomatic.Size = new System.Drawing.Size(398, 17);
            this.radioAutomatic.TabIndex = 1;
            this.radioAutomatic.TabStop = true;
            this.radioAutomatic.Text = "Сгенерировать значения идентифицируемых параметров автоматически";
            this.radioAutomatic.UseVisualStyleBackColor = true;
            // 
            // radioManual
            // 
            this.radioManual.AutoSize = true;
            this.radioManual.Enabled = false;
            this.radioManual.Location = new System.Drawing.Point(49, 130);
            this.radioManual.Name = "radioManual";
            this.radioManual.Size = new System.Drawing.Size(321, 17);
            this.radioManual.TabIndex = 2;
            this.radioManual.Text = "Ввести значения идентифицируемых параметров вручную";
            this.radioManual.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Gray;
            this.label2.Location = new System.Drawing.Point(269, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(209, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "(для каждого реального эксперимента)";
            // 
            // GenerateExperimentsForm
            // 
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Name = "GenerateExperimentsForm";
            this.Text = "Выбор способа задания значений идентифицируемых параметров";
            this.panWorkspace.ResumeLayout(false);
            this.panWorkspace.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericNumberOfExperiments)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RadioButton radioManual;
        private System.Windows.Forms.RadioButton radioAutomatic;
        private System.Windows.Forms.NumericUpDown numericNumberOfExperiments;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}
