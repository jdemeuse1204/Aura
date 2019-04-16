using Aura.AddOns;
using Aura.Common.Behavior;
using Aura.Models;
using Aura.Processors.Factories.Interfaces;
using Aura.Processors.GeneralStep;
using Aura.Processors.ProcessingStep;
using Aura.Services.Interfaces;
using Gma.System.MouseKeyHook;
using Microsoft.Win32;
using Ninject;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Aura.Processors
{
    public class MainProcessor : IMainProcessor
    {
        private readonly Session Session;
        private readonly List<IProcessRollup> ProcessRollups;

        private readonly IProcessingFactory ProcessingFactory;
        private readonly IGeneralFactory GeneralFactory;
        private readonly IAddOnManager AddOnManager;
        private readonly DebounceDispatcher DebounceDispatcher;

        private IKeyboardMouseEvents m_GlobalHook;
        private readonly SessionSwitchEventHandler SessionSwitchEventHandler;

        public IEnumerable<IProcessRollup> Rollups => ProcessRollups;
        public delegate void OnAfterRunHandler(IMainProcessorEventArgs args);
        public event OnAfterRunHandler OnAfterRun;

        [Inject]
        public MainProcessor(IProcessingFactory processingFactory, IGeneralFactory generalFactory, IAddOnManager addOnManager)
        {
            ProcessingFactory = processingFactory;
            GeneralFactory = generalFactory;
            AddOnManager = addOnManager;

            Session = new Session();
            ProcessRollups = new List<IProcessRollup>();

            SessionSwitchEventHandler = new SessionSwitchEventHandler(SystemEvents_SessionSwitch);
            SystemEvents.SessionSwitch += SessionSwitchEventHandler;

            m_GlobalHook = Hook.GlobalEvents();

            m_GlobalHook.MouseDownExt += GlobalHookMouseDownExt;
            m_GlobalHook.KeyPress += GlobalHookKeyPress;
            m_GlobalHook.MouseMove += M_GlobalHook_MouseMove;

            DebounceDispatcher = new DebounceDispatcher();
        }

        public void Run()
        {
            // Process Main Steps
            var processingSteps = ProcessingFactory.All();

            foreach (var processingStep in processingSteps)
            {
                processingStep.Run(Session, ProcessRollups);
            }

            // Process AddOns
            var addOnSteps = AddOnManager.GetAddOnApplicationProcessEvents();

            foreach (var addOnStep in addOnSteps)
            {
                addOnStep.Run(new MainProcessorEventArgs(ProcessRollups));
            }

            // After Processing Done
            OnAfterRun?.Invoke(new MainProcessorEventArgs(ProcessRollups));
        }

        public void Dispose()
        {
            GeneralFactory.Get<DisposeUser>().Run(Session, ProcessRollups);
            ProcessingFactory.Get<SaveSessionStep>().Run(Session, ProcessRollups);
            ProcessingFactory.Get<SaveProcessesStep>().Run(Session, ProcessRollups);

            SystemEvents.SessionSwitch -= SessionSwitchEventHandler;
        }

        private void SetUserActive()
        {
            DebounceDispatcher.Debounce(250, (e) =>
            {
                GeneralFactory.Get<SetUserActiveStep>().Run(Session, ProcessRollups);
            });
        }

        private void M_GlobalHook_MouseMove(object sender, MouseEventArgs e)
        {
            SetUserActive();
        }

        private void GlobalHookKeyPress(object sender, KeyPressEventArgs e)
        {
            SetUserActive();
        }

        private void GlobalHookMouseDownExt(object sender, MouseEventExtArgs e)
        {
            SetUserActive();
        }

        private void SystemEvents_SessionSwitch(object sender, SessionSwitchEventArgs e)
        {
            if (e.Reason == SessionSwitchReason.SessionLock)
            {
                GeneralFactory.Get<SetSessionLockedStep>().Run(Session, ProcessRollups);
            }
            else if (e.Reason == SessionSwitchReason.SessionUnlock)
            {
                GeneralFactory.Get<SetSessionUnlockedStep>().Run(Session, ProcessRollups);
            }
        }
    }
}
