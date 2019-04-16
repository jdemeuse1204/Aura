using Aura.AddOns;
using Aura.AddOns.Events;
using System;

namespace Aura.AddOn.Toggl
{
    public class SaveTimeToToggl : IApplicationProcessEvent
    {
        public TimeSpan RunInterval => new TimeSpan(0, 0, 1, 0, 0);

        public void Run(IMainProcessorEventArgs args)
        {
            // Save time to Toggl using the api
        }
    }
}
