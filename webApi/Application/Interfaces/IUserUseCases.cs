using webApi.Domain.Entities;

namespace webApi.Application.Interfaces
{
    // Interface para criação de métodos para casos de uso.
    public interface IUserUseCases
    {
        Task<User?> GetUserByIdAsync(Guid id);
        Task<IEnumerable<User>> GetUsersAsync();
        Task<bool> CreateUser(User user);
        Task<bool> UpdateUser(User user);
        Task<bool> DeleteUser(Guid id);
    }
}