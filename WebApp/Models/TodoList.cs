using Newtonsoft.Json;

namespace WebApp.Models;

public class TodoList : DataModel
{
    [JsonProperty("title")]
    public string Title { get; set; }

    [JsonProperty("description")]
    public string Description { get; set; }

}
