using System.Text.Json;
using System.Text.Json.Serialization;
using webApi.Application.Interfaces;
using webApi.Domain.Dtos;
using webApi.Domain.Entities;
using webApi.Domain.Interfaces;

namespace webApi.Application.UseCases
{
    public class MovieUseCase(IMovieQueryRepository queryRepository, IMoviePersistenceRepository moviePersistence) : IMovieUseCase
    {
        private readonly IMovieQueryRepository _queryRepository = queryRepository;
        private readonly IMoviePersistenceRepository _moviePersistence = moviePersistence;

        public async Task<bool> CreateMovies()
        {
            var hasMovie = await CheckExistMovies();
            if (!hasMovie.Any())
            {
                var movies = await GetMoviesInAPI();
                if (movies != null) _moviePersistence.CreateMovies(movies);
            }
            return await _moviePersistence.SaveChangeAsync();
        }

        public async Task<IEnumerable<Movie>> GetMoviesAsync()
        {
            return await _queryRepository.GetMoviesAsync();
        }

        private async Task<IEnumerable<Movie>?> CheckExistMovies()
        {
            return await _queryRepository.GetMovies();
        }
        private static async Task<IEnumerable<Movie>?> GetMoviesInAPI()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"http://www.omdbapi.com/?apikey=4d56cda3&s=Batman&type=movie");

            using var client = new HttpClient();
            var responseOMDB = await client.SendAsync(request);
            var contentResp = await responseOMDB.Content.ReadAsStringAsync();
            var objResp = JsonSerializer.Deserialize<SearchResultDto>(contentResp);
            return objResp?.Search;
        }
    }
}