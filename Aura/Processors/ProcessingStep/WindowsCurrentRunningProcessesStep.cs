﻿using Aura.AddOns;
using Aura.Models;
using Aura.Processors.ProcessingStep.Base;
using Aura.Services.Interfaces;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Aura.Processors.ProcessingStep
{
    public class WindowsCurrentRunningProcessesStep : IProcessingStep
    {
        public bool CanProcess => true;
        private readonly IProcessManager ProcessManager;

        [Inject]
        public WindowsCurrentRunningProcessesStep(IProcessManager processManager)
        {
            ProcessManager = processManager;
        }

        public void Run(Session session, List<IProcessRollup> processRollups)
        {
            // Do nothing is user is away or inactive
            if (session.IsUserInactive || session.IsSessionLocked)
            {
                return;
            }

            var loggedProcesses = processRollups.SelectMany(w => w.Processes);
            var runningProcesses = ProcessManager.GetCurrentProcesses();

            // check to see if any processes were closed
            foreach (var process in loggedProcesses)
            {
                if (process.IsActive && runningProcesses.Any(w => w.Key == process.Key) == false)
                {
                    // process was closed, deactivate it
                    process.IsRunning = false;
                    process.SetNotActive();
                }
            }

            foreach (var process in runningProcesses)
            {
                var rollup = processRollups.FirstOrDefault(w => string.Equals(w.ProcessName, process.ProcessName, StringComparison.OrdinalIgnoreCase));

                if (rollup == null)
                {
                    rollup = new ProcessRollup(process.ProcessName);
                    processRollups.Add(rollup);
                }

                var foundProcess = rollup.Processes.FirstOrDefault(w => w.Key == process.Key);

                if (foundProcess == null)
                {
                    // new process has started
                    if (process.IsActive)
                    {
                        // if its active, mark as active 
                        process.SetActive();
                    }

                    rollup.Add(process);
                }
                else
                {
                    // update it
                    if (process.IsActive && foundProcess.IsActive == false)
                    {
                        foundProcess.SetActive();
                    }
                    else if (foundProcess.IsActive == true && process.IsActive == false)
                    {
                        foundProcess.SetNotActive();
                    }
                }
            }
        }
    }
}
