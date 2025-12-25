using Application.Abstraction.Repositories;
using Domain.Entities.List;

namespace Database.Repositories;

public class TodoListRepository(AppDbContext dbContext) : Repository<TodoList>(dbContext), ITodoListRepository
{
}
