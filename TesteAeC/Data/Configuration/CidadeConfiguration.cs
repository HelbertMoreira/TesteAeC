using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TesteAeC.Models;

namespace TesteAeC.Data.Configuration
{
    public class CidadeConfiguration : IEntityTypeConfiguration<Cidade>
    {
        public void Configure(EntityTypeBuilder<Cidade> builder)
        {
            builder.ToTable("Cidade");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Estado).HasColumnType("VARCHAR(30)").IsRequired();
            builder.Property(p => p.NomeCidade).HasColumnType("VARCHAR(30)").IsRequired();
            builder.Property(p => p.AtualizadoEm).HasColumnType("DATETIME").IsRequired();

            builder.HasMany(p => p.Clima)
                .WithOne(p => p.Cidade)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasIndex(i => i.NomeCidade).HasName("idx_localidade_cidade");
        }
    }
}
