﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BabyCarrot.Extensions
{
    public static class DateTimeExtensions
    {
        public static DateTime FirstDateOfMonth(this DateTime date)
        {
            return new DateTime(date.Year, date.Month, 1);
        }
        public static DateTime LastDateOfMonth(this DateTime date)
        {
            return new DateTime(date.Year, date.Month, DateTime.DaysInMonth(date.Year, date.Month));
        }
    }
}
