using System.Threading.Tasks;

namespace Aura
{
    using Aura.Processors;
    using Aura.Data;
    using Aura.Data.Factories;
    using Aura.Data.Interfaces;
    using Aura.Data.Registry;
    using Aura.Data.Text;
    using Aura.Modals;
    using Aura.Modals.Interfaces;
    using Aura.Processors.Factories;
    using Aura.Processors.Factories.Interfaces;
    using Aura.Processors.ProcessingStep;
    using Aura.Services;
    using Aura.Services.Interfaces;
    using Ninject;
    using System.Windows;
    using System.Linq;

    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public readonly IMainProcessor Processor;
        public readonly System.Timers.Timer Timer;
        public static IKernel Container;

        public App()
        {
            // Create our DI Container
            Container = new StandardKernel();

            // Register dependencies
            RegisterDependencies();

            // Get the processor from ninject
            Processor = Container.Get<IMainProcessor>();

            // Create our timer
            Timer = new System.Timers.Timer
            {
                Interval = 10000
            };

            // configure the timer to processor on separate thread
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
            // Stop Timer
            Timer.Stop();

            // Dispose of timer
            Timer.Dispose();

            // Application Event Processor
            var applicationEventProcessor = Container.Get<IApplicationEventProcessor>();

            // Process Application Exit Events
            applicationEventProcessor.ProcessApplicationExitEvents();

            // Call base method
            base.OnExit(e);
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            // Application Event Processor
            var applicationEventProcessor = Container.Get<IApplicationEventProcessor>();

            // Process Application Start Events
            applicationEventProcessor.ProcessApplicationStartEvents();

            // Start processor timer
            Timer.Start();

            // Call Base method
            base.OnStartup(e);
        }

        private void RegisterDependencies()
        {
            // Processors should all be singletons, should only ever be one instance
            Container.Bind<IMainProcessor>().To<MainProcessor>().InSingletonScope();
            Container.Bind<IApplicationEventProcessor>().To<ApplicationEventProcessor>().InSingletonScope();
            Container.Bind<System.Timers.Timer>().ToMethod(w => Timer).InSingletonScope();

            // Managers
            Container.Bind<IRollupManager>().To<RollupManager>();
            Container.Bind<IAddOnManager>().To<AddOnManager>();
            Container.Bind<IProcessManager>().To<ProcessManager>();
            Container.Bind<IBucketsManager>().To<BucketsManager>();
            Container.Bind<IRuleManager>().To<RuleManager>();

            // Misc
            Container.Bind<IApplicationSettings>().To<ApplicationSettings>();
            Container.Bind<IModalService>().To<ModalService>();

            // Repositories
            Container.Bind<ISessionRepository>().To<SessionRepository>();
            Container.Bind<IProcessRepository>().To<ProcessRepository>();
            Container.Bind<IBucketsRepository>().To<BucketsRepository>();
            Container.Bind<IRuleRepository>().To<RuleRepository>();

            // Processor - Factories
            Container.Bind<IProcessingFactory>().To<ProcessingFactory>().WithConstructorArgument("kernel", Container);
            Container.Bind<IGeneralFactory>().To<GeneralFactory>().WithConstructorArgument("kernel", Container);

            // Data - Factories
            Container.Bind<IRulesFactory>().To<RulesFactory>();

            // Json Writers (All in singleton scope so thread locking works)
            Container.Bind<IBucketsJsonDataReaderWriter>().To<BucketsJsonDataReaderWriter>().InSingletonScope();
            Container.Bind<IProcessJsonDataReaderWriter>().To<ProcessJsonDataReaderWriter>().InSingletonScope();
            Container.Bind<ISessionJsonDataReaderWriter>().To<SessionJsonDataReaderWriter>().InSingletonScope();
            Container.Bind<IRuleJsonDataReaderWriter>().To<RuleJsonDataReaderWriter>().InSingletonScope();
        }
    }
}
