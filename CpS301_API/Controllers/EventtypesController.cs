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
    [Route("api/Eventtypes")]
    public class EventtypesController : Controller
    {
        private readonly wsoappContext _context;

        public EventtypesController(wsoappContext context)
        {
            _context = context;
        }

        // GET: api/Eventtypes
        [HttpGet]
        public IEnumerable<Eventtype> GetEventtype()
        {
            return _context.Eventtype;
        }

        // GET: api/Eventtypes/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEventtype([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var eventtype = await _context.Eventtype.SingleOrDefaultAsync(m => m.EventTypeId == id);

            if (eventtype == null)
            {
                return NotFound();
            }

            return Ok(eventtype);
        }

        // PUT: api/Eventtypes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEventtype([FromRoute] int id, [FromBody] Eventtype eventtype)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != eventtype.EventTypeId)
            {
                return BadRequest();
            }

            _context.Entry(eventtype).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EventtypeExists(id))
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

        // POST: api/Eventtypes
        [HttpPost]
        public async Task<IActionResult> PostEventtype([FromBody] Eventtype eventtype)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Eventtype.Add(eventtype);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEventtype", new { id = eventtype.EventTypeId }, eventtype);
        }

        // DELETE: api/Eventtypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEventtype([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var eventtype = await _context.Eventtype.SingleOrDefaultAsync(m => m.EventTypeId == id);
            if (eventtype == null)
            {
                return NotFound();
            }

            _context.Eventtype.Remove(eventtype);
            await _context.SaveChangesAsync();

            return Ok(eventtype);
        }

        private bool EventtypeExists(int id)
        {
            return _context.Eventtype.Any(e => e.EventTypeId == id);
        }
    }
}