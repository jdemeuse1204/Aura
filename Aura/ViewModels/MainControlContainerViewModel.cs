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
    public class MainControlContainerViewModel : ViewModel
    {
        public Visibility IsDashboardControlVisible { get; set; }
        public Visibility IsSettingsControlVisible { get; set; }

        #region Commands
        public ICommand GoToSettingsClick => new CommandHandler(() => GoToSettings(), true);
        public ICommand GoToDashboardClick => new CommandHandler(() => GoToDashboard(), true);
        #endregion

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

        private void GoToDashboard()
        {
            this.SetProperty(w => w.IsDashboardControlVisible, Visibility.Visible);
            this.SetProperty(w => w.IsSettingsControlVisible, Visibility.Hidden);
        }
    }
}
