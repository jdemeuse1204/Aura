using System;
using System.Collections.Generic;
using System.Text;

namespace Aura.AddOns
{
    public interface IClockPeriod
    {
        DateTime StartTime { get; set; }
        DateTime? EndTime { get; set; }
    }
}
