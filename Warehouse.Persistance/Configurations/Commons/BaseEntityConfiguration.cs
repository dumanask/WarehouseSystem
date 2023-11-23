using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Warehouse.Domain.Entities.Commons;

namespace Warehouse.Persistance.Configurations.Commons;

public class BaseEntityConfiguration<TEntity, TId> : IEntityTypeConfiguration<TEntity> where TEntity : BaseEntity<TId>
{
    public virtual void Configure(EntityTypeBuilder<TEntity> builder)
    {
        builder.HasKey(t => t.Id);
        builder.Property(t => t.CreatedDate).IsRequired();
        builder.Property(t => t.UpdatedDate);
        builder.Property(t => t.DeletedDate);
    }
}