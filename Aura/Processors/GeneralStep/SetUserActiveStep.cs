using Aura.AddOns;
using Aura.Models;
using Aura.Processors.GeneralStep.Base;
using Aura.Services.Interfaces;
using Ninject;
using System;
using System.Collections.Generic;

namespace Aura.Processors.GeneralStep
{
    public class SetUserActiveStep : IGeneralStep
    {
        private readonly IProcessManager ProcessManager;

        [Inject]
        public SetUserActiveStep(IProcessManager processManager)
        {
            ProcessManager = processManager;
        }

        public void Run(Session session, List<IProcessRollup> processRollups)
        {
            session.LastActivityDateTime = DateTime.Now;

            if (session.IsUserInactive == true)
            {
                // set all processes as inactive
                ProcessManager.SetAllProcessesInactive(processRollups);

                session.IsUserInactive = false;
            }
        }
    }
}
