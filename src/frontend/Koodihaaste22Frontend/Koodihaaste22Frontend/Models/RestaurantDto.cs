namespace Koodihaaste22Frontend.Models;

public class RestaurantDto
{
    [JsonPropertyName("id")]
    public string ID { get; set; } = string.Empty;

    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;

    [JsonPropertyName("openingHours")]
    public string OpeningHours { get; set; } = string.Empty;

    [JsonPropertyName("votes")]
    public int Votes { get; set; }

    [JsonPropertyName("dishes")]
    public List<DishDto> Dishes { get; set; } = new List<DishDto>();
}
