namespace Locadora.Domain.Interfaces.RepositoryInterfaces
{
    public interface IFilmeRepository : IRepository<Filme>
    {
        List<Filme> RetornaListaDeFilmesPorNomeDoDiretor(string name);
    }
}
