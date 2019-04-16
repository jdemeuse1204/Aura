using System;
using System.Collections.Generic;
using System.Text;

namespace Aura.AddOns.Events
{
    public interface IApplicationProcessEvent
    {
        TimeSpan RunInterval { get; }
        void Run(IMainProcessorEventArgs args);
    }
}
