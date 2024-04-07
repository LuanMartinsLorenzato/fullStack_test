using System.Net.Mime;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using webApi.Application.Interfaces;

namespace webApi.Presentation.Controllers
{
    // MovieController é um controlador para tratar da listagem de filmes.
    [Produces(MediaTypeNames.Application.Json)]
    [Authorize]
    [ApiController]
    public class MovieController(IMovieUseCase movieUseCase) : ControllerBase
    {
        private readonly IMovieUseCase _movieUseCase = movieUseCase;

        [HttpGet("/get-movies", Name = "get-movies")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> Get()
        {
            var MoviesDB = await _movieUseCase.GetMoviesAsync();
            return MoviesDB.Any() ? Ok(MoviesDB) : NoContent();
        }

        // [HttpPost("/create-movie", Name = "create-movie")]
        // [ProducesResponseType(StatusCodes.Status200OK)]
        // [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        // [ProducesResponseType(StatusCodes.Status403Forbidden)]
        // [ProducesResponseType(StatusCodes.Status400BadRequest)]
        // public async Task<IActionResult> Post(Movie movie, Guid userId)
        // {
        //     return await _movieUseCase.CreateMovie(movie)
        //     ? Ok("Filme salvo com sucesso")
        //     : BadRequest("Erro ao salvar o filme");
        // }

        // [HttpDelete("/delete-movie/{id}", Name = "delete-movie")]
        // [ProducesResponseType(StatusCodes.Status200OK)]
        // [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        // [ProducesResponseType(StatusCodes.Status403Forbidden)]
        // [ProducesResponseType(StatusCodes.Status404NotFound)]
        // [ProducesResponseType(StatusCodes.Status400BadRequest)]
        // public async Task<IActionResult> Delete(Guid id)
        // {
        //     return await _movieUseCase.DeleteMovie(id)
        //     ? Ok("Filme deletado com sucesso")
        //     : BadRequest("Erro ao deletar o filme");
        // }

    };
}