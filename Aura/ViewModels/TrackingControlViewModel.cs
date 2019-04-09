using Aura.AddOns.Step;
using Aura.Common;
using Aura.Common.Behavior;
using Aura.Common.Extensions;
using Aura.Processors;
using Aura.Services.Interfaces;
using Aura.ViewModels.Base;
using Ninject;
using System;
using System.Collections.ObjectModel;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;


namespace Aura.ViewModels
{
    public class TrackingControlViewModel : ViewModel
    {
        private readonly IMainProcessor MainProcessor;
        private readonly IRollupManager RollupManager;
        private readonly IBucketsManager BucketsManager;
        private readonly Timer Timer;

        public DateTime StartDate { get; set; }
        public TimeSpan InactiveTime { get; set; }
        public string TotalTime { get; set; }
        public ObservableCollection<IProcessRollup> Rollups { get; set; }
        public ObservableCollection<IBucket> Buckets { get; set; }
        public Visibility ResumeButtonVisibility{ get; set; }
        public Visibility SuspendButtonVisibility { get; set; }

        #region Commands
        public ICommand SuspendClick => new CommandHandler(() => SuspendHandler(), true);
        public ICommand ResumeClick => new CommandHandler(() => ResumeHandler(), true);
        public ActionCommand<object> ChangeBucketClick => new ActionCommand<object>(ChangeBucketHandler);
        #endregion

        [Inject]
        public TrackingControlViewModel(IMainProcessor mainProcessor, IRollupManager rollupManager, Timer timer, IBucketsManager bucketsManager)
            : base()
        {
            MainProcessor = mainProcessor;
            RollupManager = rollupManager;
            BucketsManager = bucketsManager;
            Timer = timer;

            Buckets = new ObservableCollection<IBucket>(BucketsManager.GetBuckets());

            MainProcessor.OnAfterRun += MainProcessor_OnAfterRun;
            MainProcessor.Run();

            StartDate = RollupManager.GetStartDate(MainProcessor.Rollups);
            TotalTime = RollupManager.GetTotalTime(MainProcessor.Rollups);

            ResumeButtonVisibility = Visibility.Hidden;
            SuspendButtonVisibility = Visibility.Visible;
        }

        public void SuspendHandler()
        {
            if (MessageBox.Show("Suspend Tracking?", "Are you sure?", MessageBoxButton.YesNo) != MessageBoxResult.Yes)
            {
                return;
            }

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

        public void ChangeBucketHandler(dynamic obj)
        {
            SelectionChangedEventArgs args = obj.e;
            // item added = agrs
        }

        private void MainProcessor_OnAfterRun(IMainProcessorEventArgs args)
        {
            this.SetProperty(w => w.Rollups, new ObservableCollection<IProcessRollup>(args.Rollups));
            this.SetProperty(w => w.TotalTime, RollupManager.GetTotalTime(MainProcessor.Rollups));
        }
    }
}
