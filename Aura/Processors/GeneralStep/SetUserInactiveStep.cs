using Aura.AddOns;
using Aura.Models;
using Aura.Processors.GeneralStep.Base;
using Aura.Services.Interfaces;
using Ninject;
using System;
using System.Collections.Generic;

namespace Aura.Processors.GeneralStep
{
    public class SetUserInactiveStep : IGeneralStep
    {
        private readonly IProcessManager ProcessManager;

        [Inject]
        public SetUserInactiveStep(IProcessManager processManager)
        {
            ProcessManager = processManager;
        }

        public void Run(Session session, List<IProcessRollup> processRollups)
        {
            // set all processes as inactive
            ProcessManager.SetAllProcessesInactive(processRollups);

            // set user as away
            ProcessManager.AddUserAwayRollup(processRollups);
        }
    }
}
