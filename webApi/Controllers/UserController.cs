// using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using webApi.Domain.Entities;
using webApi.Domain.Repository;

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


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var usersDB = await _repository.SearchUsers();
            return usersDB.Any() ? Ok(usersDB) : NoContent();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var userDB = await _repository.SearchUser(id);
            return userDB != null
            ? Ok(userDB)
            : NotFound("Usuário não encontrado");
        }

        [HttpPost]
        public async Task<IActionResult> Post(User user)
        {
            _repository.AddUser(user);
            return await _repository.SaveChangeAsync()
            ? Ok("Usuário adicionado com sucesso")
            : BadRequest("Erro ao salvar o usuário");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, User user)
        {
            var userDB = await _repository.SearchUser(id);
            if (userDB == null) return NotFound("Usuário não encontrado");

            userDB.Name = user.Name ?? userDB.Name;

            _repository.UpdateUser(userDB);

            return await _repository.SaveChangeAsync()
            ? Ok("Usuário atualizado com sucesso")
            : BadRequest("Erro ao atualizar o usuário");
        }

        [HttpDelete("{id}")]
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