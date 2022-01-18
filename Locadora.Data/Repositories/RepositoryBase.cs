using Locadora.Domain;
using Locadora.Domain.Interfaces.RepositoryInterfaces;

namespace Locadora.Data.Repositories
{
    public class RepositoryBase<T> : IRepository<T> where T : Entidade
    {
        protected LocadoraContext _context;

        public RepositoryBase(LocadoraContext context)
        {
            _context = context;
        }

        public void Adiciona(T entity)
        {
            _context.Set<T>().Add(entity);
            _context.SaveChanges();
        }

        public void Atualiza(T newEntity)
        {
            _context.Set<T>().Update(newEntity);
            _context.SaveChanges();
        }

        public void Deleta(T entity)
        {
            _context.Remove(entity);
            _context.SaveChanges();
        }

        public T Retorna(int id)
        {
            return _context.Set<T>().FirstOrDefault(x => x.Id == id);
        }

        public virtual List<T> RetornaLista()
        {
            return _context.Set<T>().ToList();
        }
    }
}
