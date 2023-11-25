using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Warehouse.Domain.Entities;

namespace Warehouse.Persistance.Contexts;

public class WarehouseContext : DbContext
{
    protected IConfiguration Configuration { get; }
    public WarehouseContext(DbContextOptions<WarehouseContext> options, IConfiguration configuration) : base(options)
    {
        Configuration = configuration;
    }
    public DbSet<Item> Items { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}