using webApi.Domain.Entities;

namespace webApi.Application.Interfaces
{
    public interface IUserUseCases
    {
        Task<User> GetUserByIdAsync(Guid id);
        Task<IEnumerable<User>> GetUsersAsync();
        Task<bool> CreateUser(User user);
        Task<bool> UpdateUser(Guid id, User user);
        Task<bool> DeleteUser(Guid id);
    }
}