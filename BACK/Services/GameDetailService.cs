using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using FreeGamesAPI.Interfaces;
using FreeGamesAPI.Models;

public class GameDetailService : IGameDetailService
{
    private readonly HttpClient _client;

    public GameDetailService(HttpClient client)
    {
        _client = client;
    }

    public async Task<GameDetail> GetGameDetail(int id)
    {
        var request = new HttpRequestMessage
        {
            Method = HttpMethod.Get,
            RequestUri = new Uri(_client.BaseAddress, $"api/game?id={id}")
        };

        using (var response = await _client.SendAsync(request))
        {
            response.EnsureSuccessStatusCode();
            var body = await response.Content.ReadAsStringAsync();

            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };

            var gameDetail = JsonSerializer.Deserialize<GameDetail>(body, options);

            return gameDetail;
        }
    }
}
