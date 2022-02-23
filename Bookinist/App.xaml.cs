using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Bookinist
{
    public partial class App : Application
    {
        private static IHost __Host;

        public static IHost Host => __Host
            ??= CreateHostBuilder(Environment.GetCommandLineArgs()).Build();

        public static IServiceProvider Services => Host.Services;

        public static IHostBuilder CreateHostBuilder(string[] agrs) => Microsoft.Extensions.Hosting.Host
           .CreateDefaultBuilder(agrs)
           .ConfigureServices(ConfigureServices)
        ;

        public static void ConfigureServices(HostBuilderContext host, IServiceCollection services)
        {

        }

        protected override async void OnStartup(StartupEventArgs e)
        {
            var host = Host;
            base.OnStartup(e);
            await Host.StartAsync();
        }

        protected override async void OnExit(ExitEventArgs e)
        {
            var host = Host;
            base.OnExit(e);
            await Host.StopAsync()
        }
    }
}
