﻿using leavemanagement.Configurations.Entities;
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
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new RoleSeedConfiguration());
            builder.ApplyConfiguration(new UserSeedConfiguration());
            builder.ApplyConfiguration(new UserRoleSeedConfiguration());

        }

        public DbSet<leavetype> leavetypes { get; set; }
        public DbSet<leaveallocation> leaveallocations { get; set; }
    }
}