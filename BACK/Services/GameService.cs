using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using FreeGamesAPI.Interfaces;
using FreeGamesAPI.Models;
using FreeGamesAPI.Response;

public class GameService : IGameService
{
    private readonly HttpClient _client;

    public GameService(HttpClient client)
    {
        _client = client;
    }

    public async Task<FreeGamesResponse> GetGames()
    {
        var request = new HttpRequestMessage
        {
            Method = HttpMethod.Get,
            RequestUri = new Uri(_client.BaseAddress, "free")
        };

        using (var response = await _client.SendAsync(request))
        {
            response.EnsureSuccessStatusCode();
            var body = await response.Content.ReadAsStringAsync();
            var gamesResponse = JsonSerializer.Deserialize<FreeGamesResponse>(body);

            return gamesResponse;
        }
    }
}
