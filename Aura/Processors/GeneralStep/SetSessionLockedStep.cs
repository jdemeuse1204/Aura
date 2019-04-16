using Aura.AddOns;
using Aura.Models;
using Aura.Processors.GeneralStep.Base;
using Aura.Services.Interfaces;
using Ninject;
using System.Collections.Generic;

namespace Aura.Processors.GeneralStep
{
    public class SetSessionLockedStep : IGeneralStep
    {
        private readonly IProcessManager ProcessManager;

        [Inject]
        public SetSessionLockedStep(IProcessManager processManager)
        {
            ProcessManager = processManager;
        }

        public void Run(Session session, List<IProcessRollup> processRollups)
        {
            // set all processes to inactive
            ProcessManager.SetAllProcessesInactive(processRollups);

            // Add inactive rollup
            ProcessManager.AddSessionLockedRollup(processRollups);

            session.IsSessionLocked = true;
        }
    }
}
