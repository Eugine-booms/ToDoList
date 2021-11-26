using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList
{
    public static class Programm
    {
        [STAThread]
        public static void Main(string[] args)
        {
            var app = new App();
            app.InitializeComponent();
            app.Run();
        }
        //public static IHostBuilder CreateHostBuilder(string[] args)
        //{
        //    return Host.CreateDefaultBuilder(args)
        //    .UseContentRoot(Environment.CurrentDirectory)
        //    .ConfigureServices(App.ConfigureServices);
        //}
        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            var host_builder = Host.CreateDefaultBuilder(args);
            host_builder.UseContentRoot(App.CurrentDirectory);
            host_builder.ConfigureAppConfiguration((hostingContext, config) =>
            {
                config.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                config.SetBasePath(Environment.CurrentDirectory);
               
            });

                host_builder.ConfigureServices(App.ConfigureServices);
            return host_builder;


        }


    }
}
