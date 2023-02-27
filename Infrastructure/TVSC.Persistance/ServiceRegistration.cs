using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using TVSC.Persistance.Concretes;
using TVSC.Persistance.Context;
using Microsoft.EntityFrameworkCore;
using TVSC.Application.Repositories;
using TVSC.Domain.Entities;

namespace TVSC.Persistance
{
    public static class ServiceRegistration
    {
        public static void AddPersistanceServices( this IServiceCollection services )
        {
            //App katmanındaki IPS classını,Persistance katmanındaki PS clasıyla eşitlemek için
            services.AddDbContext<TvscApiDbContext>(options => options.UseSqlServer(Configurations.ConnectionString),ServiceLifetime.Singleton);

            services.AddSingleton<IUserReadRepository, UserReadRepository>();
            services.AddSingleton<IUserWriteRepository, UserWriteRepository>();
        }
    }
}
//Scope - Singleton - Trancient