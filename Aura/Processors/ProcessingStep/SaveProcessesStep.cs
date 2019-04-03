using Aura.AddOns.Step;
using Aura.Models;
using Aura.Processors.ProcessingStep.Base;
using Aura.Services;
using Aura.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aura.Processors.ProcessingStep
{
    public class SaveProcessesStep : IProcessingStep
    {
        public bool CanProcess => true;
        private readonly IProcessManager ProcessManager;

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
