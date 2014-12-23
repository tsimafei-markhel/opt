using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using opt.Helpers;
using opt.Id;
using opt.Solvers;
using opt.Xml;

namespace opt.UI
{
    public partial class RunCalculationForm : OptIdFormBase
    {
        public RunCalculationForm()
        {
            InitializeComponent();
        }

        public RunCalculationForm(OptIdFormBase previous) 
            : base(previous)
        {
            InitializeComponent();
            AdjustFormParameters(previous);
        }

        private void buttonChooseExchangeFile_Click(object sender, EventArgs e)
        {
            if (dialogExchangeFile.ShowDialog() == DialogResult.OK)
            {
                textExchangeFilePath.Text = dialogExchangeFile.FileName;
                dialogExchangeFile.FileName = string.Empty;
            }
        }

        private void buttonChooseExternalApp_Click(object sender, EventArgs e)
        {
            if (dialogExternalApp.ShowDialog() == DialogResult.OK)
            {
                textExternalAppPath.Text = dialogExternalApp.FileName;
                dialogExternalApp.FileName = string.Empty;
            }
        }

        protected override void btnNext_Click(object sender, EventArgs e)
        {
            // Choose next form and do the job
            if (radioExternalApp.Checked)
            {
                RunExternalApp();
                return;
            }
            else if (radioManual.Checked)
            {
                // TODO
                return;

                // Now call base implementation - it is responsible for forms rotation
                // Note: It is unreachable for now, but let's keep it for future use
                //base.btnNext_Click(sender, e);
            }
        }

        #region External Application handling

        private void RunExternalApp()
        {
            string exchangeFilePath = textExchangeFilePath.Text.Trim();
            string externalAppPath = textExternalAppPath.Text.Trim();

            // Validate input
            if (string.IsNullOrEmpty(exchangeFilePath))
            {
                MessageBoxHelper.ShowExclamation("Укажите файл для обмена данными с расчетной программой.");
                return;
            }

            if (string.IsNullOrEmpty(externalAppPath))
            {
                MessageBoxHelper.ShowExclamation("Укажите исполняемый файл расчетной программы.");
                return;
            }

#if !DEBUG
            DialogResult result = MessageBox.Show("Запустить расчетную программу?\nПриложение перейдет в режим ожидания до завершения расчета.",
                Program.ApplicationSettings.ApplicationName, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (result == DialogResult.Yes)
            {
#else
            if (true)
            {
#endif
                // Disable user
                ToggleUserControls(false);

                // Save model to exchange file
                WriteExchangeFile(exchangeFilePath);

                // Run external app
                ProcessStartInfo externalAppInfo = new ProcessStartInfo();
                externalAppInfo.FileName = externalAppPath;
                externalAppInfo.Arguments = "\"" + exchangeFilePath + "\"";
                externalAppInfo.UseShellExecute = false;

                Process extAppProc = Process.Start(externalAppInfo);
                extAppProc.EnableRaisingEvents = true;
                extAppProc.Exited += new EventHandler(ExternalApp_Exited);
            }
        }

        private void ExternalApp_Exited(object sender, EventArgs e)
        {
            try
            {
                string exchangeFilePath = textExchangeFilePath.Text.Trim();

                // Update model
                if (File.Exists(exchangeFilePath))
                {
                    ModelStorage.Instance.Model = XmlIdentificationModelProvider.Open(exchangeFilePath);
                    ResidualFinder.CalculateAdequacyCriteriaValues(ModelStorage.Instance.Model);
                }

                // Invoke form's method to handle external app exit
                // This is needed because ExternalApp_Exited is invoked in another
                // thread (not in UI thread)
                Invoke(new Action(ExternalAppFinished));
            }
            catch (Exception ex)
            {
                MessageBoxHelper.ShowError(ex.Message);
            }
        }

        private void ExternalAppFinished()
        {
            nextForm = new ViewCalculatedResults(this);
            ToggleUserControls(true);
            base.btnNext_Click(this, new EventArgs());
        }

        private void WriteExchangeFile(string exchangeFilePath)
        {
            XmlIdentificationModelProvider.Save(ModelStorage.Instance.Model, exchangeFilePath);

            while (!File.Exists(exchangeFilePath))
            {
                Thread.Sleep(500);
            }
        }

        private void ToggleUserControls(bool enabled)
        {
            panWorkspace.Enabled = enabled;
            btnNext.Enabled = enabled;
            btnPrevious.Enabled = enabled;
        }

        #endregion

    }
}