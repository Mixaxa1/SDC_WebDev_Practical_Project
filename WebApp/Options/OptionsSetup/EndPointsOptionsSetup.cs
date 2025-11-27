using Microsoft.Extensions.Options;

namespace WebApp.Options.OptionsSetup;

public class EndPointsOptionsSetup(IConfiguration configuration) : IConfigureOptions<EndPointsOptions>
{
    public void Configure(EndPointsOptions options)
    {
        configuration.GetSection(EndPointsOptions.SectionName).Bind(options);
    }
}
