using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using user.Data;
using webApi.Models;
using webApi.Repository.Interfaces;

namespace webApi.Repository
{
    public class UserRepository(UserDBContext context) : IUserRepository
    {
        private readonly UserDBContext _context = context;

        public async Task<IEnumerable<User>> SearchUsers()
        {
            return await _context.Users.ToListAsync();
        }
        public async Task<User> SearchUser(Guid id)
        {
            // Corrigir implementação para retorno null, caso não ache o email ocorre erro 500 
            var getUser = await _context.Users.Where(x => x.Id == id).FirstOrDefaultAsync();
            // if (getUser == null)
            // {
            //     return null;
            // }

            return getUser;
        }

        public void AddUser(User user)
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