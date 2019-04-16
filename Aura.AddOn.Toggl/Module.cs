using Aura.AddOns.Events;
using Ninject.Modules;

namespace Aura.AddOn.Toggl
{
    public class Module : NinjectModule
    {
        public override string Name => "SaveTimeToToggl";
        public static string ModuleName { get; set; }

        public Module()
        {
            ModuleName = Name;
        }

        public override void Load()
        {
            Bind<IApplicationProcessEvent>().To<SaveTimeToToggl>();
        }
    }
}
