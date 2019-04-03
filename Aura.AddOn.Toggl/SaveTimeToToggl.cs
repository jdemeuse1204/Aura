using Aura.AddOns.Step;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aura.AddOn.Toggl
{
    public class SaveTimeToToggl : IAddOnStep
    {
        public TimeSpan RunInterval => new TimeSpan(0, 0, 1, 0, 0);

        public void Run(IMainProcessorEventArgs args)
        {
            // Save time to Toggl using the api
        }
    }
}
