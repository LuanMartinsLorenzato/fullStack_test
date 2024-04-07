using webApi.Application.Interfaces;
using webApi.Domain.Dtos;
using webApi.Domain.Entities;
using webApi.Domain.Interfaces;

namespace webApi.Application.UseCases
{
    public class UserMovieUseCases(IUserMovieRepository repository) : IUserMovieUseCases
    {
        private readonly IUserMovieRepository _repository = repository;
        public async Task<bool> AddMovieOnUser(UserMovieDto userMovieDto)
        {
            _repository.AddMovieOnUser(userMovieDto);
            return await _repository.SaveChangeAsync();
        }

        public async Task<IEnumerable<Movie>> GetMoviesOnUser(Guid userId)
        {
            return await _repository.GetMoviesOnUser(userId);
        }

        public async Task<bool> RemoveMovieOnUser(UserMovieDto userMovieDto)
        {
            _repository.RemoveMovieOnUser(userMovieDto);
            return await _repository.SaveChangeAsync();
        }
    }
}