namespace webApi.Domain.Entities
{
    public class User
    {
        // Guid para dizer que a prop Id será um Guid.
        // Guid.NewGuid() gera ids únicos na aplicação sempre que criamos um novo usuário.
        public Guid Id { get; set; } = Guid.NewGuid();
        public required string Name { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
        public required string Role { get; set; }
        public bool Active { get; set; } = true;
    }
}