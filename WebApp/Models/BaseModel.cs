using Newtonsoft.Json;

namespace WebApp.Models;

public class BaseModel
{
    [JsonProperty("id")]
    public int Id { get; set; }
}
