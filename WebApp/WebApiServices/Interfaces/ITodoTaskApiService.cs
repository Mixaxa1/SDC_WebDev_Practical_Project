using WebApp.Models.TodoList;
using WebApp.Models.TodoTask;

namespace WebApp.WebApiServices.Interfaces
{
    public interface ITodoTaskApiService
    {
        public Task<TodoTaskModel> CreateAsync(CreateTodoTaskModel postObject);

        public Task DeleteAsync(Guid id);

        public Task<List<TodoTaskModel>> GetAllAsync();

        public Task<TodoTaskModel> GetByIdAsync(Guid id, bool withIncludes = false);

        public Task<TodoTaskModel> UpdateAsync(CreateTodoTaskModel model);
    }
}
