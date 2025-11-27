using Microsoft.Extensions.Options;
using WebApp.Models;
using WebApp.Options;
using WebApp.WebApiServices.Interfaces;

namespace WebApp.WebApiServices;

public class TodoListApiService : ApiService<TodoList>, ITodoListApiService
{
    public TodoListApiService(IOptions<EndPointsOptions> options) : base(options)
    {
        this.Route = options.Value.CommonBase + options.Value.TodoListBase;
    }
}
