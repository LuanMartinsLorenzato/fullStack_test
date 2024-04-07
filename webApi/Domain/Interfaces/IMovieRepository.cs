using webApi.Domain.Entities;

namespace webApi.Domain.Interfaces
{
    public interface IMovieRepository
    {
        Task<IEnumerable<Movie>> GetMoviesAsync();
        void CreateMovie(Movie movie);
        Task<bool> SaveChangeAsync();
        void DeleteMovie(Movie movie);
        Task<Movie?> GetMovieById(Guid id);

    }
}