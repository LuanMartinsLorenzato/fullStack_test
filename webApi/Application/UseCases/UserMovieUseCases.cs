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
            var movieDB = await CheckExistingMovie(userMovieDto.MovieId);
            var userDB = await CheckExistingUser(userMovieDto.UserId);
            if (userDB == null || movieDB == null) return false;

            _repository.AddMovieOnUser(userDB, movieDB);
            return await _repository.SaveChangeAsync();
        }

        public async Task<IEnumerable<Movie>> GetMoviesOnUser(Guid userId)
        {
            return await _repository.GetMoviesOnUser(userId);
        }

        public async Task<bool> RemoveMovieOnUser(UserMovieDto userMovieDto)
        {
            var movieDB = await CheckExistingMovie(userMovieDto.MovieId);
            var userDB = await CheckExistingUser(userMovieDto.UserId);
            if (userDB == null || movieDB == null) return false;

            _repository.RemoveMovieOnUser(userDB, movieDB);
            return await _repository.SaveChangeAsync();
        }

        private async Task<Movie?> CheckExistingMovie(Guid movieId)
        {
            return await _repository.CheckExistMovie(movieId);
        }

        private async Task<User?> CheckExistingUser(Guid userId)
        {
            return await _repository.CheckExistUser(userId);
        }
    }
}