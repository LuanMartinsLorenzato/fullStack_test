using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webApi.Domain.Entities;

namespace webApi.Domain.Interfaces
{
    public interface IMovieRepository
    {
        Task<IEnumerable<Movie>> GetMoviesAsync();
        void CreateMovie(Movie movie);

        Task AddMovieToUser(Guid movieId, Guid userId);
        Task<bool> SaveChangeAsync();
        void DeleteMovie(Movie movie);
        Task<Movie> GetMovieByTitle(string title);
        Task<Movie> GetMovieById(Guid id);

    }
}