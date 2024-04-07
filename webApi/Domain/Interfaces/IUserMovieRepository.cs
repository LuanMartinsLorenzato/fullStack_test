using webApi.Domain.Dtos;
using webApi.Domain.Entities;

namespace webApi.Domain.Interfaces
{
    public interface IUserMovieRepository
    {
        void AddMovieOnUser(User user, Movie movie);
        void RemoveMovieOnUser(User user, Movie movie);
        Task<Movie?> CheckExistMovie(Guid id);
        Task<User?> CheckExistUser(Guid id);
        Task<IEnumerable<Movie>> GetMoviesOnUser(Guid userId);

        Task<bool> SaveChangeAsync();
    }
}