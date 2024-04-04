using Microsoft.EntityFrameworkCore;
using webApi.Models;

namespace user.Data
{
    // Utilizado um construtor primario como descrito na IDEO290  https://learn.microsoft.com/pt-br/dotnet/fundamentals/code-analysis/style-rules/ide0290#example
    public class UserDBContext(DbContextOptions<UserDBContext> options) : DbContext(options)
    {
        public DbSet<User> Users { get; set; }
    }
}