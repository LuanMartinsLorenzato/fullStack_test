using System.Reflection;
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
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}