using System.Linq.Expressions;
using System.Web;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using WebApp.Models;
using WebApp.Options;
using WebApp.WebApiServices.Interfaces;

namespace WebApp.WebApiServices;

public class ApiService(IOptions<EndpointsOptions> options) : IApiService
{
    protected EndpointsOptions _options = options.Value;
    protected string _baseRoute { get; init; }

    public async Task DeleteAsync(Guid id)
    {
        using var client = new HttpClient();
        var response = await client.DeleteAsync(new Uri(_baseRoute + $"{id}"));

        response.EnsureSuccessStatusCode();
    }
}
