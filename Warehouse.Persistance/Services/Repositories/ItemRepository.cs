using Warehouse.Application.Services.Repositories;
using Warehouse.Domain.Entities;
using Warehouse.Persistance.Contexts;
using Warehouse.Persistance.Services.Repositories.Commons;

namespace Warehouse.Persistance.Services.Repositories;

public class ItemRepository : EfAsyncRepository<Item, Guid, WarehouseContext>, IItemRepository
{
    public ItemRepository(WarehouseContext context) : base(context)
    {
    }
}