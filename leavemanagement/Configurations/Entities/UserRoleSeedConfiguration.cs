using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace leavemanagement.Configurations.Entities
{
    public class UserRoleSeedConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            builder.HasData(
                new IdentityUserRole<string>
                {
                    RoleId = "b8fae543-5c87-4952-a10e-14f6cea432eb",
                    UserId = "d5fad533-5c87-5952-a90e-24f6cea432ea"
                },
                 new IdentityUserRole<string>
                 {
                     RoleId = "c7fad533-5d87-4952-a91e-14d6cea462ea",
                     UserId = "e5dad533-5c87-5952-a90e-24f6cea432ea"
                 }
            );
        }
    }
}