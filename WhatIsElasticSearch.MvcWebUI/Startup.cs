using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using WhatIsElasticSearch.DAL.EntityFramework;
using WhatIsElasticSearch.MvcWebUI.DependencyResolvers;
using WhatIsElasticSearch.MvcWebUI.Entities;
using WhatIsElasticSearch.MvcWebUI.Extensions;
using WhatIsElasticSearch.MvcWebUI.Middlewares;

namespace WhatIsElasticSearch.MvcWebUI
{
    public class Startup
    {
        public IConfigurationRoot Configuration { get; }

        public Startup(IHostingEnvironment environment)
        {
            IConfigurationBuilder builder = new ConfigurationBuilder().SetBasePath(environment.ContentRootPath)
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
            services.AddDbContext<CustomIdentityDbContext>((options) =>
            {
                options.UseSqlite("Data Source=Northwind.db");
            });
            services.AddDbContext<EFDbContext>((options) =>
            {
                options.UseSqlite("Data Source=Northwind.db");
            });

            services.AddIdentity<CustomIdentityUser, CustomIdentityRole>().AddEntityFrameworkStores<CustomIdentityDbContext>()
                                                                          .AddDefaultTokenProviders();

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
            app.UseAuthentication();
            app.UseSession();
            app.UseMvcWithDefaultRoute();
            app.UseMvc((routes) =>
            {
                routes.MapRoute("default", "{controller=Presentation}/{action=Index}/{id?}");
            });
        }

        private void ConfigureRoutes(IRouteBuilder routeBuilder)
        {
            routeBuilder.MapRoute("Default", "{controller=Product}/{action=Index}/{id?}");
        }
    }
}
