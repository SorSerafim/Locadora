using Locadora.Domain;
using Locadora.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Locadora.Data
{
    public class LocadoraContext : DbContext
    {
        public DbSet<Diretor> Diretores { get; set; }
        public DbSet<Filme> Filmes { get; set; }
        public DbSet<Genero> Generos { get; set; }
        public DbSet<User> Users { get; set; }

        public LocadoraContext(DbContextOptions<LocadoraContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
