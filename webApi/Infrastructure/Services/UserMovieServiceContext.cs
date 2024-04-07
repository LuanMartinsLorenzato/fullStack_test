using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using webApi.Domain.Entities;

namespace webApi.Infrastructure.Services
{
    // UserServiceContext é utilizado para configurar a relação de Movies com Users
    public class UserMovieServiceContext : IEntityTypeConfiguration<UserMovie>
    {
        public void Configure(EntityTypeBuilder<UserMovie> builder)
        {
            builder.ToTable("tb_movie_user");
            builder.HasKey(k => new { k.UserId, k.MovieId });

            builder.HasOne(u => u.User)
                   .WithMany()
                   .HasForeignKey(f => f.UserId);

            builder.HasOne(u => u.Movie)
                   .WithMany()
                   .HasForeignKey(f => f.MovieId);
        }
    }
}