using Microsoft.EntityFrameworkCore;
using webApi.Domain.Entities;

namespace user.Infrastructure.Persistence
{
    // Utilizado o construtor primario como descrito na IDEO290  https://learn.microsoft.com/pt-br/dotnet/fundamentals/code-analysis/style-rules/ide0290#example
    public class DBContext(DbContextOptions<DBContext> options) : DbContext(options)
    {
        // Passamos os valores que serão utilizados na conversa entre EntityFramework e o banco de dados.
        // Estabelece conexão com a tabela de Users.
        public DbSet<User> Users { get; set; }

        // Estabelece conexão com a tabela de Movies.
        public DbSet<Movie> Movies { get; set; }


        // OnModelCreating é usado para configurar o modelo de dados.
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Criamos as duas primeiras tabelas.
            var user = modelBuilder.Entity<User>();
            var movie = modelBuilder.Entity<Movie>();

            // Utilizamos movie para criar a terceira tabela de relação entre Users e Movies.
            // Essa tabela contém duas chaves estrangeiras UserId e MovieId e uma chave primária composta.
            movie.HasMany(u => u.Users)
                .WithMany(m => m.Movies)
                .UsingEntity<UserMovie>(
                    x => x.HasOne(u => u.User).WithMany().HasForeignKey(f => f.UserId),
                    x => x.HasOne(u => u.Movie).WithMany().HasForeignKey(f => f.MovieId),
                    x =>
                    {
                        // Altera nome da tabela
                        x.ToTable("tb_movie_user");
                        // Define chave primária
                        x.HasKey(k => new { k.UserId, k.MovieId });
                    }
                );
            movie.HasKey(x => x.Id);
            movie.ToTable("tb_movie");
            user.ToTable("tb_user");
            user.HasKey(x => x.Id);
        }
    }
}