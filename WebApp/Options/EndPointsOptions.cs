namespace WebApp.Options;

public class EndpointsOptions
{
    public const string SectionName = "Endpoints";

    public required string CommonBase { get; init; }

    public required TodoListEndpoints ListEndpoints { get; init; }
    public required TodoTaskEndpoints TaskEndpoints { get; init; }
}
