using System.Net.Mime;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using webApi.Application.Interfaces;
using webApi.Domain.Entities;

namespace webApi.Presentation.Controllers
{
    // UserController é um controllador para ações feitas em relação ao usuário entre  elas temos:
    // Listar todos usuários, pegar apenas um usuário pelo ID, Criar usuário, atualiza o usuário e deleta usuário.

    // Especifica que a resposta do controller é no formato JSON.
    [Produces(MediaTypeNames.Application.Json)]
    // Habilita recursos específicos da API, como o binding de parâmetros de rota, query e corpo de forma automática.
    [ApiController]
    // Herdar de ControllerBase proporciona ao UserController acesso a muitos métodos e propriedades úteis para o tratamento de requisições HTTP.
    public class UserController(IUserUseCases userUseCases) : ControllerBase
    {
        // Chama os casos de uso para poderem ser injetados de acordo com a necessidade.
        private readonly IUserUseCases _userUseCases = userUseCases;

        // Indica quem tem acesso a rota devido a utilização do JWT como Authenticação.
        [Authorize(Roles = "manager")]
        // Define o metodo HTTP para chamada dos endpoints.
        [HttpGet("/get-users", Name = "get-users")]
        // Define retorno de respostas para comunicar o resultado de forma adequada.
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]

        // Utilizamos Task para lidar com operações assíncronas.
        // Utilizamos IActionResult para melhor flexibilidade nas respostas HTTP e erros que podem ocorrer.
        public async Task<IActionResult> GetUsers()
        {
            var usersDB = await _userUseCases.GetUsersAsync();
            return usersDB.Any() ? Ok(usersDB) : NoContent();
        }

        [Authorize]
        [HttpGet("/get-user", Name = "get-user")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetUserById(Guid id)
        {
            var userDB = await _userUseCases.GetUserByIdAsync(id);
            return userDB != null ? Ok(userDB) : NotFound("Usuário não encontrado");
        }

        [HttpPost("/create-user", Name = "create-user")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateUser(User user)
        {
            return await _userUseCases.CreateUser(user)
            ? Ok("Usuário adicionado com sucesso")
            : BadRequest("Erro ao salvar o usuário");
        }

        [Authorize]
        [HttpPut("/update-user", Name = "update-user")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateUser(User user)
        {
            return await _userUseCases.UpdateUser(user)
            ? Ok("Usuário atualizado com sucesso") 
            : BadRequest("Erro ao atualizar o usuário");
        }

        [Authorize]
        [HttpDelete("/delete", Name = "delete")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteUser(Guid id)
        {
            return await _userUseCases.DeleteUser(id)
            ? Ok("Usuário deletado com sucesso")
            : BadRequest("Erro ao deletar o usuário");
        }
    }
}