using API.Data;
using API.Dtos.EmployerDto;
using API.Mapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

[Route("api/employer")]
[ApiController]
public class EmployerController : ControllerBase
{
    private readonly ApplicationDbContext _context;
    
    public EmployerController(ApplicationDbContext context)
    {
        _context = context;
    }


    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var Employer = await _context.Employers.ToListAsync();

        return Ok(Employer);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var employer = await _context.Employers.FindAsync(id);

        if (employer == null)
        {
            return NotFound();
        }

        return Ok(employer);
    }


    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateEmployerDto employerDto)
    {
        var employerModel = employerDto.ToEmployerFromCreateEmployerDto();

        _context.Employers.Add(employerModel);

        await _context.SaveChangesAsync();
        
        return CreatedAtAction(nameof(GetById), new { id = employerModel.Id }, employerModel.ToEmployerDto());
    }
}