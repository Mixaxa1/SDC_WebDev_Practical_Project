using Application.Abstraction.Repositories;
using Database.Repositories;
using Domain.Entities.Task;

namespace Database.EntityServices
{
    public class TodoTaskRepository(AppDbContext dbContext) : Repository<TodoTask>(dbContext), ITodoTaskRepository
    {

    }
}
