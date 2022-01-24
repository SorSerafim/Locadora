using Locadora.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Locadora.Data.ModelTypeConfiguration
{
    public class DiretorModelTypoConfiguration : IEntityTypeConfiguration<Diretor>
    {
        public void Configure(EntityTypeBuilder<Diretor> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Nome)
                .HasMaxLength(50)
                .IsRequired();

            builder.HasIndex(x => x.Nome)
                .IsUnique();

            //builder.ToTable("Altere o nome da tabela");
        }
    }
}
