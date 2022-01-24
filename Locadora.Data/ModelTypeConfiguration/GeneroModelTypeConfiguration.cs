using Locadora.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Locadora.Data.ModelTypeConfiguration
{
    public class GeneroModelTypeConfiguration : IEntityTypeConfiguration<Genero>
    {
        public void Configure(EntityTypeBuilder<Genero> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Nome)
                .HasMaxLength(50)
                .IsRequired();

            builder.HasIndex(x => x.Nome)
                .IsUnique();

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Nome).HasMaxLength(50);
        }
    }
}
