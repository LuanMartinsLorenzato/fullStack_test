using System.Net.Mime;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using webApi.Application.Interfaces;
using webApi.Domain.Entities;

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

        [HttpPost("/create-movies", Name = "create-movie")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> Post()
        {
            return await _movieUseCase.CreateMovies()
            ? Ok("Filmes salvos com sucesso")
            : Ok("Filmes já foram salvos");
        }
    };
}