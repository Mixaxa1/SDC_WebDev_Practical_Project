using Microsoft.Extensions.Options;
using WebApp.Models.TodoList;
using WebApp.Options;
using WebApp.WebApiServices.Interfaces;

namespace WebApp.WebApiServices;

public class TodoListApiService : ApiService<TodoListModel>, ITodoListApiService
{
    public TodoListApiService(IOptions<EndPointsOptions> options) : base(options)
    {
        Route = options.Value.CommonBase + options.Value.TodoListBase;
    }
}
