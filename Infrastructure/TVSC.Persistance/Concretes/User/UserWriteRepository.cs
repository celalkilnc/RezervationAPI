using TVSC.Application.Repositories;
using TVSC.Domain.Entities;
using TVSC.Persistance.Context;
using TVSC.Persistance.Repositories;

namespace TVSC.Persistance.Concretes
{
    public class UserWriteRepository : WriteRepository<User>, IUserWriteRepository
    {
        public UserWriteRepository(TvscApiDbContext context) : base(context) { }

    }
}
