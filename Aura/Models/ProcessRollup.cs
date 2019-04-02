﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aura.Models
{
    public class ProcessRollup
    {
        public ProcessRollup(string processName)
            : this(processName, new List<WindowsProcess>())
        {
            Bucket = new Bucket();
        }

        public ProcessRollup(string processName, IEnumerable<WindowsProcess> windowsProcesses)
        {
            ProcessName = processName;
            Processes = windowsProcesses;
        }

        public Bucket Bucket { get; set; }
        public string ProcessName { get; private set; }
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

        public void Add(WindowsProcess process)
        {
            if (process.ProcessName != ProcessName)
            {
                throw new ArgumentException($"Process name {process.ProcessName} does not match {ProcessName}");
            }

            ((List<WindowsProcess>)Processes).Add(process);
        }

        public IEnumerable<WindowsProcess> Processes { get; private set; }
    }
}