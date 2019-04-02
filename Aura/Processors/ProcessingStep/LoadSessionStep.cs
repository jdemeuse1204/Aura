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
    public class LoadSessionStep : IProcessingStep
    {
        public bool CanProcess { get; private set; }
        private readonly ProcessManager ProcessManager;

        public LoadSessionStep()
        {
            ProcessManager = new ProcessManager();
        }

        public void Run(Session session, List<ProcessRollup> processRollups)
        {
            var loadedSession = ProcessManager.GetSession();

            if (loadedSession != null)
            {
                session = loadedSession;
            }

            CanProcess = false;
        }
    }
}
