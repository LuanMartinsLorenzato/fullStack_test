namespace webApi.Domain.Entities
{
    public class MovieUser
    {
        public Guid UserId { get; set; }
        public Guid MovieId { get; set; }
        public User User { get; set; }
        public Movie Movie { get; set; }

    }
}