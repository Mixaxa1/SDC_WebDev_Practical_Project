namespace Domain.Entities.TodoList;

public class TodoList : Entity
{
    public required string Title { get; set; }

    public string Description { get; set; } = string.Empty;
}
