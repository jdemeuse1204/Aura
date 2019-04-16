using Aura.Services.Interfaces;
using Ninject;

namespace Aura.Processors
{
    public class ApplicationEventProcessor : IApplicationEventProcessor
    {
        private readonly IAddOnManager AddOnManager;
        private readonly IProcessManager ProcessManager;
        private readonly IRollupManager RollupManager;

        [Inject]
        public ApplicationEventProcessor(IAddOnManager addOnManager, IProcessManager processManager, IRollupManager rollupManager)
        {
            AddOnManager = addOnManager;
            ProcessManager = processManager;
            RollupManager = rollupManager;
        }

        public void ProcessApplicationStartEvents()
        {
            // Get Application Start Events
            var startEvents = AddOnManager.GetAddOnApplicationStartEvents();
            var savedData = ProcessManager.GetLoggedProcesses();
            var rollups = RollupManager.RollupProcesses(savedData);

            // Process Application Start Events
            foreach (var startEvent in startEvents)
            {
                startEvent.Run(new MainProcessorEventArgs(rollups));
            }
        }

        public void ProcessApplicationExitEvents()
        {
            // Get Application Start Events
            var startEvents = AddOnManager.GetAddOnApplicationExitEvents();
            var savedData = ProcessManager.GetLoggedProcesses();
            var rollups = RollupManager.RollupProcesses(savedData);

            // Process Application Start Events
            foreach (var startEvent in startEvents)
            {
                startEvent.Run(new MainProcessorEventArgs(rollups));
            }
        }
    }
}
