using System.Text.Json.Serialization;

namespace webApi.Domain.Entities
{
    public class Movie
    {
        public Guid Id { get; set; }

        [JsonIgnore]
        public List<User> Users { get; set; } = [];
        public required string Title { get; set; }
        public required string Runtime { get; set; }
        public required string Released { get; set; }
        public required string Poster { get; set; }
    }
}