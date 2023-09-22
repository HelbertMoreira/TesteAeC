using Microsoft.EntityFrameworkCore;
using TesteAeC.Models;

namespace TesteAeC.Data
{
    public class AplicationContext : DbContext
    {
        public AplicationContext(DbContextOptions<AplicationContext> options)
        : base(options)
        { }

        public DbSet<Cidade> Localidades { get; set; }
        public DbSet<Clima> Previsoes { get; set; }
        public DbSet<Aeroporto> Aeroportos { get; set; }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Clima>()
            .HasOne(clima => clima.Cidade)
            .WithMany(cidade => cidade.Clima)
            .HasForeignKey(clima => clima.CidadeId);
        }
    }
}
