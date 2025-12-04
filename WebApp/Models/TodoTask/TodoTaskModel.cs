using Newtonsoft.Json;

namespace WebApp.Models.TodoTask
{
    public class TodoTaskModel : BaseModel
    {
        [JsonProperty("listid")]
        public int ListId { get; set; }
        [JsonProperty("title")]
        public string Title { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("createdat")]
        public DateTime CreatedAt { get; set; }
        [JsonProperty("dueat")]
        public DateTime DueAt { get; set; }
        [JsonProperty("status")]
        public int Status { get; set; }
        [JsonProperty("tags")]
        public IEnumerable<string> Tags { get; set; }
    }
}
