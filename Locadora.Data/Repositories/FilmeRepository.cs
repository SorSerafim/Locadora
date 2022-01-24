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

        public override Filme Retorna(int id)
        {
            return _context.Filmes
                .Include(x => x.Diretor)
                .Include(x => x.Genero)
                .FirstOrDefault(x => x.Id == id);
        }

        public override List<Filme> RetornaLista()
        {
            return _context.Filmes
                .Include(x => x.Diretor)
                .Include(x => x.Genero)
                .OrderBy(x => x.Nome)
                .ToList();
        }

        public List<Filme> RetornaListaDeFilmesPorNomeDoDiretor(string name)
        {
            return _context.Filmes
                .Include(x => x.Diretor)
                .Include(x => x.Genero)
                .Where(x => x.Diretor.Nome.Equals(name))
                .ToList();
        }
    }
}
