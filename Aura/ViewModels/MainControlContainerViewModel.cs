using Aura.Common;
using Aura.Common.Extensions;
using Aura.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Aura.ViewModels
{
    public class MainControlContainerViewModel: ViewModel
    {
        public Visibility IsDashboardControlVisible { get; set; }
        public Visibility IsSettingsControlVisible { get; set; }
        public ICommand GoToSettingsClick => new CommandHandler(() => GoToSettings(), true);

        public MainControlContainerViewModel()
        {
            IsDashboardControlVisible = Visibility.Visible;
            IsSettingsControlVisible = Visibility.Hidden;
        }

        private void GoToSettings()
        {
            this.SetProperty(w => w.IsDashboardControlVisible, Visibility.Hidden);
            this.SetProperty(w => w.IsSettingsControlVisible, Visibility.Visible);
        }
    }
}
