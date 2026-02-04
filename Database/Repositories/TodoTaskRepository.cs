using System.Linq.Expressions;
using Application.Abstraction.Repositories;
using Database.Repositories;
using Domain.Entities.Task;
using Microsoft.EntityFrameworkCore;
using LinqKit;

namespace Database.EntityServices
{
    public class TodoTaskRepository(AppDbContext dbContext) : Repository<TodoTask>(dbContext), ITodoTaskRepository
    {
        public List<TodoTask> GetByExpWithIncludes(Expression<Func<TodoTask, bool>> expression, params Expression<Func<TodoTask, object>>[] includes)
        {
            return includes.Aggregate(dbSet.AsQueryable(), (c, i) => c.Include(i)).AsExpandable().Where(expression).ToList();
        }
    }
}
