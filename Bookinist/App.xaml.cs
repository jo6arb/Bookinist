using System;
using System.Windows;
using Bookinist.Data;
using Bookinist.Services;
using Bookinist.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Bookinist
{
    public partial class App
    {
        private static IHost __Host;

        public static IHost Host => __Host
            ??= CreateHostBuilder(Environment.GetCommandLineArgs()).Build();

        public static IServiceProvider Services => Host.Services;

        public static IHostBuilder CreateHostBuilder(string[] agrs) => Microsoft.Extensions.Hosting.Host
           .CreateDefaultBuilder(agrs)
           .ConfigureServices(ConfigureServices)
        ;

        public static void ConfigureServices(HostBuilderContext host, IServiceCollection services) => services
           .AddDataBase(host.Configuration.GetSection("Data"))
           .AddViewModels()
           .AddServices()
        ;
        protected override async void OnStartup(StartupEventArgs e)
        {
            var host = Host;

            using (var scope = Services.CreateScope())
                scope.ServiceProvider.GetRequiredService<DbInitializer>().InitializeAsync().Wait();
            
            base.OnStartup(e);
            await Host.StartAsync();
        }

        protected override async void OnExit(ExitEventArgs e)
        {
            var host = Host;
            base.OnExit(e);
            await Host.StopAsync();
        }
    }
}
