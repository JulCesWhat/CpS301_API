using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CpS301_API.Models;

namespace CpS301_API.Controllers
{
    [Produces("application/json")]
    [Route("api/People")]
    public class PeopleController : Controller
    {
        private readonly wsoappContext _context;

        public PeopleController(wsoappContext context)
        {
            _context = context;
        }

        // GET: api/People
        [HttpGet]
        public IEnumerable<Person> GetPerson()
        {
            return _context.Person;
        }

        //Adding extra code here
        [HttpGet("songLeaders")]
        public async Task<IActionResult> GetSongLeaders()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = from service in _context.Service
                         join person in _context.Person
                         on service.SongleaderId equals person.PersonId
                         select person;


            return Ok(result);
        }


        // GET: api/People/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPerson([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var person = await _context.Person.SingleOrDefaultAsync(m => m.PersonId == id);

            if (person == null)
            {
                return NotFound();
            }

            return Ok(person);
        }

        // PUT: api/People/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPerson([FromRoute] int id, [FromBody] Person person)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != person.PersonId)
            {
                return BadRequest();
            }

            _context.Entry(person).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonExists(id))
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

        // POST: api/People
        [HttpPost]
        public async Task<IActionResult> PostPerson([FromBody] Person person)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Person.Add(person);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPerson", new { id = person.PersonId }, person);
        }

        // DELETE: api/People/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePerson([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var person = await _context.Person.SingleOrDefaultAsync(m => m.PersonId == id);
            if (person == null)
            {
                return NotFound();
            }

            _context.Person.Remove(person);
            await _context.SaveChangesAsync();

            return Ok(person);
        }

        private bool PersonExists(int id)
        {
            return _context.Person.Any(e => e.PersonId == id);
        }
    }
}