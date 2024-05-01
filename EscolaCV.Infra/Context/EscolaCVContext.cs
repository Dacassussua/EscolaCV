using EscolaCV.Core.Domain.Entities;
using EscolaCV.Infra.Configuration;
using Microsoft.EntityFrameworkCore;

namespace EscolaCV.Infra.Context
{
    public class EscolaCVContext : DbContext
    {
        public DbSet<Escola> escola { get; set; }
        public DbSet<Provincia> provincia { get; set; }
        public DbSet<Pais> pais { get; set; }
        public EscolaCVContext(DbContextOptions<EscolaCVContext> options)
            :base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new EscolaConfiguration());
            modelBuilder.ApplyConfiguration(new ProvinciaConfiguration());
            modelBuilder.ApplyConfiguration(new PaisConfiguration());
        }
    }
}
