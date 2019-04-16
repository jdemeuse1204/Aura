using Aura.AddOns;
using Aura.Models;
using System.Collections.Generic;

namespace Aura.Services.Interfaces
{
    public interface IProcessManager
    {
        IEnumerable<IWindowsProcess> GetCurrentProcesses();
        IEnumerable<IWindowsProcess> GetLoggedProcesses();
        void SaveProcesses(IEnumerable<IWindowsProcess> processes);
        void SaveSession(Session session);
        Session GetSession();
        IEnumerable<string> GetActiveTimePeriods(IWindowsProcess process);
        string GetTotalActiveApplicationTime(IWindowsProcess process);
        void SetAllProcessesInactive(List<IProcessRollup> processRollups);
        void AddSessionLockedRollup(List<IProcessRollup> processRollups);
        void AddUserAwayRollup(List<IProcessRollup> processRollups);
    }
}
