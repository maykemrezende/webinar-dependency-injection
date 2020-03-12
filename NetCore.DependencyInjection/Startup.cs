using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using NetCore.DependencyInjection.Configs;
using NetCore.DependencyInjection.Factories;
using NetCore.DependencyInjection.Services;
using NetCore.DependencyInjection.Services.BackgroundServices;
using NetCore.DependencyInjection.Services.Interfaces;

namespace NetCore.DependencyInjection
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            
            services.AddSingleton<ISingletonService, SingletonService>();

            services.Configure<TesteConfig>(Configuration.GetSection(nameof(TesteConfig)));
            services.AddScoped(sp => sp.GetService<IOptionsSnapshot<TesteConfig>>().Value);


            //services.TryAddSingleton<ISingletonService, SingletonService>();

            services.AddScoped<IScopedService, ScopedService>();
            services.AddTransient<ITransientService, TransientService>();

            services.AddScoped<IServiceComFactory, ServiceComFactory>(ServiceComFactoryFactory.Create);

            services.AddScoped<IAnotherDependency, AnotherDependency>();

            services.AddHostedService<DIBackgroundService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("Hello World!");
            //});

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
