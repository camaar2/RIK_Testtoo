using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Testtoo.Models;
using Microsoft.EntityFrameworkCore;

namespace Testtoo.Controllers;
[ApiController]
[Route("api/[controller]")]
public class EventsController : ControllerBase
{
    private readonly DataContext _context;

    public EventsController(DataContext context)
    {
        _context = context;
    }

    // GET: api/events
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Event>>> GetEvents()
    {
        return await _context.Events.ToListAsync();
    }

    // POST: api/events
    [HttpPost]
public async Task<ActionResult<Event>> AddEvent(EventCreationDto eventData)
{
    var @event = new Event
    {
        Name = eventData.Name,
        Location = eventData.Location,
        AdditionalInfo = eventData.AdditionalInfo,
        DateTime = eventData.DateTime,
    };

    try
    {
        _context.Events.Add(@event);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetEvent), new { id = @event.EventId }, @event);
    }
    catch (Exception ex)
    {
        return StatusCode(500, $"Internal server error: {ex.Message}");
    }
}

    // GET: api/events/{id}
    [HttpGet("{id}")]
    public async Task<ActionResult<Event>> GetEvent(int id)
    {
        var @event = await _context.Events.FindAsync(id);
        if (@event == null)
        {
            return NotFound();
        }
        return @event;
    }

    // PUT: api/events/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateEvent(int id, Event @event)
    {
        if (id != @event.EventId)
        {
            return BadRequest();
        }

        _context.Entry(@event).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!EventExists(id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return NoContent();
    }

    // DELETE: api/events/{id}
    [HttpDelete("{id}")]
    public async Task<ActionResult<Event>> DeleteEvent(int id)
    {
        var @event = await _context.Events.FindAsync(id);
        if (@event == null)
        {
            return NotFound();
        }

        _context.Events.Remove(@event);
        await _context.SaveChangesAsync();

        return @event;
    }

    private bool EventExists(int id)
    {
        return _context.Events.Any(e => e.EventId == id);
    }
    public class EventCreationDto
{
    public string Name { get; set; }
    
    public string Location { get; set; }
    
    public string AdditionalInfo { get; set; }
    
    public DateTime DateTime { get; set; }
}
}
