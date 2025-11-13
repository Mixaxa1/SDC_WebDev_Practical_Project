using WebApp.Models;

namespace WebApp.WebApiServices.Interfaces;

public interface IApiService<TModel>
    where TModel : DataModel
{
    Task Create(TModel postObject);

    Task<TModel> GetByIdAsync(int id);

    Task<List<TModel>> GetAllAsync();

    Task UpdateAsync(int id, TModel model);

    Task DeleteAsync(int id);
}
