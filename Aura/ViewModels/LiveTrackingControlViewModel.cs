using Aura.AddOns;
using Aura.Common;
using Aura.Common.Behavior;
using Aura.Common.Extensions;
using Aura.Models;
using Aura.Models.Types;
using Aura.Processors;
using Aura.Services.Interfaces;
using Aura.ViewModels.Base;
using Ninject;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Aura.ViewModels
{
    public class LiveTrackingControlViewModel : ViewModel
    {
        private readonly IMainProcessor MainProcessor;
        private readonly IRollupManager RollupManager;
        private readonly IBucketsManager BucketsManager;
        private readonly Timer Timer;

        public DateTime StartDate { get; set; }
        public TimeSpan InactiveTime { get; set; }
        public string TotalTime { get; set; }
        public ObservableCollection<IProcessRollup> Rollups { get; set; }
        public ObservableCollection<ProcessClockingPair> ProcessClockings { get; set; }
        public ObservableCollection<IBucket> Buckets { get; set; }
        public Visibility ResumeButtonVisibility { get; set; }
        public Visibility SuspendButtonVisibility { get; set; }
        public List<LiveTrackingFilterType> FilterTypes { get; set; }

        public LiveTrackingFilterType _visibleItemsControl;
        public LiveTrackingFilterType VisibleItemsControl
        {
            get { return _visibleItemsControl; }
            set
            {
                _visibleItemsControl = value;
                this.RaisePropertyChanged(w => w.VisibleItemsControl);
            }
        }

        #region Commands
        public ICommand SuspendClick => new CommandHandler(() => SuspendHandler(), true);
        public ICommand ResumeClick => new CommandHandler(() => ResumeHandler(), true);
        public ActionCommand<object> ChangeBucketClick => new ActionCommand<object>(ChangeBucketHandler);
        public ActionCommand<object> FilterTypeSelectionChanged => new ActionCommand<object>(FilterTypeSelectionChangedHander);
        #endregion

        [Inject]
        public LiveTrackingControlViewModel(IMainProcessor mainProcessor, IRollupManager rollupManager, Timer timer, IBucketsManager bucketsManager)
            : base()
        {
            MainProcessor = mainProcessor;
            RollupManager = rollupManager;
            BucketsManager = bucketsManager;
            Timer = timer;

            Buckets = new ObservableCollection<IBucket>(BucketsManager.GetBuckets());

            FilterTypes = new List<LiveTrackingFilterType>
            {
                LiveTrackingFilterType.OrderedList,
                LiveTrackingFilterType.AllProcesses
            };
            VisibleItemsControl = LiveTrackingFilterType.AllProcesses;

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

        public void FilterTypeSelectionChangedHander(dynamic obj)
        {

        }

        public void ChangeBucketHandler(dynamic obj)
        {
            SelectionChangedEventArgs args = obj.e;
            // item added = agrs
        }

        private void MainProcessor_OnAfterRun(IMainProcessorEventArgs args)
        {
            var orderedWindowsProcesses = args.Rollups.SelectMany(x => x.Processes)
                                                      .SelectMany(c => c.ClockPeriods, (process, clockPeriod) => new ProcessClockingPair(process, clockPeriod))
                                                      .OrderByDescending(w => w.ClockPeriod.StartTime);

            this.SetProperty(w => w.Rollups, new ObservableCollection<IProcessRollup>(args.Rollups));
            this.SetProperty(w => w.ProcessClockings, new ObservableCollection<ProcessClockingPair>(orderedWindowsProcesses));
            this.SetProperty(w => w.TotalTime, RollupManager.GetTotalTime(MainProcessor.Rollups));
        }
    }
}
