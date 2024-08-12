﻿namespace API.Models;

public class Employer
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Surname { get; set; } = string.Empty;
    public DateTime CreatedOn { get; set; } = DateTime.Now;
    public string OrganizationTitle { get; set; } = string.Empty;   
}