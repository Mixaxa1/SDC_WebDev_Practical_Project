using Database.EntityServices.Interfaces;
using Domain.Entities.List;

namespace Database.EntityServices;

public class TodoListDbService(AppDbContext dbContext) : EntityDbService<TodoList>(dbContext), ITodoListDbService
{
}
