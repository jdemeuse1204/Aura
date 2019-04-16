using Aura.ViewModels.Modal;
using Ninject;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aura.ViewModels.Base
{
    public class ViewModelLocator
    {
        public ViewModel DashboardControl
        {
            get { return App.Container.Get<DashboardControlViewModel>(); }
        }

        public ViewModel SettingsControl
        {
            get { return App.Container.Get<SettingsControlViewModel>(); }
        }

        public ViewModel MainControlContainer
        {
            get { return App.Container.Get<MainControlContainerViewModel>(); }
        }

        public ViewModel CalendarControl
        {
            get { return App.Container.Get<CalendarControlViewModel>(); }
        }

        public ViewModel BucketsControl
        {
            get { return App.Container.Get<BucketsControlViewModel>(); }
        }

        public ViewModel ReportsControl
        {
            get { return App.Container.Get<ReportsControlViewModel>(); }
        }

        public ViewModel ModalWindow
        {
            get { return App.Container.Get<ModalWindowViewModel>(); }
        }

        public ViewModel AddBucketControl
        {
            get { return App.Container.Get<AddBucketControlViewModel>(); }
        }

        public ViewModel LiveTrackingControl
        {
            get { return App.Container.Get<LiveTrackingControlViewModel>(); }
        }
    }
}
