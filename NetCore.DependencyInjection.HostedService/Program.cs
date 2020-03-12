using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NetCore.DependencyInjection.Services;
using NetCore.DependencyInjection.Services.Interfaces;

namespace NetCore.DependencyInjection.HostedService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices(services =>
                {
                    services.AddScoped<IScopedService, ScopedService>();
                    services.AddHostedService<TestingBackgroundService>();
                });
    }
}
