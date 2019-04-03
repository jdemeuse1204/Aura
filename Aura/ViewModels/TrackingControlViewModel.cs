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
using System.Timers;
using System.Windows;
using System.Windows.Input;


namespace Aura.ViewModels
{
    public class TrackingControlViewModel : ViewModel
    {
        private readonly IMainProcessor MainProcessor;
        private readonly IRollupManager RollupManager;
        private readonly Timer Timer;

        public DateTime StartDate { get; set; }
        public TimeSpan InactiveTime { get; set; }
        public string TotalTime { get; set; }
        public ObservableCollection<IProcessRollup> Processes { get; set; }
        public Visibility ResumeButtonVisibility{ get; set; }
        public Visibility SuspendButtonVisibility { get; set; }

        #region Commands
        public ICommand SuspendClick => new CommandHandler(() => SuspendHandler(), true);
        public ICommand ResumeClick => new CommandHandler(() => ResumeHandler(), true);
        #endregion

        [Inject]
        public TrackingControlViewModel(IMainProcessor mainProcessor, IRollupManager rollupManager, Timer timer)
            : base()
        {
            MainProcessor = mainProcessor;
            RollupManager = rollupManager;
            Timer = timer;

            MainProcessor.OnAfterRun += MainProcessor_OnAfterRun;
            MainProcessor.Run();

            StartDate = RollupManager.GetStartDate(MainProcessor.Rollups);
            TotalTime = RollupManager.GetTotalTime(MainProcessor.Rollups);

            ResumeButtonVisibility = Visibility.Hidden;
            SuspendButtonVisibility = Visibility.Visible;
        }

        public void SuspendHandler()
        {
            this.SetProperty(w => w.ResumeButtonVisibility, Visibility.Visible);
            this.SetProperty(w => w.SuspendButtonVisibility, Visibility.Hidden);

            Timer.Stop();
        }

        public void ResumeHandler()
        {
            this.SetProperty(w => w.ResumeButtonVisibility, Visibility.Hidden);
            this.SetProperty(w => w.SuspendButtonVisibility, Visibility.Visible);

            Timer.Start();
        }

        private void MainProcessor_OnAfterRun(IMainProcessorEventArgs args)
        {
            this.SetProperty(w => w.Processes, new ObservableCollection<IProcessRollup>(args.Rollups));
            this.SetProperty(w => w.TotalTime, RollupManager.GetTotalTime(MainProcessor.Rollups));
        }
    }
}
