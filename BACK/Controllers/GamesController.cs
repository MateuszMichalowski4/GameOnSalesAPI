using System.Threading.Tasks;
using FreeGamesAPI.Interfaces;
using FreeGamesAPI.Models;
using FreeGamesAPI.Response;
using Microsoft.AspNetCore.Mvc;

namespace FreeGamesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GamesController : ControllerBase
    {
        private readonly IGameService _gameService;

        public GamesController(IGameService gameService)
        {
            _gameService = gameService;
        }

        [HttpGet]
        public async Task<ActionResult<FreeGamesResponse>> GetGames()
        {
            var games = await _gameService.GetGames();
            if (games == null)
            {
                return NotFound();
            }

            return Ok(games);
        }
    }
}
