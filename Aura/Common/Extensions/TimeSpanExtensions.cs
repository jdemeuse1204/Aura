using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aura.Common.Extensions
{
    public static class TimeSpanExtensions
    {
        public static string ToReadableTime(this TimeSpan timeSpan)
        {
            if (timeSpan.Minutes == 0 && timeSpan.Hours == 0)
            {
                return GetName(timeSpan.Seconds, "second");
            }

            if (timeSpan.Minutes > 0 && timeSpan.Hours == 0)
            {
                return GetName(timeSpan.Minutes, "minute");
            }

            return $"{GetName(timeSpan.Hours, "hour")} {GetName(timeSpan.Minutes, "minute")}";
        }

        public static string ToShortReadableTime(this TimeSpan timeSpan)
        {
            if (timeSpan.Minutes == 0 && timeSpan.Hours == 0)
            {
                return GetName(timeSpan.Seconds, "sec");
            }

            if (timeSpan.Minutes > 0 && timeSpan.Hours == 0)
            {
                return GetName(timeSpan.Minutes, "min");
            }

            return $"{GetName(timeSpan.Hours, "hr")} {GetName(timeSpan.Minutes, "min")}";
        }

        private static string GetName(int value, string increment)
        {
            return value > 1 || value == 0 ? $"{value} {increment}s" : $"{value} {increment}";
        }
    }
}
