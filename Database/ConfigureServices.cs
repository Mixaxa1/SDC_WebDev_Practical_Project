using Application.Abstraction.Repositories;
using Database.EntityServices;
using Database.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Database;

public static class ConfigureServices
{
    public static IServiceCollection AddDb(this IServiceCollection services)
    {
        using var serviceProvider = services.BuildServiceProvider();

        var dbOption = serviceProvider.GetRequiredService<IOptions<DbOptions>>().Value;
        var connectionString = $"Server={dbOption.Server};Database={dbOption.DbName};Trusted_Connection=True";

        services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(connectionString));

        services.AddScoped <ITodoListRepository, TodoListRepository>();
        services.AddScoped<ITodoTaskRepository, TodoTaskRepository>();
        services.AddScoped<ITagRepository, TagRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        return services;
    }
}
