using Microsoft.AspNetCore.Mvc;
using webApi.Dtos;
using webApi.Services.Interfaces;

namespace webApi.Controllers
{
    public class AuthController(ITokenService tokenService) : ControllerBase
    {
        private readonly ITokenService _tokenService = tokenService;

        [HttpPost("login", Name = "login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            var token = await _tokenService.GenerateToken(loginDto);
            if (token == "") return Unauthorized();
            return Ok(token);
        }

    }
}