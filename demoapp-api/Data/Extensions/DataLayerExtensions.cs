using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Context;
using Data.Repositories.Abstraction;
using Data.Repositories.Concrete;
using Data.UnitOfWorks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Data.Extensions
{
    public static class DataLayerExtensions
    {
        public static IServiceCollection LoadDataLayerExtension(this IServiceCollection services,IConfiguration config) 
        {
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddDbContext<ApplicationDbContext>(opt => opt.UseMySql(config.GetConnectionString("DefaultConnection"),
                new MySqlServerVersion(new Version(8, 0, 34))));
                
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            return services;
        } 
    }
}