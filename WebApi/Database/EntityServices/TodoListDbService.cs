using WebApi.Database.EntityServices.Interfaces;
using WebApi.Domain.TodoList;

namespace WebApi.Database.EntityServices;

public class TodoListDbService(TodoListDBContext dbContext) : EntityDbService<TodoListEntity>(dbContext), ITodoListDbService
{
}
