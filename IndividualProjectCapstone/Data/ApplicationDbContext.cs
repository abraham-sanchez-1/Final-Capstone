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

            //Set default behavior to not cascade on delete, ==> Unsuccessful
            //foreach (var foreignKey in builder.Model.GetEntityTypes()
            //    .SelectMany(e => e.GetForeignKeys()))
            //{
            //    foreignKey.DeleteBehavior = DeleteBehavior.Restrict;
            //}

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
            //builder.Entity<ProjectMember>()
            // .HasOne(c => c.Developer)
            // .WithMany()
            // .OnDelete(DeleteBehavior.NoAction);
            
            //builder.Entity<ProjectMember>()
            // .HasOne(c => c.Project)
            // .WithMany()
            // .OnDelete(DeleteBehavior.NoAction);
           
        }
        public DbSet<Developer> Developers { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectMember> ProjectMembers { get; set; }
        public DbSet<RoleOpening> RoleOpenings { get; set; }
    }
}
