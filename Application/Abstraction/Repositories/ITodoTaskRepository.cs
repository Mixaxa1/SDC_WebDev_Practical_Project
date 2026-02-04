using Domain.Entities.List;
using System.Linq.Expressions;
using Domain.Entities.Task;

namespace Application.Abstraction.Repositories;

public interface ITodoTaskRepository : IRepository<TodoTask>
{
    List<TodoTask> GetByExpWithIncludes(Expression<Func<TodoTask, bool>> expression, params Expression<Func<TodoTask, object>>[] includes);
}