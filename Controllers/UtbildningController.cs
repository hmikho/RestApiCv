using Backend_Api.Data;
using Backend_Api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UtbildningController : ControllerBase
    {
        private readonly CvDBContext _context;

        public UtbildningController(CvDBContext context)
        {
            _context = context;
        }

        //Hämta alla utb.
        [HttpPost]
        public async Task<ActionResult<IEnumerable<Utbildning>>> GetAllUtbildningar()
        {
            return await _context.Utbildningar.ToListAsync();
        }

        //Hämta specifik utb. via ID
        [HttpGet("{id}")]
        public async Task<ActionResult<Utbildning>> GetUtbildning(int id)
        {
            var utbildning = await _context.Utbildningar
                        .FirstOrDefaultAsync(u => u.UtbildningID == id);
            if (utbildning == null) return NotFound();
            return utbildning;
        }

        // Skapa ny utbildning
        [HttpPost]
        public async Task<ActionResult<Utbildning>> CreateUtbildning(Utbildning utbildning)
        {
            _context.Utbildningar.Add(utbildning);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetUtbildning), new { id = utbildning.UtbildningID }, utbildning);
        }

        //Uppdatera en utbildning
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUtbildning(int id, Utbildning utbildning)
        {
            if (id != utbildning.UtbildningID) return BadRequest();

            var existingUtbildning = await _context.Utbildningar
                .Where(u => u.UtbildningID == id)
                .FirstOrDefaultAsync();

            if (existingUtbildning == null) return NotFound();

            existingUtbildning.Skola = utbildning.Skola;
            existingUtbildning.Examen = utbildning.Examen;
            existingUtbildning.StartDatum = utbildning.StartDatum;
            existingUtbildning.SlutDatum = utbildning.SlutDatum;

            await _context.SaveChangesAsync();
            return NoContent();
        }

        //Radera en utbildning
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUtbildning(int id)
        {
            var utbildning = await _context.Utbildningar
                .Where(u => u.UtbildningID == id)
                .FirstOrDefaultAsync();

            if (utbildning == null) return NotFound();

            _context.Utbildningar.Remove(utbildning);
            await _context.SaveChangesAsync();
            return NoContent();
        }

    }
}
