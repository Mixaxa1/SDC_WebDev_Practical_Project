namespace WebApp.Options;

public class EndPointsOptions
{
    public const string SectionName = "EndPoints";

    public required string CommonBase { get; init; }

    public required string TodoListBase { get; init; }
}
