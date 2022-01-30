#nullable disable
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnePunch.Dto;
using OnePunch.Utils;
using OnePunchDbContext;
using OnePunchDbContext.Models;

namespace OnePunch.Controllers
{
    [Route("api/entries")]
    [ApiController]
    public class EntryController : ControllerBase
    {
        private readonly OnePunchContext context;

        public EntryController(OnePunchContext context)
        {
            this.context = context;
        }

        // GET: api/entries
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrotimeDto>>> GetRecords()
        {
            return await context.Orotimes.Select(e => e.ToDto()).ToListAsync();
        }

        // GET: api/entries/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OrotimeDto>> GetRecord(int id)
        {
            var entry = await context.Orotimes.FindAsync(id);

            if (entry == null)
            {
                return NotFound();
            }

            return entry.ToDto();
        }

        // PUT: api/entries/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRecord(int id, OrotimeDto entry)
        {
            if (id != entry.Id)
            {
                return BadRequest();
            }

            var dbEntry = await context.Orotimes.FindAsync(id);

            if (dbEntry == null)
            {
                return NotFound();
            }

            dbEntry.Map(entry);
            
            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) when (!EntryExists(id))
            {
                return NotFound();
            }

            return NoContent();
        }

        // POST: api/entries
        [HttpPost]
        public async Task<ActionResult<OrotimeDto>> PostRecord(OrotimeDto entry)
        {
            var dbEntry = new Orotime();
            dbEntry.Map(entry);

            context.Orotimes.Add(dbEntry);
            await context.SaveChangesAsync();

            return CreatedAtAction("GetRecord", new { id = dbEntry.Id }, dbEntry.ToDto());
        }

        // DELETE: api/entries/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRecord(int id)
        {
            var @record = await context.Orotimes.FindAsync(id);
            if (@record == null)
            {
                return NotFound();
            }

            context.Orotimes.Remove(@record);
            await context.SaveChangesAsync();

            return NoContent();
        }


        private bool EntryExists(int id)
        {
            return context.Orotimes.Any(e => e.Id == id);
        }
    }
}
