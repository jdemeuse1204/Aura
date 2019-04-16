using Aura.AddOns;
using Aura.Models;
using Aura.Processors.GeneralStep.Base;
using System.Collections.Generic;
using System.Linq;

namespace Aura.Processors.GeneralStep
{
    public class DisposeUser : IGeneralStep
    {
        public void Run(Session session, List<IProcessRollup> processRollups)
        {
            var windowsProcesses = processRollups.SelectMany(w => w.Processes);

            foreach (var process in windowsProcesses)
            {
                process.IsRunning = false;
                process.SetNotActive();
            }

            session.IsUserInactive = false;
        }
    }
}
