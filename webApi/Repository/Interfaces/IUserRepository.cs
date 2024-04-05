using webApi.Models;

namespace webApi.Repository.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> SearchUsers();
        Task<User> SearchUser(Guid id);

        Task<User> GetUserByEmail(string email);

        void AddUser(User user);
        void UpdateUser(User user);
        void DeleteUser(User user);

        Task<bool> SaveChangeAsync();
    }
}