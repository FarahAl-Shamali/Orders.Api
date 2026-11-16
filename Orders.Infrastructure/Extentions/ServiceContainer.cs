using Microsoft.Extensions.DependencyInjection;
using Orders.Infrastructure.Services.Categories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Orders.Infrastructure.Extentions
{
    public static class ServiceContainer
    {
        public static IServiceCollection RegisterService(this IServiceCollection services)
        {
            services.AddTransient<ICategoryService, CategoryService>();
            return services;
        }
    }
}
