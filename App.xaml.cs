using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Globalization;
using System.Windows;

namespace ToDoList
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static bool IsDesigneMode { get; private set; } = true;

        private static IHost host;

        public static IHost Host
        {
            get
            {
                if (host != null) return host;
                host = Programm.CreateHostBuilder(Environment.GetCommandLineArgs()).Build();
                return host;
            }
        }
        protected override async void OnStartup(StartupEventArgs e)
        {
            IsDesigneMode = false;
            var host = Host;
            base.OnStartup(e);
            await host.StartAsync().ConfigureAwait(false);
        }
        protected override async void OnExit(ExitEventArgs e)
        {
            base.OnExit(e);
            var host = Host;
            await host.StopAsync().ConfigureAwait(false);
            host = null;
        }

        internal static void ConfigureServices(HostBuilderContext host, IServiceCollection services)
        {
            services.RegisterServices()
                .RegisterViewModels();
        }
        
    }
}
