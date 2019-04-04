using Aura.AddOns;
using Aura.AddOns.Step;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aura.Models
{
    public class ProcessRollup : IProcessRollup
    {
        public ProcessRollup(string processName)
            : this(processName, new List<IWindowsProcess>())
        {
        }

        public ProcessRollup(string processName, IEnumerable<IWindowsProcess> windowsProcesses)
        {
            ProcessName = processName;
            Processes = windowsProcesses;
        }

        public string ProcessName { get; private set; }
        public bool IsRunning
        {
            get
            {
                return Processes.Any(w => w.IsRunning);
            }
        }
        public bool IsActive
        {
            get
            {
                return Processes.Any(w => w.IsActive);
            }
        }
        public TimeSpan TotalTime
        {
            get
            {
                return Processes.Aggregate(new TimeSpan(), (current, next) => current + next.TotalTimeActive);
            }
        }

        public void Add(IWindowsProcess process)
        {
            if (process.ProcessName != ProcessName)
            {
                throw new ArgumentException($"Process name {process.ProcessName} does not match {ProcessName}");
            }

            ((List<IWindowsProcess>)Processes).Add(process);
        }

        public IEnumerable<IWindowsProcess> Processes { get; private set; }
    }
}
