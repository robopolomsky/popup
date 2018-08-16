using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PopUp
{
    public partial class Form1 : Form
    {
        private readonly List<PopEvent> _popEvents = new List<PopEvent>();
        private DateTime _lastClickTime;

        public Form1()
        {
            for (int i = 8; i <= 12; i++)
                _popEvents.Add(new PopEvent(null, i, 0, "Wilds Boss"));

            for (int i = 13; i <= 20; i++)
                _popEvents.Add(new PopEvent(null, i, 0, "Wilds Boss, Boss' Lair"));

            for (int i = 21; i <= 26; i++)
                _popEvents.Add(new PopEvent(null, i, 0, "Wilds Boss"));

            _popEvents.Add(new PopEvent(null, 12, 30, "3V3"));
            _popEvents.Add(new PopEvent(null, 20, 30, "3V3"));

            _popEvents.Add(new PopEvent(null, 13, 30, "Zombie Crisis"));
            _popEvents.Add(new PopEvent(null, 14, 30, "Zombie Crisis"));
            _popEvents.Add(new PopEvent(null, 17, 30, "Zombie Crisis"));
            _popEvents.Add(new PopEvent(null, 18, 30, "Zombie Crisis"));
            _popEvents.Add(new PopEvent(null, 19, 30, "Zombie Crisis"));
            _popEvents.Add(new PopEvent(null, 20, 30, "Zombie Crisis"));

            _popEvents.Add(new PopEvent(null, 19, 30, "Empire Strike"));

            _popEvents.Add(new PopEvent(DayOfWeek.Wednesday, 21, 00, "Alliance War"));

            _popEvents.Add(new PopEvent(DayOfWeek.Friday, 21, 00, "Holy Grail War"));

            InitializeComponent();
            WindowState = FormWindowState.Minimized;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            foreach (PopEvent popEvent in _popEvents)
            {
                if (_lastClickTime.AddMinutes(1) < DateTime.Now)
                    return;

                if (popEvent.IsTime())
                {
                    WindowState = FormWindowState.Minimized;
                    Show();
                    WindowState = FormWindowState.Normal;
                    _lastClickTime = DateTime.Now;
                }
            }
        }
    }
}
