using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using WebApi.Database;
using WebApi.Database.EntityServices;
using WebApi.Database.EntityServices.Interfaces;
using WebApi.Options;
using WebApi.Options.OptionsSetups;

namespace WebApi;

public static class ConfigureServices
{
    public static IServiceCollection AddDb(this IServiceCollection services)
    {
        services.ConfigureOptions<DbOptionsSetup>();

        var serviceProvider = services.BuildServiceProvider();
        var dbOption = serviceProvider.GetRequiredService<IOptions<DbOptions>>().Value;
        var connectionString = $"Server={dbOption.Server};Database={dbOption.DbName};Trusted_Connection=True";

        services.AddDbContext<TodoListDbContext>(opt => opt.UseSqlServer(connectionString));

        services.AddScoped<ITodoListDbService, TodoListDbService>();

        return services;
    }
}
