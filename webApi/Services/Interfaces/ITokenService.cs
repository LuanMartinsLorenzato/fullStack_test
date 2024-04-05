using webApi.Dtos;

namespace webApi.Services.Interfaces
{
    public interface ITokenService
    {
        Task<string> GenerateToken(LoginDto loginDto);
    }
}