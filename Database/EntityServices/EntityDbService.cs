using System.Linq.Expressions;
using Database.EntityServices.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Database.EntityServices;

public class EntityDbService<TEntity>(AppDbContext dbContext) : IEntityDbService<TEntity>
    where TEntity : Entity
{
    protected AppDbContext dbContext = dbContext;
    protected DbSet<TEntity> dbSet = dbContext.Set<TEntity>();

    public async Task CreateAsync(TEntity entity)
    {
        await dbSet.AddAsync(entity);
    }

    public async Task<TEntity?> GetByIdAsync(Guid id)
    {
        return await dbSet.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<List<TEntity>> GetAllAsync()
    {
        return await dbSet.ToListAsync();
    }

    public TEntity Update(TEntity entity)
    {
        return dbSet.Update(entity).Entity;
    }

    public void Delete(TEntity entity)
    {
        dbSet.Remove(entity);
    }

    public Task<List<TEntity>> GetAllByExpressionAsync(Expression<Func<TEntity, bool>> expression)
    {
        return dbSet.Where(expression).ToListAsync();
    }

    public async Task<TEntity?> GetByIdWithIncludesAsync(Guid id, params Expression<Func<TEntity, object>>[] includes)
    {
        return await includes.Aggregate(dbSet.AsQueryable(), (c, i) => c.Include(i)).FirstOrDefaultAsync(x => x.Id == id);
    }
}
