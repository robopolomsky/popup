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
            for (int i = 8; i <= 26; i++)
                _popEvents.Add(new PopEvent("Wilds Boss", i, 0, 4));

            for (int i = 13; i <= 20; i++)
                _popEvents.Add(new PopEvent("Boss' Lair", i, 0));

            _popEvents.Add(new PopEvent("3V3", 12, 30));
            _popEvents.Add(new PopEvent("3V3", 20, 30));

            _popEvents.Add(new PopEvent("Zombie Crisis", 13, 30));
            _popEvents.Add(new PopEvent("Zombie Crisis", 14, 30));
            _popEvents.Add(new PopEvent("Zombie Crisis", 17, 30));
            _popEvents.Add(new PopEvent("Zombie Crisis", 18, 30));
            _popEvents.Add(new PopEvent("Zombie Crisis", 19, 30));
            _popEvents.Add(new PopEvent("Zombie Crisis", 20, 30));

            _popEvents.Add(new PopEvent("Empire Strike", 19, 30));

            _popEvents.Add(new PopEvent("Alliance War", 21, 00, 0, DayOfWeek.Wednesday));

            _popEvents.Add(new PopEvent("Holy Grail War", 21, 00, 0, DayOfWeek.Friday));

            InitializeComponent();
            WindowState = FormWindowState.Minimized;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (_lastClickTime.AddMinutes(1) > DateTime.Now)
                return;

            foreach (PopEvent popEvent in _popEvents)
            {
                if (!popEvent.IsTime()) continue;

                NLog.LogManager.GetCurrentClassLogger().Debug(popEvent);
                WindowState = FormWindowState.Minimized;
                Show();
                TopMost = true;
                TopMost = false;
                WindowState = FormWindowState.Normal;
                _lastClickTime = DateTime.Now;

                return;
            }
        }
    }
}
