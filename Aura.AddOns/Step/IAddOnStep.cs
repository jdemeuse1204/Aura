using System;

namespace Aura.AddOns.Step
{
    public interface IAddOnStep
    {
        TimeSpan RunInterval { get; }
        void Run(IMainProcessorEventArgs args);
    }
}
