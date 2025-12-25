using Database;
using Microsoft.Extensions.Options;

namespace WebApi.OptionsSetups;

public class DbOptionsSetup(IConfiguration configuration) : IConfigureOptions<DbOptions>
{
    public void Configure(DbOptions options)
    {
        configuration.GetSection(DbOptions.SectionName).Bind(options);
    }
}
