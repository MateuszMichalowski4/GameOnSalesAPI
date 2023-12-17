namespace FreeGamesAPI.Models
{
    public class GameDetail
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Thumbnail { get; set; }
        public string Status { get; set; }
        public string Short_Description { get; set; }
        public string Description { get; set; }
        public string Game_Url { get; set; }
        public string Genre { get; set; }
        public string Platform { get; set; }
        public string Publisher { get; set; }
        public string Developer { get; set; }
        public string Release_Date { get; set; }
        public string Freetogame_Profile_Url { get; set; }
        public MinimumSystemRequirements Minimum_System_Requirements { get; set; }
        public List<Screenshot> Screenshots { get; set; }
    }

    public class MinimumSystemRequirements
    {
        public string Os { get; set; }
        public string Processor { get; set; }
        public string Memory { get; set; }
        public string Graphics { get; set; }
        public string Storage { get; set; }
    }

    public class Screenshot
    {
        public int Id { get; set; }
        public string Image { get; set; }
    }
}

