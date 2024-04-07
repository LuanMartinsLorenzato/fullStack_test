using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using webApi.Domain.Entities;
using webApi.Presentation.Services.Interfaces;

namespace webApi.Presentation.Services
{
    // TokenService é um serviço de configuração para o JWT (JSON Web Token).
    public class TokenService(IConfiguration configuration) : ITokenService
    {
        private readonly IConfiguration _configuration = configuration;

        public string GenerateToken(User user)
        {
            // SymmetricSecurityKey é utilizado para criptografia de tokens de segurança.
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"] ?? string.Empty));
            var issuer = _configuration["Jwt:Issuer"];
            var audience = _configuration["Jwt:Audience"];

            // SigningCredentials usado para especificar o token de segurança será assinado.
            var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

            // JwtSecurityToken contém propriedades que representam as várias partes de um token JWT
            var tokenOptions = new JwtSecurityToken(
                issuer: issuer,
                audience: audience,
                claims:
                [
                    new Claim(type: ClaimTypes.Name, user.Name),
                    new Claim(type: ClaimTypes.Role, user.Role),
                ],
                expires: DateTime.Now.AddHours(1),
                signingCredentials: signinCredentials
            );
            
            // JwtSecurityTokenHandler fornece funcionalidades para criar, validar, serializar e manipular tokens JWT de forma eficaz e segura.
            var token = new JwtSecurityTokenHandler().WriteToken(tokenOptions);

            return token;
        }
    }
}