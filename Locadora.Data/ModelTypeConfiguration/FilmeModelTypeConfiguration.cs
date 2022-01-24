using Locadora.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Locadora.Data.ModelTypeConfiguration
{
    public class FilmeModelTypeConfiguration : IEntityTypeConfiguration<Filme>
    {
        public void Configure(EntityTypeBuilder<Filme> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Nome)
                .HasMaxLength(50)
                .IsRequired();

            builder.HasIndex(x => x.Nome)
                .IsUnique();

            builder.HasOne(x => x.Diretor)
                .WithMany(x => x.Filmes)
                .HasForeignKey(x => x.DiretorId);

            builder.HasOne(x => x.Genero)
                .WithMany(x => x.Filmes)
                .HasForeignKey(x => x.GeneroId);
        }
    }
}
