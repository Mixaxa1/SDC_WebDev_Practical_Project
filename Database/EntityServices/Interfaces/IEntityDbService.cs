using Domain.Entities;

namespace Database.EntityServices.Interfaces;

public interface IEntityDbService<TEntity>
    where TEntity : Entity
{
    Task CreateAsync(TEntity entity);

    Task<TEntity?> GetByIdAsync(int id);

    Task<List<TEntity>> GetAllAsync();

    TEntity Update(TEntity entity);

    void Delete(TEntity entity);
}
