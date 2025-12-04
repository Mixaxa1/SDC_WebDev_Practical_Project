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
        await this.dbSet.AddAsync(entity);
    }

    public async Task<TEntity?> GetByIdAsync(int id)
    {
        return await this.dbSet.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<List<TEntity>> GetAllAsync()
    {
        return await this.dbSet.ToListAsync();
    }

    public TEntity Update(TEntity entity)
    {
        return this.dbSet.Update(entity).Entity;
    }

    public void Delete(TEntity entity)
    {
        this.dbSet.Remove(entity);
    }

    public Task<List<TEntity>> GetAllByExpressionAsync(Expression<Func<TEntity, bool>> expression)
    {
        return this.dbSet.Where(expression).ToListAsync();
    }

    public async Task<TEntity?> GetByIdWithIncludesAsync(int id, params Expression<Func<TEntity, object>>[] includes)
    {
        return await includes.Aggregate(dbSet.AsQueryable(), (c, i) => c.Include(i)).FirstOrDefaultAsync(x => x.Id == id);
    }
}
