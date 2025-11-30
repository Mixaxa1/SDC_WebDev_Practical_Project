using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using WebApp.Models;
using WebApp.Options;
using WebApp.WebApiServices.Interfaces;

namespace WebApp.WebApiServices;

public class ApiService<TModel>(IOptions<EndPointsOptions> options) : IApiService<TModel>
    where TModel : BaseModel
{
    protected string Route { get; init; }

    public async Task CreateAsync(TModel postObject)
    {
        using var client = new HttpClient();
        var response = await client.PostAsJsonAsync<TModel>(new Uri(this.Route), postObject);

        response.EnsureSuccessStatusCode();
    }

    public async Task DeleteAsync(int id)
    {
        using var client = new HttpClient();
        var response = await client.DeleteAsync(new Uri(this.Route + $"{id}"));

        response.EnsureSuccessStatusCode();
    }

    public async Task<List<TModel>> GetAllAsync()
    {
        List<TModel> result = [];

        using (var client = new HttpClient())
        {
            var response = await client.GetAsync(new Uri(this.Route));

            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            result = JsonConvert.DeserializeObject<List<TModel>>(content);
        }

        return result;
    }

    public async Task<TModel> GetByIdAsync(int id)
    {
        TModel result = null;
        using (var client = new HttpClient())
        {
            var response = await client.GetAsync(new Uri(this.Route + $"{id}"));

            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            result = JsonConvert.DeserializeObject<TModel>(content);
        }

        return result;
    }

    public async Task UpdateAsync(int id, TModel model)
    {
        using (var client = new HttpClient())
        {
            var response = await client.PutAsJsonAsync<TModel>(new Uri(this.Route + $"{id}"), model);

            response.EnsureSuccessStatusCode();
        }
    }
}
