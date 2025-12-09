using WebApp.Models.TodoList;
using WebApp.Models.TodoTask;

namespace WebApp.WebApiServices.Interfaces;

public interface ITodoListApiService
{
    public Task<TodoListModel> CreateAsync(CreateTodoListModel postObject);

    public Task DeleteAsync(Guid id);

    public Task<List<TodoListModel>> GetAllAsync();

    public Task<TodoListModel> GetByIdAsync(Guid id, bool withIncludes = false);

    public Task<TodoListModel> UpdateAsync(CreateTodoListModel model);
}
