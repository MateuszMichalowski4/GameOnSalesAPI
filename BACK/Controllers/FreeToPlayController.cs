using System.Collections.Generic;
using System.Threading.Tasks;
using FreeGamesAPI.Interfaces;
using FreeGamesAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace FreeGamesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FreeToPlayGamesController : ControllerBase
    {
        private readonly IFreeToPlayGameService _freeToPlayGameService;

        public FreeToPlayGamesController(IFreeToPlayGameService freeToPlayGameService)
        {
            _freeToPlayGameService = freeToPlayGameService;
        }

        [HttpGet]
        public async Task<ActionResult<List<FreeToPlayGame>>> GetFreeToPlayGames()
        {
            var games = await _freeToPlayGameService.GetFreeToPlayGames();
            if (games == null)
            {
                return NotFound();
            }

            return Ok(games);
        }
    }
}
