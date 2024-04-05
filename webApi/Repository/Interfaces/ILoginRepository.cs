using webApi.Models;

namespace webApi.Repository.Interfaces
{
    public interface ILoginRepository
    {
        Task<User> GetUserByEmail(string email);
    }
}