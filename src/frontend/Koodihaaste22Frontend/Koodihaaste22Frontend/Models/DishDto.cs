namespace Koodihaaste22Frontend.Models;

public class DishDto
{
    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;

    [JsonPropertyName("price")]
    public string Price { get; set; } = string.Empty;

    [JsonPropertyName("attributes")]
    public List<string> Attributes { get; set; } = new List<string>();
}
