namespace Locadora.Domain.Interfaces.RepositoryInterfaces
{
    public interface IRepository<T> where T : class
    {
        void Adiciona(T entity);
        void Atualiza(T newEntity);
        void Deleta(T entity);
        T Retorna(int id);
        List<T> RetornaLista();
    }
}
