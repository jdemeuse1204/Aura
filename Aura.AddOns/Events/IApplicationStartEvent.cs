namespace Aura.AddOns.Events
{
    public interface IApplicationStartEvent
    {
        void Run(IMainProcessorEventArgs args);
    }
}
