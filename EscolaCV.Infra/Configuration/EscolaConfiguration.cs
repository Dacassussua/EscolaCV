using EscolaCV.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EscolaCV.Infra.Configuration
{
    public class EscolaConfiguration:BaseConfiguration<Escola>
    {
        public override void Configure(EntityTypeBuilder<Escola> builder)
        {
            base.Configure(builder);
            builder.ToTable("Escola");
            builder.HasKey(x=>x.EscolaId);
            builder.Property(x=>x.EscolaId).UseIdentityColumn().IsRequired();
            builder.Property(x=>x.Nome).IsRequired().HasMaxLength(200);
            builder.Property(x=>x.NumSalas).IsRequired();
            builder.Property(x=>x.ProvinciaId).IsRequired();

            builder.OwnsOne(x => x.Email)
                .Property(x => x.Address)
                .HasColumnName("Email")
                .IsRequired(true);

            builder.HasOne(x=>x.provincia)
                    .WithMany(x=>x.escolas)
                    .OnDelete(DeleteBehavior.Restrict);
    }
    }
}
