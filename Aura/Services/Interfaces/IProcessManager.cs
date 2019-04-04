using Aura.AddOns.Step;
using Aura.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
