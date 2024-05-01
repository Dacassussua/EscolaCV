using EscolaCV.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EscolaCV.Infra.Configuration
{
    public class ProvinciaConfiguration:BaseConfiguration<Provincia>
    {
        public override void Configure(EntityTypeBuilder<Provincia> builder)
        {
            base.Configure(builder);
            builder.ToTable("Provincia");
            builder.HasKey(x=>x.ProvinciaId);
            builder.Property(x=>x.ProvinciaId).IsRequired().UseIdentityColumn();
            builder.Property(x=>x.Nome).IsRequired().HasMaxLength(100);
            builder.Property(x=>x.Capital).IsRequired().HasMaxLength(100);
            builder.Property(x=>x.PaisId).IsRequired();

            builder.HasOne(x=>x.pais)
                    .WithMany(x=>x.provincias)
                    .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
