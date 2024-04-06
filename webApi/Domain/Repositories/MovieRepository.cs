using Microsoft.EntityFrameworkCore;
using user.Infrastructure.Persistence;
using webApi.Domain.Entities;
using webApi.Domain.Interfaces;

namespace webApi.Domain.Repositories
{
    public class MovieRepository(DBContext context) : IMovieRepository
    {
        private readonly DBContext _context = context;

        public async Task<Movie> GetMovieByTitle(string title)
        {
            // Corrigir implementação para retorno null, caso não ache o email ocorre erro 500 
            var getMovie = await _context.Movies.FirstOrDefaultAsync(x => x.Title == title);
            return getMovie;
        }

        public async Task<Movie> GetMovieById(Guid id)
        {
            var getMovie = await _context.Movies.FirstOrDefaultAsync(x => x.Id == id);
            return getMovie;
        }

        public void CreateMovie(Movie movie)
        {
            _context.Movies.Add(movie);
        }

        public async Task AddMovieToUser(Guid movieId, Guid userId)
        {
            var movie = await _context.Movies.FirstOrDefaultAsync(x => x.Id == movieId);
            var user = await _context.Users.Include(u => u.Movies).FirstOrDefaultAsync(x => x.Id == userId);
            user.Movies.Add(movie);
            movie.Users.Add(user);
        }

        public async Task<IEnumerable<Movie>> GetMoviesAsync()
        {
            return await _context.Movies.ToListAsync();
        }

        public void DeleteMovie(Movie movie)
        {
            _context.Movies.Remove(movie);
        }

        public async Task<bool> SaveChangeAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}