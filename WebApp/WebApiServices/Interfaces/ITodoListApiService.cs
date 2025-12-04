using WebApp.Models.TodoList;

namespace WebApp.WebApiServices.Interfaces;

public interface ITodoListApiService : IApiService<TodoListModel>
{
    Task<TodoListModel> GetByIdWithTasksAsync(int id);
}
