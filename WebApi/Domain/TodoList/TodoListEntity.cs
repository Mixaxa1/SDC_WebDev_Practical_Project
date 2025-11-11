namespace WebApi.Domain.TodoList;

public class TodoListEntity : Entity
{
    public required string Title { get; set; }

    public string Description { get; set; } = string.Empty;
}
