using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using WhatIsElasticSearch.DAL.EntityFramework;
using WhatIsElasticSearch.MvcWebUI.DependencyResolvers;
using WhatIsElasticSearch.MvcWebUI.Extensions;
using WhatIsElasticSearch.MvcWebUI.Middlewares;

namespace WhatIsElasticSearch.MvcWebUI
{
    public class Startup
    {
        public IConfigurationRoot Configuration { get; }

        public Startup(IHostingEnvironment environment)
        {
            var builder = new ConfigurationBuilder().SetBasePath(environment.ContentRootPath)
                                                    .AddJsonFile("appsettings.json", false, true)
                                                    .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<EFDbContext>();
            services.AddSession();
            services.AddDistributedMemoryCache();
            services.AddMvc();
            services.AddEntityFrameworkSqlite();
            services.AddElasticsearch(Configuration);

            Ioc.RegisterServices(services, Configuration);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseFileServer();
            app.UseNodeModules(env.ContentRootPath);
            app.UseSession();
            app.UseMvcWithDefaultRoute();
            app.UseMvc((routes) =>
            {
                routes.MapRoute("default", "{controller=Presentation}/{action=Index}/{id?}");
            });
        }
    }
}
