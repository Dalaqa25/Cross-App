using System.ComponentModel.DataAnnotations;

namespace API.Dtos.ProjectsDto;

public class CreateProjectsDto
{
    [Required]  public string Title { get; set; } = string.Empty;
    [Required]  public string Description { get; set; } = string.Empty;
}