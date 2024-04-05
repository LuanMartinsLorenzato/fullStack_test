using webApi.Dtos;
using webApi.Models;

namespace webApi.Services.Interfaces
{
    public interface ITokenService
    {
        string GenerateToken(User user);
    }
}