using Aura.AddOns.Step;
using Aura.Common.Extensions;
using Aura.Processors;
using Aura.Services.Interfaces;
using Aura.ViewModels.Base;
using Ninject;
using System.Collections.ObjectModel;
using System.Linq;

namespace Aura.ViewModels
{
    public class DashboardControlViewModel : ViewModel
    {
        private readonly IMainProcessor MainProcessor;
        private readonly IRollupManager RollupManager;
        private readonly IProcessManager ProcessManager;

        public string ActiveApplicationName { get; set; }
        public ObservableCollection<string> ClockingPeriods { get; set; }
        public string TotalTimeWorked { get; set; }
        public string TotalApplicationTime { get; set; }

        [Inject]
        public DashboardControlViewModel(IMainProcessor mainProcessor, IRollupManager rollupManager, IProcessManager processManager)
        {
            MainProcessor = mainProcessor;
            RollupManager = rollupManager;
            ProcessManager = processManager;

            MainProcessor.OnAfterRun += MainProcessor_OnAfterRun;
            ClockingPeriods = new ObservableCollection<string>();
        }

        private void MainProcessor_OnAfterRun(IMainProcessorEventArgs args)
        {
            var activeApplication = RollupManager.GetActiveApplication(args.Rollups);
            var activeClockPeriods = ProcessManager.GetActiveTimePeriods(activeApplication);
            var totalApplicationTime = ProcessManager.GetTotalActiveApplicationTime(activeApplication);

            this.SetProperty(w => w.ClockingPeriods, new ObservableCollection<string>(activeClockPeriods));
            this.SetProperty(w => w.TotalTimeWorked, RollupManager.GetTotalTime(args.Rollups));
            this.SetProperty(w => w.ActiveApplicationName, activeApplication?.Name);
            this.SetProperty(w => w.TotalApplicationTime, totalApplicationTime);
        }
    }
}
