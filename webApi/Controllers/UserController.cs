// using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using webApi.Models;

namespace webApi.Controllers
{
    // [Produces(MediaTypeNames.Application.Json)]
    // Habilita recursos específicos da API, como o binding de parâmetros de rota, query e corpo de forma automática.
    [ApiController]
    // Define a rota de acesso ao controlador onde [controller] é um token que será substituído pelo nome do controlador.
    [Route("api/[controller]")]
    // Herdar de ControllerBase proporciona ao UserController acesso a muitos métodos e propriedades úteis para o tratamento de requisições HTTP.
    public class UserController : ControllerBase
    {
        private static List<User> Users()
        {
            return [
                new User{ Name = "Luan" },
                new User{ Name = "Marcos" }
            ];
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(Users());
        }

        [HttpPost]
        public IActionResult Post(User user)
        {
            var users = Users();
            users.Add(user);
            return Ok(users);
        }
    }
}