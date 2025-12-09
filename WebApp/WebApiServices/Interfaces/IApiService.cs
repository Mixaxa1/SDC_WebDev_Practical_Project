using WebApp.Models;

namespace WebApp.WebApiServices.Interfaces;

public interface IApiService
{
    Task DeleteAsync(Guid id);
}
