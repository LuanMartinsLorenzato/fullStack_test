namespace webApi.Domain.Dtos
{
    // LoginDto é utilizado para receber os dados de login.
    // Passado como record já que será imutavél e mais seguro para transmitir dados.
    public record LoginDto
    {
        public required string Email { get; set; }
        public required string Password { get; set; }
    }
}