using Newtonsoft.Json;

namespace WebApp.Models;

public class BaseModel
{
    [JsonProperty("id")]
    public Guid Id { get; set; }
}
