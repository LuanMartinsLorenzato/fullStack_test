using webApi.Models;

namespace webApi.Repository
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> SearchUsers();
        Task<User> SearchUser(Guid id);

        void AddUser(User user);
        void UpdateUser(User user);
        void DeleteUser(User user);

        Task<bool> SaveChangeAsync();
    }
}