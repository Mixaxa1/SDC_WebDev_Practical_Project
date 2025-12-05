using System.Linq.Expressions;
using Domain.Entities;

namespace Database.EntityServices.Interfaces;

public interface IEntityDbService<TEntity>
    where TEntity : Entity
{
    Task CreateAsync(TEntity entity);

    Task<TEntity?> GetByIdAsync(Guid id);

    Task<TEntity?> GetByIdWithIncludesAsync(Guid id, params Expression<Func<TEntity, object>>[] includes);

    Task<List<TEntity>> GetAllAsync();

    Task<List<TEntity>> GetAllByExpressionAsync(Expression<Func<TEntity, bool>> expression);

    TEntity Update(TEntity entity);

    void Delete(TEntity entity);
}
