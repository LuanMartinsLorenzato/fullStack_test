using webApi.Application.Interfaces;
using webApi.Domain.Entities;
using webApi.Domain.Interfaces;

namespace webApi.Application.UseCases
{
    public class MovieUseCase(IMovieRepository repository) : IMovieUseCase
    {
        private readonly IMovieRepository _repository = repository;

        public async Task<bool> CreateMovie(Movie movie)
        {
            var hasMovie = await _repository.GetMovieById(movie.Id);
            if (hasMovie == null) _repository.CreateMovie(movie);
            return await _repository.SaveChangeAsync();
        }

        public async Task<IEnumerable<Movie>> GetMoviesAsync()
        {
            return await _repository.GetMoviesAsync();
        }

        public async Task<bool> DeleteMovie(Guid id)
        {
            var movieDB = await _repository.GetMovieById(id);
            if (movieDB == null) return false;

            _repository.DeleteMovie(movieDB);

            return await _repository.SaveChangeAsync();
        }
    }
}