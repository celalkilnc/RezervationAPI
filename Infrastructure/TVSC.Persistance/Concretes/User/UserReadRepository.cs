using TVSC.Application.Repositories;
using TVSC.Domain.Entities;
using TVSC.Persistance.Context;
using TVSC.Persistance.Repositories;

namespace TVSC.Persistance.Concretes
{
    public class UserReadRepository : ReadRepository<User>, IUserReadRepository
    {
        public UserReadRepository(TvscApiDbContext context) : base(context) { }


        
    }
}
