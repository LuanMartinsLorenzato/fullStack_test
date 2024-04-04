using webApi.Domain.Entities;

namespace webApi.Domain.Repository
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