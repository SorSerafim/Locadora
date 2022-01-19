using Locadora.Domain;
using Locadora.Domain.Interfaces.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;

namespace Locadora.Data.Repositories
{
    public class FilmeRepository : RepositoryBase<Filme>, IFilmeRepository
    {
        public FilmeRepository(LocadoraContext context) : base(context)
        {
        }

        //public override List<Filme> RetornaLista()
        //{
        //    return _context.Filmes
        //        .Include(x => x.Diretor)
        //        .ThenInclude(c => c.Nome)
        //        .ToList();
        //}
    }
}
