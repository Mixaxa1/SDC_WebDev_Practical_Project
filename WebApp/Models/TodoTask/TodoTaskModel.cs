using Newtonsoft.Json;

namespace WebApp.Models.TodoTask
{
    public class TodoTaskModel
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }
        [JsonProperty("listid")]
        public Guid ListId { get; set; }
        [JsonProperty("title")]
        public string Title { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("createdat")]
        public DateTime CreatedAt { get; set; }
        [JsonProperty("dueat")]
        public DateTime DueAt { get; set; }
        [JsonProperty("status")]
        public string Status { get; set; }
        [JsonProperty("tags")]
        public IEnumerable<string> Tags { get; set; }
    }
}
