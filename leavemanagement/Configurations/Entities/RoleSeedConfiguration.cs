using leavemanagement.Constants;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace leavemanagement.Configurations.Entities
{
    public class RoleSeedConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(
                new IdentityRole
                {
                    Id = "b8fae543-5c87-4952-a10e-14f6cea432eb",
                    Name = Roles.Administrator,
                    NormalizedName = Roles.Administrator.ToUpper()
                },
                 new IdentityRole
                 {
                     Id = "c7fad533-5d87-4952-a91e-14d6cea462ea",
                     Name = Roles.User,
                     NormalizedName = Roles.User.ToUpper()
                 }
           );
        }
    }
}