using Aura.Modals.Interfaces;
using Aura.Modals.Windows;
using Aura.ViewModels.Modal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aura.Modals
{
    public class ModalService : IModalService
    {
        public bool? Show(ModalTypes modal)
        {
            var window = new ModalWindow();
            var viewModel = (ModalWindowViewModel)window.DataContext;

            viewModel.ShowControl(modal);

            return window.ShowDialog();
        }
    }
}
