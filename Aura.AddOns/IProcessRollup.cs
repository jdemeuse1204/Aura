using System;
using System.Collections.Generic;
using System.Text;

namespace Aura.AddOns
{
    public interface IProcessRollup
    {
        string ProcessName { get; }
        bool IsRunning { get; }
        bool IsActive { get; }
        TimeSpan TotalTime { get; }
        IEnumerable<IWindowsProcess> Processes { get; }

        void Add(IWindowsProcess process);
    }
}
