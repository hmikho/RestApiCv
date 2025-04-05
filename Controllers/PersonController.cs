using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Backend_Api.Models;
using Backend_Api.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Backend_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly CvDBContext _context;

        public PersonController(CvDBContext context)
        {
            _context = context;
        }

        //Hämta alla personer
        [HttpPost]
        public async Task<ActionResult<IEnumerable<Person>>> GetAllPersoner()
        {
            return await _context.Personer.ToListAsync();
        }

        //Hämta specifik person via ID
        [HttpGet("{id}")]
        public async Task<ActionResult<Person>> GetPerson(int id)
        {
            var person = await _context.Personer
                        .FirstOrDefaultAsync(p => p.PersonID == id);
            if (person == null) return NotFound();
            return person;
        }

        //Skapa ny person
        [HttpPost]
        public async Task<ActionResult<Person>> CreatePerson(Person person)
        {
            _context.Personer.Add(person);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetPerson), new { id = person.PersonID }, person);
        }

        //Uppdatera en person
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePerson(int id, Person person)
        {
            if (id != person.PersonID) return BadRequest();

            var existingPerson = await _context.Personer
                .Where(p => p.PersonID == id)
                .FirstOrDefaultAsync();

            if (existingPerson == null) return NotFound();

            existingPerson.Namn = person.Namn;
            existingPerson.Beskrivning = person.Beskrivning;
            existingPerson.Email = person.Email;
            existingPerson.Telefonnummer = person.Telefonnummer;

            await _context.SaveChangesAsync();
            return NoContent();
        }

        //Radera en person
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePerson(int id)
        {
            var person = await _context.Personer
                .Where(p => p.PersonID == id)
                .FirstOrDefaultAsync();

            if (person == null) return NotFound();

            _context.Personer.Remove(person);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
