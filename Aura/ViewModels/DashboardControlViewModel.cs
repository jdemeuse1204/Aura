using Aura.Common;
using Aura.Common.Extensions;
using Aura.Models;
using Aura.Processors;
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
        protected readonly IMainProcessor MainProcessor;

        public string Test { get; set; }
        public ObservableCollection<ProcessRollup> Processes { get; set; }

        #region Commands
        public ICommand ClickCommand => new CommandHandler(() => MyAction(), true);
        #endregion

        [Inject]
        public DashboardControlViewModel(IMainProcessor mainProcessor)
            : base()
        {
            Test = "Win";
            MainProcessor = mainProcessor;
            MainProcessor.OnAfterRun += MainProcessor_OnAfterRun;
            MainProcessor.Run();
        }

        public void MyAction()
        {
            this.SetProperty(w => w.Test, "Button!");
        }

        private void MainProcessor_OnAfterRun(MainProcessorEventArgs args)
        {
            this.SetProperty(w => w.Processes, new ObservableCollection<ProcessRollup>(args.Rollups));
        }
    }
}
