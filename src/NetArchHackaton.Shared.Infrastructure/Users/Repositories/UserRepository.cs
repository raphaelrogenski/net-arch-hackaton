using Microsoft.EntityFrameworkCore;
using NetArchHackaton.Shared.Domain.Users;
using NetArchHackaton.Shared.Infrastructure.Base.DbContexts;
using NetArchHackaton.Shared.Infrastructure.Base.Repositories;

namespace NetArchHackaton.Shared.Infrastructure.Users
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(AppDbContext context) 
            : base(context)
        {
        }
    }
}
