namespace Koodihaaste22Frontend.Models;

public class RestaurantResponseDto
{
    [JsonPropertyName("alreadyVoted")]
    public string AlreadyVoted { get; set; } = string.Empty;

    [JsonPropertyName("date")]
    public string Date { get; set; } = string.Empty;

    [JsonPropertyName("restaurants")]
    public List<RestaurantDto> Restaurants { get; set; } = new List<RestaurantDto>();
}