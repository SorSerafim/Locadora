using Locadora.Domain;
using Microsoft.EntityFrameworkCore;

namespace Locadora.Data
{
    public class LocadoraContext : DbContext
    {
        public DbSet<Diretor> Diretores { get; set; }
        public DbSet<Filme> Filmes { get; set; }
        public DbSet<Genero> Generos { get; set; }

        public LocadoraContext(DbContextOptions<LocadoraContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Diretor>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<Filme>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<Genero>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<Filme>()
                .HasOne(x => x.Diretor)
                .WithMany(x => x.Filmes)
                .HasForeignKey(x => x.DiretorId);

            modelBuilder.Entity<Filme>()
                .HasOne(x => x.Genero)
                .WithMany(x => x.Filmes)
                .HasForeignKey(x => x.GeneroId);
        }
    }
}
