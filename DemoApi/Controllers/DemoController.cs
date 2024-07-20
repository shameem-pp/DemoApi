using DemoApi.DataAccces;
using DemoApi.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DemoApi.Controllers;

[ApiController]
[Route("[controller]")]
public class DemoController(AppDbContext context) : ControllerBase
{
    private readonly AppDbContext _context = context;

    [HttpPost]
    public async Task<int> Create([FromBody] DemoDto request)
    {
        var demo= new Demo 
        { 
            ClientName = request.ClientName,
            Date = request.Date
            
        };

        _context.Demos.Add(demo);

        await _context.SaveChangesAsync();

        return demo.Id;
    }

    [HttpPut]
    public async Task<int> Update([FromBody] DemoDto request)
    {
        var demo = new Demo 
        {
            Id = request.Id,
            ClientName = request.ClientName,
            Date = request.Date
        };

        _context.Demos.Update(demo);

        await _context.SaveChangesAsync();

        return demo.Id;
    }

    [HttpGet]
    public async Task<IEnumerable<DemoDto>> Get()
    {
        var demos = await _context.Demos.ToListAsync();

        return demos.Select(x => new DemoDto(x.Id, x.ClientName, x.Date));
    }

    [HttpDelete]
    public async Task Delete(int id)
    {
        var demo = await _context.Demos.FirstOrDefaultAsync(x => x.Id == id);
        if (demo != null) 
            _context.Demos.Remove(demo);

        await _context.SaveChangesAsync();
    }
}

public record DemoDto(int Id, string ClientName, DateTimeOffset Date);
