using API.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace API.Data;

public class ApplicationDbContext : IdentityDbContext<AppUser>
{
    public ApplicationDbContext(DbContextOptions dbContextOptions)
    : base(dbContextOptions)
    {
        
    }

    public DbSet<Project> Project { get; set; }
    public DbSet<Protfolio> Protfolios { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);


        builder.Entity<Protfolio>(x => x.HasKey(p => new { p.AppUserId, p.ProjectId }));

        builder.Entity<Protfolio>()
            .HasOne(u => u.AppUser)
            .WithMany(u => u.Protfolios)
            .HasForeignKey(p => p.AppUserId);
        
        builder.Entity<Protfolio>()
            .HasOne(u => u.Project)
            .WithMany(u => u.Protfolios)
            .HasForeignKey(p => p.ProjectId);
        
        List<IdentityRole> roles = new List<IdentityRole>
        {
            new IdentityRole
            {
                Name = "Admin",
                NormalizedName = "ADMIN"
            },
            new IdentityRole
            {
                Name = "Student",
                NormalizedName = "STUDENT",
            }
        };
        builder.Entity<IdentityRole>().HasData(roles);
    }
}