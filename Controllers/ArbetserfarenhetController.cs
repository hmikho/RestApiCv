using Backend_Api.Data;
using Backend_Api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArbetserfarenhetController : ControllerBase
    {
        private readonly CvDBContext _context;

        public ArbetserfarenhetController(CvDBContext context)
        {
            _context = context;
        }

        //Hämta alla jobberfarenheter
        [HttpPost]
        public async Task<ActionResult<IEnumerable<Arbetserfarenhet>>> GetAllArbetserfarenheter()
        {
            return await _context.Arbetserfarenheter.ToListAsync();
        }

        //Hämta specifikt jobb via ID
        [HttpGet("{id}")]
        public async Task<ActionResult<Arbetserfarenhet>> GetArbetserfarenhet(int id)
        {
            var arbetserfarenhet = await _context.Arbetserfarenheter
                        .FirstOrDefaultAsync(a => a.JobbID == id);
            if (arbetserfarenhet == null) return NotFound();
            return arbetserfarenhet;
        }

        // Skapa ny arbetserfarenhet
        [HttpPost]
        public async Task<ActionResult<Arbetserfarenhet>> CreateArbetserfarenhet(Arbetserfarenhet arbetserfarenhet)
        {
            _context.Arbetserfarenheter.Add(arbetserfarenhet);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetArbetserfarenhet), new { id = arbetserfarenhet.JobbID }, arbetserfarenhet);
        }

        //Uppdatera en arbetserfarenhet
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateArbetserfarenhet(int id, Arbetserfarenhet arbetserfarenhet)
        {
            if (id != arbetserfarenhet.JobbID) return BadRequest();

            var existingArbetserfarenhet = await _context.Arbetserfarenheter
                .Where(a => a.JobbID == id)
                .FirstOrDefaultAsync();

            if (existingArbetserfarenhet == null) return NotFound();

            existingArbetserfarenhet.Jobbtitel = arbetserfarenhet.Jobbtitel;
            existingArbetserfarenhet.Företag = arbetserfarenhet.Företag;
            existingArbetserfarenhet.Beskrivning = arbetserfarenhet.Beskrivning;
            existingArbetserfarenhet.Startår = arbetserfarenhet.Startår;

            await _context.SaveChangesAsync();
            return NoContent();
        }

        //Radera en arbetserfarenhet
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletArbetserfarenhet(int id)
        {
            var arbetserfarenhet = await _context.Arbetserfarenheter
                .Where(a => a.JobbID == id)
                .FirstOrDefaultAsync();

            if (arbetserfarenhet == null) return NotFound();

            _context.Arbetserfarenheter.Remove(arbetserfarenhet);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
