using API.Data;
using API.Dtos.ProjectsDto;
using API.Mapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

[Route("api/project")]
[ApiController]
public class ProjectController : ControllerBase
{
    private readonly ApplicationDbContext _context;
    
    public ProjectController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var projectModel = await _context.Project
            .Select(s => s.ToProjectsDto()).ToListAsync();

        return Ok(projectModel);
    }


    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var findProjectId = await _context.Project.FindAsync(id);

        return Ok(findProjectId.ToProjectsDto());
    }

    [HttpPost]
    public IActionResult Create([FromBody] CreateProjectsDto createProjectsDto)
    {
        var projectModel = createProjectsDto.ToProjectFromCreateProjectDto();

        _context.Project.Add(projectModel);

        _context.SaveChanges();

       return CreatedAtAction(nameof(GetById), new { id = projectModel.Id }, projectModel.ToProjectsDto());
    }
}