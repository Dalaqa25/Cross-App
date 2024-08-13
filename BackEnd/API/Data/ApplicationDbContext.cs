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

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        List<IdentityRole> roles = new List<IdentityRole>
        {
            new IdentityRole
            {
                Name = "Admin",
                NormalizedName = "ADMIN"
            },
            new IdentityRole
            {
                Name = "Employer",
                NormalizedName = "EMPLOYER",
            },
            new IdentityRole
            {
                Name = "Worker",
                NormalizedName = "WORKER"
            }
        };
        builder.Entity<IdentityRole>().HasData(roles);
    }
}