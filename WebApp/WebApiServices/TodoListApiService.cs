using System.Web;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using WebApp.Models.TodoList;
using WebApp.Models.TodoTask;
using WebApp.Options;
using WebApp.WebApiServices.Interfaces;

namespace WebApp.WebApiServices;

public class TodoListApiService : ApiService, ITodoListApiService
{
    public TodoListApiService(IOptions<EndpointsOptions> options) : base(options)
    {
        _baseRoute = options.Value.CommonBase + options.Value.ListEndpoints.Base;
    }

    public async Task<TodoListModel> CreateAsync(CreateTodoListModel postObject)
    {
        using var client = new HttpClient();
        var response = await client.PostAsJsonAsync(new Uri(_baseRoute), postObject);

        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadAsStringAsync();
        var result = JsonConvert.DeserializeObject<TodoListModel>(content);

        return result;
    }

    public async Task<List<TodoListModel>> GetAllAsync()
    {
        List<TodoListModel> result = [];

        using var client = new HttpClient();

        var response = await client.GetAsync(new Uri(_baseRoute));

        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadAsStringAsync();
        result = JsonConvert.DeserializeObject<List<TodoListModel>>(content);

        return result;
    }

    public async Task<TodoListModel> GetByIdAsync(Guid id, bool withIncludes = false)
    {
        TodoListModel result = null;
        using (var client = new HttpClient())
        {
            var builder = new UriBuilder(_baseRoute + id.ToString());

            var query = HttpUtility.ParseQueryString(string.Empty);
            query["withIncludes"] = withIncludes.ToString();
            builder.Query = query.ToString();

            var response = await client.GetAsync(builder.ToString());

            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            result = JsonConvert.DeserializeObject<TodoListModel>(content);
        }

        return result;
    }

    public async Task<TodoListModel> UpdateAsync(CreateTodoListModel model)
    {
        TodoListModel result = null;
        using (var client = new HttpClient())
        {
            var response = await client.PutAsJsonAsync(new Uri(_baseRoute), model);

            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            result = JsonConvert.DeserializeObject<TodoListModel>(content);
        }

        return result;
    }
}
