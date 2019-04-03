using Aura.AddOns.Step;
using Aura.Common;
using Aura.Common.Extensions;
using Aura.Models;
using Aura.Processors;
using Aura.Services.Interfaces;
using Aura.ViewModels.Base;
using Ninject;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Aura.ViewModels
{
    public class DashboardControlViewModel : ViewModel
    {
        private readonly IMainProcessor MainProcessor;
        private readonly IRollupManager RollupManager;

        public string ActiveApplication { get; set; }
        public string TotalTimeWorked { get; set; }

        [Inject]
        public DashboardControlViewModel(IMainProcessor mainProcessor, IRollupManager rollupManager)
        {
            MainProcessor = mainProcessor;
            RollupManager = rollupManager;

            MainProcessor.OnAfterRun += MainProcessor_OnAfterRun;
        }

        private void MainProcessor_OnAfterRun(IMainProcessorEventArgs args)
        {
            this.SetProperty(w => w.ActiveApplication, RollupManager.GetActiveApplication(args.Rollups));
            this.SetProperty(w => w.TotalTimeWorked, RollupManager.GetTotalTime(args.Rollups));
        }
    }
}
