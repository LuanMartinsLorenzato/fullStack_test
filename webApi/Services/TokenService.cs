using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using webApi.Dtos;
using webApi.Models;
using webApi.Repository;
using webApi.Repository.Interfaces;
using webApi.Services.Interfaces;

namespace webApi.Services
{
    public class TokenService(IConfiguration configuration, IUserRepository repository) : ITokenService
    {
        private readonly IUserRepository _repository = repository;
        private readonly IConfiguration _configuration = configuration;

        public async Task<string> GenerateToken(LoginDto loginDto)
        {
            var userDB = await _repository.GetUserByEmail(loginDto.Email);

            if (loginDto.Email != userDB.Email || loginDto.Password != userDB.Password)
                return string.Empty;
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"] ?? string.Empty));
            var issuer = _configuration["Jwt:Issuer"];
            var audience = _configuration["Jwt:Audience"];

            var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

            var tokenOptions = new JwtSecurityToken(
                issuer: issuer,
                audience: audience,
                claims:
                [
                    new Claim(type: ClaimTypes.Name, userDB.Name),
                    new Claim(type: ClaimTypes.Role, userDB.Role),
                ],
                expires: DateTime.Now.AddHours(1),
                signingCredentials: signinCredentials
            );
            var token = new JwtSecurityTokenHandler().WriteToken(tokenOptions);

            return token;
        }
    }
}