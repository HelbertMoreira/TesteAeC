using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using TesteAeC.Models;

namespace TesteAeC.Data.Configuration
{
    public class ClimaConfiguration : IEntityTypeConfiguration<Clima>
    {
        public void Configure(EntityTypeBuilder<Clima> builder)
        {
            builder.ToTable("Clima");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Data).HasColumnType("DATETIME").IsRequired();
            builder.Property(p => p.Condicao).HasMaxLength(10).IsRequired();
            builder.Property(p => p.Min).IsRequired();
            builder.Property(p => p.Max).IsRequired();
            builder.Property(p => p.IndiceUv).IsRequired();
            builder.Property(p => p.CondicaoDesc).HasColumnType("VARCHAR(30)").IsRequired();
        }   
    }
}
