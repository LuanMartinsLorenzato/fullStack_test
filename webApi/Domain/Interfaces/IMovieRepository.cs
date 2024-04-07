using webApi.Domain.Entities;

namespace webApi.Domain.Interfaces
{
    public interface IMoviePersistenceRepository
    {
        void CreateMovie(Movie movie);
        Task<bool> SaveChangeAsync();
        void DeleteMovie(Movie movie);
    }

        public interface IMovieQueryRepository
    {
        Task<IEnumerable<Movie>> GetMoviesAsync();
        Task<Movie?> GetMovieById(Guid id);
    }
}