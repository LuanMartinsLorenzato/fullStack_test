using webApi.Domain.Entities;

namespace webApi.Presentation.Services.Interfaces
{
    public interface ITokenService
    {
        string GenerateToken(User user);
    }
}