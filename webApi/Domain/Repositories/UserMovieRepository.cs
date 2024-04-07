using Microsoft.EntityFrameworkCore;
using user.Infrastructure.Persistence;
using webApi.Domain.Entities;
using webApi.Domain.Interfaces;

namespace webApi.Domain.Repositories
{
    // UserRepository é responsavél pela comunicação com o EntityFramework na tabela de relação entre Users e Movies, 
    // que faz a conexão ao banco de dados.
    public class UserMovieRepository(DBContext context) : IUserMovieQueryRepository, IUserMoviePersistenceRepository
    {
        private readonly DBContext _context = context;

        // Pede ao EntityFramework o filme pelo Id.
        public async Task<Movie?> CheckExistMovie(Guid id)
        {
            var movie = await _context.Movies.FirstOrDefaultAsync(x => x.Id == id);
            return movie;
        }

        // Pede ao EntityFramework o usuário pelo Id.
        public async Task<User?> CheckExistUser(Guid id)
        {
            // Include é utilizado para trazer a relação do usuário a filmes.
            var user = await _context.Users.Include(u => u.Movies).FirstOrDefaultAsync(x => x.Id == id);
            return user;
        }

        // Pede ao EntityFramework para adicionar a relação entre filme e usuário.
        public void AddMovieOnUser(User user, Movie movie)
        {
            user.Movies.Add(movie);
        }

        // Pede ao EntityFramework para pegar todos os filmes relacionados ao usuário.
        public async Task<IEnumerable<Movie>> GetMoviesOnUser(Guid userId)
        {
            var userDB = await _context.Users.Where(u => u.Id == userId).SelectMany(m => m.Movies).ToListAsync();
            return userDB;
        }

        // Pede ao EntityFramework para retirar a relação entre filme e usuário.
        public void RemoveMovieOnUser(User user, Movie movie)
        {
            user.Movies.Remove(movie);
        }

        // Pede ao EntityFramework para salvar as alterações no banco.
        public async Task<bool> SaveChangeAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}