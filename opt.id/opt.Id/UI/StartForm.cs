using System;
using System.Windows.Forms;
using opt.Helpers;
using opt.Xml;

namespace opt.UI
{
    public partial class StartForm : OptIdFormBase
    {
        public StartForm()
        {
            InitializeComponent();
        }

        private void buttonChooseModelFile_Click(object sender, EventArgs e)
        {
            if (dialogModelFile.ShowDialog() == DialogResult.OK)
            {
                textModelFile.Text = dialogModelFile.FileName;
                dialogModelFile.FileName = string.Empty;
            }
        }

        protected override void btnNext_Click(object sender, EventArgs e)
        {
            // Choose next form and do the job
            if (radioCreate.Checked)
            {
                nextForm = new OptimizationParametersForm(this);
            }
            else if (radioLoad.Checked)
            {
                // TODO: Should we check input and provide detailed localized info on the error 
                // or just let corresponding exception be thrown and show its message to the user?
                try
                {
                    ModelStorage.Instance.Model = XmlIdentificationModelProvider.Open(textModelFile.Text);
                    nextForm = new OptimizationParametersForm(this);
                }
                catch (Exception ex)
                {
                    MessageBoxHelper.ShowError(ex.Message);
                    return;
                }
            }
            else
            {
                return;
            }

            // Let's have this for now - later will decide based on the type and contents of the model file
            //nextForm = new OptimizationParametersForm(this);

            // Now call base implementation - it is responsible for forms rotation
            base.btnNext_Click(sender, e);
        }

        private void radioLoad_CheckedChanged(object sender, EventArgs e)
        {
            label1.Enabled = radioLoad.Checked;
            textModelFile.Enabled = radioLoad.Checked;
            buttonChooseModelFile.Enabled = radioLoad.Checked;
        }
    }
}