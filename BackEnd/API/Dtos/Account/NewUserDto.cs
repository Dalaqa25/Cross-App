﻿namespace API.Dtos;

public class NewUserDto
{
     public string UserName { get; set; }
    public string Email { get; set; }
    public string Roles { get; set; }
    public string Token { get; set; }
}