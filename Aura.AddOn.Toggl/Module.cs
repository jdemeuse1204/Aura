using Aura.AddOns.Step;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            Bind<IAddOnStep>().To<SaveTimeToToggl>();
        }
    }
}
