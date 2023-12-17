using FreeGamesAPI.Models;
using FreeGamesAPI.Response;
using System.Threading.Tasks;

namespace FreeGamesAPI.Interfaces
{
    public interface IGameService
    {
        Task<FreeGamesResponse> GetGames();
    }
}
