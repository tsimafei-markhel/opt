using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mathcad.connector
{
    public partial class MainForm : Form
    {
        private const string appName = "Mathcad connector";

        private CancellationTokenSource cancellator;

        public MainForm(string modelFilePath, string mathcadFilePath)
        {
            InitializeComponent();

            Text = appName;

            if (!string.IsNullOrEmpty(modelFilePath))
            {
                optFile.Text = modelFilePath;
            }

            if (!string.IsNullOrEmpty(mathcadFilePath))
            {
                mathcadFile.Text = mathcadFilePath;
            }
        }

        private void chooseMathcadFile_Click(object sender, EventArgs e)
        {
            openFileDialog.Filter = "Mathcad XML files (*.xmcd)|*.xmcd|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                mathcadFile.Text = openFileDialog.FileName;
            }
        }

        private void chooseOptFile_Click(object sender, EventArgs e)
        {
            openFileDialog.Filter = "OPT model files (*.xml)|*.xml|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                optFile.Text = openFileDialog.FileName;
            }
        }

        private void exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void mathcadFile_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(mathcadFile.Text))
            {
                errorProvider.SetError(mathcadFile, "Specify Mathcad 15 file path");
                e.Cancel = true;
                return;
            }
        }

        private void mathcadFile_Validated(object sender, EventArgs e)
        {
            errorProvider.SetError(mathcadFile, string.Empty);
        }

        private void optFile_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(optFile.Text))
            {
                errorProvider.SetError(optFile, "Specify OPT model file path");
                e.Cancel = true;
                return;
            }
        }

        private void optFile_Validated(object sender, EventArgs e)
        {
            errorProvider.SetError(optFile, string.Empty);
        }

        private void ProgressChanged_Handler(object sender, ProgressChangedEventArgs e)
        {
            Invoke(new Action<int, int, int, string>(ProgressBarUpdate), (object)e.MinProgress, (object)e.MaxProgress, (object)e.CurrentProgress, (object)e.CurrentAction);
        }

        private void ProcessingComplete_Handler(object sender, EventArgs e)
        {
            Invoke(new Action(ProcessingComplete));
        }

        private void ProgressBarUpdate(int minProgress, int maxProgress, int currentProgress, string action)
        {
            progressBar.Visible = true;
            progressBar.Minimum = minProgress;
            progressBar.Maximum = maxProgress;
            progressBar.Value = currentProgress;

            actionLabel.Visible = true;
            actionLabel.Text = action;
        }

        private void ProcessingComplete()
        {
            ToggleUI();
            progressBar.Visible = false;
            actionLabel.Visible = false;
            actionLabel.Text = string.Empty;
        }

        private void start_Click(object sender, EventArgs e)
        {
            ToggleUI(false);

            try
            {
                Processor processor = new Processor(mathcadFile.Text, optFile.Text);
                processor.ProgressChanged += new EventHandler<ProgressChangedEventArgs>(ProgressChanged_Handler);
                processor.ProcessingComplete += new EventHandler<EventArgs>(ProcessingComplete_Handler);

                cancellator = new CancellationTokenSource();
                CancellationToken cancellationToken = cancellator.Token;
                Task processingTask = Task.Factory.StartNew(processor.ProcessModel, (object)cancellationToken, cancellationToken);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, appName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                ToggleUI();
                return;
            }
        }

        private void stop_Click(object sender, EventArgs e)
        {
            cancellator.Cancel();
        }

        private void ToggleUI(bool enabled = true)
        {
            // Direct
            mathcadFile.Enabled = enabled;
            chooseMathcadFile.Enabled = enabled;
            optFile.Enabled = enabled;
            chooseOptFile.Enabled = enabled;
            start.Enabled = enabled;
            exit.Enabled = enabled;

            // Inverse
            stop.Enabled = !enabled;
            progressBar.Enabled = !enabled;
        }
    }
}