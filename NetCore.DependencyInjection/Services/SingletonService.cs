using Microsoft.Extensions.DependencyInjection;
using NetCore.DependencyInjection.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCore.DependencyInjection.Services
{
    public class SingletonService : ISingletonService
    {
        public string Referencia { get; private set; } = Guid.NewGuid().ToString();

        private readonly IServiceScopeFactory serviceScopeFactory;

        public SingletonService(IServiceScopeFactory serviceScopeFactory)
        {
            this.serviceScopeFactory = serviceScopeFactory;
        }

        public string GetReferencia()
        {
            using var serviceScope = serviceScopeFactory.CreateScope();
            var novoScoped = serviceScope.ServiceProvider.GetService<IScopedService>();

            return novoScoped.Referencia;
        }
    }
}
