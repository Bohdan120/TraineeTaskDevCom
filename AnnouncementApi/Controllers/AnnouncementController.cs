using AnnouncementApi.Data;
using AnnouncementApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AnnouncementApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AnnouncementController : ControllerBase
    {
        private readonly AnnouncementDbContext _context;

        public AnnouncementController(AnnouncementDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Announcement>>> Get()
        {
            var announcements = await _context.Announcements.ToListAsync();
            return Ok(announcements);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Announcement>> Get(int id)
        {
            var announcement = await _context.Announcements.FindAsync(id);
            if (announcement == null) return NotFound();
            return Ok(announcement);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Announcement announcement)
        {
            _context.Announcements.Add(announcement);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(Get), new { id = announcement.Id }, announcement);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] Announcement announcement)
        {
            if (id != announcement.Id) return BadRequest();

            _context.Entry(announcement).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AnnouncementExists(id)) return NotFound();
                throw;
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var announcement = await _context.Announcements.FindAsync(id);
            if (announcement == null) return NotFound();

            _context.Announcements.Remove(announcement);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AnnouncementExists(int id)
        {
            return _context.Announcements.Any(e => e.Id == id);
        }
    }
}
