using webApi.Domain.Dtos;
using webApi.Domain.Entities;

namespace webApi.Application.Interfaces
{
    public interface ILoginUseCase
    {
        Task<User?> GetUserByEmail(LoginDto loginDto);
    }
}