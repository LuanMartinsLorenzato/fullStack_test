using Microsoft.EntityFrameworkCore;
using user.Infrastructure.Persistence;
using webApi.Domain.Dtos;
using webApi.Domain.Entities;
using webApi.Domain.Interfaces;

namespace webApi.Domain.Repositories
{
    public class UserMovieRepository(DBContext context) : IUserMovieRepository
    {
        private readonly DBContext _context = context;

        public void AddMovieOnUser(UserMovieDto userMovieDto)
        {
            var movie = _context.Movies.FirstOrDefault(x => x.Id == userMovieDto.MovieId);
            if (movie != null) {
                var user = _context.Users.Include(u => u.Movies).FirstOrDefault(x => x.Id == userMovieDto.UserId);
                user?.Movies.Add(movie);
            }
        }

        public async Task<IEnumerable<Movie>> GetMoviesOnUser(Guid userId)
        {
            var userDB = await _context.Users.Where(u => u.Id == userId).SelectMany(m => m.Movies).ToListAsync();
            return userDB;
        }

        public void RemoveMovieOnUser(UserMovieDto userMovieDto)
        {
            // Buscas ao banco deveriam sempre ter uma resposta?
            var movieDB = _context.Movies.FirstOrDefault(x => x.Id == userMovieDto.MovieId);
            if (movieDB != null) {
                var userDB = _context.Users.Include(u => u.Movies).FirstOrDefault(x => x.Id == userMovieDto.UserId);
                userDB?.Movies.Remove(movieDB);
            }
        }

        public async Task<bool> SaveChangeAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}