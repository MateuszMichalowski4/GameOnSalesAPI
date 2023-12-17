using System.Collections.Generic;

namespace FreeGamesAPI.Models
{
    public class FreeGames
    {
        public List<Game> current { get; set; }
        public List<Game> upcoming { get; set; }
    }
}
