using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aura.AddOns.Step
{
    public interface IProcessRollup
    {
        IBucket Bucket { get; }
        string ProcessName { get; }
        bool IsRunning { get; }
        bool IsActive { get; }
        TimeSpan TotalTime { get; }
        IEnumerable<IWindowsProcess> Processes { get;  }

        void Add(IWindowsProcess process);
    }
}
