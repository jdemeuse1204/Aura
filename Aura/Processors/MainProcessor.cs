using Aura.Models;
using Aura.Processors.Factories;
using Aura.Processors.GeneralStep;
using Aura.Processors.ProcessingStep;
using Gma.System.MouseKeyHook;
using Microsoft.Win32;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Aura.Processors
{
    public class MainProcessor : IMainProcessor
    {
        private readonly Session Session;
        private readonly List<ProcessRollup> ProcessRollups;

        private readonly ProcessingFactory ProcessingFactory;
        private readonly GeneralFactory GeneralFactory;

        private IKeyboardMouseEvents m_GlobalHook;
        private readonly SessionSwitchEventHandler SessionSwitchEventHandler;

        public IEnumerable<ProcessRollup> Rollups => ProcessRollups;
        public delegate void OnAfterRunHandler(MainProcessorEventArgs args);
        public event OnAfterRunHandler OnAfterRun;
        public MainProcessor()
        {
            ProcessingFactory = new ProcessingFactory();
            GeneralFactory = new GeneralFactory();

            Session = new Session();
            ProcessRollups = new List<ProcessRollup>();
            
            SessionSwitchEventHandler = new SessionSwitchEventHandler(SystemEvents_SessionSwitch);
            SystemEvents.SessionSwitch += SessionSwitchEventHandler;

            m_GlobalHook = Hook.GlobalEvents();

            m_GlobalHook.MouseDownExt += GlobalHookMouseDownExt;
            m_GlobalHook.KeyPress += GlobalHookKeyPress;
            m_GlobalHook.MouseMove += M_GlobalHook_MouseMove;
        }      

        public void Run()
        {
            var processingSteps = ProcessingFactory.All();

            foreach (var processingStep in processingSteps)
            {
                processingStep.Run(Session, ProcessRollups);
            }

            OnAfterRun?.Invoke(new MainProcessorEventArgs(ProcessRollups));
        }

        public void Dispose()
        {
            GeneralFactory.Get<DisposeUser>().Run(Session, ProcessRollups);
            ProcessingFactory.Get<SaveSessionStep>().Run(Session, ProcessRollups);
            ProcessingFactory.Get<SaveProcessesStep>().Run(Session, ProcessRollups);

            SystemEvents.SessionSwitch -= SessionSwitchEventHandler;
        }

        private void M_GlobalHook_MouseMove(object sender, MouseEventArgs e)
        {
            GeneralFactory.Get<SetUserActiveStep>().Run(Session, ProcessRollups);
        }

        private void GlobalHookKeyPress(object sender, KeyPressEventArgs e)
        {
            GeneralFactory.Get<SetUserActiveStep>().Run(Session, ProcessRollups);
        }

        private void GlobalHookMouseDownExt(object sender, MouseEventExtArgs e)
        {
            GeneralFactory.Get<SetUserActiveStep>().Run(Session, ProcessRollups);
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
