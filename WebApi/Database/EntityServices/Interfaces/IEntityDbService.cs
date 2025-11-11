using WebApi.Domain;

namespace WebApi.Database.EntityServices.Interfaces;

public interface IEntityDbService<TEntity>
    where TEntity : Entity
{
    Task CreateAsync(TEntity entity);

    Task<TEntity?> GetByIdAsync(int id);

    IAsyncEnumerable<TEntity?> GetAllAsync();

    TEntity Update(TEntity entity);

    void Delete(TEntity entity);
}
