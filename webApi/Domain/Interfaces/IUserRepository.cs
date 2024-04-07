using webApi.Domain.Dtos;
using webApi.Domain.Entities;

namespace webApi.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetUsersAsync();
        Task<User?> GetUserByIdAsync(Guid id);
        Task<User?> GetUserByEmail(LoginDto loginDto);
        void CreateUser(User user);
        void UpdateUser(User user);
        void DeleteUser(User user);
        Task<bool> SaveChangeAsync();
    }
}