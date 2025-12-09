using Newtonsoft.Json;
using WebApp.Models.TodoTask;

namespace WebApp.Models.TodoList;

public class TodoListModel
{
    [JsonProperty("id")]
    public Guid Id { get; set; }
    [JsonProperty("title")]
    public string Title { get; set; }

    [JsonProperty("description")]
    public string Description { get; set; }
    [JsonProperty("tasks")]
    public IEnumerable<TodoTaskModel> Tasks { get; set; }
}
