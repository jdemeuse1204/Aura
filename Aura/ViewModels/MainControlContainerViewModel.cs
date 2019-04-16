using Aura.Common;
using Aura.Common.Extensions;
using Aura.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace Aura.ViewModels
{
    public class MainControlContainerViewModel : ViewModel
    {
        public Visibility IsDashboardControlVisible { get; set; }
        public Visibility IsSettingsControlVisible { get; set; }
        public Visibility IsLiveTrackingControlVisible { get; set; }
        public Visibility IsBucketsControlVisible { get; set; }
        public Visibility IsCalendarControlVisible { get; set; }
        public Visibility IsReportsControlVisible { get; set; }

        #region Commands
        private bool CanExecuteGoToSettings { get; set; }
        private bool CanExecuteGoToDashboard { get; set; }
        private bool CanExecuteGoToLiveTracking { get; set; }
        private bool CanExecuteGoToCalendar { get; set; }
        private bool CanExecuteGoToBuckets { get; set; }
        private bool CanExecuteGoToReports { get; set; }


        public ICommand GoToSettingsClick => new CommandHandler(() => GoToSettingsHandler(), CanExecuteGoToSettings);
        public ICommand GoToDashboardClick => new CommandHandler(() => GoToDashboardHandler(), CanExecuteGoToDashboard);
        public ICommand GoToLiveTrackingClick => new CommandHandler(() => GoToLiveTrackingHandler(), CanExecuteGoToLiveTracking);
        public ICommand GoToBucketsClick => new CommandHandler(() => GoToBucketsHandler(), CanExecuteGoToBuckets);
        public ICommand GoToCalendarClick => new CommandHandler(() => GoToCalendarHandler(), CanExecuteGoToCalendar);
        public ICommand GoToReportsClick => new CommandHandler(() => GoToReportsHandler(), CanExecuteGoToReports);
        #endregion

        public MainControlContainerViewModel()
        {
            IsLiveTrackingControlVisible = Visibility.Visible;
            IsDashboardControlVisible = Visibility.Hidden;
            IsSettingsControlVisible = Visibility.Hidden;
            IsBucketsControlVisible = Visibility.Hidden;
            IsCalendarControlVisible = Visibility.Hidden;
            IsReportsControlVisible = Visibility.Hidden;

            UpdateCanExecute();
        }

        private void UpdateCanExecute()
        {
            CanExecuteGoToSettings = IsSettingsControlVisible != Visibility.Visible;
            CanExecuteGoToDashboard = IsDashboardControlVisible != Visibility.Visible;
            CanExecuteGoToLiveTracking = IsLiveTrackingControlVisible != Visibility.Visible;
            CanExecuteGoToCalendar = IsCalendarControlVisible != Visibility.Visible;
            CanExecuteGoToBuckets = IsBucketsControlVisible != Visibility.Visible;
            CanExecuteGoToReports = IsReportsControlVisible != Visibility.Visible;

            this.RaisePropertyChanged(w => w.GoToSettingsClick);
            this.RaisePropertyChanged(w => w.GoToDashboardClick);
            this.RaisePropertyChanged(w => w.GoToLiveTrackingClick);
            this.RaisePropertyChanged(w => w.GoToBucketsClick);
            this.RaisePropertyChanged(w => w.GoToCalendarClick);
            this.RaisePropertyChanged(w => w.GoToReportsClick);
        }

        private void GoToReportsHandler()
        {
            this.SetProperty(w => w.IsDashboardControlVisible, Visibility.Hidden);
            this.SetProperty(w => w.IsSettingsControlVisible, Visibility.Hidden);
            this.SetProperty(w => w.IsLiveTrackingControlVisible, Visibility.Hidden);
            this.SetProperty(w => w.IsBucketsControlVisible, Visibility.Hidden);
            this.SetProperty(w => w.IsCalendarControlVisible, Visibility.Hidden);
            this.SetProperty(w => w.IsReportsControlVisible, Visibility.Visible);
            UpdateCanExecute();
        }

        private void GoToSettingsHandler()
        {
            this.SetProperty(w => w.IsSettingsControlVisible, Visibility.Visible);
            this.SetProperty(w => w.IsDashboardControlVisible, Visibility.Hidden);
            this.SetProperty(w => w.IsLiveTrackingControlVisible, Visibility.Hidden);
            this.SetProperty(w => w.IsBucketsControlVisible, Visibility.Hidden);
            this.SetProperty(w => w.IsCalendarControlVisible, Visibility.Hidden);
            this.SetProperty(w => w.IsReportsControlVisible, Visibility.Hidden);
            UpdateCanExecute();
        }

        private void GoToLiveTrackingHandler()
        {
            this.SetProperty(w => w.IsLiveTrackingControlVisible, Visibility.Visible);
            this.SetProperty(w => w.IsDashboardControlVisible, Visibility.Hidden);
            this.SetProperty(w => w.IsSettingsControlVisible, Visibility.Hidden);
            this.SetProperty(w => w.IsBucketsControlVisible, Visibility.Hidden);
            this.SetProperty(w => w.IsCalendarControlVisible, Visibility.Hidden);
            this.SetProperty(w => w.IsReportsControlVisible, Visibility.Hidden);
            UpdateCanExecute();
        }

        private void GoToDashboardHandler()
        {
            this.SetProperty(w => w.IsDashboardControlVisible, Visibility.Visible);
            this.SetProperty(w => w.IsSettingsControlVisible, Visibility.Hidden);
            this.SetProperty(w => w.IsLiveTrackingControlVisible, Visibility.Hidden);
            this.SetProperty(w => w.IsBucketsControlVisible, Visibility.Hidden);
            this.SetProperty(w => w.IsCalendarControlVisible, Visibility.Hidden);
            this.SetProperty(w => w.IsReportsControlVisible, Visibility.Hidden);
            UpdateCanExecute();
        }

        private void GoToCalendarHandler()
        {
            this.SetProperty(w => w.IsDashboardControlVisible, Visibility.Hidden);
            this.SetProperty(w => w.IsSettingsControlVisible, Visibility.Hidden);
            this.SetProperty(w => w.IsLiveTrackingControlVisible, Visibility.Hidden);
            this.SetProperty(w => w.IsBucketsControlVisible, Visibility.Hidden);
            this.SetProperty(w => w.IsCalendarControlVisible, Visibility.Visible);
            this.SetProperty(w => w.IsReportsControlVisible, Visibility.Hidden);
            UpdateCanExecute();
        }

        private void GoToBucketsHandler()
        {
            this.SetProperty(w => w.IsDashboardControlVisible, Visibility.Hidden);
            this.SetProperty(w => w.IsSettingsControlVisible, Visibility.Hidden);
            this.SetProperty(w => w.IsLiveTrackingControlVisible, Visibility.Hidden);
            this.SetProperty(w => w.IsBucketsControlVisible, Visibility.Visible);
            this.SetProperty(w => w.IsCalendarControlVisible, Visibility.Hidden);
            this.SetProperty(w => w.IsReportsControlVisible, Visibility.Hidden);
            UpdateCanExecute();
        }
    }
}
