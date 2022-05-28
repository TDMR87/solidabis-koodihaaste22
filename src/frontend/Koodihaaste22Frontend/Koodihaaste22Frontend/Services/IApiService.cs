namespace Koodihaaste22Frontend.Services;

public interface IApiService
{
    Task<RestaurantResponseDto?> GetRestaurantsByCity(string city, [CallerMemberName] string caller = "");
    Task VoteForRestaurant(string restaurantId, [CallerMemberName] string caller = "");
}
