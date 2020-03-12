using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using NetCore.DependencyInjection.Configs;
using NetCore.DependencyInjection.Services.Interfaces;
using System.Collections.Generic;

namespace NetCore.DependencyInjection.Controllers
{
    [Route("api/teste-di")]
    [ApiController]
    public class DIController : ControllerBase
    {
        private readonly ISingletonService singletonService;
        private readonly IScopedService scopedService;
        private readonly ITransientService transientService;

        private readonly ISingletonService singletonService2;
        private readonly IScopedService scopedService2;
        private readonly ITransientService transientService2;

        private readonly IAnotherDependency anotherDependency;
        
        private readonly IServiceScopeFactory serviceScopeFactory;

        private readonly TesteConfig testeConfig;

        public DIController(ISingletonService singletonService,
            IScopedService scopedService,
            ITransientService transientService,
            ISingletonService singletonService2,
            IScopedService scopedService2,
            ITransientService transientService2,
            IAnotherDependency anotherDependency,
            IServiceScopeFactory serviceScopeFactory,
            TesteConfig testeConfig)
        {
            this.singletonService = singletonService;
            this.scopedService = scopedService;
            this.transientService = transientService;

            this.singletonService2 = singletonService2;
            this.scopedService2 = scopedService2;
            this.transientService2 = transientService2;

            this.anotherDependency = anotherDependency;

            this.serviceScopeFactory = serviceScopeFactory;

            this.testeConfig = testeConfig;
        }

        [HttpGet("config")]
        public IActionResult Get3()
        {
            return Ok(testeConfig.Configuracao);
        }

        [HttpGet]
        public IActionResult Get()
        {
            var list = new List<Dictionary<string, string>>();
            var dic = new Dictionary<string, string>();

            dic.Add($"controller dep: {nameof(singletonService)}", singletonService.Referencia);
            dic.Add($"controller dep: {nameof(scopedService)}", scopedService.Referencia);
            dic.Add($"controller dep: {nameof(transientService)}", transientService.Referencia);

            dic.Add($"controller dep: {nameof(singletonService2)}", singletonService2.Referencia);
            dic.Add($"controller dep: {nameof(scopedService2)}", scopedService2.Referencia);
            dic.Add($"controller dep: {nameof(transientService2)}", transientService2.Referencia);

            list.Add(dic);
            list.Add(anotherDependency.GetReferencias());

            return Ok(list);
        }

        [HttpGet("service-factory")]
        public IActionResult Get2()
        {
            using var serviceScope = serviceScopeFactory.CreateScope();
            var novoScoped = serviceScope.ServiceProvider.GetService<IScopedService>();

            using var serviceScope2 = serviceScopeFactory.CreateScope();
            var novoScoped2 = serviceScope2.ServiceProvider.GetService<IScopedService>();

            var dic = new Dictionary<string, string>();
            dic.Add(nameof(novoScoped), novoScoped.Referencia);
            dic.Add(nameof(novoScoped2), novoScoped2.Referencia);

            return Ok(dic);
        }
    }
}