using System;
using System.Collections.Generic;
using System.Text;

namespace Aura.AddOns
{
    public interface IWindowsProcess
    {
        IEnumerable<int> Ids { get; set; }
        string Key { get; set; }
        DateTime StartTime { get; set; }
        string ProcessName { get; }
        string Title { get; }
        bool IsActive { get; set; }
        bool IsRunning { get; set; }
        IntPtr Handle { get; set; }
        string Name { get; }
        TimeSpan TotalTimeActive { get; }
        IBucket Bucket { get; set; }
        IEnumerable<IClockPeriod> ClockPeriods { get; }

        void SetNotActive();
        void SetActive();
        bool Equals(string processName, string title);
    }
}
