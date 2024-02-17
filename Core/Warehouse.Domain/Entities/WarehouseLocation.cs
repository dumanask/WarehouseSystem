using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Warehouse.Domain.Entities.Commons;

namespace Warehouse.Domain.Entities;

public class WarehouseLocation : BaseEntity<Guid>
{
    public string WarehouseLocationCode { get; set; }
    public string WarehouseLocationName { get; set; }
    public string? Description { get; set; }
    public float UsableWidth { get; set; }
    public float UsableLength { get; set; }
    public float UsableHeight { get; set; }


}
