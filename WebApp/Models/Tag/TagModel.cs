using Newtonsoft.Json;

namespace WebApp.Models.TaskTag
{
    public class TagModel
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }
        [JsonProperty("title")]
        public string Title { get; set; }
    }
}
