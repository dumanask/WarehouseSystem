using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Warehouse.Application.Services.Repositories.Commons;
using Warehouse.Domain.Entities.Commons;

namespace Warehouse.Persistance.Services.Repositories.Commons;

public class EfAsyncRepository<TEntity, TId, TContext> : IAsyncRepository<TEntity, TId>
    where TEntity : BaseEntity<TId>
    where TContext : DbContext
{
    protected TContext _context;

    public EfAsyncRepository(TContext context)
    {
        _context = context;
    }

    public async Task<TEntity> AddAsync(TEntity entity)
    {
        entity.CreatedDate = DateTime.UtcNow;
        await _context.AddAsync(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<List<TEntity>> AddListAsync(List<TEntity> entities)
    {
        foreach (TEntity entity in entities)
            entity.CreatedDate = DateTime.UtcNow;
        await _context.AddRangeAsync(entities);
        await _context.SaveChangesAsync();
        return entities;
    }

    public async Task<TEntity> GetById(Expression<Func<TEntity, bool>> predicate,
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null)
    {
        var data = _context.Set<TEntity>().AsQueryable();
        if (include != null)
            data = include(data);

        var result = await data.Where(predicate).FirstOrDefaultAsync();

        return result;
    }

    public async Task<List<TEntity>> GetListAsync(Expression<Func<TEntity, bool>>? predicate = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null, bool enableTracking = true,
        CancellationToken cancellationToken = default)
    {
        var data = _context.Set<TEntity>().AsQueryable();
        if (!enableTracking)
            data = data.AsNoTracking();
        if (predicate != null)
            data = data.Where(predicate);
        if (orderBy != null)
            data = orderBy(data);
        if (include != null)
            data = include(data);

        return await data.ToListAsync();
    }

    public async Task<TEntity> UpdateAsync(TEntity entity)
    {
        entity.UpdatedDate = DateTime.UtcNow;
        _context.Update(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<List<TEntity>> UpdateListAsync(List<TEntity> entities)
    {
        foreach (TEntity entity in entities)
            entity.UpdatedDate = DateTime.UtcNow;
        _context.UpdateRange(entities);
        await _context.SaveChangesAsync();
        return entities;
    }

    public async Task<TEntity> DeleteAsync(TEntity entity, bool permanent = false)
    {
        entity.DeletedDate = DateTime.UtcNow;
        _context.Remove(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<List<TEntity>> DeleteRangeAsync(List<TEntity> entities, bool permanent = false)
    {
        //await SetEntityAsDeletedAsync(entities, permanent);
        foreach (TEntity entity in entities)
            entity.DeletedDate = DateTime.UtcNow;
        _context.RemoveRange(entities);
        await _context.SaveChangesAsync();
        return entities;
    }
}