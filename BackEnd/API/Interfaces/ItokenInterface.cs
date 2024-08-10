using API.Models;

namespace API.Interfaces;

public interface ITokenInterface
{
    string CreateToken(AppUser appUser);
}