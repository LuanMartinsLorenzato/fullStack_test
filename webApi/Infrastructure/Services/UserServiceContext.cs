using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using webApi.Domain.Entities;

namespace webApi.Infrastructure.Services
{
    // UserServiceContext é utilizado para configurar a tabela de User
    public class UserServiceContext : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("tb_user");
            builder.HasKey(x => x.Id);
        }
    }
}