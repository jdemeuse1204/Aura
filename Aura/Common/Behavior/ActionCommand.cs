using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Aura.Common.Behavior
{
    public class ActionCommand<T> : ICommand
    {
        public event EventHandler CanExecuteChanged;
        private Action<T> _action;

        public ActionCommand(Action<T> action)
        {
            _action = action;
        }

        public bool CanExecute(object parameter) { return true; }

        public void Execute(object parameter)
        {
            _action?.Invoke(parameter as dynamic);
        }
    }
}
