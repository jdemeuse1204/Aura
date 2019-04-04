using Aura.AddOns;
using Aura.AddOns.Step;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aura.Models
{
    public class WindowsProcess : IWindowsProcess
    {
        public WindowsProcess(string title, string processName, int id)
            : this(new Bucket(), new Stack<ClockPeriod>())
        {
            this.Key = string.Join(":", title, processName);
            Ids = new List<int> { id };
            ProcessName = processName;
            Title = title;
        }

        [JsonConstructor]
        public WindowsProcess(Bucket bucket, IEnumerable<ClockPeriod> clockPeriods)
        {
            Bucket = bucket;
            ClockPeriods = clockPeriods;
        }

        public IEnumerable<int> Ids { get; set; }
        public string Key { get; set; }
        public DateTime StartTime { get; set; }
        public string ProcessName { get; private set; }
        public string Title { get; private set; }
        public bool IsActive { get; set; }
        public bool IsRunning { get; set; }
        public IntPtr Handle { get; set; }
        public IBucket Bucket { get; set; }
        public IEnumerable<IClockPeriod> ClockPeriods { get; }
        public string Name
        {
            get
            {
                return $"{ProcessName ?? string.Empty} - {Title ?? string.Empty}";
            }
        }
        public TimeSpan TotalTimeActive
        {
            get
            {
                return ClockPeriods.Select(w => (w.EndTime ?? DateTime.Now) - w.StartTime).Aggregate(new TimeSpan(), (current, next) => current + next);
            }
        }

        public void SetNotActive()
        {
            IsActive = false;

            var timesToEnd = ClockPeriods.Where(w => w.EndTime == null);

            foreach (var timeToEnd in timesToEnd)
            {
                timeToEnd.EndTime = DateTime.Now;
            }
        }

        public void SetActive()
        {
            IsRunning = true;
            IsActive = true;
            ((Stack<ClockPeriod>)ClockPeriods).Push(new ClockPeriod());
        }

        public override bool Equals(object obj)
        {
            var o = obj as WindowsProcess;
            return o != null && o.Title == this.Title && o.ProcessName == this.ProcessName;
        }

        public bool Equals(string processName, string title)
        {
            return string.Equals(processName, this.ProcessName, StringComparison.OrdinalIgnoreCase) &&
                string.Equals(title, this.Title, StringComparison.OrdinalIgnoreCase);
        }
    }
}
