using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetCore.DependencyInjection.Services.Interfaces;

namespace NetCore.DependencyInjection.Controllers
{
    [Route("api/di-factory")]
    [ApiController]
    public class ServiceFactoryController : ControllerBase
    {
        private readonly IServiceComFactory serviceComFactory;
               

        public ServiceFactoryController(IServiceComFactory serviceComFactory)
        =>
            this.serviceComFactory = serviceComFactory;
        
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(serviceComFactory.Referencia);
        }
    }
}