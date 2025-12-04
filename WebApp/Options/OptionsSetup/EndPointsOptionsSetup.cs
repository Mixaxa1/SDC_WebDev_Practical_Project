using Microsoft.Extensions.Options;

namespace WebApp.Options.OptionsSetup;

public class EndpointsOptionsSetup(IConfiguration configuration) : IConfigureOptions<EndpointsOptions>
{
    public void Configure(EndpointsOptions options)
    {
        configuration.GetSection(EndpointsOptions.SectionName).Bind(options);
    }
}
