using System;
using System.Threading.Tasks;

namespace mathcad.connector
{
    public sealed class QuietHandler
    {
        private readonly string modelFile;
        private readonly string mathcadFile;

        public QuietHandler(string modelFilePath, string mathcadFilePath)
        {
            modelFile = modelFilePath;
            mathcadFile = mathcadFilePath;
        }

        public void Execute()
        {
            Processor processor = new Processor(mathcadFile, modelFile);
            processor.ProgressChanged += new EventHandler<ProgressChangedEventArgs>(ProgressChanged_Handler);
            processor.ProcessingComplete += new EventHandler<EventArgs>(ProcessingComplete_Handler);

            Task processingTask = Task.Factory.StartNew(processor.ProcessModel, null);
            processingTask.Wait();
        }

        private void ProcessingComplete_Handler(object sender, EventArgs e)
        {
            Console.WriteLine("Processing complete!");
        }

        private void ProgressChanged_Handler(object sender, ProgressChangedEventArgs e)
        {
            Console.WriteLine(e.CurrentAction + " (" + e.CurrentProgress + " / " + e.MaxProgress + ")");
        }
    }
}