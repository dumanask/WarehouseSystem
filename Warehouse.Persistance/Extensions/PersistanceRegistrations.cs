using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Warehouse.Application.Services.Repositories;
using Warehouse.Persistance.Contexts;
using Warehouse.Persistance.Services.Repositories;

namespace Warehouse.Persistance.Extensions;

public static class PersistanceRegistrations
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IItemRepository, ItemRepository>();


        services.AddDbContext<WarehouseContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("WarehouseApplication"), opt =>
            {

                opt.EnableRetryOnFailure();
            });
        });

        return services;
    }
}