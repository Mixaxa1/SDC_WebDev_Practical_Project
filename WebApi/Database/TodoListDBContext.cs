using Microsoft.EntityFrameworkCore;

namespace WebApi.Database;
public class TodoListDBContext : DbContext
{
    public TodoListDBContext(DbContextOptions<TodoListDBContext> options)
        : base(options)
    {

    }
}
