using Aura.AddOns.Step;
using Aura.Models;
using Aura.Processors.ProcessingStep.Base;
using Aura.Services;
using Aura.Services.Interfaces;
using Ninject;
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
        private readonly IProcessManager ProcessManager;

        [Inject]
        public LoadSessionStep(IProcessManager processManager)
        {
            CanProcess = true;
            ProcessManager = processManager;
        }

        public void Run(Session session, List<IProcessRollup> processRollups)
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
