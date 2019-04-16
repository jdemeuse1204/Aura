using Aura.AddOns;
using Aura.Common;
using Aura.Common.Extensions;
using Aura.Common.Helpers;
using Aura.Data.Interfaces;
using Aura.Models;
using Aura.Services.Interfaces;
using Aura.Utilities;
using Ninject;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Aura.Services
{
    public class ProcessManager : IProcessManager
    {
        private readonly IProcessRepository ProcessRepository;
        private readonly ISessionRepository SessionRepository;

        [Inject]
        public ProcessManager(IProcessRepository processRepository, ISessionRepository sessionRepository)
        {
            ProcessRepository = processRepository;
            SessionRepository = sessionRepository;
        }

        public IEnumerable<IWindowsProcess> GetCurrentProcesses()
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

        public IEnumerable<IWindowsProcess> GetLoggedProcesses()
        {
            return ProcessRepository.LoadSavedProcesses();
        }

        public void SaveProcesses(IEnumerable<IWindowsProcess> processes)
        {
            ProcessRepository.Save(processes);
        }

        public IEnumerable<string> GetActiveTimePeriods(IWindowsProcess process)
        {
            if (process == null)
            {
                return new List<string>();
            }

            return process.ClockPeriods.Select((w, index) =>
            {
                var readableTime = (w.EndTime.HasValue ? w.EndTime.Value - w.StartTime : DateTime.Now - w.StartTime).ToReadableTime();
                return $"{readableTime}{(w.EndTime.HasValue == false ? " (active)" : "")}";
            });
        }

        public void SaveSession(Session session)
        {
            SessionRepository.Save(session);
        }

        public Session GetSession()
        {
            return SessionRepository.Get();
        }

        public string GetTotalActiveApplicationTime(IWindowsProcess process)
        {
            if (process == null)
            {
                return string.Empty;
            }

            var sum = TimeSpanHelpers.Sum(process.ClockPeriods.Select(w => w.EndTime.HasValue ? (w.EndTime.Value - w.StartTime) : (DateTime.Now - w.StartTime)));

            return sum.ToReadableTime();
        }

        public void SetAllProcessesInactive(List<IProcessRollup> processRollups)
        {
            // end all processes that are running
            foreach (var process in processRollups.SelectMany(w => w.Processes).Where(w => w.IsRunning))
            {
                process.SetNotActive();
            }
        }

        public void AddSessionLockedRollup(List<IProcessRollup> processRollups)
        {
            StartUserInactivity(processRollups, Constants.UserDeviceLocked, Constants.InactiveProcessName);
        }

        public void AddUserAwayRollup(List<IProcessRollup> processRollups)
        {
            StartUserInactivity(processRollups, Constants.UserInactive, Constants.InactiveProcessName);
        }

        private void StartUserInactivity(List<IProcessRollup> processRollups, string title, string inactivityName)
        {
            var processRollup = GetOrCreateInactiveProcessRollup(processRollups);
            var windowsProcess = GetOrCreateWindowsProcess(inactivityName, title, processRollup);

            windowsProcess.SetActive();
        }

        private IWindowsProcess GetOrCreateWindowsProcess(string processName, string title, IProcessRollup processRollup)
        {
            var result = processRollup.Processes.FirstOrDefault(w => w.Title == title);

            if (result == null)
            {
                result = new WindowsProcess(title, processName, 0);
                processRollup.Add(result);
            }

            return result;
        }

        private IProcessRollup GetOrCreateInactiveProcessRollup(List<IProcessRollup> processRollups)
        {
            IProcessRollup processRollup = processRollups.FirstOrDefault(w => w.ProcessName == Constants.InactiveProcessName);

            if (processRollup == null)
            {
                processRollup = new ProcessRollup(Constants.InactiveProcessName);
                processRollups.Add(processRollup);
            }

            return processRollup;
        }
    }
}
