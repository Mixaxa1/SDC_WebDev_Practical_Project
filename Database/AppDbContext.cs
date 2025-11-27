using Domain.Entities.TodoList;
using Microsoft.EntityFrameworkCore;

namespace Database;
public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<TodoList> TodoLists { get; set; }
}
