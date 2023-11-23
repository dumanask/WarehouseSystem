using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Warehouse.Domain.Entities;
using Warehouse.Persistance.Configurations.Commons;

namespace Warehouse.Persistance.Configurations;

public class ItemConfiguration: BaseEntityConfiguration<Item, Guid>
{
    public override void Configure(EntityTypeBuilder<Item> builder)
    {
        builder.Property(x => x.ItemCode).IsRequired();
        builder.Property(x => x.ItemName).IsRequired().HasMaxLength(100);
    }
}