using Locadora.Domain;
using Locadora.Domain.Interfaces.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;

namespace Locadora.Data.Repositories
{
    public class DiretorRepository : RepositoryBase<Diretor>, IDiretorRepository
    {
        public DiretorRepository(LocadoraContext context) : base(context)
        {
        }

        //public override List<Diretor> RetornaLista()
        //{
        //    return _context.Diretores.Include(x => x.Filmes).ToList();
        //}
    }
}
