using Microsoft.Extensions.Options;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Options.OptionsSetups;

public class DbOptionsSetup(IConfiguration configuration) : IConfigureOptions<DbOptions>
{
    public void Configure(DbOptions options)
    {
        configuration.GetSection(DbOptions.SectionName).Bind(options);
    }
}
