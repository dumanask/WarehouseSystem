using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Warehouse.Domain.Entities.Commons;
using Warehouse.Domain.Enums;

namespace Warehouse.Domain.Entities;

public class StorageUnit: BaseEntity<Guid>
{
    public string StorageUnitCode { get; set; }
    public string StorageUnitName { get; set; }
    public StorageUnitType StorageUnitType { get; set; }   
    public float StorageUnitWidth { get; set; }
    public float StorageUnitLength { get; set; }
    public float StorageUnitHeight { get; set; }
    public StoragePlace StoragePlace { get; set; }

    // List of items 
    // Item Count
    //Array dönecek ve 60 item için 25 kapasiteli kutudan 3 tane oluşacak.
}
