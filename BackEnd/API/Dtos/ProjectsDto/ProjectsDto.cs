﻿namespace API.Dtos.ProjectsDto;

public class ProjectsDto
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTime CreateOn { get; set; }
}