using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Testtoo.Models;

namespace Testtoo.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ParticipantsController : ControllerBase
{
    private readonly DataContext _context;

    public ParticipantsController(DataContext context)
    {
        _context = context;
    }

    // GET: api/participants
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Participant>>> GetParticipants()
    {
        return await _context.Participants.ToListAsync();
    }

    // GET: api/participants/{id}
    [HttpGet("{id}")]
    public async Task<ActionResult<Participant>> GetParticipant(int id)
    {
        var participant = await _context.Participants.FindAsync(id);
        if (participant == null)
        {
            return NotFound();
        }
        return participant;
    }
    // GET: api/participants/event/{eventId}
    [HttpGet("event/{eventId}")]
    public async Task<ActionResult<IEnumerable<Participant>>> GetParticipantsByEventId(int eventId)
    {
        var participants = await _context.Participants.Where(p => p.EventId == eventId).ToListAsync();

        if (participants == null || !participants.Any())
        {
            return NotFound();
        }

        return participants;
    }

    // POST: api/participants
    [HttpPost]
    public async Task<ActionResult<Participant>> AddParticipant(Participant participant)
    {
        _context.Participants.Add(participant);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetParticipant), new { id = participant.ParticipantId }, participant);
    }

    // PUT: api/participants/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateParticipant(int id, Participant participant)
    {
        if (id != participant.ParticipantId)
        {
            return BadRequest();
        }

        _context.Entry(participant).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!ParticipantExists(id))
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

    // DELETE: api/participants/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteParticipant(int id)
    {
        var participant = await _context.Participants.FindAsync(id);
        if (participant == null)
        {
            return NotFound();
        }

        _context.Participants.Remove(participant);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool ParticipantExists(int id)
    {
        return _context.Participants.Any(e => e.ParticipantId == id);
    }
}


