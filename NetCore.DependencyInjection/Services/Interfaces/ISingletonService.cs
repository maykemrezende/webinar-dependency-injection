using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCore.DependencyInjection.Services.Interfaces
{
    public interface ISingletonService : IDependencyInjector
    {
        string GetReferencia();
    }
}
