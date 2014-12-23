using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace opt.Drafter.UI
{
    public partial class MainForm : Form
    {
        private ModelDraftController draftController;

        public MainForm()
        {
            InitializeComponent();

            draftController = new ModelDraftController();
        }

        private bool TryExitApplication()
        {
            if (draftController.IsChanged)
            {
            }

            return true;
        }
    }
}
