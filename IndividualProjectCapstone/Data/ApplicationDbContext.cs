using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IndividualProjectCapstone.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace IndividualProjectCapstone.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<IdentityRole>()
                .HasData(
                new IdentityRole
                {
                    Name = "User",
                    NormalizedName = "USER"
                }, new IdentityRole
                {
                    Name = "Other",
                    NormalizedName = "OTHER"
                });
            builder.Entity<ProjectMember>()
                .HasNoKey();
           
        }
        public DbSet<Developer> Developers { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectMember> ProjectMembers { get; set; }
        public DbSet<Opening> Openings { get; set; }
        public DbSet<RoleType> RoleTypes { get; set; }
        public DbSet<Review> Reviews { get; set; }

    }
}
