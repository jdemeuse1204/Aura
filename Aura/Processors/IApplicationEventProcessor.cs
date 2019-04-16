using System;
using System.Collections.Generic;
using System.Text;

namespace Aura.Processors
{
    public interface IApplicationEventProcessor
    {
        void ProcessApplicationStartEvents();
        void ProcessApplicationExitEvents();
    }
}
