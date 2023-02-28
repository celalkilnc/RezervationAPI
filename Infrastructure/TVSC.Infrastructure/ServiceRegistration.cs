using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TVSC.Application.Service;
using TVSC.Infrastructure.Concretes;

namespace TVSC.Infrastructure
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructureServices( this  IServiceCollection services)
        {
            services.AddSingleton<IMailService, MailService>();
        }
    }
}
