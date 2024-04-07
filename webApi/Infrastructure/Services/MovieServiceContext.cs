using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using webApi.Domain.Entities;

namespace webApi.Infrastructure.Services
{
    // UserServiceContext é utilizado para configurar a tabela de Movies

    public class MovieServiceContext : IEntityTypeConfiguration<Movie>
    {
        public void Configure(EntityTypeBuilder<Movie> builder)
        {
            builder.ToTable("tb_movie");
            builder.HasKey(x => x.Id);
        }
    }
}