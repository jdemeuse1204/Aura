using Aura.AddOns;
using System.Collections.Generic;

namespace Aura.Data.Interfaces
{
    public interface IProcessRepository
    {
        void Save(IEnumerable<IWindowsProcess> processes);
        IEnumerable<IWindowsProcess> LoadSavedProcesses();
    }
}
