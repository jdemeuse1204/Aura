using Aura.AddOns.Step;
using Aura.Common.Extensions;
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
            return new TimeSpan(processRollups.SelectMany(w => w.Processes).Select(w => w.TotalTimeActive.Ticks).Sum()).ToReadableTime();
        }

        public string GetActiveApplication(IEnumerable<IProcessRollup> processRollups)
        {
            var activeProcess = processRollups.SelectMany(w => w.Processes).FirstOrDefault(w => w.IsActive);

            if (activeProcess == null)
            {
                return string.Empty;
            }

            return activeProcess.Title;
        }
    }
}
