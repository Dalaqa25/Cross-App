using Microsoft.AspNetCore.Identity;

namespace API.Models;

public class AppUser : IdentityUser
{
    public DateTime CreatedOn { get; set; }
    public List<Protfolio> Protfolios { get; set; } = new List<Protfolio>();
}