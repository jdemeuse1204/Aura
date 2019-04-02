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
    }
}
