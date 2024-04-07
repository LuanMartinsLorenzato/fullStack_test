using Microsoft.EntityFrameworkCore;
using user.Infrastructure.Persistence;
using webApi.Domain.Entities;
using webApi.Domain.Interfaces;

namespace webApi.Domain.Repositories
{
    public class MovieRepository(DBContext context) : IMovieQueryRepository, IMoviePersistenceRepository
    {
        private readonly DBContext _context = context;

        public async Task<Movie?> GetMovieById(Guid id)
        {
            var getMovie = await _context.Movies.FirstOrDefaultAsync(x => x.Id == id);
            return getMovie;
        }

        public void CreateMovie(Movie movie)
        {
            _context.Movies.Add(movie);
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