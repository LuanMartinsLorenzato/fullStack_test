using webApi.Application.Interfaces;
using webApi.Domain.Entities;
using webApi.Domain.Interfaces;

namespace webApi.Application.UseCases
{
    public class UserUseCases(IUserRepository repository) : IUserUseCases
    {
        // Chama o repositório para utilizar seus métodos
        private readonly IUserRepository _repository = repository;

        public async Task<bool> CreateUser(User user)
        {
            _repository.CreateUser(user);
            return await _repository.SaveChangeAsync();
        }

        public async Task<User> GetUserByIdAsync(Guid id)
        {
            return await _repository.GetUserByIdAsync(id);
        }

        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            return await _repository.GetUsersAsync();
        }

        public async Task<bool> UpdateUser(Guid id, User user)
        {
            var userDB = await _repository.GetUserByIdAsync(id);
            if (userDB == null) return false;

            userDB.Name = user.Name ?? userDB.Name;
            userDB.Email = user.Email ?? userDB.Email;
            userDB.Password = user.Password ?? userDB.Password;
            userDB.Role = user.Role ?? userDB.Role;
            userDB.Active = user.Active == true;
            userDB.Movies = user.Movies ?? userDB.Movies;

            return await _repository.SaveChangeAsync();
        }

        public async Task<bool> DeleteUser(Guid id)
        {
            var userDB = await _repository.GetUserByIdAsync(id);
            if (userDB == null) return false;

            _repository.DeleteUser(userDB);
            
            return await _repository.SaveChangeAsync();
        }
    }
}