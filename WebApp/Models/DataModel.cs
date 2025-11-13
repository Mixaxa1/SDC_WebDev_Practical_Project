using Newtonsoft.Json;

namespace WebApp.Models;

public class DataModel
{
    [JsonProperty("id")]
    public int Id { get; set; }
}
