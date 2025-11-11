using WebApi.Database.EntityServices.Interfaces;
using WebApi.Domain;

namespace WebApi.Database.EntityServices;

public class TodoListDbService(TodoListDbContext dbContext) : EntityDbService<TodoListEntity>(dbContext), ITodoListDbService
{
}
