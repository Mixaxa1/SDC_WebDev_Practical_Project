using Microsoft.EntityFrameworkCore;
using WebApi.Database.EntityServices.Interfaces;
using WebApi.Domain;

namespace WebApi.Database.EntityServices;

public class EntityDbService<TEntity>(TodoListDbContext dbContext) : IEntityDbService<TEntity>
    where TEntity : Entity
{
    protected TodoListDbContext dbContext = dbContext;
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
}
