using System.Net.Mime;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using webApi.Application.Interfaces;
using webApi.Domain.Dtos;

namespace webApi.Presentation.Controllers
{
    // UserMovieController é um controlador que recebe os dados relacionados as duas tabelas existentes de User e Movie.

    [Produces(MediaTypeNames.Application.Json)]
    [Authorize]
    [ApiController]
    public class UserMovieController(IUserMovieUseCases userMovieUseCase) : ControllerBase
    {
        private readonly IUserMovieUseCases _userMovieUseCase = userMovieUseCase;

        [HttpPut("/add-movie-user", Name = "add-movie-user")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddMovieOnUser(UserMovieDto userMovieDto)
        {
            return await _userMovieUseCase.AddMovieOnUser(userMovieDto)
            ? Ok("Filme adicionado com sucesso")
            : BadRequest("Erro ao relacionar filme ao usuário");
        }

        [HttpPut("/remove-movie-user", Name = "remove-movie-user")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)] 
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> RemoveMovieOnUser(UserMovieDto userMovieDto)
        {
            return await _userMovieUseCase.RemoveMovieOnUser(userMovieDto)
            ? Ok("Filme retirado com sucesso!")
            : BadRequest("Erro ao retirar filme do usuário");
        }
    }
}