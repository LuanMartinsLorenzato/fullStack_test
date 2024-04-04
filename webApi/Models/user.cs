namespace webApi.Domain.Entities
{

    public class User
    {
        // Guid para dizer que a prop Id será um Guid.
        // Guid.NewGuid() gera ids únicos na aplicação sempre que criamos um novo usuário.
        public Guid Id { get; set; } = Guid.NewGuid();
        public required string Name { get; set; }
    }
}