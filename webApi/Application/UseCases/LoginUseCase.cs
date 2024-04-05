using webApi.Application.Interfaces;
using webApi.Domain.Entities;
using webApi.Domain.Interfaces;

namespace webApi.Application.UseCases
{
    public class LoginUseCase(IUserRepository repository ) : ILoginUseCase
    {        private readonly IUserRepository _repository = repository;

        public Task<User> GetUserByEmail(string email)
        {
            return _repository.GetUserByEmail(email);
        }
    }
}