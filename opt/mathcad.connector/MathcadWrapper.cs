using System;
using System.IO;
using System.Runtime.InteropServices;
//using Mathcad;

namespace mathcad.connector
{
    internal sealed class MathcadWrapper : IDisposable
    {
        //private Application mathcadApp;
        //private Worksheets mathcadWorksheets;
        //private Worksheet mathcadWorksheet;

        private string mathcadFilePath;

        public MathcadWrapper(string mathcadFile)
        {
            if (string.IsNullOrEmpty(mathcadFile))
            {
                throw new ArgumentNullException("mathcadFile");
            }

            if (!File.Exists(mathcadFile))
            {
                throw new ArgumentException("Mathcad 15 file does not exist", "mathcadFile");
            }

            mathcadFilePath = mathcadFile;

            try
            {
                //mathcadApp = new Application();
                //mathcadApp.Visible = false;
                //mathcadWorksheets = mathcadApp.Worksheets;
            }
            catch (Exception ex)
            {
                Close();
                throw ex;
            }
        }

        public void Dispose()
        {
            //if (mathcadWorksheet != null)
            //{
            //    try
            //    {
            //        mathcadWorksheet.Close(MCSaveOption.mcDiscardChanges);
            //        Marshal.ReleaseComObject(mathcadWorksheet);
            //    }
            //    catch (COMException)
            //    {
            //        // Do nothing
            //    }
            //}

            //Marshal.ReleaseComObject(mathcadWorksheets);
            //Marshal.ReleaseComObject(mathcadApp);
        }

        public void Close()
        {
            Dispose();
        }

        public void RefreshWorksheet()
        {
            //if (mathcadWorksheet != null)
            //{
            //    mathcadWorksheet.Close(MCSaveOption.mcDiscardChanges);
            //}

            //mathcadWorksheet = mathcadWorksheets.Open(mathcadFilePath);
            //Recalculate();

            //if (mathcadWorksheet == null)
            //{
            //    throw new ApplicationException("Failed to initialize Mathcad 15 worksheet");
            //}
        }

        public void SetValue(string variableIdentifier, double value)
        {
            if (string.IsNullOrEmpty(variableIdentifier))
            {
                throw new ArgumentNullException("variableIdentifier");
            }

            if (double.IsInfinity(value))
            {
                throw new ArgumentOutOfRangeException("value", "Cannot operate with Infinity values");
            }

            if (double.IsNaN(value))
            {
                throw new ArgumentException("Value is not a number", "value");
            }

            //if (mathcadWorksheet == null)
            //{
            //    throw new InvalidOperationException("Refresh Mathcad worksheet");
            //}

            //mathcadWorksheet.SetValue(variableIdentifier, value);
        }

        public double GetValue(string variableIdentifier)
        {
            if (string.IsNullOrEmpty(variableIdentifier))
            {
                throw new ArgumentNullException("variableIdentifier");
            }

            //if (mathcadWorksheet == null)
            //{
            //    throw new InvalidOperationException("Refresh Mathcad worksheet");
            //}

            //return (mathcadWorksheet.GetValue(variableIdentifier) as NumericValue).Real;
            return 0.0;
        }

        public void Recalculate()
        {
            //if (mathcadWorksheet == null)
            //{
            //    throw new InvalidOperationException("Refresh Mathcad worksheet");
            //}

            //mathcadWorksheet.Recalculate();
        }
    }
}