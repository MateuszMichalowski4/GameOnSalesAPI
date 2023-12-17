using System.Threading.Tasks;
using FreeGamesAPI.Models;

public interface IGameDetailService
{
    Task<GameDetail> GetGameDetail(int id);
}
