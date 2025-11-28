using Domain.Entities.List;
using Domain.Entities.Task;
using Microsoft.EntityFrameworkCore;

namespace Database;
public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<TodoList> TodoLists { get; set; }
    public DbSet<TodoTask> TodoTasks { get; set; }
    public DbSet<Tag> Tags { get; set; }    
}
