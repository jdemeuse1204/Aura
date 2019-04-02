using Aura.Data;
using Aura.Models;
using Aura.Utilities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aura.Services
{
    public class ProcessManager
    {
        private readonly ProcessRepository ProcessRepository;
        private readonly SessionRepository SessionRepository;

        public ProcessManager()
        {
            ProcessRepository = new ProcessRepository();
            SessionRepository = new SessionRepository();
        }

        public IEnumerable<WindowsProcess> GetCurrentProcesses()
        {
            var activeWindowHandle = WindowsApi.GetforegroundWindow();
            var activeWindowId = WindowsApi.GetWindowProcessId(activeWindowHandle);

            return Process.GetProcesses().Where(w => !string.IsNullOrEmpty(w.MainWindowTitle)).Select(w =>
            {
                return new WindowsProcess(w.MainWindowTitle, w.ProcessName, w.Id)
                {
                    IsActive = activeWindowId == w.Id,
                    Handle = w.MainWindowHandle,
                    StartTime = w.StartTime,
                    IsRunning = true
                };
            });
        }

        public IEnumerable<WindowsProcess> GetLoggedProcesses()
        {
            return ProcessRepository.LoadSavedProcesses();
        }

        public void SaveProcesses(IEnumerable<WindowsProcess> processes)
        {
            ProcessRepository.Save(processes);
        }

        public void SaveSession(Session session)
        {
            SessionRepository.Save(session);
        }

        public Session GetSession()
        {
            return SessionRepository.Get();
        }
    }
}
