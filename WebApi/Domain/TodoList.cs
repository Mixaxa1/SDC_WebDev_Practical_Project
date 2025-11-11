namespace WebApi.Domain;

public class TodoList
{
    public int Id { get; set; }

    public required string Title { get; set; }

    public string Description { get; set; } = string.Empty;
}
