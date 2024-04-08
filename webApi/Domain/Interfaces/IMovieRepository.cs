using webApi.Domain.Entities;

namespace webApi.Domain.Interfaces
{
    public interface IMoviePersistenceRepository
    {
        void CreateMovies(IEnumerable<Movie> movies);
        Task<bool> SaveChangeAsync();
    }

    public interface IMovieQueryRepository
    {
        Task<IEnumerable<Movie>> GetMoviesAsync();
        Task<IEnumerable<Movie>?> GetMovies();
    }
}