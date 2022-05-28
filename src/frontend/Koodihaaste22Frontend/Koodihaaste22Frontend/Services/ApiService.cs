namespace Koodihaaste22Frontend.Services;

public class ApiService : IApiService
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly IConfiguration _configuration;
    private readonly NavigationManager _navigationManager;
    private readonly ProtectedLocalStorage _cacheStorage;

    public ApiService(IHttpClientFactory httpClientFactory, IConfiguration configuration, ProtectedLocalStorage cacheStorage, NavigationManager navigationManager)
    {
        _httpClientFactory = httpClientFactory;
        _configuration = configuration;
        _cacheStorage = cacheStorage;
        _navigationManager = navigationManager;
    }

    /// <summary>
    /// Returns the restaurants in the specified city.
    /// </summary>
    /// <param name="city"></param>
    /// <param name="caller"></param>
    /// <returns></returns>
    /// <exception cref="InvalidOperationException"></exception>
    public async Task<RestaurantResponseDto?> GetRestaurantsByCity(string city, [CallerMemberName] string caller = "")
    {
        // Guarding
        if (string.IsNullOrWhiteSpace(city)) return await Task.FromResult(new RestaurantResponseDto());

        // The request uri to the restaurant API
        var uri = new Uri($"http://{_configuration.GetSection("Api").Value}/api/v1/restaurants/{city}");

        // Create a handler and cookie container for the request
        HttpClientHandler handler = new HttpClientHandler();
        handler.CookieContainer = new CookieContainer();

        // Get the voter id from session storage
        var voteridCache = await _cacheStorage.GetAsync<string>("VOTERID");

        // If previous voterid was found in the cache, add it to the cookie container
        if (!string.IsNullOrWhiteSpace(voteridCache.Value))
        {
            handler.CookieContainer.Add(uri, new Cookie("VOTERID", voteridCache.Value));
        }

        // Create client and execute the request to the restaurant API
        var client = new HttpClient(handler);
        var request = new HttpRequestMessage(HttpMethod.Get, uri);
        var response = await client.SendAsync(request);

        // If successfull response from the API
        if (response.IsSuccessStatusCode)
        {
            // If previous voter id was _not_ in the browser cache already
            if (string.IsNullOrWhiteSpace(voteridCache.Value))
            {
                // Get the voterid cookie value from the API response
                string voterid = handler.CookieContainer.GetCookies(new Uri($"http://{_configuration.GetSection("Api").Value}"))["VOTERID"]?.Value ?? string.Empty;

                // Save the voter id to browser cache
                await _cacheStorage.SetAsync("VOTERID", voterid);
            }

            // Get the response as stream
            using var responseStream = await response.Content.ReadAsStreamAsync();

            // Return the deserialized stream
            return await JsonSerializer.DeserializeAsync<RestaurantResponseDto>(responseStream);
        }
        else
        {
            // The request response did not indicate success
            throw new InvalidOperationException(
                $"{nameof(GetRestaurantsByCity)}: \n" +
                $"Restaurant API response was not success. \n" +
                $"Status code: {response.StatusCode} \n" +
                $"Url: {uri.AbsolutePath}. \n" +
                $"Caller: {caller}");
        }
    }

    /// <summary>
    /// Adds or removes a vote to the specified restaurant.
    /// </summary>
    /// <param name="restaurantId"></param>
    /// <param name="caller"></param>
    /// <returns></returns>
    /// <exception cref="InvalidOperationException"></exception>
    public async Task VoteForRestaurant(string restaurantId, [CallerMemberName] string caller = "")
    {
        // The request uri to the restaurant API
        var uri = new Uri($"http://{_configuration.GetSection("Api").Value}/api/v1/vote/{restaurantId}");

        // Get the voter id from session storage
        var voterid = await _cacheStorage.GetAsync<string>("VOTERID");

        // Set the voter id cookie
        HttpClientHandler handler = new HttpClientHandler();
        handler.CookieContainer = new CookieContainer();
        handler.CookieContainer.Add(uri, new Cookie("VOTERID", voterid.Value));

        // Send the request
        var client = new HttpClient(handler);
        var request = new HttpRequestMessage(HttpMethod.Post, uri);
        var response = await client.SendAsync(request);

        // Handle unsuccesfull requests
        if (!response.IsSuccessStatusCode)
        {
            throw new InvalidOperationException($"{nameof(GetRestaurantsByCity)}: API call failed. Url: {uri}. Caller: {caller}");
        }
    }
}
