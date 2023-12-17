using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using FreeGamesAPI.Interfaces;
using FreeGamesAPI.Models;

public class FreeToPlayGameService : IFreeToPlayGameService
{
    private readonly HttpClient _client;

    public FreeToPlayGameService(HttpClient client)
    {
        _client = client;
    }

    public async Task<List<FreeToPlayGame>> GetFreeToPlayGames()
    {
        var request = new HttpRequestMessage
        {
            Method = HttpMethod.Get,
            RequestUri = _client.BaseAddress
        };

        using (var response = await _client.SendAsync(request))
        {
            response.EnsureSuccessStatusCode();
            var body = await response.Content.ReadAsStringAsync();
            var games = JsonSerializer.Deserialize<List<FreeToPlayGame>>(body);

            return games;
        }
    }
}
