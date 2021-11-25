using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows;
using ToDoList.ViewModel;
using ToDoList.Servises;


namespace ToDoList
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static bool IsDesigneMode { get; private set; } = true;

        private static IHost _host;

        public static IHost Host
        {
            get
            {
                if (_host != null) return _host;
                _host = Programm.CreateHostBuilder(Environment.GetCommandLineArgs()).Build();
                return _host;
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
            host.Dispose();
            _host = null;

        }

        internal static void ConfigureServices(HostBuilderContext host, IServiceCollection services)
        {
            services
                .RegisterViewModels()
                .RegisterViewModels();
            
        }

        public static string CurrentDirectory => IsDesigneMode
             ? Path.GetDirectoryName(GetSourceCodePath())
             : Environment.CurrentDirectory;

        private static string GetSourceCodePath([CallerFilePath] string Path = null) => Path;

    }
}
