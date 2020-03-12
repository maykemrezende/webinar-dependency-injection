using NetCore.DependencyInjection.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCore.DependencyInjection.Services
{
    public class AnotherDependency : IAnotherDependency
    {
        private readonly ISingletonService singletonService;
        private readonly IScopedService scopedService;
        private readonly ITransientService transientService;

        public AnotherDependency(ISingletonService singletonService,
            IScopedService scopedService,
            ITransientService transientService)
        {
            this.singletonService = singletonService;
            this.scopedService = scopedService;
            this.transientService = transientService;
        }

        public Dictionary<string, string> GetReferencias()
        {
            var dic = new Dictionary<string, string>();

            dic.Add($"another dep: {nameof(singletonService)}", singletonService.Referencia);
            dic.Add($"another dep: {nameof(scopedService)}", scopedService.Referencia);
            dic.Add($"another dep: {nameof(transientService)}", transientService.Referencia);

            return dic; 
        }
    }
}
