namespace webApi.Domain.Entities
{
    public class UserMovie
    {
        public Guid UserId { get; set; }
        public Guid MovieId { get; set; }
        public required User User { get; set; }
        public required Movie Movie { get; set; }

    }
}