using Microsoft.EntityFrameworkCore;
using user.Data;
using webApi.Models;

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
            return await _context.Users.Where(x => x.Id == id).FirstOrDefaultAsync();
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

    }
}