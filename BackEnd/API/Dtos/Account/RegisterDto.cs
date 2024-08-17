﻿using System.ComponentModel.DataAnnotations;

namespace API.Dtos;

public class RegisterDto
{
    [Required] public string? UserName { get; set; }

    [Required] public string? Password { get; set; }

    [Required] [EmailAddress] public string? Email { get; set; }
    
    [Required] public string Roles { get; set; }
}