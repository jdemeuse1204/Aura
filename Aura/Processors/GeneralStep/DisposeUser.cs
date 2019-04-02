using Aura.Models;
using Aura.Processors.GeneralStep.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aura.Processors.GeneralStep
{
    public class DisposeUser : IGeneralStep
    {
        public void Run(Session session, List<ProcessRollup> processRollups)
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
