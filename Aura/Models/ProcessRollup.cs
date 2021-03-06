﻿using Aura.AddOns;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Aura.Models
{
    public class ProcessRollup : IProcessRollup
    {
        public ProcessRollup(string processName)
            : this(processName, new Stack<IWindowsProcess>())
        {
        }

        public ProcessRollup(string processName, Stack<IWindowsProcess> windowsProcesses)
        {
            ProcessName = processName;
            Processes = windowsProcesses;
        }

        public string ProcessName { get; set; }
        public bool IsRunning
        {
            get
            {
                return Processes.Any(w => w.IsRunning);
            }
        }
        public bool IsActive
        {
            get
            {
                return Processes.Any(w => w.IsActive);
            }
        }
        public TimeSpan TotalTime
        {
            get
            {
                return Processes.Aggregate(new TimeSpan(), (current, next) => current + next.TotalTimeActive);
            }
        }

        public void Add(IWindowsProcess process)
        {
            if (process.ProcessName != ProcessName)
            {
                throw new ArgumentException($"Process name {process.ProcessName} does not match {ProcessName}");
            }

            ((Stack<IWindowsProcess>)Processes).Push(process);
        }

        public IEnumerable<IWindowsProcess> Processes { get; private set; }
    }
}
