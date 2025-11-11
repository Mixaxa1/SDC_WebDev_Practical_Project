using Microsoft.EntityFrameworkCore;
using WebApi.Domain.TodoList;

namespace WebApi.Database;
public class TodoListDBContext : DbContext
{
    public TodoListDBContext(DbContextOptions<TodoListDBContext> options)
        : base(options)
    {
    }

    public DbSet<TodoListEntity> TodoLists { get; set; }
}
