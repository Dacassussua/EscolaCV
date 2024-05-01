using EscolaCV.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EscolaCV.Infra.Configuration
{
    public class PaisConfiguration:BaseConfiguration<Pais>
    {
        public override void Configure(EntityTypeBuilder<Pais> builder)
        {
            base.Configure(builder);
            builder.HasKey(x=>x.PaisId);
            builder.Property(x => x.PaisId).IsRequired().HasMaxLength(5);
            builder.Property(x=>x.Nome).IsRequired().HasMaxLength(100);

        }
    }
}
