using Database;
using WebApi.OptionsSetups;

namespace WebApi;

public static class ConfigureServices
{
    public static IServiceCollection ConfigureProjectsOptions(this IServiceCollection services)
    {
        services.ConfigureOptions<DbOptionsSetup>();

        return services;
    }
}
