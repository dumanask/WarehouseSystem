using Warehouse.Application.Services.Repositories.Commons;
using Warehouse.Domain.Entities;

namespace Warehouse.Application.Services.Repositories;

public interface IItemRepository: IAsyncRepository<Item, Guid>
{
    
}