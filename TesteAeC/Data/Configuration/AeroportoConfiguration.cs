using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TesteAeC.Models;

namespace TesteAeC.Data.Configuration
{
    public class AeroportoConfiguration : IEntityTypeConfiguration<Aeroporto>
    {
        public void Configure(EntityTypeBuilder<Aeroporto> builder)
        {
            builder.ToTable("Aeroporto");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.CodigoIcao).HasColumnType("VARCHAR(5)").IsRequired();
            builder.Property(p => p.AtualizadoEm).HasColumnType("DATETIME").IsRequired();
            builder.Property(p => p.PressaoAtmosferica).IsRequired();
            builder.Property(p => p.Visibilidade).HasColumnType("VARCHAR(7)").IsRequired();
            builder.Property(p => p.Vento).IsRequired();
            builder.Property(p => p.DirecaoVento).IsRequired();
            builder.Property(p => p.Umidade).IsRequired();
            builder.Property(p => p.Condicao).HasColumnType("CHAR(2)").IsRequired();
            builder.Property(p => p.CondicaoDesc).HasColumnType("VARCHAR(50)").IsRequired();
            builder.Property(p => p.Temp).IsRequired();


            builder.HasIndex(i => i.CodigoIcao).HasName("idx_aeroporto_codigo");
        }
    }
}
