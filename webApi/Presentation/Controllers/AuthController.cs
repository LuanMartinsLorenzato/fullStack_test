using Microsoft.AspNetCore.Mvc;
using webApi.Presentation.Dtos;
using webApi.Presentation.Services.Interfaces;
using webApi.Application.Interfaces;

namespace webApi.Presentation.Controllers
{
    [ApiController]
    public class AuthController(ITokenService tokenService, ILoginUseCase loginUseCase) : ControllerBase
    {
        private readonly ITokenService _tokenService = tokenService;
        private readonly ILoginUseCase _loginUseCase = loginUseCase;
        [HttpPost("login", Name = "login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            var userDB = await _loginUseCase.GetUserByEmail(loginDto.Email);
            if (userDB == null) return NotFound("Email está incorreto");
            if (userDB.Active == false) return Unauthorized("Usuário não está mais ativo");
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