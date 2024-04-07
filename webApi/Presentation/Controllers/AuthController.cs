using Microsoft.AspNetCore.Mvc;
using webApi.Domain.Dtos;
using webApi.Presentation.Services.Interfaces;
using webApi.Application.Interfaces;
using System.Net.Mime;

namespace webApi.Presentation.Controllers
{
    // AuthController é um controlador de login onde verificamos as credenciais de login em _loginUseCase.
    // Caso tenha algum problema retornamos ao usuário.
    // Caso o login esteja correto geramos o token JWT.
    [Produces(MediaTypeNames.Application.Json)]
    [ApiController]
    public class AuthController(ITokenService tokenService, ILoginUseCase loginUseCase) : ControllerBase
    {
        // Utilizado o token service para tratar das configurações do JWT para a autorização.
        private readonly ITokenService _tokenService = tokenService;
        private readonly ILoginUseCase _loginUseCase = loginUseCase;
        [HttpPost("login", Name = "login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            var userDB = await _loginUseCase.GetUserByEmail(loginDto);
            if (userDB == null) return Unauthorized("Email está incorreto");
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