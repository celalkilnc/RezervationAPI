using Microsoft.Extensions.DependencyInjection;
using TVSC.Application.Service;
using TVSC.Infrastructure.Concretes;

namespace TVSC.Infrastructure
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructureServices( this  IServiceCollection services)
        {
            services.AddSingleton<IMailService, MailService>();


            services.AddDistributedMemoryCache();
           
            services.AddSingleton<ICacheService, CacheService>();
        }
    }
}
