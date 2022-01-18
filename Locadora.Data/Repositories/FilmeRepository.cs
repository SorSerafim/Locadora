using Locadora.Domain;
using Locadora.Domain.Interfaces.RepositoryInterfaces;

namespace Locadora.Data.Repositories
{
    public class FilmeRepository : RepositoryBase<Filme>, IFilmeRepository
    {
        public FilmeRepository(LocadoraContext context) : base(context)
        {
        }
    }
}
