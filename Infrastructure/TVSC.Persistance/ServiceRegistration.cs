using Microsoft.Extensions.DependencyInjection;
using TVSC.Persistance.Concretes;
using TVSC.Persistance.Context;
using Microsoft.EntityFrameworkCore;
using TVSC.Application.Repositories;

namespace TVSC.Persistance
{
    public static class ServiceRegistration
    {
        public static void AddPersistanceServices( this IServiceCollection services )
        {
            services.AddDbContext<TvscApiDbContext>(options 
                => options.UseSqlServer(Configurations.ConnectionString),
                                                ServiceLifetime.Singleton);

            services.AddMemoryCache();

            services.AddSingleton<IUserReadRepository, UserReadRepository>();
            services.AddSingleton<IUserWriteRepository, UserWriteRepository>();
        }
    }
}
