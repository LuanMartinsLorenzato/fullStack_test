using webApi.Domain.Entities;

namespace webApi.Application.Interfaces
{
    public interface IMovieUseCase
    {
        Task<IEnumerable<Movie>> GetMoviesAsync();
        Task<bool> CreateMovie(Movie movie);
        Task<bool> DeleteMovie(Guid id);
    }
}