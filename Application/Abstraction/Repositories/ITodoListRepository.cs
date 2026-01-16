using Domain.Entities;
using System.Linq.Expressions;
using Domain.Entities.List;

namespace Application.Abstraction.Repositories;

public interface ITodoListRepository : IRepository<TodoList>
{
    Task<TodoList?> GetByIdWithTasksAndTagsAsync(Guid id);
}
