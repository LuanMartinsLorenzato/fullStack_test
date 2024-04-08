using System.Text.Json.Serialization;

namespace webApi.Domain.Entities
{
    public class Movie
    {
        public Guid Id { get; set; }

        [JsonIgnore]
        public List<User> Users { get; set; } = [];

        [JsonPropertyName("Title")]
        public string? Title { get; set; }

        [JsonPropertyName("Type")]
        public string? Type { get; set; }

        [JsonPropertyName("Year")]
        public string? Year { get; set; }

        [JsonPropertyName("Poster")]
        public string? Poster { get; set; }
    }
}