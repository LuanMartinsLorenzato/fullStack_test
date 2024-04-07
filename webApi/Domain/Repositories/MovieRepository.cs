using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using user.Infrastructure.Persistence;
using webApi.Domain.Entities;
using webApi.Domain.Interfaces;

namespace webApi.Domain.Repositories
{
    public class MovieRepository(DBContext context) : IMovieQueryRepository, IMoviePersistenceRepository
    {
        private readonly DBContext _context = context;

        public async Task<IEnumerable<Movie>?> GetMovies()
        {
            return await _context.Movies.ToListAsync();
        }

        public void CreateMovies(IEnumerable<Movie> movies)
        {
            foreach (var movie in movies)
            {
                _context.Movies.Add(movie);
            }
        }

        public async Task<IEnumerable<Movie>> GetMoviesAsync()
        {
            return await _context.Movies.ToListAsync();
        }

        public async Task<bool> SaveChangeAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}