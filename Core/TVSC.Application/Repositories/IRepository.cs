using Microsoft.EntityFrameworkCore;
using TVSC.Domain.Entities.Common;

namespace TVSC.Application.Repositories
{
    public interface IRepository<T> where T : BaseEntity
    {
        DbSet<T> Table { get; }
    }
}
