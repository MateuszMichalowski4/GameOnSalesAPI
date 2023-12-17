using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FreeGamesAPI.Interfaces;

namespace FreeGamesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameDetailController : ControllerBase
    {
        private readonly IGameDetailService _gameDetailService;

        public GameDetailController(IGameDetailService gameDetailService)
        {
            _gameDetailService = gameDetailService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _gameDetailService.GetGameDetail(id);
            return Ok(result);
        }
    }
}
