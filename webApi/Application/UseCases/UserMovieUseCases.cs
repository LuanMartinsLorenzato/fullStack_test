using webApi.Application.Interfaces;
using webApi.Domain.Dtos;
using webApi.Domain.Entities;
using webApi.Domain.Interfaces;

namespace webApi.Application.UseCases
{   
    // UserMovieUseCases é um conjunto de casos de uso para tratar a relação de filmes e usuários,
    // os principios SOLID estão aplicados para melhorar manutenção, extenção e flexibilidade do código.
    public class UserMovieUseCases(IUserMovieQueryRepository queryRepository, IUserMoviePersistenceRepository persistenceRepository) : IUserMovieUseCases
    {
        private readonly IUserMovieQueryRepository _queryRepository = queryRepository;
        private readonly IUserMoviePersistenceRepository _persistenceRepository = persistenceRepository;
        public async Task<bool> AddMovieOnUser(UserMovieDto userMovieDto)
        {
            var movieDB = await CheckExistingMovie(userMovieDto.MovieId);
            var userDB = await CheckExistingUser(userMovieDto.UserId);
            if (userDB == null || movieDB == null) return false;

            _persistenceRepository.AddMovieOnUser(userDB, movieDB);
            return await _persistenceRepository.SaveChangeAsync();
        }

        public async Task<bool> RemoveMovieOnUser(UserMovieDto userMovieDto)
        {
            var movieDB = await CheckExistingMovie(userMovieDto.MovieId);
            var userDB = await CheckExistingUser(userMovieDto.UserId);
            if (userDB == null || movieDB == null) return false;

            _persistenceRepository.RemoveMovieOnUser(userDB, movieDB);
            return await _persistenceRepository.SaveChangeAsync();
        }

        private async Task<Movie?> CheckExistingMovie(Guid movieId)
        {
            return await _queryRepository.CheckExistMovie(movieId);
        }

        private async Task<User?> CheckExistingUser(Guid userId)
        {
            return await _queryRepository.CheckExistUser(userId);
        }
    }
}