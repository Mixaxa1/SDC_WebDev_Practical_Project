using Newtonsoft.Json;
using WebApp.Models.TodoTask;

namespace WebApp.Models.TodoList;

public class TodoListModel : BaseModel
{
    [JsonProperty("title")]
    public string Title { get; set; }

    [JsonProperty("description")]
    public string Description { get; set; }
    [JsonProperty("tasks")]
    public IEnumerable<TodoTaskModel> Tasks { get; set; }
}
