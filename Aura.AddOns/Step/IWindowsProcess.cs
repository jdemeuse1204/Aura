using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aura.AddOns.Step
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

        void SetNotActive();
        void SetActive();
        bool Equals(string processName, string title);
    }
}
