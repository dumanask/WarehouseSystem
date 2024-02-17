using Warehouse.Domain.Entities.Commons;
using Warehouse.Domain.Enums;

namespace Warehouse.Domain.Entities;

public class Item : BaseEntity<Guid>
{
    public string ItemCode { get; set; }
    public string ItemName { get; set; }
    public string? Description { get; set; }
    public UnitType UnitType { get; set; }

    // Item boyutları girilecek.
} 