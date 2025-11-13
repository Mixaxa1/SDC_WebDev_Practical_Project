using WebApp.Models;
using WebApp.WebApiServices.Interfaces;

namespace WebApp.WebApiServices;

public class TodoListApiService : ApiService<TodoList>, ITodoListApiService
{
    public TodoListApiService()
    {
        this.Route = "https://localhost:7223/api/TodoList";
    }
}
