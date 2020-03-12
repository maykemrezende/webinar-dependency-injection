using NetCore.DependencyInjection.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCore.DependencyInjection.Services
{
    public class ScopedService : IScopedService
    {
        public string Referencia { get; private set; } = Guid.NewGuid().ToString();
    }
}
