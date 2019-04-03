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
    public class LoadProcessesRollupsStep : IProcessingStep
    {
        public bool CanProcess { get; private set; }
        private readonly IRollupManager RollupManager;
        private readonly IProcessManager ProcessManager;

        [Inject]
        public LoadProcessesRollupsStep(IRollupManager rollupManager, IProcessManager processManager)
        {
            CanProcess = true;
            RollupManager = rollupManager;
            ProcessManager = processManager;
        }

        public void Run(Session session, List<IProcessRollup> processRollups)
        {
            var savedData = ProcessManager.GetLoggedProcesses();
            var rolledupProcesses = RollupManager.RollupProcesses(savedData);

            processRollups.AddRange(rolledupProcesses);

            CanProcess = false;
        }
    }
}
