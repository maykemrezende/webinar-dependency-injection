using NetCore.DependencyInjection.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCore.DependencyInjection.Factories
{
    public static class ServiceComFactoryFactory
    {
        public static ServiceComFactory Create(IServiceProvider provider)
            => new ServiceComFactory(usaFactory: true);
    }
}
