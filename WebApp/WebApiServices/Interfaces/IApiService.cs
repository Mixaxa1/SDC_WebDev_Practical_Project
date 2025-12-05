using WebApp.Models;

namespace WebApp.WebApiServices.Interfaces;

public interface IApiService<TModel>
    where TModel : BaseModel
{
    Task CreateAsync(TModel postObject);

    Task<TModel> GetByIdAsync(Guid id);

    Task<List<TModel>> GetAllAsync();

    Task UpdateAsync(TModel model);

    Task DeleteAsync(Guid id);
}
