using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using WebApp.Models.TodoList;
using WebApp.Models.TodoTask;
using WebApp.Options;
using WebApp.WebApiServices.Interfaces;

namespace WebApp.WebApiServices;

public class TodoListApiService : ApiService<TodoListModel>, ITodoListApiService
{
    public TodoListApiService(IOptions<EndpointsOptions> options) : base(options)
    {
        _baseRoute = options.Value.CommonBase + options.Value.ListEndpoints.Base;
    }

    public async Task<TodoListModel> GetByIdWithTasksAsync(Guid id)
    {
        using var client = new HttpClient();

        var response = await client.GetAsync(new Uri(_baseRoute + _options.ListEndpoints.WithTasks + $"{id}"));
        response.EnsureSuccessStatusCode();

        var contetnt = await response.Content.ReadAsStringAsync();
        var result = JsonConvert.DeserializeObject<TodoListModel>(contetnt);

        return result;
    }
}
