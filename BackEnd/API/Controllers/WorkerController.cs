using API.Data;
using API.Dtos.WorkerDto;
using API.Mapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

[Route("api/worker")]
[ApiController]
public class WorkerController : ControllerBase
{
    private readonly ApplicationDbContext _context;
    
    public WorkerController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var workers = await _context.Workers.Select(s => s.ToWorkDto()).ToListAsync();




        return Ok(workers);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var worker = await _context.Workers.FindAsync(id);

        if (worker == null)
        {
            return NotFound();
        }

        return Ok(worker.ToWorkDto());
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateWorkerDto workerDto)
    {
        var workerModel = workerDto.ToWorkerFromCreateWorkerDto();

        _context.Workers.Add(workerModel);

        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetById), new { id = workerModel.Id }, workerModel.ToWorkDto());
    }
}