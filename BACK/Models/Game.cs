using System.Text.Json.Serialization;

namespace FreeGamesAPI.Models
{
    public class Game
    {
        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("namespace")]
        public string Namespace { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("effectiveDate")]
        public string EffectiveDate { get; set; }

        [JsonPropertyName("offerType")]
        public string OfferType { get; set; }

        [JsonPropertyName("expiryDate")]
        public string ExpiryDate { get; set; }

        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonPropertyName("isCodeRedemptionOnly")]
        public bool IsCodeRedemptionOnly { get; set; }

        [JsonPropertyName("productSlug")]
        public string ProductSlug { get; set; }

        [JsonPropertyName("urlSlug")]
        public string UrlSlug { get; set; }

        [JsonPropertyName("url")]
        public string Url { get; set; }
    }
}

