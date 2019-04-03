using Aura.AddOns.Step;
using Aura.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aura.Data.Interfaces
{
    public interface IProcessRepository
    {
        void Save(IEnumerable<IWindowsProcess> processes);
        IEnumerable<IWindowsProcess> LoadSavedProcesses();
    }
}
