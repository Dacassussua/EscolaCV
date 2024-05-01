using EscolaCV.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EscolaCV.Infra.Configuration
{
    public class BaseConfiguration<T> : IEntityTypeConfiguration<T> where T : BaseEntity
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.Property(x => x.CreatedDate).IsRequired();
            builder.Property(x => x.UpdateDate).IsRequired();
            builder.Property(x => x.CreateUserId).IsRequired().HasMaxLength(20);
            builder.Property(x => x.UpdateUserId).IsRequired().HasMaxLength(20);
        }
    }
}
