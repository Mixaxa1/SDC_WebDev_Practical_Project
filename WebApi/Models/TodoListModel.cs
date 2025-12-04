namespace WebApi.Models;

public class TodoListModel
{
    public Guid Id { get; set; }

    public string Title { get; set; }

    public string Description { get; set; }

    public IEnumerable<TodoTaskModel>? Tasks { get; set; }
}
