using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aura.AddOns.Step
{
    public interface IClockPeriod
    {
        DateTime StartTime { get; set; }
        DateTime? EndTime { get; set; }
    }
}
