namespace webApi.Domain.Dtos
{
    // UserMovieDto é utilizado para receber os dados usados para criar relação de usuário a filme.
    public record UserMovieDto
    {
        public required Guid UserId { get; set; }
        public required Guid MovieId { get; set; }
    }
}