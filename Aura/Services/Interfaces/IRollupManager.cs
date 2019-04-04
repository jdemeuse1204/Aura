using Aura.AddOns.Step;
using Aura.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aura.Services.Interfaces
{
    public interface IRollupManager
    {
        IEnumerable<IProcessRollup> RollupProcesses(IEnumerable<IWindowsProcess> processes);
        IWindowsProcess GetActiveApplication(IEnumerable<IProcessRollup> processRollups);
        DateTime GetStartDate(IEnumerable<IProcessRollup> processRollups);
        string GetTotalTime(IEnumerable<IProcessRollup> processRollups);
    }
}
