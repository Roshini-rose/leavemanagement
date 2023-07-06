using leavemanagement.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace leavemanagement.Configurations.Entities
{
    public class UserSeedConfiguration : IEntityTypeConfiguration<employee>
    {
        public void Configure(EntityTypeBuilder<employee> builder)
        {
            var hasher = new PasswordHasher<employee>();
            builder.HasData(
                new employee
                {
                    Id= "d5fad533-5c87-5952-a90e-24f6cea432ea",
                    Email="admin@localhost.com",
                    NormalizedEmail="ADMIN@LOCALHOST.COM",
                    UserName = "admin@localhost.com",
                    NormalizedUserName = "ADMIN@LOCALHOST.COM",
                    firstname ="System",
                    lastname="Admin",
                    PasswordHash=hasher.HashPassword(null,"Password@123"),
                    EmailConfirmed=true
                },
                new employee
                {
                    Id = "e5dad533-5c87-5952-a90e-24f6cea432ea",
                    Email = "user@localhost.com",
                    NormalizedEmail = "USER@LOCALHOST.COM",
                    UserName = "user@localhost.com",
                    NormalizedUserName = "USER@LOCALHOST.COM",
                    firstname = "System",
                    lastname = "User",
                    PasswordHash = hasher.HashPassword(null, "Password@123"),
                    EmailConfirmed=true
                }
           );
        }
    }
}