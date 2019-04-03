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
            if (timeSpan.TotalMinutes <= 0 && timeSpan.TotalHours <= 0)
            {
                return $"{timeSpan.TotalSeconds} seconds";
            }

            if (timeSpan.TotalMinutes > 0 && timeSpan.TotalHours <= 0)
            {
                return $"{timeSpan.TotalSeconds} minutes";
            }

            return $"{timeSpan.Hours} hours {timeSpan.Minutes} minutes";
        }
    }
}
