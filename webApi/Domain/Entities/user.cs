using System.Text.Json.Serialization;

namespace webApi.Domain.Entities
{
    public class User
    {
        // Guid para dizer que a prop Id será um Guid, ele gera o Id automático.
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
        public required string Role { get; set; }

        [JsonIgnore]
        public ICollection<Movie> Movies { get; set; } = [];
        public bool Active { get; set; } = true;
    }
}