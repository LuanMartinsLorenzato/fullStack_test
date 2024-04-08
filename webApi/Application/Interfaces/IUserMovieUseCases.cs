using webApi.Domain.Dtos;
using webApi.Domain.Entities;

namespace webApi.Application.Interfaces
{
    public interface IUserMovieUseCases
    {
        Task<bool> AddMovieOnUser(UserMovieDto userMovieDto);
        Task<bool> RemoveMovieOnUser(UserMovieDto userMovieDto);
    }
}