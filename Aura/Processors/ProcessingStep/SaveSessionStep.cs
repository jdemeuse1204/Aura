using Aura.Models;
using Aura.Processors.ProcessingStep.Base;
using Aura.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aura.Processors.ProcessingStep
{
    public class SaveSessionStep : IProcessingStep
    {
        public bool CanProcess => true;
        private readonly ProcessManager ProcessManager;

        public SaveSessionStep()
        {
            ProcessManager = new ProcessManager();
        }

        public void Run(Session session, List<ProcessRollup> processRollups)
        {
            ProcessManager.SaveSession(session);
        }
    }
}
