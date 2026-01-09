using Application.Abstraction.Repositories;
using Domain.Entities.List;
using Microsoft.EntityFrameworkCore;

namespace Database.Repositories;

public class TodoListRepository(AppDbContext dbContext) : Repository<TodoList>(dbContext), ITodoListRepository
{
    public async Task<TodoList?> GetByIdWithTasksAndTagsAsync(Guid id)
    {
        return await dbSet.Include(x => x.Tasks).ThenInclude(x => x.Tags).FirstOrDefaultAsync(x => x.Id == id);
    }
}
