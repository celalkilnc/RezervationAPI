using Microsoft.EntityFrameworkCore;
using TVSC.Domain.Entities;
using TVSC.Domain.Entities.Common;

namespace TVSC.Persistance.Context
{
    public class TvscApiDbContext : DbContext
    {
        public TvscApiDbContext(DbContextOptions options) : base(options) { }
        public DbSet<User> Users { get; set; }

        public DbSet<LogEvent> LogEvents { get; set; }


        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var datas = ChangeTracker.Entries<BaseEntity>();

            foreach (var data in datas)
            {
                if (data.State == EntityState.Modified)
                    data.Entity.UpdatedDate = DateTime.UtcNow;
            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
