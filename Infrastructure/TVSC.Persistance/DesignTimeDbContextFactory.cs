using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Protocols;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TVSC.Persistance.Context;

namespace TVSC.Persistance
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<TvscApiDbContext>
    {
        //Cmd üzerinden çalışmasını sağlamak için
        public TvscApiDbContext CreateDbContext(string[] args)
        {
            DbContextOptionsBuilder<TvscApiDbContext> dbContextOptionsBuilder = new();
            dbContextOptionsBuilder.UseSqlServer(Configurations.ConnectionString);

            return new TvscApiDbContext(dbContextOptionsBuilder.Options);
        }
    }
}
