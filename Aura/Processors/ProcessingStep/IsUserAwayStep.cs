using Aura.AddOns;
using Aura.Common;
using Aura.Models;
using Aura.Processors.ProcessingStep.Base;
using Aura.Services.Interfaces;
using Ninject;
using System;
using System.Collections.Generic;

namespace Aura.Processors.ProcessingStep
{
    public class IsUserAwayStep : IProcessingStep
    {
        private readonly IProcessManager ProcessManager;
        public bool CanProcess => true;

        [Inject]
        public IsUserAwayStep(IProcessManager processManager)
        {
            ProcessManager = processManager;
        }

        public void Run(Session session, List<IProcessRollup> processRollups)
        {
            if ((DateTime.Now - session.LastActivityDateTime).TotalMinutes >= Constants.UserInactiveThreshholdMinutes)
            {
                // user is away
                session.IsUserInactive = true;

                // set all processes as inactive
                ProcessManager.SetAllProcessesInactive(processRollups);

                // set user as away
                ProcessManager.AddUserAwayRollup(processRollups);
            }
            else
            {
                session.IsUserInactive = false;
            }
        }
    }
}
