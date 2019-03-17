using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WhatIsElasticSearch.BLL.Interfaces;
using WhatIsElasticSearch.BLL.Managers;
using WhatIsElasticSearch.DAL.EntityFramework;
using WhatIsElasticSearch.DAL.Interfaces;
using WhatIsElasticSearch.MvcWebUI.Services;

namespace WhatIsElasticSearch.MvcWebUI.DependencyResolvers
{
    public static class Ioc
    {
        private static ServiceProvider _serviceProvider;

        public static void RegisterServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IProductService, ProductManager>();
            services.AddScoped<IProductDAL, EFProductDAL>();

            services.AddScoped<ICategoryDAL, EFCategoryDAL>();
            services.AddScoped<ICategoryService, CategoryManager>();

            services.AddSingleton<ICartService, CartService>();
            services.AddSingleton<ICartSessionService, CartSessionService>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            _serviceProvider = services.BuildServiceProvider();
        }

        public static T GetService<T>()
        {
            return _serviceProvider.GetService<T>();
        }
    }
}
