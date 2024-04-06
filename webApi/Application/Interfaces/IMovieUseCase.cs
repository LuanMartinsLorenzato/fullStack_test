using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webApi.Domain.Entities;

namespace webApi.Application.Interfaces
{
    public interface IMovieUseCase
    {
        Task<IEnumerable<Movie>> GetMoviesAsync();
        Task<bool> CreateMovie(Movie movie);
        Task<bool> AddMovieToUser(Guid movieId, Guid userId);
        Task<bool> DeleteMovie(Guid id);
    }
}