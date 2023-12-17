using FreeGamesAPI.Models;

namespace FreeGamesAPI.Interfaces
{
    public interface IFreeToPlayGameService
    {
        Task<List<FreeToPlayGame>> GetFreeToPlayGames();
    }
}
