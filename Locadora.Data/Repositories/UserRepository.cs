using Locadora.Domain.Interfaces.RepositoryInterfaces;
using Locadora.Domain.Models;

namespace Locadora.Data.Repositories
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(LocadoraContext context) : base(context)
        {
        }
    }
}
