using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace leavemanagement.Data
{
    public class ApplicationDbContext : IdentityDbContext<employee>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<leavetype> leavetypes { get; set; }
        public DbSet<leaveallocation> leaveallocations { get; set; }
    }
}