using webApi.Application.Interfaces;
using webApi.Domain.Entities;
using webApi.Domain.Interfaces;

namespace webApi.Application.UseCases
{
    public class MovieUseCase(IMovieQueryRepository queryRepository, IMoviePersistenceRepository moviePersistence) : IMovieUseCase
    {
        private readonly IMovieQueryRepository _queryRepository = queryRepository;
        private readonly IMoviePersistenceRepository _moviePersistence = moviePersistence;

        public async Task<bool> CreateMovie(Movie movie)
        {
            var hasMovie = await CheckExistMovie(movie.Id);
            if (hasMovie == null) _moviePersistence.CreateMovie(movie);
            return await _moviePersistence.SaveChangeAsync();
        }

        public async Task<IEnumerable<Movie>> GetMoviesAsync()
        {
            return await _queryRepository.GetMoviesAsync();
        }

        public async Task<bool> DeleteMovie(Guid id)
        {
            var movieDB = await CheckExistMovie(id);
            if (movieDB == null) return false;

            _moviePersistence.DeleteMovie(movieDB);

            return await _moviePersistence.SaveChangeAsync();
        }


        private async Task<Movie?> CheckExistMovie(Guid id)
        {
            return await _queryRepository.GetMovieById(id);
        }
    }
}