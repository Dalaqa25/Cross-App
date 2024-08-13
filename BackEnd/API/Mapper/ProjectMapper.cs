using API.Dtos.ProjectsDto;
using API.Models;

namespace API.Mapper;

public static class ProjectMapper
{
    public static ProjectsDto ToProjectsDto(this Project projectModel)
    {
        return new ProjectsDto
        {
            Id = projectModel.Id,
            Title = projectModel.Title,
            CreateOn = DateTime.UtcNow,
            Description = projectModel.Description
        };
    }

    public static Project ToProjectFromCreateProjectDto(this CreateProjectsDto projectsDto)
    {
        return new Project
        {
            Title = projectsDto.Title,
            Description = projectsDto.Description
        };
    }
}