using System;
using System.Windows.Forms;

namespace opt.UI
{
    /// <summary>
    /// Form template to be used for all opt.id forms (Previous/Next buttons, window size etc.)
    /// </summary>
    public class OptIdFormBase : Form
    {
        protected Button btnExit;
        protected Button btnPrevious;
        protected Button btnNext;
        protected Panel panWorkspace;

        protected OptIdFormBase nextForm;
        protected OptIdFormBase previousForm;

        public OptIdFormBase()
        {
            InitializeComponent();
        }

        protected OptIdFormBase(OptIdFormBase previous)
        {
            InitializeComponent();

            previousForm = previous;
        }

        private void InitializeComponent()
        {
            this.btnExit = new System.Windows.Forms.Button();
            this.btnPrevious = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.panWorkspace = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnExit.Location = new System.Drawing.Point(12, 525);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 25);
            this.btnExit.TabIndex = 2;
            this.btnExit.Text = "Выход";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnPrevious
            // 
            this.btnPrevious.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrevious.Location = new System.Drawing.Point(616, 525);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(75, 25);
            this.btnPrevious.TabIndex = 0;
            this.btnPrevious.Text = "Назад";
            this.btnPrevious.UseVisualStyleBackColor = true;
            this.btnPrevious.Click += new System.EventHandler(this.btnPrevious_Click);
            // 
            // btnNext
            // 
            this.btnNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNext.Location = new System.Drawing.Point(697, 525);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(75, 25);
            this.btnNext.TabIndex = 1;
            this.btnNext.Text = "Далее";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // panWorkspace
            // 
            this.panWorkspace.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panWorkspace.Location = new System.Drawing.Point(12, 12);
            this.panWorkspace.Name = "panWorkspace";
            this.panWorkspace.Size = new System.Drawing.Size(760, 507);
            this.panWorkspace.TabIndex = 3;
            // 
            // OptIdFormBase
            // 
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.panWorkspace);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnPrevious);
            this.Controls.Add(this.btnExit);
            this.MinimumSize = new System.Drawing.Size(500, 400);
            this.Name = "OptIdFormBase";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OptIdFormBase_FormClosing);
            this.ResumeLayout(false);
        }

        protected virtual void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        protected virtual void OptIdFormBase_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        protected virtual void btnPrevious_Click(object sender, EventArgs e)
        {
            previousForm.AdjustFormParameters(this);

            previousForm.Show();
            Hide();
        }

        protected virtual void btnNext_Click(object sender, EventArgs e)
        {
            if (nextForm != null)
            {
                nextForm.AdjustFormParameters(this);
                nextForm.Show();
                Hide();
            }
        }

        /// <summary>
        /// Copies some window parameters from <paramref name="copyFrom"/>
        /// </summary>
        /// <param name="copyFrom"><see cref="OptIdFormBase"/> instance to copy window parameters from</param>
        /// <remarks>Copies: <see cref="Form.Left"/> and <see cref="Form.Top"/>; <see cref="Form.WindowState"/> 
        /// (if <see cref="Form.FormBorderStyle"/> is not <see cref="FormBorderStyle.FixedSingle"/>); 
        /// <see cref="Form.Width"/> and <see cref="Form.Height"/> (if <see cref="Form.WindowState"/> 
        /// is <see cref="FormWindowState.Normal"/>)</remarks>
        protected virtual void AdjustFormParameters(OptIdFormBase copyFrom)
        {
            Left = copyFrom.Left;
            Top = copyFrom.Top;

            if (FormBorderStyle != FormBorderStyle.FixedSingle)
            {
                WindowState = copyFrom.WindowState;
            }

            if (WindowState == FormWindowState.Normal)
            {
                Width = copyFrom.Width;
                Height = copyFrom.Height;
            }
        }
    }
}