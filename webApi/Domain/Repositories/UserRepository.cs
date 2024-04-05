using Microsoft.EntityFrameworkCore;
using user.Infrastructure.Persistence;
using webApi.Domain.Entities;
using webApi.Domain.Interfaces;

namespace webApi.Domain.Repositories
{
    public class UserRepository(DBContext context) : IUserRepository
    {
        private readonly DBContext _context = context;

        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }
        public async Task<User> GetUserByIdAsync(Guid id)
        {
            // Corrigir implementação para retorno null, caso não ache o email ocorre erro 500 
            var getUser = await _context.Users.Where(x => x.Id == id).FirstOrDefaultAsync();
            // if (getUser == null)
            // {
            //     return null;
            // }

            return getUser;
        }

        public void CreateUser(User user)
        {
            _context.Add(user);
        }

        public void UpdateUser(User user)
        {
            _context.Update(user);
        }

        public void DeleteUser(User user)
        {
            _context.Remove(user);
        }

        public async Task<bool> SaveChangeAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<User> GetUserByEmail(string email)
        {
            // Corrigir implementação para retorno null, caso não ache o email ocorre erro 500 
            var getUser = await _context.Users.FirstOrDefaultAsync(x => x.Email == email);
            // if (getUser == null)
            // {
            //     return null;
            // }
            return getUser;
        }
    }
}