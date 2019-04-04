using Aura.AddOns.Step;
using Aura.Common.Extensions;
using Aura.Common.Helpers;
using Aura.Models;
using Aura.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Aura.Services
{
    public class RollupManager : IRollupManager
    {
        public IEnumerable<IProcessRollup> RollupProcesses(IEnumerable<IWindowsProcess> processes)
        {
            return processes.GroupBy(w => w.ProcessName).Select(w => new ProcessRollup(w.Key, w.ToList()));
        }

        public DateTime GetStartDate(IEnumerable<IProcessRollup> processRollups)
        {
            return processRollups.SelectMany(w => w.Processes).Where(w => w.StartTime.Date == DateTime.Now.Date).Select(w => w.StartTime).Min();
        }

        public string GetTotalTime(IEnumerable<IProcessRollup> processRollups)
        {
            return TimeSpanHelpers.Sum(processRollups.SelectMany(w => w.Processes).Select(w => w.TotalTimeActive)).ToReadableTime();
        }

        public IWindowsProcess GetActiveApplication(IEnumerable<IProcessRollup> processRollups)
        {
            return processRollups.SelectMany(w => w.Processes).FirstOrDefault(w => w.IsActive);
        }
    }
}
