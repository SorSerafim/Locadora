using Locadora.Domain;
using Locadora.Domain.Interfaces.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;

namespace Locadora.Data.Repositories
{
    public class GeneroRepository : RepositoryBase<Genero>, IGeneroRepository
    {

        public GeneroRepository(LocadoraContext context) : base(context)
        {
        }

        public override List<Genero> RetornaLista()
        {
            return _context.Generos.Include(x => x.Filmes).ToList();
        }
    }
}
