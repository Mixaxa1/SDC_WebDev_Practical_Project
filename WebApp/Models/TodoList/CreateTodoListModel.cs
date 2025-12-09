using Newtonsoft.Json;

namespace WebApp.Models.TodoList;

public class CreateTodoListModel
{
    public Guid Id { get; set; }
    public string Title { get; set; }

    public string Description { get; set; }
}
