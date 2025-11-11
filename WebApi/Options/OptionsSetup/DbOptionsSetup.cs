using Microsoft.Extensions.Options;

namespace WebApi.Options.OptionsSetup;

public class DbOptionsSetup(IConfiguration configuration) : IConfigureOptions<DbOptions>
{
    public void Configure(DbOptions options)
    {
        configuration.GetSection(DbOptions.SectionName).Bind(options);
    }
}
