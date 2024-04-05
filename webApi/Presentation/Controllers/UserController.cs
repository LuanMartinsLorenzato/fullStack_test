// using System.Net.Mime;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using webApi.Application.Interfaces;
using webApi.Domain.Entities;

namespace webApi.Presentation.Controllers
{
    // [Produces(MediaTypeNames.Application.Json)]
    // Habilita recursos específicos da API, como o binding de parâmetros de rota, query e corpo de forma automática.
    [ApiController]
    // Define a rota de acesso ao controlador onde [controller] é um token que será substituído pelo nome do controlador.
    [Route("api/[controller]")]
    // Herdar de ControllerBase proporciona ao UserController acesso a muitos métodos e propriedades úteis para o tratamento de requisições HTTP.
    public class UserController(IUserUseCases userUseCases) : ControllerBase
    {
        private readonly IUserUseCases _userUseCases = userUseCases;

        // Indica quem tem acesso a rota
        [Authorize(Roles = "manager")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]

        public async Task<IActionResult> Get()
        {
            var usersDB = await _userUseCases.GetUsersAsync();
            return usersDB.Any() ? Ok(usersDB) : NoContent();
        }

        [Authorize(Roles = "manager,user")]
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get(Guid id)
        {
            var userDB = await _userUseCases.GetUserByIdAsync(id);
            return userDB != null ? Ok(userDB) : NotFound("Usuário não encontrado");
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post(User user)
        {
            return await _userUseCases.CreateUser(user)
            ? Ok("Usuário adicionado com sucesso")
            : BadRequest("Erro ao salvar o usuário");
        }

        [Authorize(Roles = "manager,user")]
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Put(Guid id, User user)
        {
            return await _userUseCases.UpdateUser(id, user) ?
                Ok("Usuário atualizado com sucesso") :
                BadRequest("Erro ao atualizar o usuário");
        }

        [Authorize(Roles = "manager,user")]
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Delete(Guid id)
        {
            return await _userUseCases.DeleteUser(id)
            ? Ok("Usuário deletado com sucesso")
            : BadRequest("Erro ao deletar o usuário");
        }
    }
}