using webApi.Domain.Dtos;
using webApi.Domain.Entities;

namespace webApi.Domain.Interfaces
{
    public interface IUserMovieQueryRepository
    {
        Task<Movie?> CheckExistMovie(Guid id);
        Task<User?> CheckExistUser(Guid id);
        Task<IEnumerable<Movie>> GetMoviesOnUser(Guid userId);
    }
    
    public interface IUserMoviePersistenceRepository
    {
        void AddMovieOnUser(User user, Movie movie);
        void RemoveMovieOnUser(User user, Movie movie);
        Task<bool> SaveChangeAsync();
    }
}