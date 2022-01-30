#nullable disable
using backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnePunch.Dto;
using OnePunch.Utils;

namespace OnePunch.Controllers
{
    [Route("api/entries")]
    [ApiController]
    public class EntryController : ControllerBase
    {
        private readonly OnePunchContext _context;

        public EntryController(OnePunchContext context)
        {
            _context = context;
        }

        // GET: api/entries
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EntryDto>>> GetRecords()
        {
            return await _context.Entries.Select(e => e.ToDto()).ToListAsync();
        }

        // GET: api/entries/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EntryDto>> GetRecord(int id)
        {
            var entry = await _context.Entries.FindAsync(id);

            if (entry == null)
            {
                return NotFound();
            }

            return entry.ToDto();
        }

        // PUT: api/entries/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRecord(int id, EntryDto entry)
        {
            if (id != entry.Id)
            {
                return BadRequest();
            }

            var dbEntry = await _context.Entries.FindAsync(id);

            if (dbEntry == null)
            {
                return NotFound();
            }

            dbEntry.Map(entry);
            
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) when (!EntryExists(id))
            {
                return NotFound();
            }

            return NoContent();
        }

        // POST: api/entries
        [HttpPost]
        public async Task<ActionResult<EntryDto>> PostRecord(EntryDto entry)
        {
            var dbEntry = new Entry();
            dbEntry.Map(entry);

            _context.Entries.Add(dbEntry);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRecord", new { id = dbEntry.Id }, dbEntry.ToDto());
        }

        // DELETE: api/entries/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRecord(int id)
        {
            var @record = await _context.Entries.FindAsync(id);
            if (@record == null)
            {
                return NotFound();
            }

            _context.Entries.Remove(@record);
            await _context.SaveChangesAsync();

            return NoContent();
        }


        private bool EntryExists(int id)
        {
            return _context.Entries.Any(e => e.Id == id);
        }
    }
}
