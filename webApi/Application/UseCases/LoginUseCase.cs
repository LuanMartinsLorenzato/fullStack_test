using webApi.Application.Interfaces;
using webApi.Domain.Dtos;
using webApi.Domain.Entities;
using webApi.Domain.Interfaces;

namespace webApi.Application.UseCases
{
    public class LoginUseCase(IUserQueryRepository queryRepository) : ILoginUseCase
    {
        private readonly IUserQueryRepository _queryRepository = queryRepository;

        public Task<User?> GetUserByEmail(LoginDto loginDto)
        {
            return _queryRepository.GetUserByEmail(loginDto);
        }
    }
}