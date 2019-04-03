using Aura.Processors;
using Aura.ViewModels.Base;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public ViewModel TrackingControl
        {
            get { return App.Container.Get<TrackingControlViewModel>(); }
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
    }
}
