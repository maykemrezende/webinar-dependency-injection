using NetCore.DependencyInjection.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCore.DependencyInjection.Services
{
    public class ServiceComFactory : IServiceComFactory
    {
        public ServiceComFactory(bool usaFactory)
        {
        }

        public string Referencia => Guid.NewGuid().ToString();
    }
}
