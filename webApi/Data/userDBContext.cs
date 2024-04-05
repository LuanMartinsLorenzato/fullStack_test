using Microsoft.EntityFrameworkCore;
using webApi.Models;

namespace user.Data
{
    // Utilizado o construtor primario como descrito na IDEO290  https://learn.microsoft.com/pt-br/dotnet/fundamentals/code-analysis/style-rules/ide0290#example
    public class UserDBContext(DbContextOptions<UserDBContext> options) : DbContext(options)
    {
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var user = modelBuilder.Entity<User>();
            user.ToTable("tb_user");
            user.HasKey(x => x.Id);
            user.Property(x => x.Id).HasColumnName("id").ValueGeneratedOnAdd();
            user.Property(x => x.Name).HasColumnName("name").IsRequired();
            user.Property(x => x.Email).HasColumnName("email").IsRequired();
            user.Property(x => x.Password).HasColumnName("password").IsRequired();
            user.Property(x => x.Role).HasColumnName("role").IsRequired();
            user.Property(x => x.Active).HasColumnName("active").IsRequired();
        }
    }
}