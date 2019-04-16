using Aura.AddOns;
using Aura.Models;
using Aura.Processors.GeneralStep.Base;
using Aura.Services.Interfaces;
using Ninject;
using System.Collections.Generic;

namespace Aura.Processors.GeneralStep
{
    public class SetSessionUnlockedStep : IGeneralStep
    {
        private readonly IProcessManager ProcessManager;

        [Inject]
        public SetSessionUnlockedStep(IProcessManager processManager)
        {
            ProcessManager = processManager;
        }

        public void Run(Session session, List<IProcessRollup> processRollups)
        {
            // inactivate away windows process
            ProcessManager.SetAllProcessesInactive(processRollups);

            session.IsSessionLocked = false;
        }
    }
}
