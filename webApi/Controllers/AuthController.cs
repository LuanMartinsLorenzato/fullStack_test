using Microsoft.AspNetCore.Mvc;
using webApi.Dtos;
using webApi.Models;
using webApi.Repository.Interfaces;
using webApi.Services.Interfaces;

namespace webApi.Controllers
{
    public class AuthController(ITokenService tokenService, IUserRepository repository) : ControllerBase
    {
        private readonly ITokenService _tokenService = tokenService;
        private readonly IUserRepository _repository = repository;


        [HttpPost("login", Name = "login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            var userDB = await _repository.GetUserByEmail(loginDto.Email);
            if (userDB.Active == false) return Unauthorized("Usuário não está mais ativo");
            if (loginDto.Email != userDB.Email) return Unauthorized("Email está incorreto");
            if (loginDto.Password != userDB.Password) return Unauthorized("Senha está incorreta");
            var token = _tokenService.GenerateToken(userDB);
            var response = new
            {
                user = userDB,
                token,
            };
            return Ok(response);
        }
    }
}