using Microsoft.AspNetCore.Identity;

namespace API.Models;

public class AppUser : IdentityUser
{
    public DateTime CreatedOn { get; set; }
    public string Roles { get; set; }
}