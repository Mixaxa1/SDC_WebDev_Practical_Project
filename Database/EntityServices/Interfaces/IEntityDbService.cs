using System.Linq.Expressions;
using Domain.Entities;

namespace Database.EntityServices.Interfaces;

public interface IEntityDbService<TEntity>
    where TEntity : Entity
{
    Task CreateAsync(TEntity entity);

    Task<TEntity?> GetByIdAsync(int id);

    Task<List<TEntity>> GetAllAsync();

    Task<List<TEntity>> GetAllByExpressionAsync(Expression<Func<TEntity, bool>> expression);

    TEntity Update(TEntity entity);

    void Delete(TEntity entity);
}
