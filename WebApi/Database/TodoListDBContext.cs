using Microsoft.EntityFrameworkCore;
using WebApi.Domain;
using WebApi.Models;

namespace WebApi.Database;
public class TodoListDbContext : DbContext
{
    public TodoListDbContext(DbContextOptions<TodoListDbContext> options)
        : base(options)
    {
    }

    public DbSet<TodoListEntity> TodoLists { get; set; }
    public DbSet<WebApi.Models.TodoListModel> TodoListModel { get; set; } = default!;
}
