using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Whiteboard
{
    public partial class ControlForm
    {
        private Form1 form = null;
        public ControlForm()
        {
            InitializeComponent();
        }

        private void Create_Click(object sender, EventArgs e)
        {
            if (form == null)
            {
                form = new Form1();
                form.Show();
            }
        }

        private void Close_Click(object sender, EventArgs e)
        {
            if (form != null)
            {
                form.Close();
                form = null;
            }
        }
    }
}
