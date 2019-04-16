using Aura.AddOns.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aura.Services.Interfaces
{
    public interface IAddOnManager
    {
        IEnumerable<IApplicationProcessEvent> GetAddOnApplicationProcessEvents();
        IEnumerable<IApplicationStartEvent> GetAddOnApplicationStartEvents();
        IEnumerable<IApplicationExitEvent> GetAddOnApplicationExitEvents();
    }
}
