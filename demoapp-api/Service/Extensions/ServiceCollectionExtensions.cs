using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Service.Services.Abstractions;
using Service.Services.Concretes;

namespace Service.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection LoadServiceLayerExtension(this IServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            
            services.AddScoped<IUserService, UserService>();
            


            services.AddAutoMapper(assembly);

            return services;
        }
    }
}
