using Aura.AddOns.Step;
using Aura.Models;
using Aura.Processors.ProcessingStep.Base;
using Aura.Services;
using Aura.Services.Interfaces;
using Ninject;
using System.Collections.Generic;

namespace Aura.Processors.ProcessingStep
{
    public class SaveSessionStep : IProcessingStep
    {
        public bool CanProcess => true;
        private readonly IProcessManager ProcessManager;

        [Inject]
        public SaveSessionStep(IProcessManager processManager)
        {
            ProcessManager = processManager;
        }

        public void Run(Session session, List<IProcessRollup> processRollups)
        {
            ProcessManager.SaveSession(session);
        }
    }
}
