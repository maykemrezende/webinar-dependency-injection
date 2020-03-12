using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NetCore.DependencyInjection.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace NetCore.DependencyInjection.Services.BackgroundServices
{
    public class DIBackgroundService : BackgroundService
    {
        private readonly IScopedService scopedService;
        private readonly IServiceScopeFactory serviceScopeFactory;

        public DIBackgroundService(IServiceScopeFactory serviceScopeFactory, IScopedService scopedService)
        {
            this.serviceScopeFactory = serviceScopeFactory;
            this.scopedService = scopedService;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            using var scope = serviceScopeFactory.CreateScope();

            IScopedService scopedService = scope.ServiceProvider.GetRequiredService<IScopedService>();

            var teste = scopedService.Referencia;

            return Task.CompletedTask;
        }
    }
}
