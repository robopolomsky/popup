using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PopUp
{
    public partial class Form1 : Form
    {
        private int _lastWarnedHour = -1;
        public Form1()
        {
            InitializeComponent();
            WindowState = FormWindowState.Minimized;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (DateTime.Now.Minute == 56 && DateTime.Now.Hour != _lastWarnedHour)
            {
                WindowState = FormWindowState.Minimized;
                Show();
                WindowState = FormWindowState.Normal;
                _lastWarnedHour = DateTime.Now.Hour;
            }
        }
    }
}
