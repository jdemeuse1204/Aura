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
    public class LoadProcessesRollupsStep : IProcessingStep
    {
        public bool CanProcess { get; private set; }
        private readonly RollupManager RollupManager;
        private readonly ProcessManager ProcessManager;

        public LoadProcessesRollupsStep()
        {
            CanProcess = true;
            RollupManager = new RollupManager();
            ProcessManager = new ProcessManager();
        }

        public void Run(Session session, List<ProcessRollup> processRollups)
        {
            var savedData = ProcessManager.GetLoggedProcesses();
            var rolledupProcesses = RollupManager.RollupProcesses(savedData);

            processRollups.AddRange(rolledupProcesses);

            CanProcess = false;
        }
    }
}
