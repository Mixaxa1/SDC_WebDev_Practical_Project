using Database.EntityServices.Interfaces;
using Domain.Entities.TodoList;

namespace Database.EntityServices;

public class TodoListDbService(AppDbContext dbContext) : EntityDbService<TodoList>(dbContext), ITodoListDbService
{
}
