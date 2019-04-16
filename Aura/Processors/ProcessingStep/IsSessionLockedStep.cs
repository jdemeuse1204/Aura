using Aura.AddOns;
using Aura.Models;
using Aura.Processors.ProcessingStep.Base;
using Aura.Services.Interfaces;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Aura.Processors.ProcessingStep
{
    public class IsSessionLockedStep : IProcessingStep
    {
        private readonly IProcessManager ProcessManager;
        public bool CanProcess => true;

        [Inject]
        public IsSessionLockedStep(IProcessManager processManager)
        {
            ProcessManager = processManager;
        }

        public void Run(Session session, List<IProcessRollup> processRollups)
        {
            // delete step?
        }
    }
}
