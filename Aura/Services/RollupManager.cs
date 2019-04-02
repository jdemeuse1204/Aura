using Aura.Models;
using System.Collections.Generic;
using System.Linq;

namespace Aura.Services
{
    public class RollupManager
    {
        public IEnumerable<ProcessRollup> RollupProcesses(IEnumerable<WindowsProcess> processes)
        {
            return processes.GroupBy(w => w.ProcessName).Select(w => new ProcessRollup(w.Key, w.ToList()));
        }
    }
}
