using Aura.AddOns;

namespace Aura.Models
{
    public class ProcessClockingPair
    {
        public ProcessClockingPair(IWindowsProcess process, IClockPeriod clockPeriod)
        {
            Process = process;
            ClockPeriod = clockPeriod;
        }

        public IWindowsProcess Process { get; }
        public IClockPeriod ClockPeriod { get; }
    }
}
