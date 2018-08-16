﻿using System;

namespace PopUp
{
    class PopEvent
    {
        private string _description;
        private readonly DayOfWeek? _day;
        private readonly int _hour;
        private readonly int _minute;

        public PopEvent(DayOfWeek? day, int hour, int minute, string description)
        {
            _day = day;
            _hour = hour - 1;
            if (_hour < 0) _hour += 24;
            _minute = minute - 4; // const add -4 minutes before event
            if (_minute < 0) _minute += 60;
            _description = description;
        }

        public bool IsTime()
        {
            if (_day != null && _day != DateTime.Now.DayOfWeek) return false;
            return DateTime.Now.Hour == _hour && DateTime.Now.Minute == _minute;
        }
    }
}
