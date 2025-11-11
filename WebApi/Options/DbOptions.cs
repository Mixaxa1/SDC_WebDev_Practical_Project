namespace WebApi.Options;

public class DbOptions
{
    public const string SectionName = "Database";

    public required string Server { get; init; }

    public required string DbName { get; init; }
}
