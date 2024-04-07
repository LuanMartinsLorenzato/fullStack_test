using webApi.Domain.Dtos;
using webApi.Domain.Entities;

namespace webApi.Domain.Interfaces
{
    public interface IUserMovieRepository
    {
        void AddMovieOnUser(UserMovieDto userMovieDto);
        void RemoveMovieOnUser(UserMovieDto userMovieDto);
        Task<IEnumerable<Movie>> GetMoviesOnUser(Guid userId);

        Task<bool> SaveChangeAsync();

    }
}