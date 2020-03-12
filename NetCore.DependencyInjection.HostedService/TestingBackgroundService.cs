using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NetCore.DependencyInjection.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NetCore.DependencyInjection.HostedService
{
    public class TestingBackgroundService : IHostedService, IDisposable
    {
        private int executionCount = 0;
        private Timer _timer;
        private IScopedService scopedService;
        private readonly IServiceScopeFactory serviceScopeFactory;

        public TestingBackgroundService(IServiceScopeFactory serviceScopeFactory)
        {
            this.serviceScopeFactory = serviceScopeFactory;
        }

        public Task StartAsync(CancellationToken stoppingToken)
        {
            Console.WriteLine("Tô rodando em background.");
            
            _timer = new Timer(DoWork, null, TimeSpan.Zero,
                TimeSpan.FromSeconds(5));

            return Task.CompletedTask;
        }

        private void DoWork(object state)
        {
            using var scope = serviceScopeFactory.CreateScope();

            scopedService = scope.ServiceProvider.GetRequiredService<IScopedService>();

            Console.WriteLine("Referência scoped: {0}", scopedService.Referencia);

            var count = Interlocked.Increment(ref executionCount);

            Console.WriteLine(
                "Tô rodando em background. {0}a vez", count);
        }

        public Task StopAsync(CancellationToken stoppingToken)
        {
            Console.WriteLine("Parei de rodar.");

            _timer?.Change(Timeout.Infinite, 0);

            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }
    }
}
