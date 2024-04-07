using webApi.Application.Interfaces;
using webApi.Domain.Entities;
using webApi.Domain.Interfaces;

namespace webApi.Application.UseCases
{
    // UserUseCases é um caso de uso para tratar os dados de usuário caso necessário antes de transmitir ao controlador.
    public class UserUseCases(IUserRepository repository) : IUserUseCases
    {
        // Chama o repositório para utilizar de acordo com a necessidade (Injeção de dependências).
        private readonly IUserRepository _repository = repository;

        // Pede para o repositório criar o usuário e salvar as alterações no banco.
        public async Task<bool> CreateUser(User user)
        {
            _repository.CreateUser(user);
            return await _repository.SaveChangeAsync();
        }

        // Pede para o repositório buscar o usuário pelo id.
        // Adicionei ? após User para especificar que o retorno pode ser null e isso ser tratado na resposta.
        public async Task<User?> GetUserByIdAsync(Guid id)
        {
            return await _repository.GetUserByIdAsync(id);
        }

        // Pede para o repositório buscar todos os usuários.
        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            return await _repository.GetUsersAsync();
        }

        // Pede para o repositório buscar pelo usuário e verifica se existe um usuário.
        // Após verificar passa pelos campos para garantir a alteração caso tenha ele modifica se não utiliza do próprio banco.
        // Depois de alterar os dados salva as alterações no banco.
        public async Task<bool> UpdateUser(User user)
        {
            var userDB = await _repository.GetUserByIdAsync(user.Id);
            if (userDB == null) return false;

            userDB.Name = user.Name ?? userDB.Name;
            userDB.Email = user.Email ?? userDB.Email;
            userDB.Password = user.Password ?? userDB.Password;
            userDB.Role = user.Role ?? userDB.Role;
            userDB.Active = user.Active == true;
            userDB.Movies = user.Movies ?? userDB.Movies;

            return await _repository.SaveChangeAsync();
        }

        // Pede para o repositório buscar pelo usuário e verifica se existe um usuário.
        // Caso exista ele pede ao repositório deletar o usuário.
        // Depois de deletar ele salva as alterações no banco.
        public async Task<bool> DeleteUser(Guid id)
        {
            var userDB = await _repository.GetUserByIdAsync(id);
            if (userDB == null) return false;

            _repository.DeleteUser(userDB);
            
            return await _repository.SaveChangeAsync();
        }
    }
}