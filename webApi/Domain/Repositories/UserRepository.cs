using Microsoft.EntityFrameworkCore;
using user.Infrastructure.Persistence;
using webApi.Domain.Dtos;
using webApi.Domain.Entities;
using webApi.Domain.Interfaces;

namespace webApi.Domain.Repositories
{
    // UserRepository é responsavél pela comunicação com o  EntityFramework que faz a conexão ao banco de dados.
    // Utilizamos _context para transmitir essa conversa atráves de querys que o EntityFramework gera com os métodos chamados. 
    public class UserRepository(DBContext context) : IUserRepository
    {
        private readonly DBContext _context = context;

        // Pede para o EntityFramework trazer todos os usuários da tabela de Users. 
        // IEnumerable representar uma coleção de itens.
        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }

        // Pede para o EntityFramework trazer o primeiro usuário da tabela de Users pelo Id.
        public async Task<User?> GetUserByIdAsync(Guid id)
        {
            var getUser = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
            return getUser;
        }

        // Pede para o EntityFramework adicionar o usuário a tabela.
        public void CreateUser(User user)
        {
            _context.Users.Add(user);
        }

        // Pede para o EntityFramework atualizar um usuário na tabela.
        public void UpdateUser(User user)
        {
            _context.Users.Update(user);
        }

        // Pede para o EntityFramework deletar um usuário na tabela.
        public void DeleteUser(User user)
        {
            _context.Users.Remove(user);
        }

        // Pede para o EntityFramework salvar as alterações no banco.
        public async Task<bool> SaveChangeAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        // Pede para o EntityFramework trazer o primeiro usuário da tabela de Users pelo Email.
        public async Task<User?> GetUserByEmail(LoginDto loginDto)
        {
            var getUser = await _context.Users.FirstOrDefaultAsync(x => x.Email == loginDto.Email);
            return getUser;
        }
    }
}