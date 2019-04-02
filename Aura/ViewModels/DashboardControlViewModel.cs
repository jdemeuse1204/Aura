﻿using Aura.Models;
using Aura.Processors;
using Aura.ViewModels.Base;
using Ninject;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Aura.ViewModels
{
    public class DashboardControlViewModel : ViewModel
    {
        protected readonly IMainProcessor MainProcessor;
        public readonly System.Timers.Timer Timer;

        private ObservableCollection<ProcessRollup> _processes;

        public ObservableCollection<ProcessRollup> Processes
        {
            get { return _processes; }
            set
            {
                _processes = value;
                RaisePropertyChangedEvent("Processes");
            }
        }

        public DashboardControlViewModel()
            : base()
        {
            MainProcessor = App.Container.Get<IMainProcessor>();

            Timer = new System.Timers.Timer
            {
                Interval = 5000
            };

            Timer.Elapsed += (sender, evt) =>
            {
                Task.Run(() =>
                {
                    MainProcessor.Run();
                });
            };

            Timer.Start();

            //mainProcessor.OnAfterRun += MainProcessor_OnAfterRun;
            Processes = new ObservableCollection<ProcessRollup>(MainProcessor.Rollups);
            _canExecute = true;
        }

        private ICommand _clickCommand;
        public ICommand ClickCommand
        {
            get
            {
                return _clickCommand ?? (_clickCommand = new CommandHandler(() => MyAction(), _canExecute));
            }
        }
        private bool _canExecute;
        public void MyAction()
        {

        }

        private void MainProcessor_OnAfterRun(MainProcessorEventArgs args)
        {
            Processes = new ObservableCollection<ProcessRollup>(args.Rollups);
        }
    }

    public class CommandHandler : ICommand
    {
        private Action _action;
        private bool _canExecute;
        public CommandHandler(Action action, bool canExecute)
        {
            _action = action;
            _canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute;
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            _action();
        }
    }
}
