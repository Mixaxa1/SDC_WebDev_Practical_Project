using Database.EntityServices;
using Database.EntityServices.Interfaces;
using Infrastructure.Options;
using Infrastructure.Options.OptionsSetups;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Database;

public static class ConfigureServices
{
    public static IServiceCollection AddDb(this IServiceCollection services)
    {
        services.ConfigureOptions<DbOptionsSetup>();

        var serviceProvider = services.BuildServiceProvider();
        var dbOption = serviceProvider.GetRequiredService<IOptions<DbOptions>>().Value;
        var connectionString = $"Server={dbOption.Server};Database={dbOption.DbName};Trusted_Connection=True";

        services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(connectionString));

        services.AddScoped<ITodoListDbService, TodoListDbService>();
        services.AddScoped<ITodoTaskDbService, TodoTaskDbService>();

        return services;
    }
}
