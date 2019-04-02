using Aura.Processors;
using System.Threading.Tasks;

namespace Aura
{
    using Ninject;
    using System.Windows;
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public readonly MainProcessor Processor;
        public readonly System.Timers.Timer Timer;
        public static IKernel Container;

        public App()
        {
            Processor = new MainProcessor();

            Timer = new System.Timers.Timer
            {
                Interval = 5000
            };

            Timer.Elapsed += (sender, evt) =>
            {
                Task.Run(() =>
                {
                    Processor.Run();
                });
            };
        }

        protected override void OnExit(ExitEventArgs e)
        {
            Timer.Stop();
            Timer.Dispose();
            base.OnExit(e);
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            // Create our DI Container
            Container = new StandardKernel();

            // Register dependencies
            RegisterDependencies();

            // Start processor timer
            Timer.Start();

            base.OnStartup(e);
        }

        private void RegisterDependencies()
        {
            Container.Bind<IMainProcessor>().ToMethod(w => Processor).InSingletonScope();
        }
    }
}
