using API.Data;
using API.Dtos.ProjectsDto;
using API.Mapper;
using Microsoft.AspNetCore.Authorization;
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
    [Authorize]
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
    
    public async Task<IActionResult> Create([FromBody] CreateProjectsDto createProjectsDto)
    {
        var projectModel = createProjectsDto.ToProjectFromCreateProjectDto();

        _context.Project.Add(projectModel);

        await _context.SaveChangesAsync();

       return CreatedAtAction(nameof(GetById), new { id = projectModel.Id }, projectModel.ToProjectsDto());
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateProjectDto projectDto)
    {
        var projectModel = await _context.Project.FirstOrDefaultAsync(x => x.Id == id);

        if (projectModel == null)
        {
            return NotFound();
        }

        projectModel.Title = projectDto.Title;
        projectModel.Description = projectDto.Description;

        await _context.SaveChangesAsync();

        return Ok(projectModel.ToProjectsDto());
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        var projectModel = await _context.Project.FirstOrDefaultAsync(x => x.Id == id);

        if (projectModel == null)
        {
            return NotFound();
        }

        _context.Project.Remove(projectModel);

        await _context.SaveChangesAsync();
        
        
        return NoContent();
    }
}