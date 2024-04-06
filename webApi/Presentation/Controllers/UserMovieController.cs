// using Microsoft.AspNetCore.Mvc;

// namespace webApi.Presentation.Controllers
// {
//     [ApiController]
//     public class UserMovieController(IUserMovieUseCase userMovieUseCase) : ControllerBase
//     {
//         private readonly IUserMovieUseCase _userMovieUseCase = userMovieUseCase;

//         // [Authorize(Roles = "manager,user")]
//         [HttpPut("add-movie/{movieId}/user/{userId}", Name = "add-movie-user")]
//         // [ProducesResponseType(StatusCodes.Status200OK)]
//         // [ProducesResponseType(StatusCodes.Status500InternalServerError)]
//         // [ProducesResponseType(StatusCodes.Status403Forbidden)]
//         // [ProducesResponseType(StatusCodes.Status404NotFound)]
//         // [ProducesResponseType(StatusCodes.Status400BadRequest)]
//         public async Task<IActionResult> Put(Guid movieId, Guid userId)
//         {
//             return await _userMovieUseCase.AddMovieToUser(movieId, userId)
//             ? Ok("Filme adicionado com sucesso")
//             : BadRequest("Erro ao relacionar filme ao usuário");
//         }

//         // [HttpPut("remove-movie/{movieId}/user/{userId}", Name = "remove-movie-user")]
//         // // [ProducesResponseType(StatusCodes.Status200OK)]
//         // // [ProducesResponseType(StatusCodes.Status500InternalServerError)]
//         // // [ProducesResponseType(StatusCodes.Status403Forbidden)]
//         // // [ProducesResponseType(StatusCodes.Status404NotFound)]
//         // // [ProducesResponseType(StatusCodes.Status400BadRequest)]
//         // public async Task<IActionResult> Put(Guid movieId, Guid userId)
//         // {
//         //     return await _userMovieUseCase.AddMovieToUser(movieId, userId)
//         //     ? Ok("Filme adicionado com sucesso")
//         //     : BadRequest("Erro ao relacionar filme ao usuário");
//         // }
//     }
// }