using Microsoft.EntityFrameworkCore;
using TesteAeC.Data.Configuration;
using TesteAeC.Models;

namespace TesteAeC.Data
{
    public class AplicationContext : DbContext
    {
        public DbSet<Cidade> Localidades { get; set; }
        public DbSet<Clima> Previsoes { get; set; }
        public DbSet<Aeroporto> Aeroportos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data source=(localdb)\\mssqllocaldb;Initial Catalog=TesteAeC;Integrated Security=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Passando as classes manualmente para o mapeamento do EF Core
            modelBuilder.ApplyConfiguration(new CidadeConfiguration());
            modelBuilder.ApplyConfiguration(new AeroportoConfiguration());
            modelBuilder.ApplyConfiguration(new ClimaConfiguration());

            // Ou posso já passar um assembly que o EF irá mapear todas as classes
            //modelBuilder.ApplyConfigurationsFromAssembly(typeof(AplicationContext).Assembly);

            //Outra maneira seria configurar através de DataAnnotations nas próprias classes
        }
    }
}
