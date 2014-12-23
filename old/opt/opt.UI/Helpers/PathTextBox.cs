using System.Diagnostics;
using System.Windows.Forms;

namespace opt.UI.Helpers
{
    public class PathTextBox : TextBox
    {
        public PathTextBox()
        {
            AllowDrop = true;
            DragDrop += PathTextBox_DragDrop;
            DragEnter += PathTextBox_DragEnter;
        }

        void PathTextBox_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        protected virtual void PathTextBox_DragDrop(object sender, DragEventArgs e)
        {
            string[] fileList = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            if (fileList.GetLength(0) > 0)
            {
                Text = fileList[0];
            }
        }
    }
}