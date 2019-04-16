using Aura.AddOns;
using System;
using System.Collections.Generic;

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
