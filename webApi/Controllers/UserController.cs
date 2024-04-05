// using System.Net.Mime;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using webApi.Models;
using webApi.Repository.Interfaces;

namespace webApi.Controllers
{
    // [Produces(MediaTypeNames.Application.Json)]
    // Habilita recursos específicos da API, como o binding de parâmetros de rota, query e corpo de forma automática.
    [ApiController]
    // Define a rota de acesso ao controlador onde [controller] é um token que será substituído pelo nome do controlador.
    [Route("api/[controller]")]
    // Herdar de ControllerBase proporciona ao UserController acesso a muitos métodos e propriedades úteis para o tratamento de requisições HTTP.
    public class UserController(IUserRepository repository) : ControllerBase
    {
        // Chama o repositório para utilizar seus métodos
        private readonly IUserRepository _repository = repository;

        // Indica quem tem acesso a rota
        [Authorize(Roles = "manager")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]

        public async Task<IActionResult> Get()
        {
            var usersDB = await _repository.SearchUsers();
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
            var userDB = await _repository.SearchUser(id);
            return userDB != null
            ? Ok(userDB)
            : NotFound("Usuário não encontrado");
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post(User user)
        {
            _repository.AddUser(user);
            return await _repository.SaveChangeAsync()
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
            var userDB = await _repository.SearchUser(id);
            if (userDB == null) return NotFound("Usuário não encontrado");

            userDB.Name = user.Name ?? userDB.Name;
            userDB.Email = user.Email ?? userDB.Email;
            userDB.Password = user.Password ?? userDB.Password;
            userDB.Role = user.Role ?? userDB.Role;
            userDB.Active = user.Active == true;

            _repository.UpdateUser(userDB);

            return await _repository.SaveChangeAsync()
            ? Ok("Usuário atualizado com sucesso")
            : BadRequest("Erro ao atualizar o usuário");
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
            var userDB = await _repository.SearchUser(id);
            if (userDB == null) return NotFound("Usuário não encontrado");

            _repository.DeleteUser(userDB);

            return await _repository.SaveChangeAsync()
            ? Ok("Usuário deletado com sucesso")
            : BadRequest("Erro ao deletar o usuário");
        }
    }
}