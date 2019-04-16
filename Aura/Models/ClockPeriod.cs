using Aura.AddOns;
using System;

namespace Aura.Models
{
    public class ClockPeriod : IClockPeriod
    {
        public ClockPeriod()
        {
            StartTime = DateTime.Now;
        }

        public DateTime StartTime { get; set; }
        public DateTime? EndTime { get; set; }
    }
}
