using Microsoft.EntityFrameworkCore;
using webApi.Domain.Entities;

namespace user.Infrastructure.Persistence
{
    // Utilizado o construtor primario como descrito na IDEO290  https://learn.microsoft.com/pt-br/dotnet/fundamentals/code-analysis/style-rules/ide0290#example
    public class DBContext(DbContextOptions<DBContext> options) : DbContext(options)
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Movie> Movies { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var user = modelBuilder.Entity<User>();
            var movie = modelBuilder.Entity<Movie>();
            movie.ToTable("tb_movie");
            movie.HasMany(u => u.Users)
                .WithMany(m => m.Movies)
                .UsingEntity<MovieUser>(
                    x => x.HasOne(u => u.User).WithMany().HasForeignKey(f => f.UserId),
                    x => x.HasOne(u => u.Movie).WithMany().HasForeignKey(f => f.MovieId),
                    x =>
                    {
                        x.ToTable("tb_movie_user");
                        x.HasKey(k => new { k.UserId, k.MovieId });

                        x.Property(p => p.UserId).IsRequired();
                        x.Property(p => p.MovieId).IsRequired();
                    }
                );
            movie.HasKey(x => x.Id);
            user.ToTable("tb_user");
            user.HasKey(x => x.Id);
            user.Property(x => x.Id).ValueGeneratedOnAdd();
        }
    }
}