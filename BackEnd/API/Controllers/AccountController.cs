using API.Dtos;
using API.Interfaces;
using API.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;
[Route("api/account")]
[ApiController]
public class AccountController : ControllerBase
{
    private readonly UserManager<AppUser> _userManager;

    private readonly ITokenInterface _tokenInterface;
    public AccountController(UserManager<AppUser> userManager, ITokenInterface tokenInterface)
    {
        _userManager = userManager;
        _tokenInterface = tokenInterface;
    }
    

    [HttpPost("register")]
    public async Task<IActionResult> Create([FromBody] RegisterDto registerDto)
    {
        try
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var appUser = new AppUser
            {
                UserName = registerDto.UserName,
                Email = registerDto.Email,
                
            };

            if (registerDto.Password == null)
            {
                return BadRequest("Password is required");
            }

            var createdUser = await _userManager.CreateAsync(appUser, registerDto.Password);

            if (createdUser.Succeeded)
            {
                var roleResult = await _userManager.AddToRoleAsync(appUser, "User");
                if (roleResult.Succeeded)
                {
                    return Ok(
                            new NewUserDto
                            {
                                UserName = appUser.UserName,
                                Email = appUser.Email,
                                Token = _tokenInterface.CreateToken(appUser)
                            }
                        );
                }
                else
                {
                    return BadRequest(roleResult.Errors);
                }
            }
            else
            {
                return StatusCode(500, createdUser.Errors);
            }
        }
        catch (Exception e)
        {
            return StatusCode(500, "Internal server error");
        }
    }
}