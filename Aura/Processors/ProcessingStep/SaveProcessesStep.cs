using Aura.AddOns;
using Aura.Models;
using Aura.Processors.ProcessingStep.Base;
using Aura.Services.Interfaces;
using Ninject;
using System.Collections.Generic;
using System.Linq;

namespace Aura.Processors.ProcessingStep
{
    public class SaveProcessesStep : IProcessingStep
    {
        public bool CanProcess => true;
        private readonly IProcessManager ProcessManager;

        [Inject]
        public SaveProcessesStep(IProcessManager processManager)
        {
            ProcessManager = processManager;
        }

        public void Run(Session session, List<IProcessRollup> processRollups)
        {
            ProcessManager.SaveProcesses(processRollups.SelectMany(w => w.Processes));
        }
    }
}
